using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;

namespace Company.DataPages
{
    public class AddressDelete : Web
    {
        //    public AddressDataPageDelete()
        //        : base("Follow", "foll_FollowID", "FollowNewEntry")
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
                string Addressid = Dispatch.EitherField("addr_AddressID");
                Record rec = FindRecord("Address", "addr_AddressID=" + Addressid);
                EntryGroup Addressentry = new EntryGroup("CompanyAddressEntry");
                Addressentry.Fill(rec);
                AddTabHead("Address");
                //GetTabs("Address", "Address");
                string hMode = Dispatch.EitherField("HiddenMode");
                if (hMode == "Save")
                {

                    //Record rec =  base.FindCurrentRecord("Address");
                    rec.DeleteRecord = true;
                    rec.SaveChanges();
                    Dispatch.Redirect(UrlDotNet("Company", "RunAddressList") + "&comp_companyid=" + compid);
                }


                /* Add your code here */
                compid = Dispatch.EitherField("comp_companyid");
                if (string.IsNullOrEmpty(compid))
                    compid = Dispatch.EitherField("key1");
                /* Add your code here */
                AddContent(HTML.InputHidden("HiddenMode", ""));
                Addressentry.GetHtmlInViewMode(rec);
                AddContent(Addressentry);
                AddSubmitButton("确认删除", "delete.gif", "javascript:document.EntryForm.HiddenMode.value='Save';");
                AddUrlButton("Cancel", "Cancel.gif", UrlDotNet("Company", "RunAddressList") + "&comp_companyid=" + compid);

            }
            catch (Exception error)
            {
                this.AddError(error.Message);
            }
        }

    }
}