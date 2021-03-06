﻿using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace task_5
{
    
    class Program
    {
        private static double[] ReadFile(string path)
        {
            string[] file_path = File.ReadAllText(path).Split(" ");
            double[] array = new double[file_path.Length];
            for (int i = 0; i < file_path.Length; i++)
            {
                try
                {
                    array[i] = Convert.ToDouble(file_path[i]);
                }
                catch (InvalidCastException e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
               
            }
            return array;
        }

        private static void from_neg_to_pos(ref double[] x)
        {
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] < 0)
                {
                    x[i] *= -1;
                }
            }

        }
        private static void create_new_ar(double[] x, double[] y, ref double[] z)
        {
            int k = 0;
            foreach (int i in x)
            {
                foreach (int j in y)
                {

                    double new_element = ((i + j) / 2);
                    while (true)
                    {
                        z[k] = new_element;
                        k += 1;
                        break;
                    }
                    break;

                }
            }
        }


        static void Main(string[] args)
        {
            string x_file = "x.txt";
            string y_file = "y.txt";

            double[] x_ar = ReadFile(x_file);
            double[] y_ar = ReadFile(y_file);
            double[] z_ar = new double[x_ar.Length];

            from_neg_to_pos(ref x_ar);

            create_new_ar(x_ar, y_ar, ref z_ar);

            Console.WriteLine(string.Join(' ', z_ar));

        }
    }
}
