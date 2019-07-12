using System.Collections.Generic;

namespace MatrixCalculation.FileOprations.Interfaces
{
    interface IMatrixResultToFileWritter
    {
        void WriteResult(IEnumerable<double[,]> calculationResult, string path, string filename);
    }
}
