using System;
using System.Collections.Generic;
using System.Text;
using LTCSDL.Common.DAL;
using System.Linq;

namespace LTCSDL.DAL
{
    using LTCSDL.DAL.Models;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using System.Data;

    public class CategoriesRep : GenericRep<NorthwindContext, Categories>
    {
        #region -- Overrides --
        public override Categories Read(int id)
        {
            var res = All.FirstOrDefault(p => p.CategoryId == id);
            return res;
        }

        public int Remove(int id)
        {
            var m = base.All.First(i => i.CategoryId == id);
            m = base.Delete(m); //TODO
            return m.CategoryId;
        }
        #endregion

        public object De1_1a_XuatDsNhanVienVaDoanhThuTuongUngKhiNhapDMY(DateTime date)
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
                cmt.CommandText = "De1_1a_XuatDsNhanVienVaDoanhThuTuongUngKhiNhapDMY";
                cmt.CommandType = CommandType.StoredProcedure;
                cmt.Parameters.AddWithValue("@date", date);
                da.SelectCommand = cmt;
                da.Fill(ds);
                //kiem tra
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var x = new
                        {
                            EmployeeID = row["EmployeeID"],
                            LastName = row["LastName"],
                            FirstName = row["FirstName"],
                            Revenue = row["Revenue"]

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

        public object De1_1a_XuatDsNhanVienVaDoanhThuTuongUngKhiNhapDMY_LinQ(DateTime date)
        {
            var res = Context.Orders
                .Join(Context.OrderDetails, a => a.OrderId, b => b.OrderId, (a, b) => new
                {
                    a.OrderDate,
                    a.EmployeeId,
                    Revenue = b.Quantity * (1 - (decimal)b.Discount) * b.UnitPrice

                })
                .Join(Context.Employees, a => a.EmployeeId, b => b.EmployeeId, (a, b) => new
                {
                    a.OrderDate,
                    a.EmployeeId,
                    a.Revenue,
                    b.FirstName,
                    b.LastName
                }).Where(x => x.OrderDate.Value.Date == date.Date).ToList();

            var data = res.GroupBy(x => x.EmployeeId).Select(
                x => new
                {
                    x.First().EmployeeId,
                    x.First().FirstName,
                    x.First().LastName,
                    Revenue = x.Sum(x => x.Revenue)
                });
            return data;
        }

        public object De1_1b_XuatDsNhanVienVaDoanhThuTuongUngStartEnd(DateTime startdate, DateTime enddate)
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
                cmt.CommandText = "De1_1b_XuatDsNhanVienVaDoanhThuTuongUngStartEnd";
                cmt.CommandType = CommandType.StoredProcedure;
                cmt.Parameters.AddWithValue("@start", startdate);
                cmt.Parameters.AddWithValue("@end", enddate);
                da.SelectCommand = cmt;
                da.Fill(ds);
                //kiem tra
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var x = new
                        {
                            LastName = row["LastName"],
                            FirstName = row["FirstName"],
                            Revenue = row["Revenue"]
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

        public object De1_1b_XuatDsNhanVienVaDoanhThuTuongUngStartEnd_LinQ(DateTime startdate, DateTime enddate)
        {
            var res = Context.Orders
                .Join(Context.OrderDetails, a => a.OrderId, b => b.OrderId, (a, b) => new
                {
                    a.OrderDate,
                    a.EmployeeId,
                    Revenue = b.Quantity * (1 - (decimal)b.Discount) * b.UnitPrice

                })
                .Join(Context.Employees, a => a.EmployeeId, b => b.EmployeeId, (a, b) => new
                {
                    a.OrderDate,
                    a.EmployeeId,
                    a.Revenue,
                    b.FirstName,
                    b.LastName
                }).Where(x => x.OrderDate.Value.Date >= startdate.Date && x.OrderDate.Value.Date <= enddate.Date).ToList();

            var data = res.GroupBy(x => x.EmployeeId).Select(
                x => new
                {
                    x.First().EmployeeId,
                    x.First().FirstName,
                    x.First().LastName,
                    Revenue = x.Sum(x => x.Revenue)
                });
            return data;
        }

        public object De2_1b_NhapMaDonHangXuatChiTietDonHang(string ordId)
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
                cmt.CommandText = "De2_1b_NhapMaDonHangXuatChiTietDonHang";
                cmt.CommandType = CommandType.StoredProcedure;
                cmt.Parameters.AddWithValue("@OrderID", ordId);
                da.SelectCommand = cmt;
                da.Fill(ds);
                //kiem tra
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var x = new
                        {
                            OrderID = row["OrderID"],
                            CustomerID = row["CustomerID"],
                            EmployeeID = row["EmployeeID"],
                            OrderDate = row["OrderDate"],
                            RequiredDate = row["RequiredDate"]

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

        


        public object De2_1a_DsDonHangTrongStartEndPhanTrang(DateTime startdate, DateTime enddate, int page, int size)
        {
            List<object> res = new List<object>();
            var cnn = (SqlConnection)Context.Database.GetDbConnection();
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                var cmd = cnn.CreateCommand();
                cmd.CommandText = "De2_1a_DsDonHangTrongStartEndPhanTrang";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@startdate", startdate);
                cmd.Parameters.AddWithValue("@enddate", enddate);
                cmd.Parameters.AddWithValue("@page", page);
                cmd.Parameters.AddWithValue("@size", size);
                da.SelectCommand = cmd;
                da.Fill(ds);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var x = new
                        {
                            OrderID = row["OrderID"],
                            CustomerID = row["CustomerID"],
                            EmployeeID = row["EmployeeID"],
                            OrderDate = row["OrderDate"],
                            RequiredDate = row["RequiredDate"],
                            ShippedDate = row["ShippedDate"],
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



        //31/5
        public object getCustOrderHist(string cusId)
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
                cmt.CommandText = "CustOrderHist";
                cmt.CommandType = CommandType.StoredProcedure;
                cmt.Parameters.AddWithValue("@CustomerID", cusId);
                da.SelectCommand = cmt;
                da.Fill(ds);
                //kiem tra
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var x = new
                        {
                            ProductName = row["ProductName"],
                            Total = row["Total"]
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


        public object getCustOrdersDetail(string ordId)
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
                cmt.CommandText = "CustOrdersDetail";
                cmt.CommandType = CommandType.StoredProcedure;
                cmt.Parameters.AddWithValue("@OrderID", ordId);
                da.SelectCommand = cmt;
                da.Fill(ds);
                //kiem tra
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var x = new
                        {
                            ProductName = row["ProductName"],
                            UnitPrice = row["UnitPrice"],
                            Quantity = row["Quantity"],
                            Discount = row["Discount"],
                            ExtendedPrice = row["ExtendedPrice"]

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



        public object getCustOrderHist_LinQ(string CusId)
        {
            var res = Context.Products
                .Join(Context.OrderDetails, a => a.ProductId, b => b.ProductId, (a, b) => new
                {
                    a.ProductId,
                    a.ProductName,
                    b.Quantity,
                    b.OrderId
                })
                .Join(Context.Orders, a => a.OrderId, b => b.OrderId, (a, b) => new
                {
                    a.ProductId,
                    a.ProductName,
                    a.Quantity,
                    a.OrderId,
                    b.CustomerId
                }).Where(x => x.CustomerId == CusId).ToList();

            var data = res.GroupBy(x => x.ProductName).Select(x => new
            {
                ProductName = x.First().ProductName,
                ProductId = x.First().ProductId,
                CustomerId = x.First().CustomerId,
                Total = x.Sum(p => p.Quantity)
            });
            return data;
        }


        public object getEmployeeRenenue(DateTime date)
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
                cmt.CommandText = "spSel_GetEmployeeRevenue";
                cmt.CommandType = CommandType.StoredProcedure;
                cmt.Parameters.AddWithValue("@date", date);
                da.SelectCommand = cmt;
                da.Fill(ds);
                //kiem tra
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var x = new
                        {
                            EmployeeID = row["EmployeeID"],
                            LastName = row["LastName"],
                            FirstName = row["FirstName"],
                            Revenue = row["Revenue"]
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


        public object getEmployeeRenenueWithStartEndDate(DateTime startdate, DateTime enddate)
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
                cmt.CommandText = "spSelGetEmployeeRenenueWithStartEndDate";
                cmt.CommandType = CommandType.StoredProcedure;
                cmt.Parameters.AddWithValue("@start", startdate);
                cmt.Parameters.AddWithValue("@end", enddate);
                da.SelectCommand = cmt;
                da.Fill(ds);
                //kiem tra
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var x = new
                        {
                            EmployeeID = row["EmployeeID"],
                            LastName = row["LastName"],
                            FirstName = row["FirstName"],
                            Revenue = row["Revenue"]
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

        public object getEmployeeRenenue_LinQ(DateTime date)
        {
            var res = Context.Orders
                .Join(Context.OrderDetails, a => a.OrderId, b => b.OrderId, (a, b) => new
                {
                    a.OrderDate,
                    a.EmployeeId,
                    Revenue = b.Quantity * (1 - (decimal)b.Discount) * b.UnitPrice

                })
                .Join(Context.Employees, a => a.EmployeeId, b => b.EmployeeId, (a, b) => new
                {
                    a.OrderDate,
                    a.EmployeeId,
                    a.Revenue,
                    b.FirstName,
                    b.LastName
                }).Where(x => x.OrderDate.Value.Date == date.Date).ToList();

            var data = res.GroupBy(x => x.EmployeeId).Select(
                x => new
                {
                    x.First().EmployeeId,
                    x.First().FirstName,
                    x.First().LastName,
                    Revenue = x.Sum(x => x.Revenue)
                });
            return data;
        }

        //public object getEmployeeRenenue_LinQ2(DateTime date)
        //{
        //    var empl = from e in Context.Employees
        //               join o in Context.Orders on e.EmployeeId equals o.EmployeeId
        //               join od in Context.OrderDetails on o.OrderId equals od.OrderId
        //               where o.OrderDate.Value.Date == date.Date

        //               select new 
        //               { 
        //                   id = e.EmployeeId,
        //                   firstname= e.FirstName,
        //                   lastname = e.LastName,
        //                   date = o.OrderDate,
        //                   Revenue = od.Quantity * (1 - (decimal)od.Discount) * od.UnitPrice
        //               };

        //    var data = empl.GroupBy(x => x.id).ToDictionary(x => x.Key, x => x.Select(x => x.firstname));



        //    return data;
        //}

        public object getEmployeeRenenueWithStartEndDate_LinQ(DateTime startdate, DateTime enddate)
        {
            var res = Context.Orders
                .Join(Context.OrderDetails, a => a.OrderId, b => b.OrderId, (a, b) => new
                {
                    a.OrderDate,
                    a.EmployeeId,
                    Revenue = b.Quantity * (1 - (decimal)b.Discount) * b.UnitPrice

                })
                .Join(Context.Employees, a => a.EmployeeId, b => b.EmployeeId, (a, b) => new
                {
                    a.OrderDate,
                    a.EmployeeId,
                    a.Revenue,
                    b.FirstName,
                    b.LastName
                }).Where(x => x.OrderDate.Value.Date >= startdate.Date && x.OrderDate.Value.Date <= enddate.Date).ToList();

            var data = res.GroupBy(x => x.EmployeeId).Select(
                x => new
                {
                    x.First().EmployeeId,
                    x.First().FirstName,
                    x.First().LastName,
                    Revenue = x.Sum(x => x.Revenue)
                });
            return data;
        }

        public object getTimKiemTenNhanVien(string key, int page, int size, DateTime dateForm, DateTime dateTo)
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
                cmt.CommandText = "spSel_TimKiemTenNhanVien";
                cmt.CommandType = CommandType.StoredProcedure;
                cmt.Parameters.AddWithValue("@key", key);
                cmt.Parameters.AddWithValue("@page", page);
                cmt.Parameters.AddWithValue("@size", size);
                cmt.Parameters.AddWithValue("@dateForm", dateForm);
                cmt.Parameters.AddWithValue("@dateTo", dateTo);
                da.SelectCommand = cmt;
                da.Fill(ds);
                //kiem tra
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var x = new
                        {
                            OrderID = row["OrderID"],
                            CustomerID = row["CustomerID"],

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

        //dde 5 cau 3a tim kiem nhan vien theo ten va title LinQ
        public object SearchEmployee(string keyword, int page, int size)
        {

            var empl = from e in Context.Employees
                       where e.LastName.Contains(keyword.ToString()) ||
                             e.FirstName.Contains(keyword.ToString()) ||
                             e.Title.Contains(keyword.ToString())
                       select new
                       {
                           id = e.EmployeeId,
                           first_name = e.FirstName,
                           last_name = e.LastName,
                           title = e.Title,
                           title_of_cour = e.TitleOfCourtesy,
                           birth_day = e.BirthDate,
                           hire_day = e.HireDate,
                           address = e.Address,
                           city = e.City,
                           region = e.Region,
                           postle_code = e.PostalCode,
                           country = e.Country,
                           home_phone = e.HomePhone,
                           extension = e.Extension,
                           notes = e.Notes,
                           reports_to = e.ReportsTo,

                       };

            var offset = (page - 1) * size;
            var total = empl.Count();
            int totalpage = (total % size) == 0 ? (total / size) : (int)((total / size) + 1);
            var data = empl.OrderBy(x => x.first_name).Skip(offset).Take(size).ToList();

            var res = new
            {
                data = data,
                total_record = total,
                total_page = totalpage,
                page = page,
                size = size
            };
            return res;
        }


        //dde 5 cau 3b tim kiem nhan vien theo ten va title LinQ
        public object SearchEmployeeWithBirthDay(int month, int page, int size)
        {
            var empl = from e in Context.Employees
                       where e.BirthDate.Value.Month == month
                       select new
                       {
                           id = e.EmployeeId,
                           first_name = e.FirstName,
                           last_name = e.LastName,
                           title = e.Title,
                           title_of_cour = e.TitleOfCourtesy,
                           birth_day = e.BirthDate,
                           hire_day = e.HireDate,
                           address = e.Address,
                           city = e.City,
                           region = e.Region,
                           postle_code = e.PostalCode,
                           country = e.Country,
                           home_phone = e.HomePhone,
                           extension = e.Extension,
                           notes = e.Notes,
                           reports_to = e.ReportsTo,
                       };
            var offset = (page - 1) * size;
            var total = empl.Count();
            int totalpage = (total % size) == 0 ? (total / size) : (int)((total / size) + 1);
            var data = empl.OrderBy(x => x.first_name).Skip(offset).Take(size).ToList();
            var res = new
            {
                data = data,
                total_record = total,
                total_page = totalpage,
                page = page,
                size = size
            };
            return res;
        }


    }
}