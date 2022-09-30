using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ex5
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //Information
            Console.WriteLine("Enter Name : ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Student Number : ");
            string studentNum = Console.ReadLine();

            string[] subjects = new string[7];
            string[] level = new string[7];
            string[] results = new string[7];
            int[] points = new int[7];

            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine($"Enter Subject Name {i + 1} : ");
                subjects[i] = Console.ReadLine();

                Console.WriteLine($"Enter Subject Level {i + 1} : ");
                level[i] = Console.ReadLine();

                Console.WriteLine($"Enter Subject Result for {i + 1} : ");
                results[i] = Console.ReadLine();
            }

            // calculating Information
            int totalPoints = CalculatePoints(results, level, points);

            // displaying results
            displayResults(name, studentNum, subjects, results, level, points, totalPoints);

            // write to file
            inputDetailToFile(name, studentNum, subjects, results, level, points, totalPoints);

            Console.ReadLine();

        }

        private static void inputDetailToFile(string name, string studentNum, string[] subjects, string[] results, string[] levels, int[] points, int totalPoints)
        {
            StreamWriter sw = new StreamWriter("results.txt");

            sw.WriteLine($"Name : {name}");
            sw.WriteLine($"Student number : {studentNum}");

            for (int i = 0; i < results.Length; i++)
            {
                sw.WriteLine($"{subjects[i],10} {levels[i],10} {results[i],10} {points[i],10}");
            }

            sw.WriteLine($"total points : {totalPoints}");

            sw.Flush();
            sw.Close();
        }
        private static void displayResults(string name, string studentNum, string[] subjects, string[] results, string[] levels, int[] points, int totalPoints)
        {
            Console.WriteLine($"Name : {name}");
            Console.WriteLine($"Student Number : {studentNum}");

            for (int i = 0; i < results.Length; i++)
            {
                Console.WriteLine($"{subjects[i],10} {levels[i],10} {results[i],10} {points[i],10}");

            }
            Console.WriteLine($"Total Points : {totalPoints}");
        }
        
        private static int CalculatePoints(string[] data, string[] level, int[] studentPoints)
        {
            int[] gradeBoundaries = new int[] { 90, 80, 70, 60, 50, 40, 30, 0 };
            int[] higherPoints = new int[] { 100, 88, 77, 66, 56, 46, 37, 0 };
            int[] ordinaryPoints = new int[] { 56, 46, 37, 28, 20, 12, 0, 0 };

            int totalPoints = 0, points = 0;
            for (int i = 0; i < data.Length; i++)
            {
                int result = Convert.ToInt32(data[i]);

                for (int j = 0; j < gradeBoundaries.Length; j++)
                {
                    if (result >= gradeBoundaries[j])
                    {
                        points = level[i].ToLower().Equals("h") ? higherPoints[j] : ordinaryPoints[j];
                    }
                }

                studentPoints[i] = points;
            }

            Array.Sort(studentPoints);
            Array.Reverse(studentPoints);

            for (int i = 0; i < 6; i++)
            {
                totalPoints += studentPoints[i];
            }

            return totalPoints;
        }
    }
}
