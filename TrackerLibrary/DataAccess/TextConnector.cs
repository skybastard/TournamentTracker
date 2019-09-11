using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextHelpers;
	

	

namespace TrackerLibrary
{
    public class TextConnector : IDataConnection
    {
        private const string PrizesFile = "PrizeModels.csv";

        // TODO wire up for prize IO to text files
        public PrizeModel CreatePrize(PrizeModel model)
        {

           
            
            // convert prizes to list of string
            // save list of string to textfile

            // load the textfile
            // conv text to list <prizemodel>
            List<PrizeModel> prizes =  PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();

            // find the max id
            int currentId = 1;
            if(prizes.Count > 0)
            {
                currentId = prizes.OrderByDescending(x => x.id).First().id + 1;
            }
             
            model.id = currentId;

            // add new record with id (max + 1)
            prizes.Add(model);

            prizes.SaveToPrizeFile(PrizesFile);

            return model;

        }
    }
}
