using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public class MatchupEntryModel
    {
        /// <summary>
        /// Reps one team in the matchup
        /// </summary>
        public TeamModel TeamCompeting { get; set; }
        /// <summary>
        /// reps the score of one team
        /// </summary>
        public double Score { get; set; }
        /// <summary>
        /// reps the matchup this team came from
        /// </summary>
        public MatchupModel ParentMatchup { get; set; }
        
        public MatchupEntryModel(double initialScore)
        {
            Console.WriteLine();
        }
    }
}
