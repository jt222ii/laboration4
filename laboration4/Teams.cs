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
        public int[] _teamPoints = new int[15];
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
            
            //Console.WriteLine( _teamNames[teamsAdded] + ": " + _teamPoints[teamsAdded] );
        }

        public void removeTeam(int chosenteam)
        {
            
            string[] tempArray = _teamNames.Where(w => w != _teamNames[chosenteam]).ToArray();
            int[] tempPoints = _teamPoints.Where(w => w != _teamPoints[chosenteam]).ToArray();
            int tempspot = 0;
            for (int i = 0; i < _teamNames.Length-1; i++)
            {
                if (tempArray[i] != null)
                {
                    _teamNames[tempspot] = tempArray[i];
                    _teamPoints[tempspot] = tempPoints[i];
                    teamsAdded = teamsAdded - 1;
                    tempspot += 1;
                }
                else if(tempArray[i] == null && _teamNames[i] != null)
                {
                    _teamNames[i] = null;
                    _teamPoints[tempspot] = 0;
                    teamsAdded = teamsAdded - 1;
                    tempspot += 1;
                }
                else 
                    tempspot += 1;
            }
            
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
                int[] points = new int[15];
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
                        Console.WriteLine("{2}. {1}: {0}", points[i], names[i], nummer);
                        nummer += 1;
                    }
                }
            }
            else
            {
                Console.WriteLine("Det finns inga lag registrerade här");
                Console.ReadKey();
            }
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
                Console.WriteLine("Det finns inga lag registrerade här");
                Console.ReadKey();
            }
        }

    }
}
