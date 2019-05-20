using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yuksel_Sales_Website_MVC_WCF.Classes
{
    public class Product
    {
        public string product_name { get; set; }
        public string product_description { get; set; }
        public double product_price { get; set; }
        public int product_stock_count { get; set; }
    }
}