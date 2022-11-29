using System;
using System.Drawing;
using System.Linq;
using FastBitmapLib;

namespace ColorReduction.Reducers
{
    public sealed class OrderedDitheringReducer : ColorReducer
    {
        private readonly ValueDitherer _blue;
        private readonly ValueDitherer _green;
        private readonly ValueDitherer _red;

        public OrderedDitheringReducer(int kRed, int kGreen, int kBlue, bool randomPosition)
        {
            _red = new ValueDitherer(kRed, randomPosition);
            _green = new ValueDitherer(kGreen, randomPosition);
            _blue = new ValueDitherer(kBlue, randomPosition);
        }

        public override Bitmap Reduce(Bitmap image)
        {
            var output = new Bitmap(image.Width, image.Height);
            using var bitmap = new FastBitmap(output);

            for (var y = 0; y < bitmap.Height; y++)
                for (var x = 0; x < bitmap.Width; x++)
                {
                    var color = image.GetPixel(x, y);
                    var newColor = Color.FromArgb(
                        _red.GetValue(color.R, x, y),
                        _green.GetValue(color.G, x, y),
                        _blue.GetValue(color.B, x, y)
                    );
                    output.SetPixel(x, y, newColor);
                }

            return output;
        }

        private sealed class ValueDitherer
        {
            private readonly int _levels;
            private readonly int[,] _pattern;
            private readonly int _patternSize;
            private readonly Random? _random;

            public ValueDitherer(int levels, bool randomPosition)
            {
                _levels = levels;
                _patternSize = CalculatePatternSize(levels);
                _pattern = CreatePattern(_patternSize);
                if (randomPosition) _random = new Random();
            }

            private static int CalculatePatternSize(int levels)
            {
                var sizes = new[] { 2, 3, 4, 6, 8, 12, 16 };
                var size = Math.Sqrt(255.0 / (levels - 1));
                return sizes.First(s => s >= size);
            }

            private static int[,] CreatePattern(int size)
            {
                switch (size)
                {
                    case 2:
                        return new[,]
                        {
                            { 0, 2 },
                            { 3, 1 }
                        };
                    case 3:
                        return new[,]
                        {
                            { 6, 8, 4 },
                            { 1, 0, 3 },
                            { 5, 2, 7 }
                        };
                }

                if (size == 0 || size % 2 != 0)
                    throw new ArgumentException(@$"{size} is not a valid pattern size", nameof(size));

                var d = CreatePattern(size / 2);
                var result = new int[size, size];
                for (var y = 0; y < size; y++)
                    for (var x = 0; x < size; x++)
                        if (x < size / 2)
                        {
                            if (y < size / 2)
                                result[x, y] = 4 * d[x % (size / 2), y % (size / 2)];
                            else
                                result[x, y] = 4 * d[x % (size / 2), y % (size / 2)] + 3;
                        }
                        else
                        {
                            if (y < size / 2)
                                result[x, y] = 4 * d[x % (size / 2), y % (size / 2)] + 2;
                            else
                                result[x, y] = 4 * d[x % (size / 2), y % (size / 2)] + 1;
                        }

                return result;
            }

            private int CalculateIntensity(int value)
            {
                var width = 255.0 / ((_levels - 1) * _patternSize * _patternSize - 1);
                var k = value / width;
                var r = (int)k;
                return k > r + 0.5 ? r + 1 : r;
            }

            private int GetPatternThreshold(int x, int y)
            {
                if (_random is null) return _pattern[x % _patternSize, y % _patternSize];
                var randX = _random.Next(_patternSize);
                var randY = _random.Next(_patternSize);
                return _pattern[randX, randY];
            }

            public int GetValue(int value, int x, int y)
            {
                var intensity = CalculateIntensity(value);
                var threshold = GetPatternThreshold(x, y);

                var col = intensity / (_patternSize * _patternSize);
                var re = intensity % (_patternSize * _patternSize);

                return (int)(255.0 / (_levels - 1) * (re >= threshold ? col + 1 : col));
            }
        }
    }
}