using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLibrary
{
   public class Product
    {
        [Key]
        private int product_code = -1;
        private string product_name = "Sample Product";
        private string product_description = "This product has been generated for sample purposes.";
        private double product_price = 0;

        public int ProductCode
        {
            get
            {
                return product_code;
            }
            set
            {
                product_code = value;
            }
        }

        public string ProductName
        {
            get
            {
                return product_name;
            }
            set
            {
                product_name = value;
            }
        }


        public string ProductDescription
        {
            get
            {
                return product_description;
            }
            set
            {
                product_description = value;
            }
        }

        public double ProductPrice
        {
            get
            {
                return product_price;
            }
            set
            {
                product_price = value;
            }
        }


    }
}
