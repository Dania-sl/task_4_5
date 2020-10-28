using System;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System.Reflection.Metadata;

namespace task_4
{
    class Program

    {
        private static double[] Array_of_grad(ref double[] all_grad, ref double[] second_all_grad, ref double user_number)
        {

            Console.Write("Press k if you want use keyboard and f if you want use file ");
            ConsoleKey key = Console.ReadKey().Key;
            Console.WriteLine("");
            if(key == ConsoleKey.K)
            {
                Console.Write("Enter gradus: ");
                var grad_1 = Console.ReadLine();
                while (!double.TryParse(grad_1, out all_grad[0]))
                {
                    Console.WriteLine("Enter correct value, type double!");
                    grad_1 = Console.ReadLine();
                }
                Console.Write("Enret minutes: ");
                var minut_1 = Console.ReadLine();
                while (!double.TryParse(minut_1, out all_grad[1]))
                {
                    Console.WriteLine("Enter correct value, type double!");
                    minut_1 = Console.ReadLine();
                }
                Console.Write("Enter seconds: ");
                var second_1 = Console.ReadLine();
                while (!double.TryParse(second_1, out all_grad[2]))
                {
                    Console.WriteLine("Enter correct value, type double!");
                    second_1 = Console.ReadLine();
                }


                Console.Write("Enter gradus: ");
                var second_grad_1 = Console.ReadLine();
                while (!double.TryParse(second_grad_1, out second_all_grad[0]))
                {
                    Console.WriteLine("Enter correct value, type double!");
                    second_grad_1 = Console.ReadLine();
                }
                Console.Write("Enret minutes: ");
                var second_minut_1 = Console.ReadLine();
                while (!double.TryParse(second_minut_1, out second_all_grad[1]))
                {
                    Console.WriteLine("Enter correct value, type double!");
                    second_minut_1 = Console.ReadLine();
                }
                Console.Write("Enter seconds: ");
                var second_second_1 = Console.ReadLine();
                while (!double.TryParse(second_second_1, out second_all_grad[2]))
                {
                    Console.WriteLine("Enter correct value, type double!");
                    second_second_1 = Console.ReadLine();
                }
                all_grad = normal_appearance(all_grad);
                second_all_grad = normal_appearance(second_all_grad);
                Console.WriteLine($"{all_grad[0]}.{all_grad[1]}'{all_grad[2]}''");
                Console.WriteLine($"{second_all_grad[0]}.{second_all_grad[1]}'{second_all_grad[2]}''");
            }
            if (key == ConsoleKey.F )
            {
                string path = "test.txt";
                string[] all_grad_string = File.ReadLines(path).First().Split(" ");
                Console.WriteLine(string.Join(' ', all_grad_string));
                string[] second_all_grad_string = File.ReadLines(path).Last().Split(" ");
                Console.WriteLine(string.Join(' ', second_all_grad_string));
                all_grad = ReadFile(all_grad_string);
                second_all_grad = ReadFile(second_all_grad_string);
                all_grad = normal_appearance(all_grad);
                second_all_grad = normal_appearance(second_all_grad);
            }
            else
            {
                Console.WriteLine("You enter wrong key");
                Environment.Exit(0);
            }
            Console.Write("Enrer number for multiplex: ");
            var user_number_1 = Console.ReadLine();
            while (!double.TryParse(user_number_1, out user_number))
            {
                Console.WriteLine("Enter correct value, type double!");
                user_number_1 = Console.ReadLine();
            }

            return null;
        }
        private static double[] ReadFile(string[] file_path)
        {
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
        private static double[] normal_appearance(double[] grad_arr)
        {
            if (grad_arr[2] >= 60)
            {
                grad_arr[1] += (grad_arr[2] - grad_arr[2] % 60) / 60;
                grad_arr[2] = grad_arr[2] % 60;
            }
            if (grad_arr[1] >= 60)
            {
                grad_arr[0] += (grad_arr[1] - grad_arr[1] % 60) / 60;
                grad_arr[1] = grad_arr[1] % 60;
            }

            return grad_arr;
        }

        private static double[] Sum_ans(double[] grad_sum)
        {
            while (grad_sum[2] >= 60)
            {
                grad_sum[1] += 1;
                grad_sum[2] -= 60;
            }
            while (grad_sum[1] >= 60)
            {
                grad_sum[0] += 1;
                grad_sum[1] -= 60;
            }

            return grad_sum;
        }
        private static double[] Sum(double[] second_all_grad, double[] all_grad)
        {
            double[] grad_sum = new double[3];
            grad_sum[0] = all_grad[0] + second_all_grad[0];
            grad_sum[1] = all_grad[1] + second_all_grad[1];
            grad_sum[2] = all_grad[2] + second_all_grad[2];
            grad_sum = Sum_ans(grad_sum);

            return grad_sum;
        }

        private static double[] Dif_ans(double[] grad_dif)
        {
            if (grad_dif[2] < 0)
            {
                grad_dif[1] -= 1;
                grad_dif[2] += 60;
            }
            if (grad_dif[1] < 0)
            {
                grad_dif[0] -= 1;
                grad_dif[1] += 60;
            }

            return grad_dif;
        }
        private static double[] Dif(double[] second_all_grad, double[] all_grad)
        {
            double[] grad_dif = new double[3];
            grad_dif[0] = all_grad[0] - second_all_grad[0];
            grad_dif[1] = all_grad[1] - second_all_grad[1];
            grad_dif[2] = all_grad[2] - second_all_grad[2];
            if (grad_dif[0] < 0 || (grad_dif[1] < 0 && grad_dif[0] <= 0))
            {
                grad_dif[0] = second_all_grad[0] - all_grad[0];
                grad_dif[1] = second_all_grad[1] - all_grad[1];
                grad_dif[2] = second_all_grad[2] - all_grad[2];
                grad_dif = Dif_ans(grad_dif);
            }
            else
            {
                grad_dif = Dif_ans(grad_dif);
            }
            return grad_dif;

        }
        private static double[] Mult(double[] second_all_grad, double[] all_grad, double user_number)
        {
            double[] grad_mult = new double[3];
            grad_mult[0] = all_grad[0] * user_number;
            grad_mult[1] = all_grad[1] * user_number;
            grad_mult[2] = all_grad[2] * user_number;
            grad_mult = Sum_ans(grad_mult);

            return grad_mult;

        }
        private static double Rad(double[] all_grad)
        {
            double all_grad_sum = all_grad[0] + all_grad[1] / 60 + all_grad[2] / 3600;
            double rad = (all_grad_sum * 3.14) / 180;

            return rad;
        }
        static void Main(string[] args)

        {
            double user_number = 0 ;
            double[] all_grad = new double[3];
            double[] second_all_grad = new double[3];

            Array_of_grad(ref all_grad, ref second_all_grad,ref user_number);

            Console.Write("Sum of angles = ");
            Console.WriteLine(string.Join(' ', Sum(second_all_grad, all_grad)));
            Console.Write("Difference of angles = ");
            Console.WriteLine(string.Join(' ', Dif(second_all_grad, all_grad)));
            Console.Write("Multiplication by a number = ");
            Console.WriteLine(string.Join(' ', Mult(second_all_grad, all_grad, user_number)));
            Console.Write("Rad of angles = ");
            Console.WriteLine(Rad(all_grad));


        }
    }
}
