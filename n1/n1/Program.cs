using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace n1
{
    class Program
    {
         static void Main(string[] args)
        {
            Console.Title = "Task2-1";
            Console.Write("Введите число в степени в формате {x^k} = ");
            string _text = Console.ReadLine();
            UltraPow up = new UltraPow(_text);
            if (up.success)
            {
                Console.WriteLine("\nsqrt({0}) = {1}", _text, up.GetPow());
            }
            else
            {
                Console.WriteLine("\nОшибка!\nДанные введены не верно.");
            }
            
            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }

   class UltraPow
    {
        private double number;
        public bool success;
        public UltraPow(string _pow)
        {
            string ptrn = @"([0-9]+)\^([0-9]+)";
            Match _match = Regex.Match(_pow, ptrn);
            if (_match.Success)
            {
                float n = Convert.ToSingle(_match.Groups[2].Value);
                float x = Convert.ToSingle(_match.Groups[1].Value);
                this.number = Math.Pow(x,n);
                this.success = true;
            }
            else
            {
                this.success = false;
            }
        }

        public double GetPow()
        {
            double acc = 0.000001;
            double a = number / 2, b = a + 1;
            while (Math.Abs(a - b) > acc)
            {
                b = a;
                a = 0.5 * (a + number / a);
            }
            return a;
        }
    }
    
}
