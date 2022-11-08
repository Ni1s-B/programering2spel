using System;
using static System.Net.Mime.MediaTypeNames;

namespace provspel
{
   
    internal class Program
    {
        static void Main(string[] args)
        {
            int points = 0;
            Random rand = new Random();//impoterar random som rand
            int[] colors = new int[100];//Gör en array för färgerna/talen
            int i = 0;//gör en räknare 
            bool fail = false;//vareabel som komer bli true om man förlorar
            while (i < 100 && !fail)//lopp som avlsutar spelet om man når nivå 100 eller förlorar
            {
                int number = rand.Next(1, 3);
                colors[i] = number;//lägger in färgerna i arrayen.
                Console.WriteLine("Poäng: " + Convert.ToString(points) + "\n\n");//visar hur många poäng som spelaren har 
                for (int j = 0; j <= i; j++)//lopp skriver översätter skumptalen till färgere och printar ut dom.
                {
                    if (colors[j] == 1) 
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write("  1 ");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write("  2 ");
                    }
                    
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("   ");
                }
                Thread.Sleep(1000 + 200 * i);//visar färgerna i en sekund och ökar tiden beroende på antal färger
                int[] answerArray = new int [i+1];//gör en array för spelarens inputt
                answerArray=userInput(i + 1,points );//kallar på funktion som lägger in användarens gissningar i en lista
                
                for (int j = 0; j <= i; j++) //loop som gämför spelarens svar med de rätta svaren.
                {
                    if (colors[j] != answerArray[j]) 
                    { 
                        fail= true;
                        break;
                    }
                        
                }
                if (fail)
                {
                    Console.WriteLine("du fick fel");
                }
                else
                {
                    Console.WriteLine("Du fick rätt!");
                    points++;
                }
                Thread.Sleep(1200);
                Console.Clear();
                i++;
            }
            Console.WriteLine("Bra jobbat du fick " + Convert.ToString(points) + " poäng");
        }
        static int[] userInput(int numberOfGuesses,int points2)//en funktion som låter användaren skriva in sina gisningar och retonerar gisningarna som en lista
        { 

            int[] arrayOfGuesses = new int[numberOfGuesses];
            for (int k = 0; k < numberOfGuesses; k++)
            {
                int guesses;
                Console.Clear();
                Console.WriteLine("Poäng: "+Convert.ToString(points2)+"\n\nGissning kvar: "+Convert.ToString(numberOfGuesses-k));
                guesses = Convert.ToInt32(Console.ReadLine());
                arrayOfGuesses[k] = guesses;
            }
            return (arrayOfGuesses);
        }
    }
}