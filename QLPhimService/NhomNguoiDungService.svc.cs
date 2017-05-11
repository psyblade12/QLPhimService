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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "NhomNguoiDungService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select NhomNguoiDungService.svc or NhomNguoiDungService.svc.cs at the Solution Explorer and start debugging.
    public class NhomNguoiDungService : INhomNguoiDungService
    {
        NhomNguoiDungLogic NhomNguoiDungLogic = new NhomNguoiDungLogic();
        public List<NhomNguoiDungContract> LayNhomNguoiDung()
        {
            List<NhomNguoiDungContract> kq = NhomNguoiDungLogic.LayNhomNguoiDung().Select(x => new NhomNguoiDungContract { NhomNguoiDungID = x.NhomNguoiDungID, Ten = x.Ten, MaSo = x.MaSo }).ToList();
            return kq;
        }
    }
}
