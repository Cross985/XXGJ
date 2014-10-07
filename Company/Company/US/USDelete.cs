using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;

namespace Company.DataPages
{
    public class UseSituationDelete : Web
    {
        //    public UseSituationDataPageDelete()
        //        : base("UseSituation", "usst_UseSituationID", "UseSituationNewEntry")
        //    {
        //        this.CancelButton = false;
        //        this.DeleteButton = false;
        //    }
        
        public override void BuildContents()
        {
            try
            {
                AddContent(HTML.Form());
                string compid = string.Empty;
                string UseSituationid = Dispatch.EitherField("usst_UseSituationID");
                Record rec = FindRecord("UseSituation", "usst_UseSituationID=" + UseSituationid);
                EntryGroup UseSituationentry = new EntryGroup("UseSituationNewEntry");
                UseSituationentry.Fill(rec);
                AddTabHead("UseSituation");
                string hMode = Dispatch.EitherField("HiddenMode");
                if (hMode == "Save")
                {
                    rec.DeleteRecord = true;
                    rec.SaveChanges();
                    Dispatch.Redirect(UrlDotNet("Company", "RunUSList") + "&comp_companyid=" + compid);
                }


                /* Add your code here */
                compid = Dispatch.EitherField("comp_companyid");
                if (string.IsNullOrEmpty(compid))
                    compid = Dispatch.EitherField("key1");
                /* Add your code here */
                AddContent(HTML.InputHidden("HiddenMode", ""));
                UseSituationentry.GetHtmlInViewMode(rec);
                AddContent(UseSituationentry);
                AddSubmitButton("确认删除", "delete.gif", "javascript:document.EntryForm.HiddenMode.value='Save';");
                AddUrlButton("Cancel", "Cancel.gif", UrlDotNet("Company", "RunUSList") + "&comp_companyid=" + compid);

            }
            catch (Exception error)
            {
                this.AddError(error.Message);
            }
        }

    }
}