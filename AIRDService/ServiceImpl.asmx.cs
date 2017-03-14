using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace AnimalService
{
    /// <summary>
    /// Summary description for AnimalServiceImpl
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AnimalServiceImpl : System.Web.Services.WebService, IStatisticsReportingSoap
    {
        public AuthInfo AuthInfoValue
        {
            get
            {
                return null;
            }

            set
            {
                Console.WriteLine(value);
            }
        }

        Random rand = new Random();
        public ReportingInfoResponse Add(ReportingInfo reportingInfo)
        {
            Console.WriteLine(reportingInfo);

            if(rand.NextDouble() > 0.5)
                return new ReportingInfoResponse { Reporting = reportingInfo, ErrorMessage = new ErrorMessage { Message = "Wrong server dude", Code = 101 } };
            else
                return new ReportingInfoResponse { Reporting = reportingInfo };
        }
        

        YearlyReportingInfoReponse IStatisticsReportingSoap.Finalize(YearlyReportingInfo yearlyReportingInfo)
        {
            throw new NotImplementedException();
        }
    }
}
