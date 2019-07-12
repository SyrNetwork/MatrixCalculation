using System.Collections.Generic;

namespace MatrixCalculation.MatrixOperations.Interfaces
{
    interface IMatrixMultiply
    {
        double[,] MultiplyMatrices(IEnumerable<double[,]> matrices);
    }
}
