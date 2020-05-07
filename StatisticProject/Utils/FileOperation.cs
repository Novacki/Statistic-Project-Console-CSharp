using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using NPOI.SS.Formula.Functions;

namespace StatisticProject.Utils
{
    static class FileOperation
    {
        private static readonly string _pathDirectory = @"c:\CalculationContent";
        private static readonly string _fileName = _pathDirectory + @"\ResultsCalculations.txt";
     
        public static void SaveFile(string content)
        {
            if (!Directory.Exists(_pathDirectory))
                Directory.CreateDirectory(_pathDirectory);


            WriteFile(content);

            Console.WriteLine("File path: " + _fileName);
        }

        private static void OpenOrCreateFile()
        {
            using (FileStream fs = new FileStream(_fileName, FileMode.OpenOrCreate)) { }
        }

        private static void WriteFile(string content)
        {
            OpenOrCreateFile();
            using (FileStream fs = new FileStream(_fileName, FileMode.Append))
            {
                using(StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(content);
                }
            }
        }
    }
}
