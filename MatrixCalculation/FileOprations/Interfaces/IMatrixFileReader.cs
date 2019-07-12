using System;
using System.Collections.Generic;

namespace MatrixCalculation.FileOprations.Interfaces
{
    interface IMatrixFileReader
    {
        event Action<IEnumerable<string>> OnDirectoryRead;
        IEnumerable<KeyValuePair<string,string>> GetFilesData(string path);
    }
}
