using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FangYang_0114AllLabApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter First Number:");
            double n1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Second Number:");
            double n2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter operator:");
            string op = Console.ReadLine();
            double result = 0;
            bool valid = true;
            switch (op)
            {
                case "+":
                    result = n1 + n2;
                    break;
                case "-":
                    result = n1 - n2;
                    break;
                case "*":
                    result = n1 * n2;
                    break;
                case "/":
                    result = n1 / n2;
                    break;
                    default:
                        valid = false;
                    break;
            }
            if (valid) Console.WriteLine("Result is :" + result);
            else Console.WriteLine("Invalid Operator!");
            
        }
    }
}
