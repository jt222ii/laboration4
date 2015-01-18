using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboration4
{
    class Tests3
    {
        public void test()
        {
            Console.WriteLine("Iteration 3 - Test 1 skickar in en array till average metoden i count och jämför det returnerade värdet med vad som bör returneras");
            if(test1())
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Det returnerade värdet från testarrayen matchade det förväntade resultatet - TEST SUCCESS!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Det returnerade värdet från testarrayen matchade INTE det förväntade resultatet - TEST FAILURE");
                Console.ResetColor();
            }

            Console.WriteLine("Iteration 3 - Test 2 kollar så att poängen läggs till korrekt");
            if (test2())
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Poängen lades till korrekt - TEST SUCCESS!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Något gjorde att poängen inte lades till korrekt - TEST FAILURE");
                Console.ResetColor();
            }


            Console.ReadKey();
        }



        public bool test1()
        {
            count count = new count();
            int[] testarray = new int[5];
            testarray[0] = 1;
            testarray[1] = 3;
            testarray[2] = 2;
            testarray[3] = 5;
            testarray[4] = 4;
            decimal expectedresult = 3;
            decimal result = count.average(testarray);
            if (result == expectedresult)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool test2()
        {
            Teams team = new Teams();
            team.addPoints(0, 5);
            team.addPoints(1, 7);
            if (team._teamPoints[0] == 5 && team._teamPoints[1] == 7)
            {
                return true;
            }
            else
                return false;
        }
    }
}
