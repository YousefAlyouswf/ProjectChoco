using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectChoco
{
    class UserInterface
    {
        public int menu(string menuText)
        {
            try
            {

                message("\n");
                message(menuText);  //display menu text
                message("\n Choice: ");
                string input = Console.ReadLine();
                int choice = int.Parse(input); //read choice as an integer
                return choice;
            }
            catch (FormatException ex)        //not a valid integer
            {
                errorMessage("Please enter digits only.");
                return menu(menuText);              //give the user another chance
            }
            catch (InvalidOperationException ex)
            {
                //End of input, either of a test case using an input file
                //or the user presses Ctrl + Z (Windows)
                //or Ctrl + D (Unix) to exit the system.
                throw ex;
            }
            catch (Exception ex)       //all other exceptions
            {
                errorMessage(ex.Message);
                return 0;
            }
        }

        /** Displays the message as an error message
	 *  @param msg the message to display
	 */
        public void errorMessage(string msg)
        {
            Console.WriteLine("\n\n***Error: " + msg + "\n");
            //Make sure the user takes notice.  Similar to modal
            //error dialog in a GUI
            Console.Write("Press enter to continue ...");
            Console.ReadLine();
        }//errorMessage

        /** Displays the message as a standard message on a new line.
         *  @param msg the message to display
         */

        public void message(string msg)
        {
            Console.Write("\n" + msg);
        }//message

        /** Displays a prompt to the user for a string 
	 *  and returns the user's input
	 *  @param prompt the prompt
	 *  @return the user input 
	 */
        public string promptForString(string prompt)
        {
            message(prompt);
            string input = Console.ReadLine();
            return input;
        }//promptForString

        /** Diplays a prompt to the user for a long integer 
	 *  and returns the user's input
	 *  @param prompt the prompt
	 *  @return the user input 
	 */
        public long promptForLong(string prompt)
        {
            try
            {
                message(prompt);    //display prompt
                string input = Console.ReadLine(); 
                long number = Convert.ToInt64(input);//convert to long
                return number;
            }
            catch (FormatException ex) //not a valid long
            {
                errorMessage("Please enter digits only.");
                return promptForLong(prompt);  //give the user another chance
            }
        }//getLong

        /** Diplays a prompt to the user for a date and returns the user's input
	 *  @param prompt the prompt
	 *  @return the user input 
	 */
        public DateTime promptForDate(string prompt)
        {
            try
            {
                message(prompt);  //display prompt
                string dateString = Console.ReadLine();  //read input
                DateTime dt = new DateTime(Convert.ToInt64(dateString));
                string.Format("{0:MM/dd/yyyy}", dt);
                return DateTime.Parse(dateString);  //convert to a date
            }
            catch (FormatException ex)
            {
                errorMessage("Invalid date. Please follow format given.");
                return promptForDate(prompt); //give the user another chance
            }

        }//promptForDate

        /** Displays a prompt to the user for a double value and 
	 *  returns the user's input
	 *  @param prompt the prompt
	 *  @return the user input
	 */
        public double promptForDouble(string prompt)
        {
            try
            {
                message(prompt);
                string input = Console.ReadLine();
                double value = Double.Parse(input); //convert to a double
                return value;
            }
            catch (InvalidOperationException ex)  //not a valid double
            {
                errorMessage("Please enter digits and at most one decimal point");
                return promptForDouble(prompt);  //give the user another chance
            }
        }//promptForDouble

        /** Displays a prompt to the user for a double value, and returns the 
	 *  user's input. If the user gives no value, the default value is returned.
	 *  @param prompt the prompt
	 *  @param defaultValue the defaultValue
	 *  @return the user input or the defaultValue
	 */
        public double promptForDouble(string prompt, double defaultValue)
        {
            try
            {
                message(prompt);
                string input = Console.ReadLine();
                //test for no value
                if (input != null && input.Length > 0)
                {
                    double value = Double.Parse(input); //convert to double
                    return value;
                }
                else return defaultValue;  //no value given -- return default value
            }
            catch (InvalidOperationException ex)
            {
                errorMessage("Please enter digits and at most one decimal point");
                return promptForDouble(prompt);  //give the user another chance
            }
        }//promptForDouble

        /** Returns the value given formatted as currency
	 *  @param value the value to be formatted
	 *  @return the value as a currency string
	 */
        public string formatAsCurrency(double value)
        {
            return value.ToString("C", new System.Globalization.CultureInfo("en-US"));
        }//formatAsCurrency

    }
}
