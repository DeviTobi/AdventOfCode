namespace AdventOfCode_2022.Solutions
{
    public class SectionRange
    {
        public int LowerBound { get; init; }
        public int UpperBound { get; init; }

        public SectionRange(string rangeStr) 
        {
            var split = rangeStr.Split('-');

            LowerBound = int.Parse(split[0]);
            UpperBound = int.Parse(split[1]);
        }
    }
}
