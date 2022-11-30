using System;
using System.Drawing;
using FastBitmapLib;

namespace ColorReduction.Reducers
{
    public class ErrorPropagationReducer : ColorReducer
    {
        private readonly int _kBlue;
        private readonly int _kGreen;
        private readonly int _kRed;

        public ErrorPropagationReducer(int kRed, int kGreen, int kBlue)
        {
            _kRed = kRed;
            _kGreen = kGreen;
            _kBlue = kBlue;
        }

        public override Bitmap Reduce(Bitmap image)
        {
            var red = new ValueDitherer(_kRed, image, c => c.R);
            var green = new ValueDitherer(_kGreen, image, c => c.G);
            var blue = new ValueDitherer(_kBlue, image, c => c.B);

            var output = new Bitmap(image.Width, image.Height);
            using var bitmap = new FastBitmap(output);

            for (var y = 0; y < bitmap.Height; y++)
                for (var x = 0; x < bitmap.Width; x++)
                {
                    var newColor = Color.FromArgb(
                        red.GetValue(x, y),
                        green.GetValue(x, y),
                        blue.GetValue(x, y)
                    );
                    output.SetPixel(x, y, newColor);
                }

            return output;
        }

        private sealed class ValueDitherer
        {
            private readonly int[,] _filter;
            private readonly int _filterSum;
            private readonly int _filterX;
            private readonly int _filterY;
            private readonly int _levels;
            private readonly int _sizeX;
            private readonly int _sizeY;
            private readonly double[,] _values;

            public ValueDitherer(int levels, Bitmap bitmap, Func<Color, int> selector)
            {
                _filter = new[,]
                {
                    { 0, 0, 2 },
                    { 0, 0, 4 },
                    { 0, 0, 8 },
                    { 0, 8, 4 },
                    { 0, 4, 2 }
                };
                _filterSum = 32;
                _filterX = 2;
                _filterY = 1;

                _levels = levels;
                _sizeX = bitmap.Width;
                _sizeY = bitmap.Height;
                _values = new double[_sizeX, _sizeY];
                for (var y = 0; y < _sizeY; y++)
                    for (var x = 0; x < _sizeX; x++)
                        _values[x, y] = selector(bitmap.GetPixel(x, y));
            }

            private static int QuantizeComponent(double value, int levels)
            {
                var width = 255.0 / (levels - 1);
                var k = value / width;
                var r = (int)k;
                return (int)((k > r + 0.5 ? r + 1 : r) * width);
            }

            public int GetValue(int x, int y)
            {
                var result = QuantizeComponent(_values[x, y], _levels);
                var error = _values[x, y] - result;

                for (var yf = -_filterY; yf <= _filterY; yf++)
                    for (var xf = -_filterX; xf <= _filterX; xf++)
                    {
                        if (x + xf < 0 || x + xf >= _sizeX || y + yf < 0 || y + yf >= _sizeY) continue;
                        var change = error / _filterSum * _filter[xf + _filterX, yf + _filterY];
                        _values[x + xf, y + yf] += change;
                    }

                return result;
            }
        }
    }
}