using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace laboration4
{
    class Program
    {
        static void Main(string[] args)
        {
            Tests tests = new Tests();
            tests.test();
            Tests2 tests2 = new Tests2();
            tests2.test();
            Console.Clear();
            Teams teams = new Teams();
            count countPoints = new count();
            do
            {
                try
                {
                    while (true)
                    {
                        Console.Clear();
                        int userchoice = int.Parse(userinput("Välkommen. Vad vill du göra? \n1. registrera lag \n2. Se rankingen \n3. hantera lag \n4. Räkna poäng  \n0. stäng av"));
                        switch (userchoice)
                        {
                            case 0:
                                Console.WriteLine("stänger av");
                                return;
                            case 1: // registrera lag
                                while (true)
                                {
                                    try
                                    {

                                        string userInput = userinput("Namn på laget?(3-12 bokstäver)");
                                        teams.addTeam(userInput);
                                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine("Lag registrerat");
                                        Console.ResetColor();
                                        Console.ReadKey();
                                        break;

                                    }
                                    catch (ArgumentOutOfRangeException) 
                                    {
                                        Console.BackgroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("du skrev inte ett namn som är minst 3 bokstäver och högst 12 bokstäver långt");
                                        Console.ResetColor();
                                        Console.ReadKey();
                                        break;                                     
                                    }
                                    catch (ArgumentException)
                                    {
                                        Console.BackgroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("Ett lag med det namnet finns redan! Registrering misslyckad");
                                        Console.ResetColor();
                                        Console.ReadKey();
                                        break;
                                    }
                                    catch (Exception)
                                    {
                                        Console.BackgroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("Det finns redan maximalt antal lag i turneringen. Tyvärr!");
                                        Console.ResetColor();
                                        Console.ReadKey();
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
                                        Console.BackgroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("DU VALDE INTE ETT LAG");
                                        Console.ResetColor();
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
                                            Console.BackgroundColor = ConsoleColor.DarkRed;
                                            Console.WriteLine("du skrev inte ett namn som är minst 3 bokstäver och högst 12 bokstäver långt");
                                            Console.ResetColor();
                                            Console.ReadKey();
                                            break;
                                        }
                                        catch (ArgumentException)
                                        {
                                            Console.BackgroundColor = ConsoleColor.DarkRed;
                                            Console.WriteLine("Ett lag med det namnet finns redan!");
                                            Console.ResetColor();
                                            Console.ReadKey();
                                            break;
                                        }
                                        catch (Exception)
                                        {
                                            Console.BackgroundColor = ConsoleColor.DarkRed;
                                            Console.WriteLine("Något gick fel...");
                                            Console.ResetColor();
                                            Console.ReadKey();
                                            break;
                                        }
                                }
                                break;

                            case 4: //Välja lag och lägga till poängen till laget.
                                int[] pointArray = new int[5];
                                for (int i = 0; i < pointArray.Length; i++)
                                {
                                    try
                                    {
                                        pointArray[i] = int.Parse(userinput(string.Format("Ange poängen(1-10) från domare nr {0}: ", i + 1)));
                                        if (pointArray[i] > 10 || pointArray[i] < 1)
                                        {
                                            Console.BackgroundColor = ConsoleColor.DarkRed;
                                            Console.WriteLine("Du angav en poäng som inte var inom korrekt intervall 1-10! försök igen\n");
                                            Console.ResetColor();
                                            i = i - 1;
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        Console.BackgroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("Du skrev inte in ett nummer... försök igen!\n");
                                        Console.ResetColor();
                                        i = i - 1;
                                    }
                                }
                                decimal average = countPoints.average(pointArray);
                                if (teams.teamsAdded != 0)
                                {
                                    teams.showTeams();
                                    int userchoice2 = int.Parse(userinput(string.Format("Välj laget som ska få poängen: {0:0.00}!", average)));
                                    if (userchoice2 > teams.teamsAdded || userchoice2 < 1)
                                    {
                                        Console.BackgroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("Du valde inget lag");
                                        Console.ResetColor();
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        teams.addPoints(userchoice2 - 1, average);
                                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine("poängen tillagd!");
                                        Console.ResetColor();
                                        Console.ReadKey();
                                    }
                                }
                                else
                                {
                                    Console.BackgroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("Det finns inga registrerade lag att ge poängen: {0:0.00} - Lägg till ett lag och försök igen", average);
                                    Console.ResetColor();
                                    Console.ReadKey();
                                }
                                break;
                            default:
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("du valde inget av alternativen...");
                                Console.ResetColor();
                                Console.ReadKey();
                                break;
                        }
                    }
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Du skrev inte in ett nummer");
                    Console.ResetColor();
                    Console.ReadKey();
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
