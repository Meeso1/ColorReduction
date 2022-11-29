using System.Drawing;
using FastBitmapLib;

namespace ColorReduction.Reducers
{
    public class AverageDitheringReducer : ColorReducer
    {
        private readonly int _kBlue;
        private readonly int _kGreen;
        private readonly int _kRed;

        public AverageDitheringReducer(int kRed, int kGreen, int kBlue)
        {
            _kRed = kRed;
            _kGreen = kGreen;
            _kBlue = kBlue;
        }

        private static int QuantizeComponent(int value, int levels)
        {
            var width = 255.0 / (levels - 1);
            var k = value / width;
            var r = (int)k;
            return (int)((k > r + 0.5 ? r + 1 : r) * width);
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
                        QuantizeComponent(color.R, _kRed),
                        QuantizeComponent(color.G, _kGreen),
                        QuantizeComponent(color.B, _kBlue)
                    );
                    output.SetPixel(x, y, newColor);
                }

            return output;
        }
    }
}