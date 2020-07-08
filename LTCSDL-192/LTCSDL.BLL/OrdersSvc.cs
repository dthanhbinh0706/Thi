using Newtonsoft.Json;
using LTCSDL.BLL;
using LTCSDL.Common.Rsp;
using LTCSDL.Common.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
namespace LTCSDL.BLL
{
    using DAL;
    using DAL.Models;

    public class OrdersSvc : GenericSvc<OrdersRep, Orders>
    {
        #region -- Overrides --

        /// <summary>
        /// Read single object
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Return the object</returns>
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="m">The model</param>
        /// <returns>Return the result</returns>
        public override SingleRsp Update(Orders m)
        {
            var res = new SingleRsp();

            var m1 = m.OrderId > 0 ? _rep.Read(m.OrderId) : _rep.Read(m.OrderId);
            if (m1 == null)
            {
                res.SetError("EZ103", "No data.");
            }
            else
            {
                res = base.Update(m);
                res.Data = m;
            }

            return res;
        }
        #endregion
        public OrdersSvc() { }

        public object De7_1a_TimKiemOrderEmployeeNameTheoTuKhoaCoPhanTrang(string key, int page, int size)
        {
            return _rep.De7_1a_TimKiemOrderEmployeeNameTheoTuKhoaCoPhanTrang(key, page, size);
        }

        public object De7_1c_TimKiemOrderProductNameTheoTuKhoaCoPhanTrang_LinQ(string key, int page, int size)
        {
            return _rep.De7_1c_TimKiemOrderProductNameTheoTuKhoaCoPhanTrang_LinQ(key, page, size);
        }

        public object De7_3b_ProductKhongCoDonHangTrongNgayDoCoPhanTrang_LinQ(DateTime date, int page, int size)
        {
            return _rep.De7_3b_ProductKhongCoDonHangTrongNgayDoCoPhanTrang_LinQ(date, page, size);
        }

        public object De6_1a_TimKiemProductKhiNhapProNmCateNmCoPhanTrang(string key, int page, int size)
        {
            return _rep.De6_1a_TimKiemProductKhiNhapProNmCateNmCoPhanTrang(key, page, size);
        }

        public object De6_1b_TimKiemProductKhiNhapCategoryIDCoPhanTrang(int id, int page, int size)
        {
            return _rep.De6_1b_TimKiemProductKhiNhapCategoryIDCoPhanTrang(id, page, size);
        }

        public object De6_1c_TimKiemProductTrongGiaMinMaxCoPhanTrang_LinQ(decimal min, decimal max, int page, int size)
        {
            return _rep.De6_1c_TimKiemProductTrongGiaMinMaxCoPhanTrang_LinQ(min, max, page, size);
        }

        public object De6_3b_ProductKhongCoTrongTonKhoPhanTrang(int page, int size)
        {
            return _rep.De6_3b_ProductKhongCoTrongTonKhoPhanTrang(page, size);
        }

        public object De5_1c_TimKiemEmployeeKhiNhapFirstLastNameTitleCoPhanTrang(string key, int page, int size)
        {
            return _rep.De5_1c_TimKiemEmployeeKhiNhapFirstLastNameTitleCoPhanTrang(key, page, size);
        }

        public object De5_1c_TimKiemEmployeeKhiNhapFirstLastNameTitleCoPhanTrang_LinQ(string keyword, int page, int size)
        {
            return _rep.De5_1c_TimKiemEmployeeKhiNhapFirstLastNameTitleCoPhanTrang_LinQ(keyword, page, size);
        }

        public object De5_3b_TimKiemNVNgaySinhTrongThangKhiNhapThangSinh_LinQ(int month, int page, int size)
        {
            return _rep.De5_3b_TimKiemNVNgaySinhTrongThangKhiNhapThangSinh_LinQ(month, page, size);
        }

        public object De4_3a_TimKiemSupplierKhiNhapCompanyNameCountryCoPhanTrang_LinQ(string keyword, int page, int size)
        {
            return _rep.De4_3a_TimKiemSupplierKhiNhapCompanyNameCountryCoPhanTrang_LinQ(keyword, page, size);
        }


    }


}
