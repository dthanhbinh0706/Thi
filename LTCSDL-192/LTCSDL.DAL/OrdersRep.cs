using LTCSDL.Common.DAL;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;

namespace LTCSDL.DAL
{
    using Models;
    using System.Collections.Generic;
    using LTCSDL.Common.Rsp;
    public class OrdersRep : GenericRep<NorthwindContext, Orders>
    {
        #region -- Overrides --

        /// <summary>
        /// Read single object
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Return the object</returns>
        public override Orders Read(int id)
        {
            var res = All.FirstOrDefault(p => p.OrderId == id);
            return res;
        }


        /// <summary>
        /// Remove and not restore
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Number of affect</returns>
        public int Remove(int id)
        {
            var m = base.All.First(i => i.OrderId == id);
            m = base.Delete(m); //TODO
            return m.OrderId;
        }

        #endregion

        public object De7_1a_TimKiemOrderEmployeeNameTheoTuKhoaCoPhanTrang(string key, int page, int size)
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
                cmd.CommandText = "De7_1a_TimKiemOrderEmployeeNameTheoTuKhoaCoPhanTrang";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@key", key);
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
                            ShipVia = row["ShipVia"],
                            Freight = row["Freight"],
                            ShipName = row["ShipName"],
                            ShipAddress = row["ShipAddress"],
                            ShipCity = row["ShipCity"],
                            ShipRegion = row["ShipRegion"],
                            ShipPostalCode = row["ShipPostalCode"],
                            ShipCountry = row["ShipCountry"],
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

        public object De7_1c_TimKiemOrderProductNameTheoTuKhoaCoPhanTrang_LinQ(string key, int page, int size)
        {
            var ord = from o in Context.Orders
                      join od in Context.OrderDetails on o.OrderId equals od.OrderId
                      join p in Context.Products on od.ProductId equals p.ProductId

                      where p.ProductName.Contains(key)
                      select new
                      {
                          OrderID = o.OrderId,
                          CustomerID = o.CustomerId,
                          EmployeeID = o.EmployeeId,
                          OrderDate = o.OrderDate,
                          RequiredDate = o.RequiredDate,
                          ShippedDate = o.ShippedDate,
                          ShipVia = o.ShipVia,
                          Freight = o.Freight,
                          ShipName = o.ShipName,
                          ShipAddress = o.ShipAddress,
                          ShipCity = o.ShipCity,
                          ShipRegion = o.ShipRegion,
                          ShipPostalCode = o.ShipPostalCode,
                          ShipCountry = o.ShipCountry,
                          ProductName = p.ProductName,

                      };

            var offset = (page - 1) * size;
            var total = ord.Count();
            int totalpage = (total % size) == 0 ? (total / size) : (int)((total / size) + 1);
            var data = ord.OrderByDescending(x => x.OrderID).Skip(offset).Take(size).ToList();

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

        public object De7_3b_ProductKhongCoDonHangTrongNgayDoCoPhanTrang_LinQ(DateTime date, int page, int size)
        {
            var res = Context.OrderDetails
                .Join(Context.Orders, a => a.OrderId, b => b.OrderId, (a, b) => new
                {
                    a.ProductId,
                    a.OrderId,
                    b.OrderDate
                })
                .Join(Context.Products, a => a.ProductId, b => b.ProductId, (a, b) => new
                {
                    b.ProductName,
                    a.ProductId,
                    a.OrderId,
                    a.OrderDate
                })
                .Where(x => x.OrderDate.Value.Date == date.Date)
                .Select(x => new
                {
                    x.ProductName,
                    x.ProductId,
                }).Distinct().ToList();

            var data = Context.Products
            .Select(x => new
            {
                x.ProductName,
                x.ProductId,
            }).ToList().Except(res);

            var offset = (page - 1) * size;
            var total = data.Count();
            int totalpage = (total % size) == 0 ? (total / size) : (int)((total / size) + 1);
            var datas = data.Skip(offset).Take(size).ToList();

            var ress = new
            {
                data = data,
                total_record = total,
                total_page = totalpage,
                page = page,
                size = size
            };
            return ress;
        }

        public object De6_1a_TimKiemProductKhiNhapProNmCateNmCoPhanTrang(string key, int page, int size)
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
                cmd.CommandText = "De6_1a_TimKiemProductKhiNhapProNmCateNmCoPhanTrang";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@key", key);
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
                            ProductName = row["ProductName"],
                            SupplierID = row["SupplierID"],
                            CategoryID = row["CategoryID"],
                            QuantityPerUnit = row["QuantityPerUnit"],
                            UnitPrice = row["UnitPrice"],
                            UnitsInStock = row["UnitsInStock"],
                            UnitsOnOrder = row["UnitsOnOrder"],
                            ReorderLevel = row["ReorderLevel"],
                            Discontinued = row["Discontinued"],
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

