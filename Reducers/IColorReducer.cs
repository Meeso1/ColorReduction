using System.Drawing;

namespace ColorReduction.Reducers
{
    public interface IColorReducer
    {
        Bitmap Reduce(Bitmap image);
    }
}