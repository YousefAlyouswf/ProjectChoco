using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectChoco
{
    class Members : Persons
    {
        /** Creates a new empty Members object.
   */
        public Members()
        {
        }//constructor


        /** Reads all the members in text file FILE_NAME into the collection.
         *  @throws NumberFormatException if the member number is not a valid 
         *          integer
         *  @throws IllegalArgumentException if any of the values are invalid.
         *  @throws ArrayIndexOutOfBoundsException if there are not enough values 
         *          in the string
         */
        public void open()
        {
            //open persons collection if not already open
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
        }//open

        /** Writes all the members in the collection to the text file FILE_NAME.
         *  @throws FileNotFoundException if the file cannot be created
         */
        public void close()
        {
            base.close();
            saveToFile(FILE_NAME);
        }//close

        /** Searches for a member with the given member number in the collection.
         *  @param memberNumber the number for which to search
         *  @return the member if found, otherwise null
         */
        public Member find(long memberNumber)
        {
            return (Member)search(memberNumber);
        }//find
         //********************class variable
        private static string FILE_NAME = "Members.txt";  //default collection
    }
}
