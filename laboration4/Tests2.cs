using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboration4
{
    class Tests2
    {
        public void test()
        {
            Console.WriteLine("Iteration 2 - Test 1 - lägger till 4 lag tar bort det andra och jämför sedan det med en hårdkodad array.");
            string[] testarray1 = new string[15];
            testarray1[0] = "lag1";
            testarray1[1] = "lag3";
            testarray1[2] = "lag4";
            if (test1("lag1","lag2","lag3","lag4",testarray1))
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("testarrayen där ett värde tas bort ser likadan ut som den hårdkodade arrayen! TEST SUCCESS!");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Arrayerna är inte lika - det är något fel med borttagningen av lag! TEST FAILURE!");
            }

            //test 2 byta namn till ett för kort namn
            Console.WriteLine("Iteration 2 - Test 2 - lägger till två lag byter sedan namnet på den andra till ett för kort namn");
            if (test2("lag1", "lag2", "aa"))
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Det gick inte byta till ett för kort namn! - TEST SUCCESS");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Det gick att byta namn till ett namn som var för kort! TEST FAILURE!");
            }

            //test 3 byta namn till ett för långt namn
            Console.WriteLine("Iteration 2 - Test 3 - lägger till två lag byter sedan namnet på den andra till ett för långt namn");
            if (test2("lag1", "lag2", "MERÄNTOLVBOKSTÄVER"))
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Det gick inte att byta till ett för långt namn! - TEST SUCCESS");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Det fick att byta till nett för långt namn - TEST FAIL!");
            }

            //test 4 byta namn till ett namn som redan finns
            Console.WriteLine("Iteration 2 - Test 3 - lägger till två lag byter sedan namnet på den andra till ett för namn som redan finns");
            if (test2("lag1", "lag2", "lag1"))
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Det gick inte att byta till ett namn som redan finns! - TEST SUCCESS");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Det gick att byta till ett namn som redan fanns... - TEST FAILURE!");
            }




            Console.ReadKey();
        }

        public bool test1(string lag1, string lag2, string lag3, string lag4, string[] array)
        {

            Teams team = new Teams();
            team.addTeam(lag1);
            team.addTeam(lag2);
            team.addTeam(lag3);
            team.addTeam(lag4);
            team.removeTeam(1);

            for (int i = 0; i < team._teamNames.Length; i++)
            {
                if(team._teamNames[i] != array[i])
                {
                    return false;
                }
                
            }

            return true;
        }
        public bool test2(string lag1, string lag2, string newname) // denna kan testa test 2-4
        {
            Teams team = new Teams();
            team.addTeam(lag1);
            team.addTeam(lag2);
            try
            {
                team.changeName(1, newname);
                return false;
            }
            catch
            {
                return true;
            }
            
        }
    }
}
