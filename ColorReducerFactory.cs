using System;
using ColorReduction.Reducers;

namespace ColorReduction
{
    public static class ColorReducerFactory
    {
        public static ColorReducer Create(string algorithmName, ReducerOptions options)
        {
            if (!options.Validate())
                throw new InvalidOperationException(
                    $"{nameof(ReducerOptions)} object was not validated. "
                    + $"Contains values: {nameof(options.KRed)} = {options.KRed}, "
                    + $"{nameof(options.KGreen)} = {options.KGreen}, "
                    + $"{nameof(options.KBlue)} = {options.KBlue}, "
                    + $"{nameof(options.KAll)} = {options.KAll}"
                );

            return algorithmName switch
            {
                "Average dithering" => new AverageDitheringReducer(options.KRed, options.KGreen, options.KBlue),
                "Ordered dithering (random)" => new OrderedDitheringReducer(options.KRed, options.KGreen, options.KBlue,
                    true),
                "Ordered dithering (consecutive)" => new OrderedDitheringReducer(options.KRed, options.KGreen,
                    options.KBlue, false),
                "Error propagation" => new ErrorPropagationReducer(options.KRed, options.KGreen, options.KBlue),
                "Popularity algorithm" => new PopularityAlgorithmReducer(),
                "None" => new NullReducer(),
                _ => throw new ArgumentException(@$"Unrecognized algorithm type: {algorithmName}",
                    nameof(algorithmName))
            };
        }
    }
}