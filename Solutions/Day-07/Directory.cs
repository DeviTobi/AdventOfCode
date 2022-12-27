namespace AdventOfCode_2022.Solutions
{
    public class Directory
    {
        public Directory(string name, Directory? parent)
        {
            Name = name;
            Parent = parent;
        }

        public string Name { get; set; }

        public int CurrentLevelFileSize { get; set; }
        
        public int GetTotalSize()
        {
            return CurrentLevelFileSize + Directories.Sum(d => d.Value.GetTotalSize());
        }

        public Directory? Parent { get; set; }

        public Dictionary<string, Directory> Directories { get; set; } = new Dictionary<string, Directory>();
    }
}
