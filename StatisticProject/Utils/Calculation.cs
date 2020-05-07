using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;


namespace StatisticProject.Utils
{
 
    class Calculation 
    {
        private static ICollection<double> Numbers = new List<double>();
     
        public static  double Average()
        {
            return Numbers.Average();
        }


        public static double Variant()
        {
            return Numbers.Sum(x => Math.Pow(x - Average(), 2)) / Numbers.Count();
        }

        public static double VarianceStandardDeviation()
        {
            return Math.Sqrt(Variant());
        }

        public static double Mediate()
        {
            return Numbers.OrderBy(x => x).ToList()[Numbers.Count() / 2];
        }

     
        public static void AddNumber(double number)
        {
            Numbers.Add(number);
        }

        public static void SaveContentStatistics()
        {
            StringBuilder sb = new StringBuilder();
            string aux = "(";

            var orderNumbers = Numbers.OrderBy(x => x);
            sb.Append("Moda: ");
            foreach(var number in orderNumbers)
            {
                sb.Append(number + " ");
            }
            sb.AppendLine();
            sb.AppendLine("Mediate: " + Mediate());

            sb.AppendLine();
           
            sb.Append("Average: ");
            foreach (var numbers in orderNumbers)
            {
                aux += numbers + " + ";
            }

            aux = aux.Remove(aux.Length - 3, 3);
            sb.Append(aux + ") / " + Numbers.Count() + " = " + Average().ToString("F2"));
            sb.AppendLine();
            sb.AppendLine("Average: " + Average());
            sb.AppendLine();

            aux = "";
            sb.Append("Variant: ");
            foreach(var numbers in Numbers)
            {
                aux += "(" + numbers + "-" + Average().ToString("F2") + ")^2 + "; 
            }
            aux = aux.Remove(aux.Length - 3, 3);
            sb.Append(aux + " / " + Numbers.Count() + " = " + Variant().ToString("F2"));
            sb.AppendLine();
            sb.AppendLine("Variant: " + Variant().ToString("F2"));
            sb.AppendLine();
            
            sb.AppendLine("SD: Square Root of " + Variant().ToString("F2") + " is " + VarianceStandardDeviation().ToString("F2"));
            
            Console.WriteLine(sb);

            FileOperation.SaveFile(sb.ToString());

        }
    }
}
