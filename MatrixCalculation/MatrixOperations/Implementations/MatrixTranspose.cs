using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MatrixCalculation.MatrixOperations.Interfaces;

namespace MatrixCalculation.MatrixOperations.Implementations
{
    class MatrixTranspose : IMatrixTranspose
    {
        public IEnumerable<double[,]> TransposeMatrices(IEnumerable<double[,]> matrices)
        {
            var resultMatrices = new List<double[,]>();
            foreach (var matrix in matrices)
            {
                var tmpMatrix = DenseMatrix.OfArray(matrix) as Matrix<double>;
                resultMatrices.Add(tmpMatrix.ToArray());
            }
            return resultMatrices;
        }
    }
}
