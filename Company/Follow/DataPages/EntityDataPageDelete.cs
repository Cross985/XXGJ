using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;

namespace Follow.DataPages
{
    public class FollowDataPageDelete : Web
    {
    //    public FollowDataPageDelete()
    //        : base("Follow", "foll_FollowID", "FollowNewEntry")
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
                string followid = Dispatch.EitherField("foll_FollowID");
                Record rec = FindRecord("Follow","foll_FollowID="+followid );
                EntryGroup followentry = new EntryGroup("FollowNewEntry");
                followentry.Fill(rec);
                AddTabHead("Follow");
                string hMode = Dispatch.EitherField("HiddenMode");
                if (hMode == "Save")
                {
                   
                   //Record rec =  base.FindCurrentRecord("Follow");
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
                followentry.GetHtmlInViewMode(rec);
                AddContent(followentry);
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