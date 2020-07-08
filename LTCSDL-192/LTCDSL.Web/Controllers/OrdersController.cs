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
    using System.Collections.Generic;
    //using BLL.Req;
    using Common.Rsp;
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        public OrdersController()
        {
            _svc = new OrdersSvc();
        }
        private readonly OrdersSvc _svc;

        [HttpGet("De7_1a_TimKiemOrderEmployeeNameTheoTuKhoaCoPhanTrang")]
        public IActionResult De7_1a_TimKiemOrderEmployeeNameTheoTuKhoaCoPhanTrang(string key, int page, int size)
        {
            var res = new SingleRsp();
            res.Data = _svc.De7_1a_TimKiemOrderEmployeeNameTheoTuKhoaCoPhanTrang(key, page, size);
            return Ok(res);
        }

        [HttpGet("De7_1c_TimKiemOrderProductNameTheoTuKhoaCoPhanTrang_LinQ")]
        public IActionResult De7_1c_TimKiemOrderProductNameTheoTuKhoaCoPhanTrang_LinQ(string key, int page, int size)
        {
            var res = new SingleRsp();
            res.Data = _svc.De7_1c_TimKiemOrderProductNameTheoTuKhoaCoPhanTrang_LinQ(key, page, size);
            return Ok(res);
        }

        [HttpGet("De7_3b_ProductKhongCoDonHangTrongNgayDoCoPhanTrang_LinQ")]
        public IActionResult De7_3b_ProductKhongCoDonHangTrongNgayDoCoPhanTrang_LinQ(DateTime date, int page, int size)
        {
            var res = new SingleRsp();
            res.Data = _svc.De7_3b_ProductKhongCoDonHangTrongNgayDoCoPhanTrang_LinQ(date, page, size);
            return Ok(res);
        }

        [HttpGet("De6_1a_TimKiemProductKhiNhapProNmCateNmCoPhanTrang")]
        public IActionResult De6_1a_TimKiemProductKhiNhapProNmCateNmCoPhanTrang(string key, int page, int size)
        {
            var res = new SingleRsp();
            res.Data = _svc.De6_1a_TimKiemProductKhiNhapProNmCateNmCoPhanTrang(key, page, size);
            return Ok(res);
        }

        [HttpGet("De6_1b_TimKiemProductKhiNhapCategoryIDCoPhanTrang")]
        public IActionResult De6_1b_TimKiemProductKhiNhapCategoryIDCoPhanTrang(int id, int page, int size)
        {
            var res = new SingleRsp();
            res.Data = _svc.De6_1b_TimKiemProductKhiNhapCategoryIDCoPhanTrang(id, page, size);
            return Ok(res);
        }

        [HttpGet("De6_1c_TimKiemProductTrongGiaMinMaxCoPhanTrang_LinQ")]
        public IActionResult De6_1c_TimKiemProductTrongGiaMinMaxCoPhanTrang_LinQ(decimal min, decimal max, int page, int size)
        {
            var res = new SingleRsp();
            res.Data = _svc.De6_1c_TimKiemProductTrongGiaMinMaxCoPhanTrang_LinQ(min, max, page, size);
            return Ok(res);
        }

        [HttpGet("De6_3b_ProductKhongCoTrongTonKhoPhanTrang")]
        public IActionResult De6_3b_ProductKhongCoTrongTonKhoPhanTrang(int page, int size)
        {
            var res = _svc.De6_3b_ProductKhongCoTrongTonKhoPhanTrang(page, size);
            return Ok(res);
        }

        [HttpGet("De5_1c_TimKiemEmployeeKhiNhapFirstLastNameTitleCoPhanTrang")]
        public IActionResult De5_1c_TimKiemEmployeeKhiNhapFirstLastNameTitleCoPhanTrang(string key, int page, int size)
        {
            var res = new SingleRsp();
            res.Data = _svc.De5_1c_TimKiemEmployeeKhiNhapFirstLastNameTitleCoPhanTrang(key, page, size);
            return Ok(res);
        }

        [HttpGet("De5_1c_TimKiemEmployeeKhiNhapFirstLastNameTitleCoPhanTrang_LinQ")]
        public IActionResult De5_1c_TimKiemEmployeeKhiNhapFirstLastNameTitleCoPhanTrang_LinQ(string keyword, int page, int size)
        {
            var res = new SingleRsp();
            res.Data = _svc.De5_1c_TimKiemEmployeeKhiNhapFirstLastNameTitleCoPhanTrang_LinQ(keyword, page, size);
            return Ok(res);
        }

        [HttpGet("De5_3b_TimKiemNVNgaySinhTrongThangKhiNhapThangSinh_LinQ")]
        public IActionResult De5_3b_TimKiemNVNgaySinhTrongThangKhiNhapThangSinh_LinQ(int month, int page, int size)
        {
            var res = new SingleRsp();
            res.Data = _svc.De5_3b_TimKiemNVNgaySinhTrongThangKhiNhapThangSinh_LinQ(month, page, size);
            return Ok(res);
        }

        [HttpGet("De4_3a_TimKiemSupplierKhiNhapCompanyNameCountryCoPhanTrang_LinQ")]
        public IActionResult De4_3a_TimKiemSupplierKhiNhapCompanyNameCountryCoPhanTrang_LinQ(string keyword, int page, int size)
        {
            var res = new SingleRsp();
            res.Data = _svc.De4_3a_TimKiemSupplierKhiNhapCompanyNameCountryCoPhanTrang_LinQ(keyword, page, size);
            return Ok(res);
        }
    }

}
