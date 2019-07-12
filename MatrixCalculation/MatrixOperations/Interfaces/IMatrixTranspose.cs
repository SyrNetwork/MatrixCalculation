using System.Collections.Generic;

namespace MatrixCalculation.MatrixOperations.Interfaces
{
    interface IMatrixTranspose
    {
        IEnumerable<double[,]> TransposeMatrices(IEnumerable<double[,]> matrices);
    }
}
