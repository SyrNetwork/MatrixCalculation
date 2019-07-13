using System;
using System.IO;
using System.Linq;
using MatrixCalculation.FileOprations.Interfaces;
using MatrixCalculation.MatrixOperations.Interfaces;

namespace MatrixCalculation
{
    class MatricesCalculationFromDirectory : IMatricesCalculationFromDirectory
    {
        private IMatrixFileReader _matrixFileReader;
        private IMatrixParser _matrixParser;
        private IMatrixCalculation _matrixCalculation;
        private IMatrixResultToFileWritter _matrixResultToFileWritter;
        public void CalculateMatricesFromDirectory(string directoryPath)
        {
            var filenamesWithFiledaData = _matrixFileReader.GetFilesData(directoryPath);
            _matrixFileReader.OnDirectoryRead += findedFilesWithMatrices => {
                Console.WriteLine($"В директории {directoryPath} найдены .txt файлы: ");
                foreach (var file in findedFilesWithMatrices)
                {
                    Console.WriteLine(file);
                }
                Console.WriteLine();
            };

            foreach (var file in filenamesWithFiledaData)
            {
                Console.WriteLine($"Обработка файла: {file.Key}");
                var matricesFromFile = _matrixParser.GetMatrixData(file.Value);
                var operationFromFile = _matrixParser.GetMatrixOperation(file.Value);

                if (matricesFromFile == null  || !matricesFromFile.Any())
                {
                    Console.WriteLine($"Ошибка в файле {file.Key}: отсутствует матрица");
                    continue;
                }

                if (string.IsNullOrEmpty(operationFromFile))
                {
                    Console.WriteLine($"Ошибка в файле {file.Key}: отсутствует операция");
                    continue;
                }

                Console.WriteLine($"Найдена операция {operationFromFile}");
                var resultOfCalculation = _matrixCalculation.ExecuteMatrixOperation(matricesFromFile, operationFromFile.ToUpper());
                if (resultOfCalculation == null || !resultOfCalculation.Any())
                {
                    Console.WriteLine("Результат не будет записан");
                    continue;
                }
                _matrixResultToFileWritter.WriteResult(resultOfCalculation, directoryPath, file.Key);
                Console.WriteLine($"Результат записан по адресу {Path.Combine(directoryPath, file.Key + "_result.txt")}");
            }
        }

        public MatricesCalculationFromDirectory(IMatrixFileReader matrixFileReader, IMatrixParser matrixParser, IMatrixCalculation matrixCalculation, IMatrixResultToFileWritter matrixResultToFileWritter)
        {
            _matrixFileReader = matrixFileReader;
            _matrixParser = matrixParser;
            _matrixCalculation = matrixCalculation;
            _matrixResultToFileWritter = matrixResultToFileWritter;
        }
    }
}
