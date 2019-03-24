using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectChoco
{
    public abstract class Report
    {
        /** Creates a new report
	 */
        public Report()
        {
            // Send all output to the Appendable object sb
            StringBuilder sb = new StringBuilder();
            ICustomFormatter formatter = new ICustomFormatter(sb);

            // Add a heading
            addHeading("Chocoholics Anonymous");
        }//default constructor


        /** Adds a heading, centre justified, to the report
         *  @param heading the heading to be added
         */
        public void addHeading(string heading)
        {
            //centre justify headings, assume 80 characters per line
            string firstHalf = heading.Substring(0, heading.Length / 2);
            string secondHalf = heading.Substring(heading.Length / 2);
            formatter.format("%40s", firstHalf);
            formatter.format("%-40s%n%n", secondHalf);
        }//addHeading

        /** Adds an error message to the report
         *  @param message the message to be added
         */
        public void addErrorMessage(string message)
        {
            formatter.format("%n*****Error: %s*****%n", message);
        }//addErrorMessage

        /** Simulates sending a report by email.  The report is saved to a
         *  text file named by the "email address" given plus the extension .txt.
         *  @param emailAddress the email address to which the report must be sent
         *  @throws FileNotFoundException if the file cannot be created
         */
        public void sendByEmail(string emailAddress)
        {
            StreamWriter out1 = null;
            fileName = emailAddress + ".txt";
		out1 = new StreamWriter(fileName);
		out1.WriteLine(sb);
		out1.Close();
        }//sendByEmail

        /** Displays the report on the given user interface
         *  @param ui the user interface
         */
        public void display(UserInterface ui)
        {
            ui.message(sb.ToString());
        }//display

        /** Simulates printing the report.  The report is saved to a text file
         *  named by the printer name given.
         *  @param printerName the printer to which the report must be printed
         *  @throws FileNotFoundException if the file cannot be created
         */
        public void print(string printerName)
        {
            sendByEmail(printerName);
        }//print

        /** Returns the name of the file to which this report was last saved.
         *  If called before print or sendByEmail is called, null is returned.
         *  @return the file name last used to save the report
         */
        public string getFileName()
        {
            return fileName;
        }//getFileName

        //*********************class variables

        /** Currency is displayed in dollars, according to specification
         */
        //protected static NumberFormat currencyFormatter
        //                    = NumberFormat.getCurrencyInstance(Locale.US);

        //*********************instance variables
        /** The formatter that builds the report.
         */
        private string fileName;
    }
}
