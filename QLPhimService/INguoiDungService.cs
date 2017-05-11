using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace QLPhimService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "INguoiDungService" in both code and config file together.
    [ServiceContract]
    public interface INguoiDungService
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "/doctatca", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        List<NguoiDungContract> DocTatCa();

        [OperationContract]
        [WebInvoke(UriTemplate = "/them", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        string ThemNguoiDung(NguoiDungContract nguoidung);

        [OperationContract]
        [WebInvoke(UriTemplate = "/sua", Method = "PUT", ResponseFormat = WebMessageFormat.Json)]
        string SuaNguoiDung(NguoiDungContract nguoidung);

        [OperationContract]
        [WebInvoke(UriTemplate = "/xoa/{ma}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)]
        string XoaNguoiDung(string ma);

        [OperationContract]
        [WebInvoke(UriTemplate = "/dangnhap?ten={ten}&ma={ma}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        bool DangNhap(string ten, string ma);
    }

    [DataContract]
    public class NguoiDungContract
    {
        [DataMember]
        public int NguoiDungID { get; set; }
        [DataMember]
        public string Ten { get; set; }
        [DataMember]
        public string MatKhau { get; set; }
        [DataMember]
        public int NhomNguoiDungID { get; set; }
    }
}
