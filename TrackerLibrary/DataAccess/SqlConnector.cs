using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

    

namespace TrackerLibrary.DataAccess

{
    public class SqlConnector : IDataConnection // this is built in
    {
        
        /// <summary>
        ///  Saves a new model to the database
        /// </summary>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            // IDbConnection is from Microsoft
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(
                GlobalConfig.CnnString("Tournaments")))
            {
                var p = new DynamicParameters();
                p.Add("@PlaceNumber", model.PlaceNumber);
                p.Add("@PlaceName", model.PlaceName);
                p.Add("@PrizeAmount", model.Prizeamount);
                p.Add("@PrizePercentage", model.PrizePercentage);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spPrizes_Insert", p, commandType: CommandType.StoredProcedure);

                model.id = p.Get<int>("@id");

                return model;
            }
        }
    }
}
 