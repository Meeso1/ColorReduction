using System;
using ColorReduction.Reducers;

namespace ColorReduction
{
    public static class ColorReducerFactory
    {
        public static IColorReducer Create(string algorithmName, ReducerOptions options)
        {
            if (!options.Validate())
                throw new ArgumentException(@$"{nameof(ReducerOptions)} object is not valid", nameof(options));

            return algorithmName switch
            {
                "Average dithering" => new AverageDitheringReducer(options.KRed, options.KGreen, options.KBlue),
                "Ordered dithering (random)" => new OrderedDitheringReducer(options.KRed, options.KGreen, options.KBlue,
                    true),
                "Ordered dithering (consecutive)" => new OrderedDitheringReducer(options.KRed, options.KGreen,
                    options.KBlue, false),
                "Error propagation" => new ErrorPropagationReducer(options.KRed, options.KGreen, options.KBlue),
                "Popularity algorithm" => new PopularityAlgorithmReducer(options.KAll),
                "None" => new NullReducer(),
                _ => throw new ArgumentException(@$"Unrecognized algorithm type: {algorithmName}",
                    nameof(algorithmName))
            };
        }
    }
}