using System;
using System.Collections.Generic;
using System.Text;
using LTCSDL.Common.Rsp;
using LTCSDL.Common.BLL;

namespace LTCSDL.BLL
{
    using DAL;
    using DAL.Models;
    public class CategoriesSvc : GenericSvc<CategoriesRep, Categories>
    {
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }


        public override SingleRsp Update(Categories m)
        {
            var res = new SingleRsp();
            var ml = m.CategoryId > 0 ? _rep.Read(m.CategoryId) : _rep.Read(m.Description);
            if (ml == null)
            {
                res.SetError("EZ103", "No data");
            }
            else
            {
                res = base.Update(m);
                res.Data = m;
            }
            return res;
        }

        public CategoriesSvc() { }

        public object De1_1a_XuatDsNhanVienVaDoanhThuTuongUngKhiNhapDMY(DateTime date)
        {
            return _rep.De1_1a_XuatDsNhanVienVaDoanhThuTuongUngKhiNhapDMY(date);
        }

        public object De1_1a_XuatDsNhanVienVaDoanhThuTuongUngKhiNhapDMY_LinQ(DateTime date)
        {
            return _rep.De1_1a_XuatDsNhanVienVaDoanhThuTuongUngKhiNhapDMY_LinQ(date);
        }

        public object De1_1b_XuatDsNhanVienVaDoanhThuTuongUngStartEnd(DateTime startdate, DateTime enddate)
        {
            return _rep.De1_1b_XuatDsNhanVienVaDoanhThuTuongUngStartEnd(startdate, enddate);
        }

        public object De1_1b_XuatDsNhanVienVaDoanhThuTuongUngStartEnd_LinQ(DateTime startdate, DateTime enddate)
        {
            return _rep.De1_1b_XuatDsNhanVienVaDoanhThuTuongUngStartEnd_LinQ(startdate, enddate);
        }

        public object De2_1b_NhapMaDonHangXuatChiTietDonHang(string ordId)
        {
            return _rep.De2_1b_NhapMaDonHangXuatChiTietDonHang(ordId);
        }

        public object De2_1a_DsDonHangTrongStartEndPhanTrang(DateTime startdate, DateTime enddate, int page, int size)
        {
            return _rep.De2_1a_DsDonHangTrongStartEndPhanTrang(startdate, enddate, page, size);
        }



        public object getCustOrderHist(string cusId)
        {
            return _rep.getCustOrderHist(cusId);
        }

        public object getCustOrdersDetail(string ordId)
        {
            return _rep.getCustOrdersDetail(ordId);
        }

        public object getCustOrderHist_LinQ(string cusId)
        {
            return _rep.getCustOrderHist_LinQ(cusId);
        }

        public object getEmployeeRenenue(DateTime date)
        {
            return _rep.getEmployeeRenenue(date);
        }

        public object getEmployeeRenenue_LinQ(DateTime date)
        {
            return _rep.getEmployeeRenenue_LinQ(date);
        }

        public object getEmployeeRenenueWithStartEndDate(DateTime startdate, DateTime enddate)
        {
            return _rep.getEmployeeRenenueWithStartEndDate(startdate, enddate);
        }

        public object getEmployeeRenenueWithStartEndDate_LinQ(DateTime startdate, DateTime enddate)
        {
            return _rep.getEmployeeRenenueWithStartEndDate_LinQ(startdate, enddate);
        }
        ////
        ///
        public object getTimKiemTenNhanVien(string key, int page, int size, DateTime dateForm, DateTime dateTo)
        {
            return _rep.getTimKiemTenNhanVien(key, page, size, dateForm, dateTo);
        }/////

        //// Search nhan vien
        public object SearchEmployee(string keyword, int page, int size)
        {
            return _rep.SearchEmployee(keyword, page, size);
        }

        //// Search ngay sinh nhan vien
        public object SearchEmployeeWithBirthDay(int month, int page, int size)
        {
            return _rep.SearchEmployeeWithBirthDay(month, page, size);
        }



    }
}