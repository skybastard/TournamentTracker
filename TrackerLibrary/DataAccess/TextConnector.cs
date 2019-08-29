using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary
{
    public class TextConnector : IDataConnection
    {
        // TODO wire up for prize IO to text files
        public PrizeModel CreatePrize(PrizeModel model)
        {
            model.id = 1;

            return model;

        }
    }
}