        public object De6_1b_TimKiemProductKhiNhapCategoryIDCoPhanTrang(int id, int page, int size)
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
                cmd.CommandText = "De6_1b_TimKiemProductKhiNhapCategoryIDCoPhanTrang";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
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
                            ProductName = row["ProductName"],
                            SupplierID = row["SupplierID"],
                            CategoryID = row["CategoryID"],
                            QuantityPerUnit = row["QuantityPerUnit"],
                            UnitPrice = row["UnitPrice"],
                            UnitsInStock = row["UnitsInStock"],
                            UnitsOnOrder = row["UnitsOnOrder"],
                            ReorderLevel = row["ReorderLevel"],
                            Discontinued = row["Discontinued"],
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

        public object De6_1c_TimKiemProductTrongGiaMinMaxCoPhanTrang_LinQ(decimal min, decimal max, int page, int size)
        {
            var pro = from p in Context.Products
                      where p.UnitPrice >= min && p.UnitPrice <= max
                      select new
                      {
                          id = p.ProductId,
                          name = p.ProductName,
                          unit_price = p.UnitPrice
                      };

            var offset = (page - 1) * size;
            var total = pro.Count();
            int totalpage = (total % size) == 0 ? (total / size) : (int)((total / size) + 1);
            var data = pro.OrderBy(x => x.unit_price).Skip(offset).Take(size).ToList();

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

        public object De6_3b_ProductKhongCoTrongTonKhoPhanTrang(int page, int size)
        {
            var pro = from p in Context.Products
                      where p.UnitsInStock == 0
                      select new
                      {
                          id = p.ProductId,
                          name = p.ProductName,
                          unit_price = p.UnitPrice,
                          unit_in_stock = p.UnitsInStock
                      };

            var offset = (page - 1) * size;
            var total = pro.Count();
            int totalpage = (total % size) == 0 ? (total / size) : (int)((total / size) + 1);
            var data = pro.OrderBy(x => x.id).Skip(offset).Take(size).ToList();

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

        public object De5_1c_TimKiemEmployeeKhiNhapFirstLastNameTitleCoPhanTrang(string key, int page, int size)
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
                cmd.CommandText = "De5_1c_TimKiemEmployeeKhiNhapFirstLastNameTitleCoPhanTrang";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@key", key);
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
                            EmployeeID = row["EmployeeID"],
                            LastName = row["LastName"],
                            FirstName = row["FirstName"],
                            Title = row["Title"],
                            TitleOfCourtesy = row["TitleOfCourtesy"],
                            BirthDate = row["BirthDate"],
                            HireDate = row["HireDate"],
                            Address = row["Address"],
                            City = row["City"],
                            Region = row["Region"],
                            PostalCode = row["PostalCode"],
                            Country = row["Country"],
                            HomePhone = row["HomePhone"],
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

        public object De5_1c_TimKiemEmployeeKhiNhapFirstLastNameTitleCoPhanTrang_LinQ(string keyword, int page, int size)
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

        public object De5_3b_TimKiemNVNgaySinhTrongThangKhiNhapThangSinh_LinQ(int month, int page, int size)
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

        public object De4_3a_TimKiemSupplierKhiNhapCompanyNameCountryCoPhanTrang_LinQ(string keyword, int page, int size)
        {

            var empl = from e in Context.Suppliers
                       where e.CompanyName.Contains(keyword.ToString()) ||
                             e.Country.Contains(keyword.ToString()) 
                       select new
                       {
                           id = e.SupplierId,
                           company_Name = e.CompanyName,
                           contact_Name = e.ContactName,
                           contact_Title = e.ContactTitle,
                           address = e.Address,
                           city = e.City,
                           region = e.Region,
                           postal_Code = e.PostalCode,
                           country = e.Country,
                           phone = e.Phone,
                           fax = e.Fax,
                           home_Page = e.HomePage,
                           

                       };

            var offset = (page - 1) * size;
            var total = empl.Count();
            int totalpage = (total % size) == 0 ? (total / size) : (int)((total / size) + 1);
            var data = empl.OrderBy(x => x.id).Skip(offset).Take(size).ToList();

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
