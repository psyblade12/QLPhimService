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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "XuatChieuService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select XuatChieuService.svc or XuatChieuService.svc.cs at the Solution Explorer and start debugging.
    public class XuatChieuService : IXuatChieuService
    {
        XuatChieuLogic XuatChieuLogic = new XuatChieuLogic();
        public List<DateTime> DocNgay()
        {
            List<DateTime> kq = XuatChieuLogic.DocNgay();
            return kq;
        }

        public List<int> LayCaChieu()
        {
            List<int> kq = XuatChieuLogic.LayCaChieu();
            return kq;
        }

        public List<int> LayIDPhimTheoNgayVaGioBatDau(string ngay, string giobatdau)
        {
            DateTime ngaymuontim = Convert.ToDateTime(ngay);
            int giobatdaumuontim = Convert.ToInt32(giobatdau);
            List<int> kq = XuatChieuLogic.LayIDPhimTheoNgayVaGioBatDau(ngaymuontim, giobatdaumuontim);
            return kq;
        }
    }
}
