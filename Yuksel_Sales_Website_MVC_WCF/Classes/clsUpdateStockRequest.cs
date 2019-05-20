using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yuksel_Sales_Website_MVC_WCF.Classes
{
    public class clsUpdateStockRequest
    {
        public int product_code { get; set; }
        public int product_stock_count { get; set; }
    }
}