namespace ColorReduction
{
    public sealed class ReducerOptions
    {
        public ReducerOptions(int kRed, int kBlue, int kGreen, int kAll)
        {
            KRed = kRed;
            KGreen = kGreen;
            KBlue = kBlue;
            KAll = kAll;
        }

        public int KRed { get; }
        public int KGreen { get; }
        public int KBlue { get; }
        public int KAll { get; }

        public bool Validate()
        {
            // TODO: Add some more validation
            return KRed > 1 && KGreen > 1 && KBlue > 1 && KAll > 1;
        }
    }
}