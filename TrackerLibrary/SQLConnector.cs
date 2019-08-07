using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public class SQLConnector : IDataconnection
    {
        //todo make CreatePrize save to database
        /// <summary>
        /// saves new prize to database
        /// </summary>
        /// <param name="model"></param>
        /// <returns> the prize information</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            model.Id = 1;

            return model;
        }
    }
}
