using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectChoco
{
    class ProviderDirectory
    {
        /**
	 * Creates a new ProviderDirectory
	 */
        public ProviderDirectory()
        {
            string title = "Provider Directory";

            string.Format("%31s %n%n", title);
            string.Format("%-25s %-6s   %8s %n", "Service Name", "Code", "Fee");
            string.Format("%-25s %-6s   %8s %n", "------------", "----", "---");

        }//default constructor

        /** Adds a line of detail about a service
         *  @param name the name of the service
         *  @param code the code of the service
         *  @param fee the fee payable for the service
         */
        public void addDetail(string name, string code, double fee)
        {
            string.Format("%-25s %-6s   %8s %n", name, code, fee);
        }//addDetail

        internal void addErrorMessage(object p)
        {
            throw new NotImplementedException();
        }
    }
}
