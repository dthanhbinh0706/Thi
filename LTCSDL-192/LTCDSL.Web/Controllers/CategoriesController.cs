using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LTCSDL.Web.Controllers
{
    using BLL;
    using DAL.Models;
    using Common.Req;
    using Common.Rsp;


    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        public CategoriesController()
        {
            _svc = new CategoriesSvc();
        }

        [HttpGet("De1_1a_XuatDsNhanVienVaDoanhThuTuongUngKhiNhapDMY")]
        public IActionResult De1_1a_XuatDsNhanVienVaDoanhThuTuongUngKhiNhapDMY(DateTime date)
        {
            var res = _svc.De1_1a_XuatDsNhanVienVaDoanhThuTuongUngKhiNhapDMY(date);
            return Ok(res);
        }

        [HttpGet("De1_1a_XuatDsNhanVienVaDoanhThuTuongUngKhiNhapDMY_LinQ")]
        public IActionResult De1_1a_XuatDsNhanVienVaDoanhThuTuongUngKhiNhapDMY_LinQ(DateTime date)
        {
            var res = _svc.De1_1a_XuatDsNhanVienVaDoanhThuTuongUngKhiNhapDMY_LinQ(date);
            return Ok(res);
        }

        [HttpPost("De1_1b_XuatDsNhanVienVaDoanhThuTuongUngStartEnd")]
        public IActionResult De1_1b_XuatDsNhanVienVaDoanhThuTuongUngStartEnd([FromBody]RevenueReq req)
        {
            var res = new SingleRsp();
            res.Data = _svc.De1_1b_XuatDsNhanVienVaDoanhThuTuongUngStartEnd(req.startdate, req.enddate);
            return Ok(res);
        }

        [HttpPost("De1_1b_XuatDsNhanVienVaDoanhThuTuongUngStartEnd_LinQ")]
        public IActionResult De1_1b_XuatDsNhanVienVaDoanhThuTuongUngStartEnd_LinQ([FromBody]RevenueReq req)
        {
            var res = new SingleRsp();
            res.Data = _svc.De1_1b_XuatDsNhanVienVaDoanhThuTuongUngStartEnd_LinQ(req.startdate, req.enddate);
            return Ok(res);
        }

        [HttpPost("De2_1b_NhapMaDonHangXuatChiTietDonHang")]
        public IActionResult De2_1b_NhapMaDonHangXuatChiTietDonHang(string ordId)
        {
            var res = new SingleRsp();
            res.Data = _svc.De2_1b_NhapMaDonHangXuatChiTietDonHang(ordId);
            return Ok(res);
        }

        [HttpPost("De2_1a_DsDonHangTrongStartEndPhanTrang")]
        public IActionResult De2_1a_DsDonHangTrongStartEndPhanTrang(DateTime startdate, DateTime enddate, int page, int size)
        {
            var res = new SingleRsp();
            res.Data = _svc.De2_1a_DsDonHangTrongStartEndPhanTrang(startdate, enddate, page, size);
            return Ok(res);
        }


        [HttpPost("get-by-id")]
        public IActionResult getCategoryById([FromBody]SimpleReq req)
        {
            var res = new SingleRsp();
            res = _svc.Read(req.Id);
            return Ok(res);
        }

        [HttpPost("get-all")]
        public IActionResult getAllCategories()
        {
            var res = new SingleRsp();
            res.Data = _svc.All;
            return Ok(res);
        }

        [HttpPost("get-count-orderid")]
        public IActionResult getCustOrderHist([FromBody]SimpleReq req)
        {
            var res = new SingleRsp();
            res.Data = _svc.getCustOrderHist(req.Keyword);
            return Ok(res);
        }

        [HttpPost("get-count-orderid-LinQ")]
        public IActionResult getCustOrderHist_LinQ([FromBody]SimpleReq req)
        {
            var res = new SingleRsp();
            res.Data = _svc.getCustOrderHist_LinQ(req.Keyword);
            return Ok(res);
        }

        [HttpPost("get-order-detail")]
        public IActionResult getCustOrdersDetail([FromBody]SimpleReq req)
        {
            var res = new SingleRsp();
            res.Data = _svc.getCustOrdersDetail(req.Keyword);
            return Ok(res);
        }

        [HttpPost("get-emplyee-revenue")]
        public IActionResult getEmployeeRenenue([FromBody]RevenueReq req)
        {
            var res = new SingleRsp();
            res.Data = _svc.getEmployeeRenenue(req.startdate);
            return Ok(res);
        }

        [HttpGet("gerevenue-employee")]
        public IActionResult getEmployeeRenenue1(DateTime date)
        {
            var res = _svc.getEmployeeRenenue(date);
            return Ok(res);
        }

        [HttpGet("get-emplyee-revenue-linq")]
        public IActionResult getEmployeeRenenue_LinQ(DateTime date)
        {
            var res = _svc.getEmployeeRenenue_LinQ(date);
            return Ok(res);
        }

        [HttpPost("get-emplyee-revenue-with-star-end")]
        public IActionResult getEmployeeRenenueWithStartEndDate([FromBody]RevenueReq req)
        {
            var res = new SingleRsp();
            res.Data = _svc.getEmployeeRenenueWithStartEndDate(req.startdate, req.enddate);
            return Ok(res);
        }


        [HttpPost("get-emplyee-revenue-with-star-end-linq")]
        public IActionResult getEmployeeRenenueWithStartEndDate_LinQ([FromBody]RevenueReq req)
        {
            var res = new SingleRsp();
            res.Data = _svc.getEmployeeRenenueWithStartEndDate_LinQ(req.startdate, req.enddate);
            return Ok(res);
        }


        [HttpGet("search-employees")]
        public IActionResult SearchEmployee(string keyword, int page, int size)
        {
            var res = _svc.SearchEmployee(keyword, page, size);
            return Ok(res);
        }

        [HttpGet("search-employees-with-month-in-birthday")]
        public IActionResult SearchEmployeeWithBirthDay(int month, int page, int size)
        {
            var res = _svc.SearchEmployeeWithBirthDay(month, page, size);
            return Ok(res);
        }


        private readonly CategoriesSvc _svc;
    }
}