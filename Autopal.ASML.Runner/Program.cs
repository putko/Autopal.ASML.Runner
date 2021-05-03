using System;
using System.Globalization;
using Autopal.ASML.Runner.Configuration;
using Autopal.ASML.Runner.SequenceAnalysis;
using Autopal.ASML.Runner.SumOfMultiple;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Autopal.ASML.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .SetupServices()
                .BuildServiceProvider();

            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();
            logger.LogInformation("Starting application");

            var endApp = false;
            // Display title.
            Console.WriteLine("Runner in C#\r");
            Console.WriteLine("------------------------\n");

            // Declare variables and set to empty.
            while (!endApp)
            {
                // Ask the user to select problem.
                var selection = DisplayAvailableProblemsMenu();
                switch (selection)
                {
                    case 1:
                        var limit = DisplaySumOfMultipleMenu();
                        if (limit > 0)
                        {
                            var sumOfMultiple = CallSumOfMultiple(limit);
                            PrintSumOfMultipleResult(limit, sumOfMultiple);
                        }
                        break;
                    case 2:
                        var input = DisplaySequenceAnalysisMenu();
                        var result = CallSequenceAnalysis(input);
                        PrintSequenceAnalysisResult(input, result);
                        break;
                    case 3:
                        endApp = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input provided...");
                        break;
                }
            }
        }

        private static void PrintSequenceAnalysisResult(string input, string result)
        {
            Console.WriteLine();
            Console.WriteLine($"Output is '{result}' for the input '{input}'");
            Console.WriteLine();
        }

        private static void PrintSumOfMultipleResult(in int limit, in ulong result)
        {
            Console.WriteLine();
            Console.WriteLine($"Sum of all number that can be divided to 3 or 5 below '{limit}' is '{result}'");
            Console.WriteLine();
        }

        private static ulong CallSumOfMultiple(in int limit)
        {
            SumOfMultipleSolver solver = new SumOfMultipleSolver();
            return solver.Solve(limit);
        }
        
        private static string CallSequenceAnalysis(in string input)
        {
            SequenceAnalysisSolver solver = new SequenceAnalysisSolver();
            return solver.Solve(input);
        }

        public static int DisplayAvailableProblemsMenu()
        {
            Console.WriteLine("Please select one of the available problems");
            Console.WriteLine();
            Console.WriteLine("1. SumOfMultiple");
            Console.WriteLine("2. SequenceAnalysis");
            Console.WriteLine("3. Exit");
            var input = Console.ReadLine()?.ToLower();
            switch (input)
            {
                case "sumofmultiple":
                    return 1;
                case "sequenceanalysis":
                    return 2;
                case "exit":
                    return 3;
            }

            if (int.TryParse(input, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
            {
                return result;
            }

            return -1;
        }

        public static int DisplaySumOfMultipleMenu()
        {
            Console.WriteLine("This option calculates the sum of all natural numbers that are a multiple of 3 or 5 below a limit provided as input");
            var limit = int.MinValue;
            while (limit < 1)
            {
                Console.Write("Please enter a valid limit (1-2147483647) or type exit for the previous menu:");
                var result = Console.ReadLine();
                if (result == "exit")
                    return -1;
                if (!int.TryParse(result, NumberStyles.Integer, CultureInfo.InvariantCulture, out limit)) continue;
                if (limit > 0)
                    break;
            }

            return limit;
        }

        public static string DisplaySequenceAnalysisMenu()
        {
            Console.WriteLine("This option finds the uppercase words in a string, provided as input, and order all characters in these words alphabetically.");
            Console.Write("Please type your input then press enter:");
            var result = Console.ReadLine();
            return result;
        }
    }
}
