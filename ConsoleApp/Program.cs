using System;
using System.IO;
using ChessSolution;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Chess");

            StreamReader inputFile;
            string outputFile;
            
            try
            {
                inputFile = new StreamReader(args[0]);
                outputFile = args[1];
            }
            catch (Exception)
            {
                throw new InvalidDataException("Two filenames needed!");
            }
            
            
            Solution solution = new Solution();
            var res = solution.FindSolution(inputFile);

            Console.WriteLine(res);
            
            //outputFile.Write(res);
            File.WriteAllText(outputFile, res);
            

            Console.WriteLine("Solution written into given output file!");
        }
    }
}