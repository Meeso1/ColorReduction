using System;
using System.Drawing;
using FastBitmapLib;

namespace ColorReduction.Reducers
{
    public sealed class ErrorPropagationReducer : IColorReducer
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

        public Bitmap Reduce(Bitmap image)
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
            private readonly int _filterSizeX;
            private readonly int _filterSizeY;
            private readonly int _filterSum;
            private readonly int _levels;
            private readonly double[,] _values;
            private readonly int _valuesSizeX;
            private readonly int _valuesSizeY;

            public ValueDitherer(int levels, Bitmap bitmap, Func<Color, int> selector)
            {
                // Burkes filter
                _filter = new[,]
                {
                    { 0, 0, 2 },
                    { 0, 0, 4 },
                    { 0, 0, 8 },
                    { 0, 8, 4 },
                    { 0, 4, 2 }
                };
                _filterSum = 32;
                _filterSizeX = 2;
                _filterSizeY = 1;

                _levels = levels;
                _valuesSizeX = bitmap.Width;
                _valuesSizeY = bitmap.Height;
                _values = new double[_valuesSizeX, _valuesSizeY];
                for (var y = 0; y < _valuesSizeY; y++)
                    for (var x = 0; x < _valuesSizeX; x++)
                        _values[x, y] = selector(bitmap.GetPixel(x, y));
            }

            private static int DitherValue(double value, int levels)
            {
                var width = 255.0 / (levels - 1);
                var k = value / width;
                var r = (int)k;
                return (int)((k > r + 0.5 ? r + 1 : r) * width);
            }

            public int GetValue(int x, int y)
            {
                var result = DitherValue(_values[x, y] < 255 ? _values[x, y] : 255, _levels);
                PropagateError(x, y, _values[x, y] - result);
                return result;
            }

            private void PropagateError(int x, int y, double error)
            {
                for (var yf = -_filterSizeY; yf <= _filterSizeY; yf++)
                    for (var xf = -_filterSizeX; xf <= _filterSizeX; xf++)
                    {
                        if (x + xf < 0 || x + xf >= _valuesSizeX || y + yf < 0 || y + yf >= _valuesSizeY) continue;
                        _values[x + xf, y + yf] += error / _filterSum * _filter[xf + _filterSizeX, yf + _filterSizeY];
                    }
            }
        }
    }
}