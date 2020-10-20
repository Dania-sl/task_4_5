using System;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace task_4
{
    class Program
    {
        private static string Sum(double grad, double minut, double second, double second_grad, double second_minut, double second_second) {
            double main_grad_sum = grad + second_grad;
            double main_minut_sum = minut + second_minut;
            double main_second_sum = second + second_second;
            if (main_second_sum >= 60)
            {
                main_minut_sum += 1;
                main_second_sum -= 60;
            }
            if (main_minut_sum >= 60)
            {
                main_grad_sum += 1;
                main_minut_sum -= 60;
            }
            string main_grad_sum_string = Convert.ToString(main_grad_sum);
            string main_minut_sum_string = Convert.ToString(main_minut_sum);
            string main_second_sum_string = Convert.ToString(main_second_sum);
            Console.Write("sum of angles = ");
            string final_sum =$"{main_grad_sum_string}.{main_minut_sum_string}'{main_second_sum_string}''";
        
            return final_sum;


        }
        private static string Dif(double grad, double minut, double second, double second_grad, double second_minut, double second_second) {
            double main_grad_dif = grad - second_grad;
            double main_minut_dif = minut - second_minut;
            double main_second_dif = second - second_second;
            if (main_grad_dif < 0 || (main_minut_dif < 0 && main_grad_dif <= 0))
            {

                main_grad_dif = second_grad - grad;
                main_minut_dif = second_minut - minut;
                main_second_dif = second_second - second;
                if (main_second_dif < 0)
                {
                    main_minut_dif -= 1;
                    main_second_dif += 60;
                }
                if (main_minut_dif < 0)
                {
                    main_grad_dif -= 1;
                    main_minut_dif += 60;
                }
                string main_grad_dif_string = Convert.ToString(main_grad_dif);
                string main_minut_dif_string = Convert.ToString(main_minut_dif);
                string main_second_dif_string = Convert.ToString(main_second_dif);
                Console.Write("Difference of angles = ");
                string final_dif = $"{main_grad_dif_string}.{main_minut_dif_string}'{main_second_dif_string}''";
             
                return final_dif;

            }
            else
            {
                if (main_second_dif < 0)
                {
                    main_minut_dif -= 1;
                    main_second_dif += 60;
                }
                if (main_minut_dif < 0)
                {
                    main_grad_dif -= 1;
                    main_minut_dif += 60;
                }
                string main_grad_dif_string = Convert.ToString(main_grad_dif);
                string main_minut_dif_string = Convert.ToString(main_minut_dif);
                string main_second_dif_string = Convert.ToString(main_second_dif);
                Console.Write("Difference of angles = ");
                string final_dif = $"{main_grad_dif_string}.{main_minut_dif_string}'{main_second_dif_string}''";
               
                return final_dif;
            }
            

        }
        private static string Mult(double grad, double minut, double second, double second_grad, double second_minut, double second_second) {
            double user_number;
            Console.Write("Enrer number for multiplex: ");
            var user_number_1 = Console.ReadLine();
            while (!double.TryParse(user_number_1, out user_number))
            {
                Console.WriteLine("Enter correct value, type double!");
                user_number_1 = Console.ReadLine();
            }
            double main_grad_mult = grad * user_number;
            double main_minut_mult = minut * user_number;
            double main_second_mult = second * user_number;
            if (main_second_mult >= 60)
            {
                main_minut_mult += 1;
                main_second_mult -= 60;
            }
            if (main_minut_mult >= 60)
            {
                main_grad_mult += 1;
                main_minut_mult -= 60;
            }
            string main_grad_mult_string = Convert.ToString(main_grad_mult);
            string main_minut_mult_string = Convert.ToString(main_minut_mult);
            string main_second_mult_string = Convert.ToString(main_second_mult);
            Console.Write("Multiplication of angles = ");
            string final_mult = $"{main_grad_mult_string}.{main_minut_mult_string}'{main_second_mult_string}''";
            
            return final_mult;

        }
        private static double Rad(double grad, double minut, double second, double second_grad, double second_minut, double second_second) {
            double all_grad = grad + minut / 60 + second / 3600;
            double rad = (all_grad * 3.14) / 180;
            Console.Write("Rad of angles = ");
            return rad;
        }
        static void Main(string[] args)
        {
          
            double grad;
            double minut;
            double second;
            double second_grad;
            double second_minut;
            double second_second;
            Console.Write("Press enter if you want use kyeboard");
            if (Console.ReadLine() == "")
            {
                Console.Write("Enter gradus: ");
                var grad_1 = Console.ReadLine();
                while (!double.TryParse(grad_1, out grad))
                {
                    Console.WriteLine("Enter correct value, type double!");
                    grad_1 = Console.ReadLine();
                }
                Console.Write("Enret minutes: ");
                var minut_1 = Console.ReadLine();
                while (!double.TryParse(minut_1, out minut))
                {
                    Console.WriteLine("Enter correct value, type double!");
                    minut_1 = Console.ReadLine();
                }
                Console.Write("Enter seconds: ");
                var second_1 = Console.ReadLine();
                while (!double.TryParse(second_1, out second))
                {
                    Console.WriteLine("Enter correct value, type double!");
                    second_1 = Console.ReadLine();
                }
                Console.WriteLine($"{grad}.{minut}'{second}''");

                Console.Write("Enter gradus: ");
                var second_grad_1 = Console.ReadLine();
                while (!double.TryParse(second_grad_1, out second_grad))
                {
                    Console.WriteLine("Enter correct value, type double!");
                    second_grad_1 = Console.ReadLine();
                }
                Console.Write("Enret minutes: ");
                var second_minut_1 = Console.ReadLine();
                while (!double.TryParse(second_minut_1, out second_minut))
                {
                    Console.WriteLine("Enter correct value, type double!");
                    second_minut_1 = Console.ReadLine();
                }
                Console.Write("Enter seconds: ");
                var second_second_1 = Console.ReadLine();
                while (!double.TryParse(second_second_1, out second_second))
                {
                    Console.WriteLine("Enter correct value, type double!");
                    second_second_1 = Console.ReadLine();
                }
                Console.WriteLine($"{second_grad}.{second_minut}'{second_second}''");
            }
            else
            {
                string path = @"D:\PRoject\task_4_5\test.txt";
                using (StreamReader sr = new StreamReader(path, Encoding.Default))
                {

                    grad = Convert.ToDouble(sr.ReadLine());
                    minut = Convert.ToDouble(sr.ReadLine());
                    second = Convert.ToDouble(sr.ReadLine());
                    second_grad = Convert.ToDouble(sr.ReadLine());
                    second_minut = Convert.ToDouble(sr.ReadLine());
                    second_second = Convert.ToDouble(sr.ReadLine());
                    Console.WriteLine($"{grad}.{minut}'{second}''");
                    Console.WriteLine($"{second_grad}.{second_minut}'{second_second}''");


                }
            }

            Console.WriteLine(Sum(grad, minut, second, second_grad, second_minut, second_second));
            Console.WriteLine(Dif(grad, minut, second, second_grad, second_minut, second_second));
            Console.WriteLine(Mult(grad, minut, second, second_grad, second_minut, second_second));
            Console.WriteLine(Rad(grad, minut, second, second_grad, second_minut, second_second));


        }
    }
}
