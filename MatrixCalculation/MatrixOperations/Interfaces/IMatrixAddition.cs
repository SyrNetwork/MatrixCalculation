using System.Collections.Generic;

namespace MatrixCalculation.MatrixOperations.Interfaces
{
    interface IMatrixAddition
    {
        double[,] AddMatrices(IEnumerable<double[,]> matrices);
    }
}
