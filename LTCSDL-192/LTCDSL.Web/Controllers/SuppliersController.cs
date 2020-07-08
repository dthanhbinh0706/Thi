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
    public class SuppliersController : ControllerBase
    {
        private SuppliersSvc _svc;

        public SuppliersController()
        {
            _svc = new SuppliersSvc();
        }

        [HttpDelete("De4_3b_Xoa1RecrdSupplierTheoSupplierId_LinQ_{Id}")]
        public IActionResult De4_3b_Xoa1RecrdSupplierTheoSupplierId_LinQ(int Id)
        {
            var res = _svc.De4_3b_Xoa1RecrdSupplierTheoSupplierId_LinQ(Id);
            return Ok(res);
        }
    }
}