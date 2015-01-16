using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboration4
{
    class Tests
    {
        public void test()
        {
            //test 1
            Console.WriteLine("test 1 - för få bokstäver");
            if(test1("AB"))
            { 
                Console.WriteLine("registreringen gick igenom med mindre än 3 bokstäver - testet misslyckades!");
            }
            else
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("registreringen gick inte igenom med för få bokstäver - testet lyckat!");
                Console.ResetColor();
            //test 2
            Console.WriteLine("test 2 - för många bokstäver");
            if (test1("ABCDEFGHIJKLMNOP"))
            {
                Console.WriteLine("registreringen gick igenom med mer än 12 bokstäver - testet misslyckades!");
            }
            else
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("registreringen gick inte igenom med för många bokstäver - testet lyckat!");
                Console.ResetColor();

            //test 3
            Console.WriteLine("test 3 - registrering med ett namn som redan finns");
            test1("ABCDEFG");
            if (samename("ABCDEFG", "ABCDEFG"))
            {
                Console.WriteLine("registreringen gick igenom vid registrering av två lag med samma namn - testet misslyckades!");
            }
            else
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("registreringen gick inte igenom vid registrering av två lag med samma namn - testet lyckat!");
                Console.ResetColor();

            //test 4
            Console.WriteLine("test 4 - Giltigt antal bokstäver");
            if (test1("ABCDEFG"))
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("registreringen gick igenom med giltigt antal bokstäver - testet lyckades!");
                Console.ResetColor();
            }
            else
                Console.WriteLine("registreringen gick inte igenom med giltigt antal bokstäver - testet misslyckat!");

            //test 5
            Console.WriteLine("test 5 - av fler lag än det finns platser i tävlingen(Det finns 15 platser testar att skriva in 16 lag)");
            if (toomanyteams("ABC"))
            {
                Console.WriteLine("Det gick att registrera mer lag än maximalt antal lag - testet misslyckades");
            }
            else
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("det gick inte att registrera mer lag än maximalt antal lag - testet lyckades!");
                Console.ResetColor();

            Console.ReadKey();
        }    

        public bool test1(string name)
        {
            Teams teams = new Teams();
            try
            {
                teams.addTeam(name);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool samename(string name, string name2)
        {          
            Teams teams = new Teams();
            try
            {
                teams.addTeam(name);
                teams.addTeam(name2);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool toomanyteams(string name)
        {
            Teams teams = new Teams();
            try
            {
                for (int i = 0; i <= 15; i++) //maximalt antal lag är hårdkodat in till 15 lag. Denna loop försöker lägga till 16 lag.
                {
                    teams.addTeam(string.Format(name+i));
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
