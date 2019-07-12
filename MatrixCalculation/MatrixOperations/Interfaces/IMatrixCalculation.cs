using System.Collections.Generic;

namespace MatrixCalculation.MatrixOperations.Interfaces
{
    interface IMatrixCalculation
    {
        IEnumerable<double[,]> ExecuteMatrixOperation(IEnumerable<double[,]> matrices, string operation);
    }
}
