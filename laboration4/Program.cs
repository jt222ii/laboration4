using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboration4
{
    class Program
    {
        static void Main(string[] args)
        {
            Teams teams = new Teams();
            int[] keys = { 1, 4, 3, 2, 5 };
            string[] items = { "abc", "def", "ghi", "jkl", "mno" };
            Array.Sort(items, keys);
            for (int i = 0; i < keys.Length; i++)
            {
                Console.WriteLine(keys[i] + items[i]);
            }

            
            try
            {
                while (true)
                {
                    int userchoice = int.Parse(userinput("Välkommen. Vad vill du göra? \n1. registrera lag \n2. Se rankingen \n3. hantera lag \n4. Räkna poäng  \n0. stäng av"));
                    switch (userchoice)
                    {
                        case 0:
                            Console.WriteLine("stänger av");
                            return;
                        case 1:
                            while (true)
                            {
                                try
                                {
                                    string userInput = userinput("Namn på laget?(3-12 bokstäver)");
                                    if (userInput.Length <= 12 && userInput.Length >= 3)
                                    {
                                        teams.addTeam(userInput);
                                        break;
                                    }
                                    else
                                    {
                                        throw new ArgumentOutOfRangeException();
                                    }
                                }
                                catch { Console.WriteLine("du skrev inte ett namn som är minst 3 bokstäver och högst 12 bokstäver långt"); }
                            }
                            Console.WriteLine("Lag registrerat");
                            break;
                        case 2: //Se lagen och dess poäng
                            teams.showTeams();
                            break;
                        case 3: //Ta bort/byta namn på lag
                            //visa listan på lag
                            //
                            break;
                        case 4: //Välja lag och lägga till poängen till laget.
                            break;
                        default:
                            Console.WriteLine("du valde inget av alternativen...");
                            break;
                    } 
                }
            }
            catch
            {
                Console.WriteLine("Du skrev inte in ett nummer");
            }

        }

        public static string userinput(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }
    }
}
