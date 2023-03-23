using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{

    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Introduzca dos numeros");
            double num1 = Convert.ToDouble(Console.ReadLine());
            double num2 = Convert.ToDouble(Console.ReadLine());

            if (num1>num2)
            {
                Console.WriteLine($"El {num1} es mayor que el {num2}");
            } else
            {
                Console.WriteLine($"El {num2} es mayor que el {num1}");
            }
            Console.ReadLine();
        }
    }
}


