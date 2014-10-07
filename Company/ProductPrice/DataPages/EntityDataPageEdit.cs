using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Controls;

namespace ProductPrice.DataPages
{
    public class ProductPriceDataPageEdit : DataPageEdit
    {
        public ProductPriceDataPageEdit()
            : base("ProductPrice", "prpi_ProductPriceID", "ProductPriceNewEntry")
        {
            this.CancelButton = false;
            
        }
        string compid = string.Empty;
        public override void BuildContents()
        {
            try
            {
                GetTabs("ProductPrice", "ProductPrice");
                /* Add your code here */
                compid = Dispatch.EitherField("comp_companyid");
                if (string.IsNullOrEmpty(compid))
                    compid = Dispatch.EitherField("key1");
                /* Add your code here */
                base.BuildContents();

                AddUrlButton("Cancel", "Cancel.gif", UrlDotNet("Company", "RunDataPage") + "&comp_companyid=" + compid);

               
            }
            catch (Exception error)
            {
                this.AddError(error.Message);
            }
        }
        public override void AfterSave(EntryGroup screen)
        {
            //Entry comp = screen.GetEntry("prpi_companyid");
            //string compid = Dispatch.EitherField("comp_companyid");
            //if (string.IsNullOrEmpty(compid))
            //    compid = Dispatch.EitherField("key1");
            //comp.DefaultValue = compid;
            //Record prpiRec = base.FindCurrentRecord("ProductPrice");
            //prpiRec.SetField("prpi_companyid",compid);
            //prpiRec.SaveChanges();
            //base.AfterSave(screen);
            Dispatch.Redirect(UrlDotNet("Company", "RunProductPriceList") + "&comp_companyid=" + compid + "&J=Summary");
        }
    }
}