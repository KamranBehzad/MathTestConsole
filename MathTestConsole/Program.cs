using System;
using NsLib.Extensions;
using NsLib.Helpers;

namespace MathTestConsole
{
    internal class Program
    {
        private const string path = @"c:\temp\MathTestConsole\";
        private const string baseFileName = @"sin";
        private const string fileExt = @".csv";

        private static void Main(string[] args)
        {
            const double maxAmplitude = 1000;
            double coefLong = 36; // I want my sine function to have period of 36 units
            double coefShort = 13; // I want my sine function to have period of 7 units

            double degreeCoefLong = 360 / coefLong;
            double degreeCoefShort = 360 / coefShort;
            double halfAmplitude = maxAmplitude / 2;
            double quarterAmplitude = maxAmplitude / 4;


            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("MathTest Console");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            // Open csv file
            IoHelper.CreateDirectory(path);
            var fullFilePath = path + baseFileName + XDateTime.NowToFileSuffix() + fileExt;
            TextFileHelper.OpenTextFileForWrite(fullFilePath, false);
            // Write header
            TextFileHelper.AppendLine("Degrees," +
                                      "Sin," +
                                      "Sin+1," +
                                      "Amplified Sin + 1," +
                                      "Amplified SinShort + 1," +
                                      "Amplified SinLong + 1," +
                                      "Mixed,"
            );

            for (int degree = 0; degree < 720; degree++)
            {
                var sin = Math.Sin(degree * Math.PI / 180);
                var sinShort = Math.Sin(degreeCoefShort * degree * Math.PI / 180);
                var sinLong = Math.Sin(degreeCoefLong * degree * Math.PI / 180);
                //Console.WriteLine($"{degree}°: Sin={sin:f4}");
                // write data to CSV file
                TextFileHelper.AppendLine($"{degree}," +
                                          $"{sin}," +
                                          $"{sin+1}," +
                                          $"{halfAmplitude * (sin + 1)}," +
                                          $"{halfAmplitude * (sinShort + 1)}," +
                                          $"{halfAmplitude * (sinLong + 1)}," +
                                          $"{quarterAmplitude * (sinShort + sinLong + 2)},"
                                          );
            }

            TextFileHelper.CloseWriteTextFile();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press any key ...");
            //Console.ReadKey();

            GlobalHelper.ProcessStart(fullFilePath);


        }
    }
}
