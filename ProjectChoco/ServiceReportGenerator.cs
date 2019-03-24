using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectChoco
{
    class ServiceReportGenerator
    {
        public ServiceReportGenerator()
        {
            try
            {
                Services services = new Services();
                services.open();

                //Create a new provider directory
                report = new ProviderDirectory();

                //Get all services
                List<Service> allServices = services.getAllOrderedByName();

                //Add all services to provider directory
                foreach (Service aService in allServices)
                    report.addDetail(aService.getName(), aService.getCode(),
                            aService.getFee());

                services.close();

            }
            catch (FileNotFoundException ex)
            {
                //occurs if the file cannot be created
                report.addErrorMessage(ex.Message);
            }
            catch (FormatException ex)
            {
                //occurs if the file format is incorrect
                report.addErrorMessage(ex.Message);
            }
        }//default constructor

        public ProviderDirectory getReport()
        {
            return report;
        }//getReport

        //********************instance variable
        private ProviderDirectory report;
    }
}
