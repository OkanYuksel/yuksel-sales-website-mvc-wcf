using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Yuksel_Sales_Website_MVC_WCF.Classes;
using System.Web.Script.Serialization;
namespace Yuksel_Sales_Website_MVC_WCF.Controllers
{
    public class DataController : Controller
    {
        [HttpPost]
        public string BuyProduct(int product_code, int sales_count)
        {
            string strResponse = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:38456/Service.svc/json/buyProduct");
                clsBuyProductRequest buyProductObj = new clsBuyProductRequest { product_code = product_code, sales_count = sales_count };
                string strData = Newtonsoft.Json.JsonConvert.SerializeObject(buyProductObj);
                request.Method = "PUT";
                request.ContentType = "application/json";
                request.ContentLength = strData.Length;
                using (Stream webStream = request.GetRequestStream())
                using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
                {
                    requestWriter.Write(strData);
                }
                WebResponse webResponse = request.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
                using (StreamReader responseReader = new StreamReader(webStream))
                {
                    strResponse = responseReader.ReadToEnd();
                    Console.Out.WriteLine(strResponse);
                }
            }
            catch (Exception ex)
            {
                strResponse = ex.ToString();
                Console.Out.WriteLine("-----------------");
                Console.Out.WriteLine(ex.Message);
            }

            return strResponse;
        }

        [HttpPost]
        public RandomMessage AddNewProduct(string product_name, string product_description, double product_price, int product_stock_count)
        {
            try
            {
                Product product = new Product { product_name = product_name, product_description = product_description, product_price = product_price, product_stock_count = product_stock_count };
                string strData = Newtonsoft.Json.JsonConvert.SerializeObject(product);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:38456/Service.svc/json/AddNewProduct");
                request.Method = "PUT";
                request.ContentType = "application/json";
                request.ContentLength = strData.Length;
                using (Stream webStream = request.GetRequestStream())
                using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
                {
                    requestWriter.Write(strData);
                }
                WebResponse webResponse = request.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
                using (StreamReader responseReader = new StreamReader(webStream))
                {
                    string response = responseReader.ReadToEnd();
                    Console.Out.WriteLine(response);
                }
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("-----------------");
                Console.Out.WriteLine(ex.Message);
            }

            return new RandomMessage { Message = "Successful" };
        }


        [HttpPost]
        public ActionResult UpdateProductStock(int product_code, int product_stock_count)
        {
            try
            {
            clsUpdateStockRequest requestDataObj = new clsUpdateStockRequest { product_code = product_code, product_stock_count = product_stock_count };
            string strData = Newtonsoft.Json.JsonConvert.SerializeObject(requestDataObj);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:38456/Service.svc/json/UpdateProduct");
            request.Method = "PUT";
            request.ContentType = "application/json";
            request.ContentLength = strData.Length;
            using (Stream webStream = request.GetRequestStream())
            using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
            {
                requestWriter.Write(strData);
            }

                WebResponse webResponse = request.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
                using (StreamReader responseReader = new StreamReader(webStream))
                {
                    string response = responseReader.ReadToEnd();
                    Console.Out.WriteLine(response);
                }
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("-----------------");
                Console.Out.WriteLine(ex.Message);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public int UserValidation(string username, string password)
        {
            int user_id = -1;
            try
            {
            clsUserValidationResponse response = new clsUserValidationResponse();
            clsUserValidationRequest userObj = new clsUserValidationRequest { username = username, password = password };
            string strData = Newtonsoft.Json.JsonConvert.SerializeObject(userObj);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:38456/Service.svc/json/UserValidation");
            request.Method = "PUT";
            request.ContentType = "application/json";
            request.ContentLength = strData.Length;
            using (Stream webStream = request.GetRequestStream())
            using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
            {
                requestWriter.Write(strData);
            }

                WebResponse webResponse = request.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
                using (StreamReader responseReader = new StreamReader(webStream))
                {
                    response = Newtonsoft.Json.JsonConvert.DeserializeObject<clsUserValidationResponse>(responseReader.ReadToEnd());
                }
                user_id = response.UserValidationResult;
            }
            catch (Exception ex)
            {
                user_id = -1;
                Console.Out.WriteLine("-----------------");
                Console.Out.WriteLine(ex.Message);
            }
            if (user_id > 0)
            {
                Session["user_id"] = user_id;
            }
            return user_id;
        }
    }
}