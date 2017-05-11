using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using QLPhimBDO;
using QLPhimLogic;

namespace QLPhimService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "NguoiDungService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select NguoiDungService.svc or NguoiDungService.svc.cs at the Solution Explorer and start debugging.
    public class NguoiDungService : INguoiDungService
    {
        NguoiDungLogic NguoiDungLogic = new NguoiDungLogic();

        public List<NguoiDungContract> DocTatCa()
        {
            List<NguoiDungContract> kq = NguoiDungLogic.DocTatCa().Select(x => new NguoiDungContract { NguoiDungID = x.NguoiDungID, Ten = x.Ten, MatKhau = x.MatKhau, NhomNguoiDungID = x.NhomNguoiDungID}).ToList();
            return kq;
        }

        public string ThemNguoiDung(NguoiDungContract nguoidung)
        {
            NguoiDungBDO nguoidungsethem = ChuyenContractThanhBDO(nguoidung);
            string ketqua = NguoiDungLogic.ThemNguoiDung(nguoidungsethem);
            return ketqua;
        }

        public string SuaNguoiDung(NguoiDungContract nguoidung)
        {
            NguoiDungBDO nguoidungsesua = ChuyenContractThanhBDO(nguoidung);
            string ketqua = NguoiDungLogic.SuaNguoiDung(nguoidungsesua);
            return ketqua;
        }

        public NguoiDungBDO ChuyenContractThanhBDO (NguoiDungContract nguoidung)
        {
            NguoiDungBDO kq = new NguoiDungBDO { NguoiDungID = nguoidung.NguoiDungID, MatKhau = nguoidung.MatKhau, Ten = nguoidung.Ten, NhomNguoiDungID = nguoidung.NhomNguoiDungID };
            return kq;
        }

        public string XoaNguoiDung(string ma)
        {
            int mamuonxoa = Convert.ToInt32(ma);
            string ketqua = NguoiDungLogic.XoaNguoiDung(mamuonxoa);
            return ketqua;
        }

        public bool DangNhap(string ten, string ma)
        {
            bool dangnhap = NguoiDungLogic.DangNhap(ten, ma);
            return dangnhap;
            //if(dangnhap == true)
            //{
            //    return "Đăng nhập thành công.";
            //}
            //else
            //{
            //    return "Đăng nhập thất bại.";
            //}
        }
    }
}
