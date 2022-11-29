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
                "Average dithering" => new AverageDitheringReducer(),
                "Ordered dithering (random)" => new OrderedDitheringReducer(),
                "Ordered dithering (consecutive)" => new OrderedDitheringReducer(),
                "Error propagation" => new ErrorPropagationReducer(),
                "Popularity algorithm" => new PopularityAlgorithmReducer(),
                "None" => new NullReducer(),
                _ => throw new ArgumentException(@$"Unrecognized algorithm type: {algorithmName}",
                    nameof(algorithmName))
            };
        }
    }
}