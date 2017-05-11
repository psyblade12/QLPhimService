using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

namespace QLPhimService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPhimService" in both code and config file together.
    [ServiceContract]
    public interface IPhimService
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "/doctatca", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        List<PhimContract> DocTatCa();

        [OperationContract]
        [WebInvoke(UriTemplate = "/doctheoma/{ma}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        PhimContract DocTheoMa(string Ma);

        [OperationContract]
        [WebInvoke(UriTemplate = "/timtheotheloai?theloai={theloai}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        List<PhimContract> TimTheoTheLoai(string Theloai);

        [OperationContract]
        [WebInvoke(UriTemplate = "/themphim", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        string ThemPhim(PhimContract phimmuonthem);

        [OperationContract]
        [WebInvoke(UriTemplate = "/suaphim", Method = "PUT", ResponseFormat = WebMessageFormat.Json)]
        string SuaPhim(PhimContract phimmuonsua);

        [OperationContract]
        [WebInvoke(UriTemplate = "/xoaphim/{ma}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)]
        string XoaPhim(string Ma);

        [OperationContract]
        [WebInvoke(UriTemplate = "/layphimmoi/{soluong}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        List<PhimContract> LayPhimMoi(string Soluong);

        [OperationContract]
        [WebInvoke(UriTemplate = "/laytheloai", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        List<string> LayTheLoai();
    }
    [DataContract]
    public class PhimContract
    {
        [DataMember]
        public int PhimID { get; set; }
        [DataMember]
        public string Ten { get; set; }
        [DataMember]
        public string DaoDien { get; set; }
        [DataMember]
        public string DienVien { get; set; }
        [DataMember]
        public string TheLoai { get; set; }
        [DataMember]
        public string PhienBan { get; set; }
        [DataMember]
        public string HangPhim { get; set; }
        [DataMember]
        public string NuocSanXuat { get; set; }
        [DataMember]
        public int DoDai { get; set; }
        [DataMember]
        public string Poster { get; set; }
        [DataMember]
        public string GioiThieu { get; set; }
        [DataMember]
        public string Trailer { get; set; }
        [DataMember]
        public string Pdf { get; set; }
        string Authority = HttpContext.Current.Request.Url.Authority;
        [DataMember]
        public string PosterURL
        {
            set { }
            get
            {
                string ApplicationPath = HttpContext.Current.Request.ApplicationPath;
                if (ApplicationPath.Length > 1)
                {
                    ApplicationPath = ApplicationPath + "/";
                }
                string posterthemvaoduongdan;
                if (Poster == null)
                {
                    posterthemvaoduongdan = "noPoster.jpg";
                }
                else
                {
                    posterthemvaoduongdan = Poster;
                }
                string url = string.Format("http://{0}{1}Posters/{2}", Authority, ApplicationPath, posterthemvaoduongdan);
                return url;
            }
        }
        [DataMember]
        public string pdfURL
        {
            set { }
            get
            {
                string ApplicationPath = HttpContext.Current.Request.ApplicationPath;
                if (ApplicationPath.Length > 1) ApplicationPath += "/";
                string url = string.Format("http://{0}{1}PDFs/{2}", Authority, ApplicationPath, (Pdf == null) ? "noPDF.pdf" : Pdf);
                return url;
            }
        }
        [DataMember]
        public string TrailerURL
        {
            set { }
            get
            {
                string url = "";
                string ApplicationPath = HttpContext.Current.Request.ApplicationPath;
                if (ApplicationPath.Length > 1) ApplicationPath += "/";
                if (Trailer != null)
                    url = string.Format("http://{0}{1}Trailers/{2}", Authority, ApplicationPath, Trailer);
                return url;
            }
        }
    }
}
