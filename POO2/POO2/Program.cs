using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO2
{
    class Program
    {
        public class Tragaperras {

            public int coins { get; set; }
            public bool[] panels { get; set; }


            public Tragaperras()
            {
                this.coins = 0;
                this.panels = new bool[] { false, false, false };
            }

            public void play()
            {
                this.coins++;
                var random = new Random();
                for (int i=0; i<3; i++)
                {
                    // Genero un numero aleatorio entre 0 y 1. Si es 1 se le asigan true, si es 0 false.
                    panels[i] = random.Next(2) == 1;
                    Console.WriteLine(panels[i]);
                }

                bool allPanelsAreTrue = true;
                foreach (bool panel in panels)
                {
                    if (panel==false)
                    {
                        allPanelsAreTrue = false;
                    } 
                }

                if (allPanelsAreTrue)
                {
                    Console.WriteLine($"Congratulations!!!. You won {this.coins} coins!!");
                    this.coins = 0;
                } else
                {
                    Console.WriteLine("Good luck next time!!");
                }
            }
        }

        static void Main(string[] args)
        {
            try
            {
                Tragaperras tragaperras = new Tragaperras();
                bool keepPlaying = true;

                do
                {
                    tragaperras.play();
                    Console.WriteLine("\nPress 1 to spin again\nPress any other button to quit");
                    int playAgain = Convert.ToInt32(Console.ReadLine());
                    if (playAgain != 1)
                    {
                        keepPlaying = false;
                    }
                } while (keepPlaying);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Thank you for playing");
            }
        }
    }
}
