using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        public static List<IDataconnection> Connections { get; private set; } = new List<IDataconnection>();

        public static void InitializeConnections(bool database, bool textfiles)
        {
            if (database)
            {
                // todo set up sql connector
                SQLConnector sql = new SQLConnector();
                Connections.Add(sql);

            }
            if (textfiles)
            {
                // todo textfile
                TextConnector text = new TextConnector();
                Connections.Add(text);
                
            }
        }

    }
}
