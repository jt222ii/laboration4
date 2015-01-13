using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboration4
{
    
    class Teams
    {
        
        public string[] _teamNames = new string[10];
        public int[] _teamPoints = new int[10];
        public int teamsAdded = 0;
        
        public void addTeam(string name)
        {
            
            _teamPoints[teamsAdded] = 0;
            _teamNames[teamsAdded] = name;
            for (int i = 0; i < _teamNames.Length; i++)
            {
                
            }

            teamsAdded++;
            Console.Clear();
            //Console.WriteLine( _teamNames[teamsAdded] + ": " + _teamPoints[teamsAdded] );
        }

        public void removeTeam()
        {

        }

        public void showTeams()
        {
            int nummer = 1;
            if (teamsAdded > 0)
            {
                
                Array.Sort(_teamPoints, _teamNames);
                Array.Reverse(_teamPoints);
                Array.Reverse(_teamNames);
                
                for (int i = 0; i < _teamNames.Length; i++)
                {

                    if (_teamNames[i] != null)
                    {
                        Console.WriteLine("{2}. {1}: {0}", _teamPoints[i], _teamNames[i], nummer);
                        nummer += 1;
                    }

                }
            }
            else
                Console.WriteLine("Det finns inga lag registrerade här");
        }

    }
}
