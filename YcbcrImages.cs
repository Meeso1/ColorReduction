using System.Drawing;

namespace ColorReduction
{
    public sealed class YcbcrImages
    {
        public YcbcrImages(Bitmap y, Bitmap cb, Bitmap cr)
        {
            Y = y;
            Cb = cb;
            Cr = cr;
        }

        public YcbcrImages(string yPath, string cbPath, string crPath) : this(new Bitmap(yPath), new Bitmap(cbPath),
            new Bitmap(crPath))

        {
        }

        public Bitmap Y { get; }
        public Bitmap Cb { get; }
        public Bitmap Cr { get; }
    }
}