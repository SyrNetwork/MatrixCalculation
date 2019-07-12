using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MatrixCalculation.FileOprations.Interfaces;

namespace MatrixCalculation.FileOprations.Implementations
{
    class MatrixFileReader : IMatrixFileReader
    {
        public event Action<IEnumerable<string>> OnDirectoryRead;
        public IEnumerable<KeyValuePair<string,string>> GetFilesData(string path)
        {
            var dataFromFilesWithFilenames = new List<KeyValuePair<string, string>>();
            if (Directory.Exists(path))
            {
                var files = Directory.GetFiles(path, "*.txt").Where(x => !x.Contains("_result"));
                OnDirectoryRead?.Invoke(files);
                foreach (var file in files)
                {
                    var content = File.ReadAllText(file);
                    var kvp = new KeyValuePair<string, string>(file.Replace(".txt", ""), content);
                    dataFromFilesWithFilenames.Add(kvp);
                }
            }
            return dataFromFilesWithFilenames;
        }
    }
}
