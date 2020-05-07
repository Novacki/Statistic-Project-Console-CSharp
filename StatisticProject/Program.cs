using StatisticProject.Utils;
using System;

namespace StatisticProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter with the quantity of numbers");
            int quantity = int.Parse(Console.ReadLine());

            for(int i = 0; i < quantity; i++)
            {
                Console.Write($"Enter with the {i + 1} number: ");
                Calculation.AddNumber(double.Parse(Console.ReadLine()));

            }
            Console.WriteLine();
            Calculation.SaveContentStatistics();
        }
    }
}
