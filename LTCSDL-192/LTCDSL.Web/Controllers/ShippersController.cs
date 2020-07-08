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
    public class ShippersController : ControllerBase
    {
        private ShippersSvc _svc;

        public ShippersController()
        {
            _svc = new ShippersSvc();
        }

        [HttpPost("De4_2_Them1RecrdShipperTraVeRecrdDaThem")]
        public IActionResult De4_2_Them1RecrdShipperTraVeRecrdDaThem([FromBody]ShippersReq req)
        {
            var res = _svc.De4_2_Them1RecrdShipperTraVeRecrdDaThem(req.CompanyName, req.Phone);
            return Ok(res);
        }

        [HttpPost("De4_2_Them1RecrdShipperTraVeRecrdDaThem_LinQ")]
        public IActionResult De4_2_Them1RecrdShipperTraVeRecrdDaThem_LinQ([FromBody]ShippersReq req)
        {
            var res = _svc.De4_2_Them1RecrdShipperTraVeRecrdDaThem_LinQ(req);
            return Ok(res);
        }

        [HttpPut("De4_2_CapNhat1RecrdShipperTraVeRecrdDaThem_LinQ")]
        public IActionResult De4_2_CapNhat1RecrdShipperTraVeRecrdDaThem_LinQ([FromBody]ShippersReq req)
        {
            var res = _svc.De4_2_CapNhat1RecrdShipperTraVeRecrdDaThem_LinQ(req);
            return Ok(res);
        }

        [HttpDelete("De4_2_Xoa1RecrdShipperTheoShipperId_LinQ_{Id}")]
        public IActionResult De4_2_Xoa1RecrdShipperTheoShipperId_LinQ(int Id)
        {
            var res = _svc.De4_2_Xoa1RecrdShipperTheoShipperId_LinQ(Id);
            return Ok(res);
        }
        
        [HttpGet("De3_1c_NhapThangNamXuatDoanhThuTheoQuocGia_LinQ")]
        public IActionResult De3_1c_NhapThangNamXuatDoanhThuTheoQuocGia_LinQ(int month, int year)
        {
            var res = _svc.De3_1c_NhapThangNamXuatDoanhThuTheoQuocGia_LinQ(month, year);
            return Ok(res);
        }

        [HttpGet("De3_1b_Top10SPBanChay")]
        public IActionResult De3_1b_Top10SPBanChay(int month, int year, int x)
        {
            var res = _svc.De3_1b_Top10SPBanChay(month, year, x);
            return Ok(res);
        }


        

    }
}