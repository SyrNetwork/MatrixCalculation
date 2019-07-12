using System.Collections.Generic;
using System.IO;
using System.Linq;
using MatrixCalculation.FileOprations.Interfaces;

namespace MatrixCalculation.FileOprations.Implementations
{
    class MatrixResultWritter : IMatrixResultToFileWritter
    {
        public void WriteResult(IEnumerable<double[,]> calculationResult, string path, string filename)
        {
            var resultMatrices = calculationResult.ToList();
            using (TextWriter tw = new StreamWriter(Path.Combine(path, filename+"_result.txt")))
            {
                foreach (var resultMatrix in resultMatrices)
                {
                    for (var j = 0; j < resultMatrix.GetLength(0); j++)
                    {
                        for (var i = 0; i < resultMatrix.GetLength(1); i++)
                        {
                            tw.Write(resultMatrix[i, j] + " ");
                        }
                        tw.WriteLine();
                    }
                    tw.WriteLine();
                }
            }
        }
    }
}
