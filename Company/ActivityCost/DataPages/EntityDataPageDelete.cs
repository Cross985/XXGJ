using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;

namespace ActivityIncome.DataPages
{
    public class ActivityIncomeDataPageDelete : Web
    {
    //    public ActivityIncomeDataPageDelete()
    //        : base("ActivityIncome", "acin_ActivityIncomeID", "ActivityIncomeNewEntry")
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
                string ActivityIncomeid = Dispatch.EitherField("acin_ActivityIncomeID");
                Record rec = FindRecord("ActivityIncome","acin_ActivityIncomeID="+ActivityIncomeid );
                EntryGroup ActivityIncomeentry = new EntryGroup("ActivityIncomeNewEntry");
                ActivityIncomeentry.Fill(rec);
                AddTabHead("ActivityIncome");
                string hMode = Dispatch.EitherField("HiddenMode");
                if (hMode == "Save")
                {
                   
                   //Record rec =  base.FindCurrentRecord("ActivityIncome");
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
                ActivityIncomeentry.GetHtmlInViewMode(rec);
                AddContent(ActivityIncomeentry);
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