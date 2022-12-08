namespace AdventOfCode_2022.Solutions
{
    public abstract class RockPaperScissor
    {
        public abstract int DefaultChoicePoints { get; }
        public abstract string LosesTo { get; }
        public abstract string WinsAgainst { get; }

        public int ResolveScore(string opponent)
        {
            if (LosesTo == opponent)
                return DefaultChoicePoints;

            if (WinsAgainst == opponent)
                return DefaultChoicePoints + 6;

            return DefaultChoicePoints + 3;
        }

        public abstract int GetScoreOnOutcome(string outcome);
}
}
