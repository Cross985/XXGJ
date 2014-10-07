using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Controls;

namespace ActivityIncome.DataPages
{
    public class ActivityIncomeDataPageEdit : DataPageEdit
    {
        public ActivityIncomeDataPageEdit()
            : base("ActivityIncome", "acin_ActivityIncomeID", "ActivityIncomeNewEntry")
        {
            this.CancelButton = false;
            
        }
        string compid = string.Empty;
        public override void BuildContents()
        {
            try
            {
                GetTabs("ActivityIncome", "ActivityIncome");
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
            //Entry comp = screen.GetEntry("acin_companyid");
            //string compid = Dispatch.EitherField("comp_companyid");
            //if (string.IsNullOrEmpty(compid))
            //    compid = Dispatch.EitherField("key1");
            //comp.DefaultValue = compid;
            //Record acinRec = base.FindCurrentRecord("ActivityIncome");
            //acinRec.SetField("acin_companyid",compid);
            //acinRec.SaveChanges();
            //base.AfterSave(screen);
            Dispatch.Redirect(UrlDotNet("Company", "RunActivityList") + "&comp_companyid=" + compid + "&J=Summary");
        }
    }
}