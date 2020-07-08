using System;
using System.Collections.Generic;
using System.Text;
using LTCSDL.Common.DAL;
using System.Linq;

namespace LTCSDL.DAL
{
    using LTCSDL.Common.Rsp;
    using LTCSDL.DAL.Models;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using System.Data;

    public class SuppliersRep : GenericRep<NorthwindContext, Suppliers>
    {
        #region -- Overrides --
        public override Suppliers Read(int id)
        {
            var res = All.FirstOrDefault(s => s.SupplierId == id);
            return res;
        }
        #endregion

        public bool De4_3b_Xoa1RecrdSupplierTheoSupplierId_LinQ(int Id)
        {
            Suppliers ship = Context.Suppliers.FirstOrDefault(x => x.SupplierId == Id);
            if (ship == null) return false;
            Context.Suppliers.Remove(ship);
            Context.SaveChangesAsync();
            return true;
        }
    }
}
