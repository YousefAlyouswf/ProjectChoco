using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectChoco
{
    class ClaimSubmitter
    {
        /** Creates a new Claim Submitter object
	 *  @param theProvider the provider submitting the claim
	 *  @param theMember the member to whom the service was provided
	 */
        public ClaimSubmitter(Provider theProvider, Member theMember)
        {
            try
            {
                ui = new UserInterface();

                services = new Services();
                claims = new Claims();
                services.open();
                claims.open();

                //get the service date
                DateTime serviceDate = ui.promptForDate
                            ("Service Date (" + UserInterface.DATE_FORMAT + "): ");

                //get the correct service
                Service theService = null;
                bool correctCode = false;
                do
                {
                    //get the service code
                    string serviceCode = ui.promptForString("Service Code: ");
                    theService = services.find(serviceCode);
                    if (theService == null)
                        ui.errorMessage("Invalid code.  Please re-enter.");
                    else
                    {
                        //confirm the service
                        string answer = ui.promptForString("Service: "
                                     + theService.getName()
                                     + "  \nIs this correct? (Y)es or (N)o: ");
                        if (answer != null && answer.Length >= 1 &&
                            char.ToUpper(answer[0]) == 'Y')
                            correctCode = true;
                    }
                } while (!correctCode);


                //Create new claim.  The constructor initializes
                //the submission date and time with the system time.
                Claim aClaim = new Claim(theService.getCode(),
                             theProvider.getNumber(), theMember.getNumber(),
                             serviceDate);
                claims.add(aClaim);
                //Display success confirmation and service fee
                ui.message("Your claim has been submitted successfully.");
                ui.message("Service fee due to you: "
                    + ui.formatAsCurrency(theService.getFee()));

                services.close();
                claims.close();
            }
            catch (ArgumentException ex)
            {
                //File format is incorrect
                ui.errorMessage(ex.Message);
            }
            catch (IndexOutOfRangeException ex)
            {
                //Thrown by the constructor for the claim object.
                //This should only happen if the comments entered are too long.
                ui.errorMessage(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                //occurs if the file cannot be created
                ui.errorMessage(ex.Message);
            }

        }//default constructor

        //*******************instance variables
        private Services services;
        private Claims claims;

        private UserInterface ui;
    }
}
