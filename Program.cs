using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            int numGiven = 0;
            bool keepLooping = true;
            Console.Write("Welcome to the dice roller. ");

            //finds out how many sides there will be
            while (keepLooping == true)
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Please choose how many sides you would like. (note: only whole numbers above 0 are accepted)");
                        numGiven = int.Parse(Console.ReadLine());
                        if (numGiven < 1)
                        {
                            throw new FormatException();
                        }

                        break;

                    }
                    catch (FormatException)
                    {
                        Console.Write("That is not a valid number. ");

                    }
                }
                Console.WriteLine(DiceRoller(numGiven));

                while (true)
                {
                    Console.WriteLine("Do you want to try again? yes or no");
                    string answer = Console.ReadLine();
                    if (answer.ToLower() == "no")
                    {
                        keepLooping = false;
                        break;
                    }
                    else if (answer != "yes")
                    {
                        Console.WriteLine("That was not a valid option");
                    }
                    else
                    {
                        break;
                    }
                }
            }
            Console.ReadKey();
        }

        public static string DiceRoller(int num)
        {
            Random rand = new Random();
            //declares dice values
            int diceSides = num;
            int die1 = rand.Next(1, diceSides + 1);
            int die2 = rand.Next(1, diceSides + 1);
            int total = die1 + die2;
            string res = "";

            if (diceSides != 6)
            {
                Console.WriteLine($"You rolled a {die1} and a {die2}. Your total is {total}");
            }
            else
            {
                if (die2 == 1 && die1 == 1)
                {
                    res += "You rolled 2 1s. You got snake eyes. ";
                }
                else if ((die1 == 1 && die2 == 2) || (die1 == 2 && die2 == 1))
                {
                    res += "You rolled a 1 and a 2. You got ace deuce. ";
                }
                else if (die1 == 6 && die2 == 6)
                {
                    res += "You rolled 2 6s. You got box cars. ";
                }
                else
                {
                    res += $"You rolled a {die1} and a {die2}. Your total is {total}. ";
                }

                if (total == 2 || total == 3 || total == 12)
                {
                    res += "You got craps. Unfortunate. ";
                }
                else if (total == 7 || total == 11)
                {
                    res += "You won, way to go.";
                }
            }
            return res;
        }
    }
}
