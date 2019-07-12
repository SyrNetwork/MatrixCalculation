using System;
using System.Collections.Generic;
using System.Linq;
using MatrixCalculation.FileOprations.Interfaces;

namespace MatrixCalculation.FileOprations.Implementations
{
    class MatrixParser : IMatrixParser
    {
        public IEnumerable<double[,]> GetMatrixData(string data)
        {
            var matrixList = new List<double[,]>();
            var allMatricesFromFile = data.Split(new[] {Environment.NewLine + Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries).Skip(0);
            foreach (var matrix in allMatricesFromFile)
            {
                var multiDemMatrix = matrix.Split(new [] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    var _data = multiDemMatrix
                        .Select(s => s.Trim())
                        .Where(s => !string.IsNullOrEmpty(s))
                        .Select(s => s.Split(' ')
                            .Select(double.Parse)
                            .ToArray())
                        .ToArray();
                    matrixList.Add(JaggedToMultidimensional(_data));
                }
                catch (Exception)
                {
                    // ignored
                }
            }
            return matrixList;
        }

        public string GetMatrixOperation(string data)
        {
            var operation = data.Split(new[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .FirstOrDefault(x => Enum.IsDefined(typeof(AllowedOperations), x.ToUpper()));
            return operation;
        }

        private T[,] JaggedToMultidimensional<T>(T[][] jaggedArray)
        {
            var rows = jaggedArray.Length;
            var cols = jaggedArray.Max(subArray => subArray.Length);
            var array = new T[rows, cols];
            for (var i = 0; i < rows; i++)
            {
                cols = jaggedArray[i].Length;
                for (var j = 0; j < cols; j++)
                {
                    array[i, j] = jaggedArray[i][j];
                }
            }
            return array;
        }
    }
}
