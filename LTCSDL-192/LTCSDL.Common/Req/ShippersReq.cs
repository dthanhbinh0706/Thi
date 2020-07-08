using System;
using System.Collections.Generic;
using System.Text;

namespace LTCSDL.Common.Req
{
    public class ShippersReq
    {
        public int ShipperID { get; set; }
        public string CompanyName { get; set; }
        public string? Phone { get; set; }
    }
}