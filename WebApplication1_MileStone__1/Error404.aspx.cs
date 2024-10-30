using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1_MileStone__1
{
    public partial class Error404 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Log 404 errors to a text file (or any other logging mechanism)
            string logFile = Server.MapPath("~/Logs/ErrorLog.txt");
            string errorMessage = $"404 Error: Page not found at {Request.Url} on {DateTime.Now}";

            // Check if log file exists, otherwise create it
            if (!File.Exists(logFile))
            {
                File.Create(logFile).Dispose();
            }

            // Append error message to the log file
            using (StreamWriter writer = new StreamWriter(logFile, true))
            {
                writer.WriteLine(errorMessage);
            }
        }
    }
}