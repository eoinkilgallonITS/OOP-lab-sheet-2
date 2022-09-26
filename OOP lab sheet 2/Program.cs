﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab_sheet_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filepath = @"C: \Users\S00223854\OneDrive - Atlantic TU\OOP\OOP lab sheet 2\results.txt";

            try
            {
                string[] fileContents = file.ReadAllLines(filepath);

                int totalPoints = 0;
                int results = 0;
                int points = 0;

                for (int i = 0; i < fileContents.Length; i++)
                {
                    results = Convert.ToInt32(fileContents[i]);

                    if (results >= 90)
                    {
                        points = 100;
                    }
                    else if (results >= 80)
                    {
                        points = 88;
                    }
                    else if (results >= 70)
                    {
                        points = 77;
                    }
                    else if (results >= 60)
                    {
                        points = 66;
                    }
                    else if (results >= 50)
                    {
                        points = 56;
                    }
                    else if (results >= 40)
                    {
                        points = 46;
                    }
                    else if (results >= 30)
                    {
                        points = 37;
                    }
                    else if (results <= 30)
                    {
                        points = 0;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
