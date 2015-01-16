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
            Tests tests = new Tests();
            tests.enhetstesteriteration1();

            Console.Clear();
            Teams teams = new Teams();

            do
            {
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
                                        teams.addTeam(userInput);
                                        Console.WriteLine("Lag registrerat");
                                        break;

                                    }
                                    catch (ArgumentOutOfRangeException) { Console.WriteLine("du skrev inte ett namn som är minst 3 bokstäver och högst 12 bokstäver långt"); }
                                    catch (ArgumentException)
                                    {
                                        Console.WriteLine("Ett lag med det namnet finns redan!");
                                        break;
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("Det finns redan maximalt antal lag i turneringen. Tyvärr!");
                                        break;
                                    }

                                }

                                break;
                            case 2: //Se lagen och dess poäng
                                teams.showLeaderboard(); 
                                break;
                            case 3: //Ta bort/byta namn på lag
                                //visa listan på lag

                                teams.showTeams();
                                int chosenteam = 0;
                                if (teams.teamsAdded != 0)
                                {
                                    chosenteam = int.Parse(userinput("Välj ett lag!"));
                                    if (teams._teamNames[chosenteam - 1] == null)
                                    {
                                        Console.WriteLine("DU VALDE INTE ETT LAG");
                                        Console.ReadKey();
                                        break; 
                                    }
                                }
                                else
                                {
                                    break;
                                }
                                switch (int.Parse(userinput("Vad vill du göra?\n1. ta bort lag 2. byta namn 0. avbryt")))
                                {
                                    case 0:
                                        break;
                                    case 1:
                                        teams.removeTeam(chosenteam - 1);
                                        break;
                                    case 2:
                                        try
                                        {
                                            string newname = userinput("Skriv in det nya namnet!");
                                            teams.changeName((chosenteam - 1), newname);
                                            break;
                                        }
                                        catch (ArgumentOutOfRangeException) 
                                        { 
                                            Console.WriteLine("du skrev inte ett namn som är minst 3 bokstäver och högst 12 bokstäver långt");
                                            break;
                                        }
                                        catch (ArgumentException)
                                        {
                                            Console.WriteLine("Ett lag med det namnet finns redan!");
                                            break;
                                        }
                                        catch (Exception)
                                        {
                                            Console.WriteLine("Det finns redan maximalt antal lag i turneringen. Tyvärr!");
                                            break;
                                        }
                                }
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
            } while (true);

        }

        public static string userinput(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }
    }
}
