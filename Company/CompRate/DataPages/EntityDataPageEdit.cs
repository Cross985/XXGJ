using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Controls;

namespace CompRate.DataPages
{
    public class CompRateDataPageEdit : DataPageEdit
    {
        public CompRateDataPageEdit()
            : base("CompRate", "cprt_CompRateID", "CompRateNewEntry")
        {
            this.CancelButton = false;
            
        }
        string compid = string.Empty;
        public override void BuildContents()
        {
            try
            {
                GetTabs("CompRate", "CompRate");
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
            //Entry comp = screen.GetEntry("cprt_companyid");
            //string compid = Dispatch.EitherField("comp_companyid");
            //if (string.IsNullOrEmpty(compid))
            //    compid = Dispatch.EitherField("key1");
            //comp.DefaultValue = compid;
            //Record cprtRec = base.FindCurrentRecord("CompRate");
            //cprtRec.SetField("cprt_companyid",compid);
            //cprtRec.SaveChanges();
            //base.AfterSave(screen);
            Dispatch.Redirect(UrlDotNet("Company", "RunCompRateList") + "&comp_companyid=" + compid + "&J=Summary");
        }
    }
}