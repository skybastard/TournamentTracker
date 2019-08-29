using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrackerUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // init database connections
            TrackerLibrary.GlobalConfig.InitializeCinnections(TrackerLibrary.DatabaseType.Sql);
            //Application.Run(new TournamentDashBoard());

            Application.Run(new CreatePrize());
        }
    }
}
