using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace QLPhimService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMaHoaService" in both code and config file together.
    [ServiceContract]
    public interface IMaHoaService
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "/mahoatinydes?key={ma}&banro={banro}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        string MaHoaTinyDES(string ma, string banro);

        [OperationContract]
        [WebInvoke(UriTemplate = "/giaimatinydes?key={ma}&banma={banma}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        string GiaiMaTinyDES(string ma, string banma);

        [OperationContract]
        [WebInvoke(UriTemplate = "/mahoabaomatrsa?e={e}&N={N}&M={M}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        string MaHoaBaoMatRSA(string e, string N, string M);

        [OperationContract]
        [WebInvoke(UriTemplate = "/giaimabaomatrsa?d={d}&N={N}&C={C}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        string GiaiMaBaoMatRSA(string d, string N, string C);

        [OperationContract]
        [WebInvoke(UriTemplate = "/mahoachungthucrsa?d={d}&N={N}&M={M}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        string MaHoaChungThucRSA(string d, string N, string M);

        [OperationContract]
        [WebInvoke(UriTemplate = "/giaimachungthucrsa?e={e}&N={N}&C={C}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        string GiaiMaChungThucRSA(string e, string N, string C);
    }
}
