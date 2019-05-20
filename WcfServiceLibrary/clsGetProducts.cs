using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace WcfServiceLibrary
{
    class clsGetProducts : IGetProducts
    {
        //This method calling all products with a quantity greater than 0 
        public string getProducts()
        {
            List<Products> productList = new List<Products>();
            try
            {

                using (var context = new SalesDBEntities())
                {
                    var products = from p in context.Products
                                   where p.product_stock_count > 0
                                   orderby p.product_code descending
                                   select p;

                    foreach (Products product in products)
                    {
                        productList.Add(product);
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return JsonConvert.SerializeObject(productList);
        }

        //service checks the stocks. If it is enough, it performs sales.
        public string buyProduct(string product_code, string count)
        {
            if (product_code != "" && count != "")
            {
                try
                {
                    int prod_code = 0;
                    int prod_count = 0;
                    using (var context = new SalesDBEntities())
                    {
                        prod_code = int.Parse(product_code);
                        prod_count = int.Parse(count);
                        Products product_for_update = context.Products.First(u => u.product_code == prod_code);
                        if (product_for_update.product_stock_count >= prod_count)
                        {
                            product_for_update.product_stock_count = product_for_update.product_stock_count - prod_count;
                            context.Sales.Add(new Sales { product_code = prod_code, sale_count = prod_count, sale_date = DateTime.Now });
                            context.SaveChanges();
                            return "Successful";
                        }
                        else
                        {
                            return "Error.Insufficient stock.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            else
            {
                return "Error. Request Paremeters Are Invalid.";
            }
        }

        //Singular add product
        public string AddNewProduct(string prod_name, string prod_description, double prod_price, int prod_stock_count)
        {
            if (prod_name != "" && prod_description != "" && prod_price > 0 && prod_stock_count > 0)
            {
                try
                {
                    using (var context = new SalesDBEntities())
                    {
                        context.Products.Add(new Products { product_name = prod_name, product_description = prod_description, product_price = prod_price, product_stock_count = prod_stock_count });
                        context.SaveChanges();
                    }
                    return "Success";
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            else
            {
                return "Error. Request Paremeters Are Invalid.";
            }
        }

        public string UpdateProductStock(int product_code, int product_stock_count)
        {
            if (product_code > 0 && product_stock_count > 0)
            {
                try
                {
                    using (var context = new SalesDBEntities())
                    {
                        Products product_for_update = context.Products.First(u => u.product_code == product_code);
                        product_for_update.product_stock_count = product_stock_count;
                        context.SaveChanges();
                    }
                    return "Success";
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            else
            {
                return "Error. Request Paremeters Are Invalid.";
            }
        }

        public int UserValidation(string username, string password)
        {
            if (username != "" && password != "")
            {
                try
                {
                    using (var context = new SalesDBEntities())
                    {
                        var users = from p in context.Users
                                    where p.username == username && p.password == password
                                    select p;

                        if (users.Count() > 0)
                        {
                            return users.FirstOrDefault().user_id;
                        }
                        else { return -1; }
                    }
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }
    }
}
