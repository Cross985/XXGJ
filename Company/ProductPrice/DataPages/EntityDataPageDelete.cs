using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;

namespace ProductPrice.DataPages
{
    public class ProductPriceDataPageDelete : Web
    {
    //    public ProductPriceDataPageDelete()
    //        : base("ProductPrice", "prpi_ProductPriceID", "ProductPriceNewEntry")
    //    {
    //        this.CancelButton = false;
    //        this.DeleteButton = false;
    //    }
        string compid = string.Empty;
        public override void BuildContents()
        {
            try
            {
                AddContent(HTML.Form());
                string ProductPriceid = Dispatch.EitherField("prpi_ProductPriceID");
                Record rec = FindRecord("ProductPrice","prpi_ProductPriceID="+ProductPriceid );
                EntryGroup ProductPriceentry = new EntryGroup("ProductPriceNewEntry");
                ProductPriceentry.Fill(rec);
                AddTabHead("ProductPrice");
                string hMode = Dispatch.EitherField("HiddenMode");
                if (hMode == "Save")
                {
                   
                   //Record rec =  base.FindCurrentRecord("ProductPrice");
                   rec.DeleteRecord = true;
                   rec.SaveChanges();
                   Dispatch.Redirect(UrlDotNet("Company", "RunDataPage") + "&comp_companyid=" + compid);
                }
                
                            
                /* Add your code here */
                compid = Dispatch.EitherField("comp_companyid");
                if (string.IsNullOrEmpty(compid))
                    compid = Dispatch.EitherField("key1");
                /* Add your code here */
                AddContent(HTML.InputHidden("HiddenMode", ""));
                ProductPriceentry.GetHtmlInViewMode(rec);
                AddContent(ProductPriceentry);
                AddSubmitButton("确认删除", "delete.gif", "javascript:document.EntryForm.HiddenMode.value='Save';");
                AddUrlButton("Cancel", "Cancel.gif", UrlDotNet("Company", "RunDataPage") + "&comp_companyid=" + compid);

            }
            catch (Exception error)
            {
                this.AddError(error.Message);
            }
        }
       
    }
}