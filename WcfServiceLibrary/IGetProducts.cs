using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Web;

namespace WcfServiceLibrary
{
    [ServiceContract]
    interface IGetProducts
    {
        [OperationContract]
        [WebInvoke(Method = "GET",ResponseFormat = WebMessageFormat.Json,
        RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "json/getProducts")]
        string getProducts();

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "json/buyProduct")]
        string buyProduct(string product_code, string sales_count);

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json,
       RequestFormat = WebMessageFormat.Json,
       BodyStyle = WebMessageBodyStyle.Wrapped,
       UriTemplate = "json/AddNewProduct")]
        string AddNewProduct(string product_name, string product_description, double product_price, int product_stock_count);

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json,
      RequestFormat = WebMessageFormat.Json,
      BodyStyle = WebMessageBodyStyle.Wrapped,
      UriTemplate = "json/UpdateProductStock")]
        string UpdateProductStock(int product_code,  int product_stock_count);

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json,
RequestFormat = WebMessageFormat.Json,
BodyStyle = WebMessageBodyStyle.Wrapped,
UriTemplate = "json/UserValidation")]
        int UserValidation(string username, string password);
    }
}
