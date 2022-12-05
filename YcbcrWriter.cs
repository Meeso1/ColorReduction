using System.Drawing;
using FastBitmapLib;

namespace ColorReduction
{
    public static class YcbcrWriter
    {
        public static Bitmap Read(YcbcrImages input)
        {
            var output = new Bitmap(input.Y.Width, input.Y.Height);
            using var bitmap = new FastBitmap(output);
            bitmap.Lock();
            for (var y = 0; y < output.Height; y++)
                for (var x = 0; x < output.Width; x++)
                    bitmap.SetPixel(x, y, Color.FromArgb(
                        input.Y.GetPixel(x, y).R,
                        (int)(input.Cb.GetPixel(x, y).B / 255.0 * 224.0) + 16,
                        (int)(input.Cr.GetPixel(x, y).R / 255.0 * 224.0) + 16
                    ));
            bitmap.Unlock();

            return output;
        }

        public static YcbcrImages Write(Bitmap input)
        {
            var outputY = CreateY(input);
            var outputCb = CreateCb(input);
            var outputCr = CreateCr(input);

            return new YcbcrImages(outputY, outputCb, outputCr);
        }

        private static Bitmap CreateY(Bitmap input)
        {
            var outputY = new Bitmap(input.Width, input.Height);
            using var bitmapY = new FastBitmap(outputY);
            bitmapY.Lock();
            for (var y = 0; y < input.Height; y++)
                for (var x = 0; x < input.Width; x++)
                    bitmapY.SetPixel(x, y, Color.FromArgb(
                        input.GetPixel(x, y).R,
                        input.GetPixel(x, y).R,
                        input.GetPixel(x, y).R
                    ));
            bitmapY.Unlock();

            return outputY;
        }

        private static Bitmap CreateCb(Bitmap input)
        {
            var outputCb = new Bitmap(input.Width, input.Height);
            using var bitmapCb = new FastBitmap(outputCb);
            bitmapCb.Lock();
            for (var y = 0; y < input.Height; y++)
                for (var x = 0; x < input.Width; x++)
                {
                    var t1 = (input.GetPixel(x, y).G - 16) / 224.0;
                    bitmapCb.SetPixel(x, y, Color.FromArgb(
                        127,
                        255 - (int)(t1 * 255),
                        (int)(t1 * 255)
                    ));
                }

            bitmapCb.Unlock();

            return outputCb;
        }

        private static Bitmap CreateCr(Bitmap input)
        {
            var outputCr = new Bitmap(input.Width, input.Height);
            using var bitmapCr = new FastBitmap(outputCr);
            bitmapCr.Lock();
            for (var y = 0; y < input.Height; y++)
                for (var x = 0; x < input.Width; x++)
                {
                    var t2 = (input.GetPixel(x, y).B - 16) / 224.0;
                    bitmapCr.SetPixel(x, y, Color.FromArgb(
                        (int)(t2 * 255),
                        255 - (int)(t2 * 255),
                        127
                    ));
                }

            bitmapCr.Unlock();

            return outputCr;
        }
    }
}