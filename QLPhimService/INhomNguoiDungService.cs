using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace QLPhimService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "INhomNguoiDungService" in both code and config file together.
    [ServiceContract]
    public interface INhomNguoiDungService
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "/laynhomnguoidung", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        List<NhomNguoiDungContract> LayNhomNguoiDung();
    }

    [DataContract]
    public class NhomNguoiDungContract
    {
        [DataMember]
        public int NhomNguoiDungID { get; set; }
        [DataMember]
        public string Ten { get; set; }
        [DataMember]
        public string MaSo { get; set; }
    }
}
