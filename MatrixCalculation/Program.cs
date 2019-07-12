using Microsoft.Extensions.DependencyInjection;
using System;
using MatrixCalculation.FileOprations.Implementations;
using MatrixCalculation.FileOprations.Interfaces;
using MatrixCalculation.MatrixOperations.Implementations;
using MatrixCalculation.MatrixOperations.Interfaces;

namespace MatrixCalculation
{
    class Program
    {
        private static IMatricesCalculationFromDirectory _matricesCalculation;
        static void ConfigureServices()
        {
            var serivces = new ServiceCollection();
            serivces.AddScoped<IMatrixFileReader, MatrixFileReader>()
                .AddSingleton<IMatrixAddition, MatrixAddition>()
                .AddSingleton<IMatrixSubstraction, MatrixSubstraction>()
                .AddSingleton<IMatrixTranspose, MatrixTranspose>()
                .AddSingleton<IMatrixMultiply, MatrixMultiply>()
                .AddSingleton<IMatrixParser, MatrixParser>()
                .AddScoped<IMatrixResultToFileWritter, MatrixResultWritter>()
                .AddScoped<IMatrixCalculation, MatrixCalculationManager>()
                .AddSingleton<IMatricesCalculationFromDirectory, MatricesCalculationFromDirectory>();
            var serviceProvider = serivces.BuildServiceProvider();
            _matricesCalculation = serviceProvider.GetService<IMatricesCalculationFromDirectory>();
        }

        static void Main(string[] args)
        {
            ConfigureServices();
            Console.WriteLine("Введите путь к директории с файлами: ");
            var directoryPath = Console.ReadLine();
            _matricesCalculation.CalculateMatricesFromDirectory(directoryPath);
            Console.ReadKey();
        }
    }
}
