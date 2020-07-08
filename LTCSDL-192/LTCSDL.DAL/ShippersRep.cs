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

    public class ShippersRep : GenericRep<NorthwindContext, Shippers>
    {
        #region -- Overrides --
        public override Shippers Read(int id)
        {
            var res = All.FirstOrDefault(s => s.ShipperId == id);
            return res;
        }
        #endregion

        public SingleRsp De4_2_Them1RecrdShipperTraVeRecrdDaThem_LinQ(Shippers ship)
        {
            var res = new SingleRsp();
            using (var context = new NorthwindContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Shippers.Add(ship);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }

        public SingleRsp De4_2_CapNhat1RecrdShipperTraVeRecrdDaThem_LinQ(Shippers ship)
        {
            var res = new SingleRsp();
            using (var context = new NorthwindContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Shippers.Update(ship);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }

        public bool De4_2_Xoa1RecrdShipperTheoShipperId_LinQ(int Id)
        {
            Shippers ship = Context.Shippers.FirstOrDefault(x => x.ShipperId == Id);
            if (ship == null) return false;
            Context.Shippers.Remove(ship);
            Context.SaveChangesAsync();
            return true;
        }

        public object De4_2_Them1RecrdShipperTraVeRecrdDaThem(string companyname, string phone)
        {
            List<object> res = new List<object>();
            var cmn = (SqlConnection)Context.Database.GetDbConnection();
            if (cmn.State == ConnectionState.Closed)
                cmn.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                var cmt = cmn.CreateCommand();
                cmt.CommandText = "De4_2_Them1RecrdShipperTraVeRecrdDaThem";
                cmt.CommandType = CommandType.StoredProcedure;
                cmt.Parameters.AddWithValue("@CompanyName", companyname);
                cmt.Parameters.AddWithValue("@Phone", phone);
                da.SelectCommand = cmt;
                da.Fill(ds);
                //kiem tra
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var x = new
                        {
                            ShipperID = row["ShipperID"],
                            CompanyName = row["CompanyName"],
                            Phone = row["Phone"]
                        };
                        res.Add(x);
                    }

                }

            }
            catch (Exception e)
            {
                res = null;
            }
            return res;
        }

        public object De3_1c_NhapThangNamXuatDoanhThuTheoQuocGia_LinQ(int month, int year)
        {
            var res = Context.Orders
                     .Join(Context.OrderDetails, a => a.OrderId, b => b.OrderId, (a, b) => new
                     {
                         a.ShipCountry,
                         a.OrderDate,
                         Revenue = (b.Quantity * (1 - (decimal)b.Discount) * b.UnitPrice)
                     }).Where(x => x.OrderDate.Value.Month == month && x.OrderDate.Value.Year == year)
                       .ToList();

            var data = res.GroupBy(x => x.ShipCountry).Select(x => new
            {
                ShipCountry = x.First().ShipCountry,
                Revenue = x.Sum(x => x.Revenue)
            });
            return data;
        }

        //Get 10 Product ban chay theo doanh thu va so luong
        public object De3_1b_Top10SPBanChay(int month, int year, int x)
        {
            List<object> res = new List<object>();
            var cmn = (SqlConnection)Context.Database.GetDbConnection();
            if (cmn.State == ConnectionState.Closed)
                cmn.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                var cmt = cmn.CreateCommand();
                cmt.CommandText = "De3_1b_Top10SPBanChay";
                cmt.CommandType = CommandType.StoredProcedure;
                cmt.Parameters.AddWithValue("@month", month);
                cmt.Parameters.AddWithValue("@year", year);
                cmt.Parameters.AddWithValue("@x", x);
                da.SelectCommand = cmt;
                da.Fill(ds);
                //kiem tra
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        if (x == 0)
                        {
                            var z = new
                            {
                                ProductID = row["ProductID"],
                                ProductName = row["ProductName"],
                                quantity = row["quantity"],
                            };
                            res.Add(z);
                        }
                        else
                        {
                            var z = new
                            {
                                ProductID = row["ProductID"],
                                ProductName = row["ProductName"],
                                revenue = row["revenue"],
                            };
                            res.Add(z);
                        }
                    }

                }

            }
            catch (Exception e)
            {
                res = null;
            }
            return res;
        }

    }
}