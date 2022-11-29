using System.Drawing;

namespace ColorReduction.Reducers
{
    public abstract class ColorReducer
    {
        public abstract Bitmap Reduce(Bitmap image);
    }
}