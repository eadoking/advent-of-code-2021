using System.IO;

namespace AdventOfCode.Helpers
{
    public class InputReader
    {
        private readonly string _filePath;

        public InputReader(string fileName)
        {
            _filePath = Path.Combine(Path.GetFullPath(@"..\..\.."), fileName);
        }

        public string ReadFileAsOneString()
        {
            return File.ReadAllText(_filePath);
        }
        
        public string[] ReadFileAsLines()
        {
            return File.ReadAllLines(_filePath);
        }
    }
}