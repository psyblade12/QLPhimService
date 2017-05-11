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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PhimService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PhimService.svc or PhimService.svc.cs at the Solution Explorer and start debugging.
    public class PhimService : IPhimService
    {
        PhimLogic PhimLogic = new PhimLogic();
        public List<PhimContract> DocTatCa()
        {
            List<PhimContract> kq = PhimLogic.DocTatCa().Select(x=>new PhimContract {PhimID = x.PhimID, Ten = x.Ten, NuocSanXuat = x.NuocSanXuat, DaoDien =x.DaoDien, DienVien = x.DienVien, DoDai = x.DoDai, GioiThieu = x.GioiThieu, HangPhim =x.HangPhim, Pdf = x.PDF, PhienBan = x.PhienBan, Poster = x.Poster, TheLoai = x.TheLoai, Trailer = x.Trailer }).ToList();
            return kq;
        }

        public PhimContract DocTheoMa(string Ma)
        {
            int idphimmuontim = Convert.ToInt32(Ma);
            PhimBDO kqtimduoc = PhimLogic.DocTheoMa(idphimmuontim);
            PhimContract kqtrave = new PhimContract() {PhimID = kqtimduoc.PhimID, Ten = kqtimduoc.Ten, DaoDien = kqtimduoc.DaoDien, DienVien = kqtimduoc.DienVien, DoDai = kqtimduoc.DoDai, GioiThieu = kqtimduoc.GioiThieu, HangPhim = kqtimduoc.HangPhim, NuocSanXuat = kqtimduoc.NuocSanXuat, Pdf = kqtimduoc.PDF, PhienBan = kqtimduoc.PhienBan, Poster = kqtimduoc.Poster, TheLoai = kqtimduoc.TheLoai, Trailer = kqtimduoc.Trailer };
            return kqtrave;
        }

        public List<PhimContract> TimTheoTheLoai(string Theloai)
        {
            List<PhimContract> dsketquatimduoc = PhimLogic.TimTheoTheLoai(Theloai).Select(x => new PhimContract { PhimID = x.PhimID, Ten = x.Ten, DaoDien = x.DaoDien, DienVien = x.DienVien, DoDai = x.DoDai, GioiThieu = x.GioiThieu, HangPhim = x.HangPhim, NuocSanXuat = x.NuocSanXuat, Pdf = x.PDF, PhienBan = x.PhienBan, Poster = x.Poster, TheLoai = x.TheLoai, Trailer = x.Trailer }).ToList();
            return dsketquatimduoc;
        }
        public List<PhimContract> LayPhimMoi(string Soluong)
        {
            int soluongmuonlay = Convert.ToInt32(Soluong);
            List<PhimContract> kq = PhimLogic.DocPhimMoi(soluongmuonlay).Select(x=> new PhimContract { PhimID = x.PhimID, Ten = x.Ten, NuocSanXuat = x.NuocSanXuat, DaoDien = x.DaoDien, DienVien = x.DienVien, DoDai = x.DoDai, GioiThieu = x.GioiThieu, HangPhim = x.HangPhim, Pdf = x.PDF, PhienBan = x.PhienBan, Poster = x.Poster, TheLoai = x.TheLoai, Trailer = x.Trailer }).ToList();
            return kq;
        }
        public List<string> LayTheLoai()
        {
            List<string> kq = PhimLogic.DocTheLoai();
            return kq;
        }

        public string ThemPhim(PhimContract phimmuonthem)
        {
            PhimBDO phimsethem = ChuyenTuContractSangDBO(phimmuonthem);
            string stringketqua = PhimLogic.ThemPhim(phimsethem);
            return stringketqua;
        }

        public string SuaPhim(PhimContract phimmuonsua)
        {
            PhimBDO phimsesua = ChuyenTuContractSangDBO(phimmuonsua);
            string stringketqua = PhimLogic.SuaPhim(phimsesua);
            return stringketqua;
        }

        public string XoaPhim(string Ma)
        {
            int masomuonxoa = Convert.ToInt32(Ma);
            string ketqua = PhimLogic.XoaPhim(masomuonxoa);
            return ketqua;
        }

        public PhimBDO ChuyenTuContractSangDBO(PhimContract phim)
        {
            PhimBDO kq = new PhimBDO { PhimID = phim.PhimID, Ten = phim.Ten, DaoDien = phim.DaoDien, DienVien = phim.DienVien, DoDai = phim.DoDai, GioiThieu = phim.GioiThieu, HangPhim = phim.HangPhim, NuocSanXuat = phim.NuocSanXuat, PDF = phim.Pdf, PhienBan = phim.PhienBan, Poster = phim.Poster, TheLoai = phim.TheLoai, Trailer = phim.Trailer };
            return kq;
        }
    }
}
