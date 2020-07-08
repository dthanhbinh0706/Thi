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

    public class SuppliersSvc : GenericSvc<SuppliersRep, Suppliers>
    {
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }

        public object De4_3b_Xoa1RecrdSupplierTheoSupplierId_LinQ(int Id)
        {
            return _rep.De4_3b_Xoa1RecrdSupplierTheoSupplierId_LinQ(Id);
        }

        public SuppliersSvc() { }
    }
}