using System.Drawing;

namespace ColorReduction.Reducers
{
    public interface IColorReducer
    {
        public Bitmap Reduce(Bitmap image);
    }
}