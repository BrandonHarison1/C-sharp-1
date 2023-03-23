using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio6
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Escribe un numero");
            int num = Convert.ToInt32(Console.ReadLine());
            char[] line = new char[num];

            Console.WriteLine("Escribe un caracter");
            char c = Convert.ToChar(Console.ReadLine());
           
            for (int i=0; i<num; i++)
            {
                line[i] = c;
                if (i>1)
                {
                    if (line[i - 1] == c || i - 1 != 0)
                    {
                        line[i - 1] = Convert.ToChar(" ");
                    }
                    if (i == num - 1)
                    {
                        for (int x=0; x<num; x++)
                        {
                            line[x] = Convert.ToChar(c);
                        }
                    }
                }
                Console.WriteLine("{0}", string.Join(" ", line));
            }        
            Console.ReadLine();
        }
    }
}
