using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.LinearAlgebra.Double;
using MatrixCalculation.MatrixOperations.Interfaces;

namespace MatrixCalculation.MatrixOperations.Implementations
{
    class MatrixMultiply : IMatrixMultiply
    {
        public double[,] MultiplyMatrices(IEnumerable<double[,]> matrices)
        {
            var resultMatrix = DenseMatrix.OfArray(matrices.FirstOrDefault()).Transpose();
            foreach (var matrix in matrices.Skip(1))
            {
                resultMatrix = resultMatrix.Multiply(DenseMatrix.OfArray(matrix).Transpose());
            }
            var resultMatrixAsArray = resultMatrix.ToArray();
            return resultMatrixAsArray;
        }
    }
}
