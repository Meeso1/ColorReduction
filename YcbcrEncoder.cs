using System.Drawing;
using FastBitmapLib;

namespace ColorReduction
{
    public sealed class YcbcrEncoder
    {
        private readonly Bitmap _input;

        public YcbcrEncoder(Bitmap input)
        {
            _input = input;
        }

        public Bitmap Encode()
        {
            var output = new Bitmap(_input.Width, _input.Height);
            using var bitmap = new FastBitmap(output);

            for (var y = 0; y < bitmap.Height; y++)
                for (var x = 0; x < bitmap.Width; x++)
                    output.SetPixel(x, y, ToYcbcr(_input.GetPixel(x, y)));

            return output;
        }

        public Bitmap Decode()
        {
            var output = new Bitmap(_input.Width, _input.Height);
            using var bitmap = new FastBitmap(output);

            for (var y = 0; y < bitmap.Height; y++)
                for (var x = 0; x < bitmap.Width; x++)
                    output.SetPixel(x, y, FromYcbcr(_input.GetPixel(x, y)));

            return output;
        }

        private static Color ToYcbcr(Color color)
        {
            var y = 0.257 * color.R + 0.504 * color.G + 0.098 * color.B + 16;
            var cb = -0.148 * color.R - 0.291 * color.G + 0.439 * color.B + 128;
            var cr = 0.439 * color.R - 0.368 * color.G - 0.071 * color.B + 128;

            return Color.FromArgb((int)y, (int)cb, (int)cr);
        }

        private static Color FromYcbcr(Color color)
        {
            var r = 1.164 * (color.R - 16) + 1.596 * (color.B - 128);
            var g = 1.164 * (color.R - 16) - 0.392 * (color.G - 128) - 0.813 * (color.B - 128);
            var b = 1.164 * (color.R - 16) + 2.017 * (color.G - 128);

            if (r < 0) r = 0;
            if (r > 255) r = 255;

            if (g < 0) g = 0;
            if (g > 255) g = 255;

            if (b < 0) b = 0;
            if (b > 255) b = 255;

            return Color.FromArgb((int)r, (int)g, (int)b);
        }
    }
}