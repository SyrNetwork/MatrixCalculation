using System.Collections.Generic;

namespace MatrixCalculation.MatrixOperations.Interfaces
{
    interface IMatrixSubstraction
    {
        double[,] SubstractMatrices(IEnumerable<double[,]> matrices);
    }
}
