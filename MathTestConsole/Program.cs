using System;

using NsLib.Helpers;

namespace MathTestConsole
{
    internal class Program
    {
        private const string path = @"c:\temp\MathTestConsole\";
        private const string sinFileName = @"sin.csv";

        private static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("MathTest Console");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            // Open csv file
            IoHelper.CreateDirectory(path);
            var fullFilePath = path + sinFileName;
            TextFileHelper.OpenTextFileForWrite(fullFilePath, false);
            // Write header
            TextFileHelper.AppendLine("Degrees," +
                                      "Sin," +
                                      "Abs(Sin)," +
                                      "1000 x Abs(Sin)," +
                                      "1000 x Abs(Sin x2)," +
                                      "1000 x Abs(Sin x10)");

            for (int degree = 0; degree < 720; degree++)
            {
                var sin = Math.Sin(degree * Math.PI / 180);
                var sinx2 = Math.Sin(2 * degree * Math.PI / 180);
                var sinx10 = Math.Sin(10 * degree * Math.PI / 180);
                //var cos = Math.Cos(degree*Math.PI/180);
                Console.WriteLine($"{degree}°: Sin={sin:f4}");
                // write data to CSV file
                TextFileHelper.AppendLine($"{degree}," +
                                          $"{sin}," +
                                          $"{Math.Abs(sin)}," +
                                          $"{1000 * Math.Abs(sin)}," +
                                          $"{1000 * Math.Abs(sinx2)}," +
                                          $"{1000 * Math.Abs(sinx10)}"
                                          );
            }

            TextFileHelper.CloseWriteTextFile();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press any key ...");
            Console.ReadKey();

            GlobalHelper.ProcessStart(fullFilePath);


        }
    }
}
