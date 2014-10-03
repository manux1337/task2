using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Collections;

namespace n2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title="Task2-2";
            GO1:Console.Write("Введите положительное число = ");
            Binary _bin = new Binary();
            UInt16 _digits = UInt16.Parse(Console.ReadLine());
            try
            {
                _bin.Encode(_digits);
            }
            catch (OverflowException e)
            {
                if (e.Source != null)
                    Console.WriteLine("\nОшибка!\nЧисло не положительное.\n");
                goto GO1;
            }
            Console.WriteLine("\n{0} в двоичном коде {{{1}}}", _digits, _bin.result);
            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();

        }

    }
     class Binary
    {
        private Stack st = new Stack();
        private string _result;
        public string result
        {
            get
            {
                return this._result;
            }
        }
        public void Encode(uint a)
        {
            while (a > 0)
            {
                this.st.Push((char)a % 2);
                a /= 2;
            }

            while (st.Count != 0)
            {
                this._result += this.st.Pop();
            }
        }

    }
}
