using System.Drawing;
using FastBitmapLib;

namespace ColorReduction.Reducers
{
    public sealed class NullReducer : IColorReducer
    {
        public Bitmap Reduce(Bitmap image)
        {
            var output = new Bitmap(image.Width, image.Height);
            using var bitmap = new FastBitmap(output);

            for (var y = 0; y < bitmap.Height; y++)
                for (var x = 0; x < bitmap.Width; x++)
                    output.SetPixel(x, y, image.GetPixel(x, y));

            return output;
        }
    }
}