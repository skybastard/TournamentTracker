using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

// load the textfile
// conv text to list <prizemodel>
// find the max id
// add new record with id (max + 1)
// convert prizes to list of string
// save list of string to textfile

namespace TrackerLibrary.DataAccess.TextHelpers
{
    public static class TextConnectorProcessor
    {

        public static string FullFilePath(this string fileName) //PrizeModels.csv
        {

            // this is in App.config path, filename is PrizeModels.csv
            return $"{ConfigurationManager.AppSettings["filePath"]}\\{fileName}"; 
        }

        public static List<string> LoadFile(this string file)
        {
            if (!File.Exists(file))
            {
                return new List<string>();
            }

            return File.ReadAllLines(file).ToList();
        }

        public static List<PrizeModel> ConvertToPrizeModels(this List<string> lines)
        {
            List<PrizeModel> output = new List<PrizeModel>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');
                PrizeModel p = new PrizeModel();
                p.id = int.Parse(cols[0]);
                p.PlaceNumber = int.Parse(cols[1]);
                p.PlaceName = cols[2];
                p.Prizeamount = decimal.Parse(cols[3]);
                p.PrizePercentage = double.Parse(cols[4]);
                output.Add(p);
            }

            return output;
        }

        public static void SaveToPrizeFile(this List<PrizeModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (PrizeModel p in models)
            {
                lines.Add($"{ p.id },{ p.PlaceNumber },{p.PlaceName},{ p.Prizeamount }," +
                    $"{ p.PrizePercentage }");

                File.WriteAllLines(fileName.FullFilePath(), lines);
            }
        }

    }
}
