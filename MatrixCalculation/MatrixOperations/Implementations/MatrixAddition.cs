using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.LinearAlgebra.Double;
using MatrixCalculation.MatrixOperations.Interfaces;

namespace MatrixCalculation.MatrixOperations.Implementations
{
    class MatrixAddition : IMatrixAddition
    {
        public double[,] AddMatrices(IEnumerable<double[,]> matrices)
        {
            var resultMatrix = DenseMatrix.OfArray(matrices.FirstOrDefault()).Transpose();
            foreach (var matrix in matrices.Skip(1))
            {
                resultMatrix = resultMatrix.Add(DenseMatrix.OfArray(matrix).Transpose());
            }
            var resultMatrixAsArray = resultMatrix.ToArray();
            return resultMatrixAsArray;
        }
    }
}
