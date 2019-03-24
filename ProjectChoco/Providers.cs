using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectChoco
{
    class Providers : Persons
    {
        /**
	 * Creates a new empty Providers object
	 */
        public Providers()
        {
        }//default constructor

        /** Reads all the providers in the FILE_NAME text file into the collection.
         *  @throws NumberFormatException if the provider number is not a valid 
         *          integer
         *  @throws IllegalArgumentException if any of the values are invalid.
         *  @throws ArrayIndexOutOfBoundsException if there are not enough values 
         *             in the string
         */
        public void open()
        {
            //Initialize the next number if this has not already been done
            if (!(Person.getNextNumber() > 0))
                base.open();

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
        }
        /** Writes all the providers in the collection to the FILE_NAME text file.
         *  @throws FileNotFoundException if the file cannot be created
         */
        public void close()
        {
            base.close();
            saveToFile(FILE_NAME);
        }//close

        /** Searches for a provider with the given provider number in the collection.
         *  @param providerNumber the number for which to search
         *  @return the provider if found, otherwise null
         */
        public Provider find(long providerNumber)
        {
            return (Provider)search(providerNumber);
        }//find


        //******************class variable
        private static string FILE_NAME = "Providers.txt";  //default store
    }
}
