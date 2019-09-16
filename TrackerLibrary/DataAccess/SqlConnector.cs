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
        private const string db = "Tournaments";
        public PersonModel CreatePerson(PersonModel model)
        {
            // IDbConnection is from Microsoft
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(
                GlobalConfig.CnnString("Tournaments")))
            {
                var p = new DynamicParameters();
                p.Add("@FirstName", model.FirstName);
                p.Add("@LastName", model.LastName);
                p.Add("@EmailAddress", model.EmailAdderss);
                p.Add("@CellphoneNumber", model.CellphoneNumber);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spPeople_Insert", p, commandType: CommandType.StoredProcedure);

                model.Id = p.Get<int>("@id");

                return model;
            }
        }

        //This is a change for github

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

                model.id = p.Get<int>("@id"); //TODO fix this error here

                return model;
            }
        }

        public List<PersonModel> GetPerson_All()
        {
            List<PersonModel> output;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("Tournaments")))
            {
                //TODO dbo.spPeople_GetAll is not existing
                output = connection.Query<PersonModel>("dbo.spPeople_GetAll").ToList();
            }

            return output;

            

        }
    }
}
 