using System.Drawing;
using FastBitmapLib;

namespace ColorReduction.Reducers
{
    public class NullReducer : ColorReducer
    {
        public override Bitmap Reduce(Bitmap image)
        {
            var output = new Bitmap(image.Width, image.Height);
            using var bitmap = new FastBitmap(output);

            for (var y = 0; y < bitmap.Height; y++)
                for (var x = 0; x < bitmap.Width; x++)
                {
                    var color = image.GetPixel(x, y);
                    output.SetPixel(x, y, Color.FromArgb(color.G, color.B, color.R));
                }

            return output;
        }
    }
}