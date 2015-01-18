using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboration4
{
    
    class Teams
    {
        public string[] _teamNames = new string[15];
        public decimal[] _teamPoints = new decimal[15];
        public int teamsAdded = 0;
        
        public void addTeam(string name)
        {
            if (name.Length > 12 || name.Length < 3)
            { throw new ArgumentOutOfRangeException(); }
            if (teamsAdded == _teamNames.Length)
            { throw new Exception(); }

            _teamPoints[teamsAdded] = 0;           
            for (int i = 0; i < _teamNames.Length; i++)
            {
                if(name == _teamNames[i])
                {
                    throw new ArgumentException();
                }
            }
            _teamNames[teamsAdded] = name;
            teamsAdded++;
        }

        public void removeTeam(int chosenteam)
        {

            int k = 0;
            string[] newArray = new string[_teamNames.Length];
            decimal[] newInt = new decimal[_teamNames.Length];
            for (int i = 0; i < _teamNames.Length-1; i++)
            {
                if (i == chosenteam)
                {
                    k = 1;
                }
                if (i !=_teamNames.Length-1)
                {
                    newArray[i] = _teamNames[i + k];
                    newInt[i] = _teamPoints[i + k]; 
                }
                else if(i == _teamNames.Length-1)
                {
                    newArray[i] = null;
                    newInt[i] = 0;
                }

            }
            teamsAdded = teamsAdded - 1;
            Array.Copy(newArray, _teamNames, 15);
            Array.Copy(newInt, _teamPoints, 15);
            
        }
        public void changeName(int chosenteam, string name)
        {           
           
            if (name.Length > 12 || name.Length < 3)
            { throw new ArgumentOutOfRangeException(); }
            if (teamsAdded == _teamNames.Length)
            { throw new Exception(); }
            for (int i = 0; i < _teamNames.Length; i++)
            {
                if (name == _teamNames[i])
                {
                    throw new ArgumentException();
                }
            }
            _teamNames[chosenteam] = name;
        }

        public void showLeaderboard()
        {
            int nummer = 1;
            if (teamsAdded > 0)
            {
                decimal[] points = new decimal[15];
                string[] names = new string[15];
                Array.Copy(_teamNames, names, 15);
                Array.Copy(_teamPoints, points, 15);
                Array.Sort(points, names);
                Array.Reverse(points);
                Array.Reverse(names);

                for (int i = 0; i < names.Length; i++)
                {
                    if (names[i] != null)
                    {
                        
                        Console.WriteLine("\n{2}. {1}: {0:0.00}\n", points[i], names[i], nummer);
                        
                        nummer += 1;
                    }
                }
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Det finns inga lag registrerade");
                Console.ResetColor();

            }
            Console.ReadKey();
        }

        public void showTeams()
        {
            int nummer = 1;
            if (teamsAdded > 0)
            {
                for (int i = 0; i < _teamNames.Length; i++)
                {
                    if (_teamNames[i] != null)
                    {
                        Console.WriteLine("{1}. {0}", _teamNames[i], nummer);
                        nummer += 1;
                    }
                }
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Det finns inga lag registrerade");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
        public void addPoints(int chosenteam, decimal points)
        {
          _teamPoints[chosenteam] += points;
        }

    }
}
