using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduzca su nombre");
            string name = Console.ReadLine();

            Console.WriteLine("Introduzca su edad");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Introduzca el nombre de una ciudad");
            string city = Console.ReadLine();

            Console.WriteLine($"Te llamas {name} y tienes {age}. Bienvenido a {city}");
            Console.ReadLine();
        }
    }
}
