using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace ProductPrice.DataPages
{
    public class ProductPriceDataPage : DataPage
    {

        public ProductPriceDataPage()
            : base("ProductPrice", "prpi_ProductPriceID", "ProductPriceDetailBox")
        {
        }

        public override void BuildContents()
        {
            try
            {
                
                /* Add your code here */

                base.BuildContents();
            }
            catch (Exception error)
            {
                this.AddError(error.Message);
            }
        }
    }
}