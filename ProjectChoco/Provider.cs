using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectChoco
{
    class Provider : Person
    {
        public Provider() :base()
        {
            
            //no default value for type
        }//Provider default constructor

        /** Creates a provider from a string representation of the provider.
         *  @param data the string representation
        *  @throws NumberFormatException if the provider number is not a valid 
        *          integer
        *  @throws IllegalArgumentException if any of the values are invalid.
        *  @throws ArrayIndexOutOfBoundsException if there are not enough values 
        *             in the string
         */
        public Provider(string data) : base(data)
        {
        }//Provider constructor using string data


        //****************accessor method

        /** Returns the type of the provider as a single character
         *  @return the provider's type
         */
        public char getType()
        {
            return type;
        }//getType

        //****************mutator method

        /** Changes the type of the provider
         *  @param newType the new type of the provider
         *  @throws IllegalArgumentException if newType is not one of the 
         *             allowed type characters
         */
        public void setType(char newType)
        {
            if (PROVIDER_TYPES.IndexOf(newType) < 0)
                throw new ArgumentOutOfRangeException(PROVIDER_TYPE_HELP);
            type = newType;
        }//setType

        //****************utility methods

        /** Returns a string representation of the provider consisting of the values,
          *  converted to strings, of all the instance variables separated by
          *  the character SEPARATOR.
          *  @return the string representation of the provider.
          */
        public string toString()
        {
            return base.toString() + SEPARATOR + type;
        }//toString

        /** Changes all the instance variables to the values given by the string 
         *  representation of the provider.
         *  @param data the string representation of the provider
         *  @throws NumberFormatException if the provider number is 
         *             not a valid integer
         *  @throws IllegalArgumentException if any of the values are
         *             invalid.
         *  @throws IndexOutOfBoundsException if there are 
         *             not enough values in the string
         */
        public void fromString(string data)
        {
            base.fromString(data);
            setType(data[data.Length - 1]);
        }//fromString

        /** Returns a string representation of the provider in a format that is
         *  suitable for text display.
         *  @return a formatted string representation of the provider
         */
        public string toFormattedString()
        {
            return base.toFormattedString() + "\nType:           " + type;
        }//toFormattedString


        //****************instance variable
        private char type;  //The only allowable types are Dietitician (D), 
                            //Internist (I) and Exercise Specialist (E)

        //****************class variables
        private static string PROVIDER_TYPES = "DIE";
	/** Message giving the characters that are valid for the provider type
	 */
	public static string PROVIDER_TYPE_HELP = "Provider type must be "
				+ "one of the following characters: D(ietitian), "
				+ "I(nternist) or E(xercise Specialist)";
    }
}
