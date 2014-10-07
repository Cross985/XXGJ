using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Controls;

namespace Follow.DataPages
{
    public class FollowDataPageEdit : DataPageEdit
    {
        public FollowDataPageEdit()
            : base("Follow", "foll_FollowID", "FollowNewEntry")
        {
            this.CancelButton = false;
            
        }
        string compid = string.Empty;
        public override void BuildContents()
        {
            try
            {
                GetTabs("Follow", "Follow");
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
            //Entry comp = screen.GetEntry("foll_companyid");
            //string compid = Dispatch.EitherField("comp_companyid");
            //if (string.IsNullOrEmpty(compid))
            //    compid = Dispatch.EitherField("key1");
            //comp.DefaultValue = compid;
            //Record FollRec = base.FindCurrentRecord("Follow");
            //FollRec.SetField("foll_companyid",compid);
            //FollRec.SaveChanges();
            //base.AfterSave(screen);
            Dispatch.Redirect(UrlDotNet("Company", "RunFollowList") + "&comp_companyid=" + compid + "&J=Summary");
        }
    }
}