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
