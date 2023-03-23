using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al juego adivina el numero. Escribe un numero entre 1 y 100\nDispone de 10 intentos para adivinarlo\n");

            Random rand = new Random();
            int randNumber = rand.Next(1, 101);
            int tries = 0;
            int NUM_TRIES = 10;
            bool numberGuessed = false;

            do
            {
                if (numberGuessed == false)
                {
                    Console.WriteLine($"Escribe un numero entre 1 y 100. Te quedan {NUM_TRIES - tries} intentos");
                    try
                    {
                        int userNumber = Convert.ToInt32(Console.ReadLine());
                        if (userNumber < 1 || userNumber > 100)
                        {
                            throw new Exception($"El numero {userNumber} esta fuera del rango permitido");
                        }

                        if (userNumber > randNumber)
                        {
                            Console.WriteLine($"El numero que has introducido es demasiado grande");
                        }
                        else if (userNumber < randNumber)
                        {
                            Console.WriteLine($"El numero que has introducido es demasiado pequeno");
                        }
                        else
                        {
                            Console.WriteLine($"Enhorabuena, has adivinado el numero en {tries} intentos");
                            numberGuessed = true;
                        }
                        tries++;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("El valor introducido no es un numero valido");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            } while (numberGuessed == false && tries < NUM_TRIES);

            Console.ReadLine();
        }
    }
}
