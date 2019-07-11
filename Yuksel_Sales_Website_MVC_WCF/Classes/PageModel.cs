using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace Yuksel_Sales_Website_MVC_WCF.Models
{
    public abstract class PageModel<T> where T : class
    {
        public int Page { get; set; }

        public int Total { get; set; }

        public int PageSize { get; set; }

        public IPagedList<T> PageListModel { get; set; }

        abstract public PageModel<T> Paging(int? Page, int PageSize);
    }

    public class ProductPage : PageModel<Products>
    {
        public override PageModel<Products> Paging(int? Page, int PageSize)
        {
            SalesDBEntities db = new SalesDBEntities();

            this.Page = Page ?? 1;
            this.PageSize = PageSize;

            this.Total = db.Products.Count();

            this.PageListModel = db.Products.OrderBy(a => a.product_code).ToPagedList(this.Page, this.PageSize);

            return this;
        }
    }

    public class CategoryPage : PageModel<ProductCategory>
    {
        public override PageModel<ProductCategory> Paging(int? Page, int PageSize)
        {
            SalesDBEntities db = new SalesDBEntities();

            this.Page = Page ?? 1;
            this.PageSize = PageSize;

            this.Total = db.ProductCategory.Count();

            this.PageListModel = db.ProductCategory.OrderBy(a => a.CategoryID).ToPagedList(this.Page, this.PageSize);

            return this;
        }
    }
}