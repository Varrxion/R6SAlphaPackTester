using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace AlphaPackTester
{
    class Program
    {
        static void Main(string[] args)
        {
            int resultnum = 0;
            int wins = 0;
            int losses = 0;
            int highestchance = 2;
            int currentchance = 2;
            int endnum = 0;
            var randobj = new Random();

            int wongames = 0;
            int lostgames = 0;

            Console.Write("How many simulations to run: ");
            int.TryParse(Console.ReadLine(), out endnum);
            int[] winchancearr = new int[endnum];

            while (wins!=endnum)
            {
                resultnum++;
                int rand = randobj.Next(1, 101);
                int winloss = randobj.Next(1, 101);

                if (winloss <= 60) //put your winrate here
                {
                    wongames++;
                }
                else
                {
                    lostgames++;
                    rand = 999;
                }

                //Console.WriteLine($"The number is {rand}"); //to show num generation
                if (rand <= currentchance)
                {
                    //Console.WriteLine($"Current chance was {currentchance}, when won."); //to show chance when get pack

                    winchancearr[wins] = currentchance; //write current chance to array for later calculation

                    if (highestchance < currentchance)
                    {
                        highestchance = currentchance;
                    }
                    currentchance = 2;
                    wins++;
                }
                else if (rand==999)
                {
                    currentchance = currentchance + 2;
                    losses++;
                }
                else
                {
                    currentchance = currentchance + 3;
                    losses++;
                }
                //Console.WriteLine($"Result number {resultnum} is above");
            }

            int arrread = 0;
            double arrtotal = 0;
            while (arrread!=endnum)
            {
                //Console.WriteLine($"the end chance for run {arrread+1} was {winchancearr[arrread]}");
                arrtotal = arrtotal + winchancearr[arrread];
                arrread++;
            }

            double avgchance = arrtotal / endnum;

            Console.WriteLine($"Total won games was {wongames}, Total lost games was {lostgames}");
            Console.WriteLine($"The average chance is: {avgchance}");
            Console.WriteLine($"Total wins was {wins}");
            Console.WriteLine($"Total losses was {losses}");
            Console.WriteLine($"Highest chance achieved was {highestchance}");
            Console.Write("Hit enter to exit");
            Console.ReadLine();
        }
    }
}
