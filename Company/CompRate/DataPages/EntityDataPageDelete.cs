using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;

namespace CompRate.DataPages
{
    public class CompRateDataPageDelete : Web
    {
    //    public CompRateDataPageDelete()
    //        : base("CompRate", "cprt_CompRateID", "CompRateNewEntry")
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
                string CompRateid = Dispatch.EitherField("cprt_CompRateID");
                Record rec = FindRecord("CompRate","cprt_CompRateID="+CompRateid );
                EntryGroup CompRateentry = new EntryGroup("CompRateNewEntry");
                CompRateentry.Fill(rec);
                AddTabHead("CompRate");
                string hMode = Dispatch.EitherField("HiddenMode");
                if (hMode == "Save")
                {
                   
                   //Record rec =  base.FindCurrentRecord("CompRate");
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
                CompRateentry.GetHtmlInViewMode(rec);
                AddContent(CompRateentry);
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