using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Escribe un dia de la semana");
            string dayWeek = Console.ReadLine().ToLower();

            switch (dayWeek)
            {
                case "lunes":
                case "martes":
                case "miercoles":
                case "jueves":
                case "viernes":
                    Console.WriteLine($"El {dayWeek} no es fin de semana");
                break;
                case "sabado":
                case "domingo":
                    Console.WriteLine($"El {dayWeek} es fin de semana");
                break;
                default:
                    Console.WriteLine($"El {dayWeek} no existe como dia de la semana");
                break;
            }

            Console.ReadLine();
        }
    }
}
