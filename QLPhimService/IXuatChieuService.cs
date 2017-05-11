using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace QLPhimService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IXuatChieuService" in both code and config file together.
    [ServiceContract]
    public interface IXuatChieuService
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "/docngay", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        List<DateTime> DocNgay();

        [OperationContract]
        [WebInvoke(UriTemplate = "/laycachieu", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        List<int> LayCaChieu();

        [OperationContract]
        [WebInvoke(UriTemplate = "/tim?ngay={ngay}&giobatbatdau={giobatdau}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        List<int> LayIDPhimTheoNgayVaGioBatDau(string ngay, string giobatdau);
    }
    public class XuatChieuContract
    {
        public int XuatChieuID { get; set; }
        public System.DateTime Ngay { get; set; }
        public int LichChieuID { get; set; }
        public int CaChieuID { get; set; }
        public int PhongID { get; set; }
        public int PhimID { get; set; }
    }
}
