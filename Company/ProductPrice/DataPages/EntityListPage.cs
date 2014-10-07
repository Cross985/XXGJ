using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace ProductPrice.DataPages
{
    public class ProductPriceListPage : ListPage
    {
        public ProductPriceListPage()
            : base("ProductPrice", "ProductPriceList", "ProductPriceFilterBox")
        {
            //FilterByField = "";
            //FilterByContextId = (int)Sage.KeyList.UserId;

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