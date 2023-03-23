using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Escribe un numero aleatorio");
            int randNum = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[randNum];
            Random random = new Random();

            for (int i=0; i<array.Length; i++)
            {               
                array[i] = random.Next();
            }

            Console.WriteLine("{0}", string.Join(", ", array));
            Console.ReadLine();
        }
    }
}
