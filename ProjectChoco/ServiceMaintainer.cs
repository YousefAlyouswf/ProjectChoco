﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectChoco
{
    class ServiceMaintainer
    {
        /**
	 * Creates a new ServiceMaintainer control object
	 */
        public ServiceMaintainer()
        {
            try
            {
                //Create and open the service collection
                services = new Services();
                services.open();

                //Create a user interface and set up menu
                ui = new UserInterface();
               string menuText = "1.\tAdd a New Service\n" +
                              "2.\tEdit a Service\n" +
                              "3.\tDelete a Service\n" +
                              "4.\tQuit\n";

                int choice;
                do
                {
                    ui.message("\t\t\tMaintain Services\n\n");
                    choice = ui.menu(menuText);  //display menu and get choice
                    switch (choice)
                    {
                        case 1: addService(); break;
                        case 2: editService(); break;
                        case 3: deleteService(); break;
                        case 4: break;
                        default: ui.errorMessage("Invalid choice.  Please re-enter."); break;
                    }
                } while (choice != 4);

                //close the service collection 
                services.close();
            }
            catch (FormatException ex)  //Error in file format
            {
                ui.errorMessage(ex.Message);
                return;
            }
            catch (FileNotFoundException ex)
            {
                //occurs if the file cannot be created
                ui.errorMessage(ex.Message);
            }
        }//default constructor

        // Allows the user to add a new service to the collection
        private void addService()
        {
            try
            {
                ui.message("\tAdd a service\n\n");

                //Create a new default service.
                Service newService = new Service();

                //get attribute values
                //false means no old values to retain
                updateService(ui, newService, false);

                //Add to collection
                services.add(newService);

                //Display the service
                ui.message("New service details: \n");
                ui.message(newService.toFormattedString() + "\n");
            }
            catch (FormatException ex)
            {
                //occurs if the service code is already in use
                ui.errorMessage(ex.Message);
            }
        }//addService

        // Allows the user to update an existing service's details
        private void editService()
        {
            ui.message("\tEdit a service\n\n");

            //get service code
           string code = ui.promptForString("Service code: ");

            //search for service in collection
            Service aService = services.find(code);

            if (aService != null)
            {
                //display service
                ui.message("Current Service Details: \n"
                    + aService.toFormattedString());

                //get updated service attributes
                //true means retain an old value if a new one is not provided
                ui.message("\nEnter the new details.  "
                                + "Press Enter for values that are correct:\n");
                updateService(ui, aService, true);

                //update the service in the collection
                services.update(aService);

                //display updated service
                ui.message("Updated Service details:");
                ui.message(aService.toFormattedString());
            }
            else ui.errorMessage("Service code " + code + " cannot be found.\n");
        }//editService


        //  Allows the user to delete an existing service
        private void deleteService()
        {
            ui.message("\tDelete a service\n\n");

            //get service code
           string code = ui.promptForString("Service code: ");

            //search for service in collection
            Service aService = services.find(code);
            if (aService != null)
            {
                //display service
                ui.message("Current Service Details: \n"
                    + aService.toFormattedString());

                //get confirmation of deletion
               string answer = ui.promptForString
                  ("\nAre you sure you want to delete this service? (Y)es or (N)o: ");
                if (answer != null && answer.Length >= 1)
                    if (Char.ToUpper(answer[0]) == 'Y')
                    {

                        //delete service from collection
                        services.delete(code);

                        //display acknowledgment
                        ui.message("The service has been deleted.\n");
                    }
                    else ui.message("The service has not been deleted.\n");
                else ui.message("The service has not been deleted.\n");
            }
            else
                ui.errorMessage("Service code " + code + " cannot be found.");

        }//deleteService

        //Utility method to get user input and update attributes of a service
        private void updateService(UserInterface ui, Service aService, Boolean retainOldValue)
        {
            try
            {
               string input;

                //Get value for code if it has not already been set
                if (aService.getCode() == null)  //code may not be changed
                {
                    input = ui.promptForString("Code: ");
                    aService.setCode(input);
                }

                //get value for name
                input = ui.promptForString("Name: ");
                if (input.Length == 0 && retainOldValue)
                    aService.setName(aService.getName());    //ensure valid name
                else aService.setName(input);

                //get value for fee
                double fee;
                if (retainOldValue)
                    fee = ui.promptForDouble("Fee: ", aService.getFee());
                else fee = ui.promptForDouble("Fee: ");
                aService.setFee(fee);
            }
            catch (FormatException ex)
            {
                ui.errorMessage(ex.Message);
                ui.message("Current details:");
                ui.message(aService.toFormattedString());
                ui.message("\nPlease repeat input.  "
                    + "Press Enter for details that are correct.");
                updateService(ui, aService, true);    //Give the user another chance
            }
        }//updateService

        //**************instance variables
        private UserInterface ui;
        private Services services;

        //********************************************************************
        /**
         * Runs the ServiceMaintainer independently of the rest of the system.
         * @param args not used
         */
        static void Main(String[] args)
        {
            try
            {
                new ServiceMaintainer();
            }
            catch (Exception ex)
            {
                UserInterface ui = new UserInterface();
                ui.message("\nEnd of test run.\n");
            }

            Console.ReadKey();
        }//main

    }
}
