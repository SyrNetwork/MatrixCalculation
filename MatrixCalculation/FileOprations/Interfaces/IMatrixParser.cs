using System.Collections.Generic;

namespace MatrixCalculation.FileOprations.Interfaces
{
    interface IMatrixParser
    {
        IEnumerable<double[,]> GetMatrixData(string data);
        string GetMatrixOperation(string data);
    }
}
