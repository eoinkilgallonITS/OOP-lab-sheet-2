using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ex3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\S00223854\Downloads\results.txt";
            string[] fileContent = File.ReadAllLines(filePath);

            int totalPoints = calculatePoints(fileContent);

            Console.WriteLine($"Total point are {totalPoints} ");

        }
        private static int calculatePoints(string[] data)
        {
            int[] gradeRange = new int[8] { 90, 80, 70, 60, 50, 40, 30, 0};
            int[] higherPoints = new int[8] { 100, 88, 77, 66, 56, 46, 37, 0};

            int totalPoints = 0;
            int points = 0;
            int result = 0;

            for (int i = 0; i < data.Length; i++)
            {
                result = Convert.ToInt32(data[i]);

                for (int j = 0; j < gradeRange.Length; j++)
                {
                    if (result >= gradeRange[j])
                    {
                        points = higherPoints[j];
                        break;
                    }
                }
                totalPoints += points;
            }
            return totalPoints;
        }
    }
}
