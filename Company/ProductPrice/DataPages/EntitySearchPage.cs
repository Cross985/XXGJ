using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace ProductPrice.DataPages
{
    public class ProductPriceSearchPage : SearchPage
    {
        public ProductPriceSearchPage()
            : base("ProductPriceSearchBox", "ProductPriceGrid")
        {
        }
    }
}