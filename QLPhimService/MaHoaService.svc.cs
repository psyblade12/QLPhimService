using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace QLPhimService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MaHoaService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MaHoaService.svc or MaHoaService.svc.cs at the Solution Explorer and start debugging.
    public class MaHoaService : IMaHoaService
    {
        public string MaHoaTinyDES(string ma, string banro)
        {
            try
            {
                string khoa = ma;
                char[] cackitumuonmahoa = banro.ToCharArray();
                string chuoiketqua = "";
                foreach (char s in cackitumuonmahoa)
                {
                    chuoiketqua = chuoiketqua + GiaiThuatTinyDES.MaHoaTinyDES2(s, khoa);
                }
                return chuoiketqua;
            }
            catch
            {
                return "Có lỗi xảy ra rồi.";
            }
        }

        public string GiaiMaTinyDES(string ma, string banma)
        {
            try
            {
                string khoa = ma;
                char[] cackitumuonmahoa = banma.ToCharArray();
                string chuoiketqua = "";
                foreach (char s in cackitumuonmahoa)
                {
                    chuoiketqua = chuoiketqua + GiaiThuatTinyDES.GiaiMaTinyDES2(s, khoa);
                }
                return chuoiketqua;
            }
            catch
            {
                return "Có lỗi xảy ra rồi.";
            }
        }

        public string MaHoaBaoMatRSA(string e, string N, string M)
        {
            try
            {
                string ketqua = "";
                char[] mangchar = M.ToCharArray();
                List<int> mangso = new List<int>();
                foreach (char c in mangchar)
                {
                    mangso.Add(Convert.ToInt32(c));
                }
                foreach (int i in mangso)
                {
                    int soketquagiaima = GiaiThuat.MaHoaBaoMatRSA(Convert.ToInt32(e), Convert.ToInt32(N), i);
                    char charduocmahoa = (char)soketquagiaima;
                    ketqua = ketqua + charduocmahoa;
                }
                return ketqua;
            }
            catch
            {
                return "Có lỗi xả ra";
            }
        }

        public string GiaiMaBaoMatRSA(string d, string N, string C)
        {
            try
            {
                string ketqua = "";
                char[] mangchar = C.ToCharArray();
                List<int> mangso = new List<int>();
                foreach (char c in mangchar)
                {
                    mangso.Add(Convert.ToInt32(c));
                }
                foreach (int i in mangso)
                {
                    int soketquagiaima = GiaiThuat.GiaiMaBaoMatRSA(Convert.ToInt32(d), Convert.ToInt32(N), i);
                    char charduocmahoa = (char)soketquagiaima;
                    ketqua = ketqua + charduocmahoa;
                }
                return ketqua;
            }
            catch
            {
                return "Có lỗi xảy ra.";
            }
        }

        public string MaHoaChungThucRSA(string d, string N, string M)
        {
            try
            {
                string ketqua = "";
                char[] mangchar = M.ToCharArray();
                List<int> mangso = new List<int>();
                foreach (char c in mangchar)
                {
                    mangso.Add(Convert.ToInt32(c));
                }
                foreach (int i in mangso)
                {
                    int soketquagiaima = GiaiThuat.MaHoaChungThucRSA(Convert.ToInt32(d), Convert.ToInt32(N), i);
                    char charduocmahoa = (char)soketquagiaima;
                    ketqua = ketqua + charduocmahoa;
                }
                return ketqua;
            }
            catch
            {
                return "Có lỗi xảy ra";
            }
        }

        public string GiaiMaChungThucRSA(string e, string N, string C)
        {
            try
            {
                try
                {
                    string ketqua = "";
                    char[] mangchar = C.ToCharArray();
                    List<int> mangso = new List<int>();
                    foreach (char c in mangchar)
                    {
                        mangso.Add(Convert.ToInt32(c));
                    }
                    foreach (int i in mangso)
                    {
                        int soketquagiaima = GiaiThuat.GiaiMaChungThucRSA(Convert.ToInt32(e), Convert.ToInt32(N), i);
                        char charduocmahoa = (char)soketquagiaima;
                        ketqua = ketqua + charduocmahoa;
                    }
                    return ketqua;
                }
                catch
                {
                    return "Có lỗi xảy ra.";
                }
            }
            catch
            {
                return "Có lỗi xảy ra";
            }
        }
    }
}
