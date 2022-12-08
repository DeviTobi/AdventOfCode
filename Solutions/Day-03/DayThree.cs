namespace AdventOfCode_2022.Solutions
{
    public partial class DayThree : ISolution
    {
        public void Run()
        {
            var rucksacks = File.ReadAllLines("InputFiles\\DayThreeInput.txt");

            var sumOfItems = 0;
            foreach(var rucksack in rucksacks)
            {
                sumOfItems += CharToPriority(GetWrongItemFromRucksack(rucksack));
            }

            Console.WriteLine(sumOfItems);
        }

        public char GetWrongItemFromRucksack(string rucksack)
        {
            var firstCompartment = new int[53];

            for(int i = 0; i < rucksack.Length; i++)
            {
                var index = CharToPriority(rucksack.ToCharArray()[i]);

                if (i < rucksack.Length / 2)
                {
                    firstCompartment[index]++;
                    continue;
                }

                if (firstCompartment[index] >= 1)
                    return rucksack.ToCharArray()[i];
            }

            throw new Exception("No wrong item found");
        }

        public int CharToPriority(char c) => char.IsLower(c) ? c - 96 : c - 38;
    }
}
