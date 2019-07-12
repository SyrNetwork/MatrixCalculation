using System;
using System.Collections.Generic;
using MatrixCalculation.MatrixOperations.Interfaces;

namespace MatrixCalculation.MatrixOperations.Implementations
{
    class MatrixCalculationManager : IMatrixCalculation
    {
        private IMatrixAddition _matrixAddition;
        private IMatrixSubstraction _matrixSubstraction;
        private IMatrixMultiply _matrixMultiply;
        private IMatrixTranspose _matrixTranspose;
        public IEnumerable<double[,]> ExecuteMatrixOperation(IEnumerable<double[,]> matrices, string operation)
        {
            var result = new List<double[,]>();
            try
            {
                switch (operation)
                {
                    case "ADD":
                    {
                        result.Add(_matrixAddition.AddMatrices(matrices));
                        break;
                    }
                    case "MULTIPLY":
                    {
                        result.Add(_matrixMultiply.MultiplyMatrices(matrices));
                        break;
                    }
                    case "SUBSTRACT":
                    {
                        result.Add(_matrixSubstraction.SubstractMatrices(matrices));
                        break;
                    }
                    case "TRANSPOSE":
                        result.AddRange(_matrixTranspose.TransposeMatrices(matrices));
                        break;
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("При обработке матрицы произошла ошибка, текст ошибки: " + e.Message);
            }

            return result;
        }

        public MatrixCalculationManager(IMatrixAddition matrixAddition, IMatrixSubstraction matrixSubstraction, IMatrixMultiply matrixMultiply, IMatrixTranspose matrixTranspose)
        {
            _matrixAddition = matrixAddition;
            _matrixSubstraction = matrixSubstraction;
            _matrixMultiply = matrixMultiply;
            _matrixTranspose = matrixTranspose;
        }
    }
}
