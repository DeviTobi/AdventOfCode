namespace AdventOfCode_2022.Solutions
{
    public class DaySix : ISolution
    {
        public void Run()
        {
            var dataPacket = File.ReadAllText("InputFiles\\Day-06-Input.txt");

            var queue = new Queue<char>();

            var markerIndex = 0;
            for(var i=0; i<dataPacket.Length; i++)
            {
                var c = dataPacket[i];

                queue.Enqueue(c);

                if (queue.Count > 4)
                    queue.Dequeue();

                if (queue.Count == 4 && MarkerFound(queue))
                {
                    markerIndex = i+1;
                    break;
                }
            }

            Console.WriteLine(markerIndex);
        }

        public void RunPartTwo()
        {
            // TODO
        }

        public bool MarkerFound(Queue<char> queue)
        {
            HashSet<char> chars = new HashSet<char>();
            foreach(var c in queue)
            {
                if (chars.Contains(c))
                    return false;

                chars.Add(c);
            }

            return true;
        }
    }
}
