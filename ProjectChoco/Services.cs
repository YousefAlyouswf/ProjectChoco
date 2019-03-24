using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjectChoco
{
    class Services
    {
        /**
	 * Creates a new empty Services object
	 */
        public Services()
        {
            List<Service> serviceList = new List<Service>();
        }//default constructor

        public void open()
        {
            
            try

            {
                StreamReader reader = new StreamReader(FILE_NAME);
                string inFile = reader.ReadToEnd();
                Console.WriteLine(inFile);

               
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }//open

        /** Writes all the services in the collection to the FILE_NAME text file.
	 *  @throws FileNotFoundException if the file cannot be created
	 */
        public void close()
        {
            StreamReader outFile = new StreamReader(FILE_NAME);
            foreach (Service aService in serviceList)
                outFile.ReadLine();
            outFile.Close();
        }//close

        /** Searches for a service with the given service code in the collection.
         *  @param serviceCode the code for which to search
         *  @return the service if found, otherwise null
         */
        public Service find(string serviceCode)
        {
            foreach (Service aService in serviceList)
                if (aService.getCode() == (serviceCode))
                    return aService;

            return null;
        }//search

        /** Adds the given service to the collection.
         *  Services are stored in alphabetical order of service name to facilitate
         *  Provider Directory (Service Report) generation.
         *  @param aService the service to be added
         *  @throws IllegalArgumentException if the code of the service to be added
         *				is not unique.
         */
        public void add(Service aService)
        {
            Service tempService = find(aService.getCode());
            if (tempService != null) throw new ArgumentException
                        ("A service with this code already exists");
            for (int i = 0; i < serviceList.Count; i++)
            {
                if (aService.getName().CompareTo(serviceList[i].getName()) < 0)
                {
                    serviceList.Add(aService);
                    return;
                }
            }
            //add to end of list
            serviceList.Add(aService);
        }//add

        /** Updates the given service in the collection.
         *  @param aService the service to be updated
         */
        public void update(Service aService)
        {
            //if the name of the service has been changed, the list may no longer be
            //in alphabetical order.  Thus, delete the service from the list
            //and add it again.
            delete(aService.getCode());
            add(aService);
        }//update

        /** Deletes the service with the given service number from the collection
         *  @param serviceCode the code of the service to delete
         */
        public void delete(string serviceCode)
        {
            for (int i = 0; i < serviceList.Count; i++)
                if (serviceList[i].getCode() == (serviceCode))
                {
                    serviceList.RemoveAt(i);
                    return;
                }
        }//delete

        /** Returns all the services in the collection
         *  @return all the services
         */
        public List<Service> getAllOrderedByName()
        {
            return serviceList;
        }//getAllOrderedByName


        //***************instance variable	
        private List<Service> serviceList; //the collection of services

        //***************class variable 
        private static string FILE_NAME = "Services.txt";
    }
}
