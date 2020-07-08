using System;
using System.Collections.Generic;
using System.Text;
using LTCSDL.Common.Rsp;
using LTCSDL.Common.BLL;


namespace LTCSDL.BLL
{
    using DAL;
    using DAL.Models;
    using LTCSDL.Common.Req;

    public class ShippersSvc : GenericSvc<ShippersRep, Shippers>
    {
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }

        public object De4_2_Them1RecrdShipperTraVeRecrdDaThem(string companyname, string phone)
        {
            return _rep.De4_2_Them1RecrdShipperTraVeRecrdDaThem(companyname, phone);
        }
        public SingleRsp De4_2_Them1RecrdShipperTraVeRecrdDaThem_LinQ(ShippersReq ship)
        {
            var res = new SingleRsp();
            Shippers shipper = new Shippers();
            shipper.ShipperId = ship.ShipperID;
            shipper.CompanyName = ship.CompanyName;
            shipper.Phone = ship.Phone;
            res = _rep.De4_2_Them1RecrdShipperTraVeRecrdDaThem_LinQ(shipper);

            return res;
        }

        public SingleRsp De4_2_CapNhat1RecrdShipperTraVeRecrdDaThem_LinQ(ShippersReq ship)
        {
            var res = new SingleRsp();
            Shippers shipper = new Shippers();
            shipper.ShipperId = ship.ShipperID;
            shipper.CompanyName = ship.CompanyName;
            shipper.Phone = ship.Phone;
            res = _rep.De4_2_CapNhat1RecrdShipperTraVeRecrdDaThem_LinQ(shipper);

            return res;
        }

        public object De4_2_Xoa1RecrdShipperTheoShipperId_LinQ(int Id)
        {
            return _rep.De4_2_Xoa1RecrdShipperTheoShipperId_LinQ(Id);
        }

        public object De3_1c_NhapThangNamXuatDoanhThuTheoQuocGia_LinQ(int month, int year)
        {
            return _rep.De3_1c_NhapThangNamXuatDoanhThuTheoQuocGia_LinQ(month, year);
        }

        public object De3_1b_Top10SPBanChay(int month, int year, int x)
        {
            return _rep.De3_1b_Top10SPBanChay(month, year, x);
        }

        public ShippersSvc() { }
    }
}