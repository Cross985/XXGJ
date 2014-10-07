using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Controls;
using Sage.CRM.Data;
using Sage.CRM.UI;


namespace Company
{
    public class AddressAdd:Web
    {
        public override void BuildContents()
        {
            try
            {
                AddContent(HTML.Form());
                string compid = Dispatch.EitherField("comp_companyid");
                if (string.IsNullOrEmpty(compid))
                    compid = Dispatch.EitherField("key1");
                string hMode = Dispatch.EitherField("HiddenMode");
                EntryGroup AddrEntry = new EntryGroup("CompanyAddressEntry");
                AddrEntry.Title = "地址信息";
                int errflag = 0;
                AddTabHead("Address");
                //GetTabs("CompanyAddress", "Address");
                if (hMode == "Save")
                {
                    Record AddrRec = new Record("Address");
                    AddrEntry.Fill(AddrRec);
                    if (AddrEntry.Validate() == true)
                    {
                        AddrRec.SetField("addr_companyid",compid);
                        AddrRec.SaveChanges();
                        Dispatch.Redirect(UrlDotNet(ThisDotNetDll, "RunAddressList") + "&comp_companyid=" + compid + "&J=Summary&T=CompanySummary");
                    }
 
                }
                if (errflag != -1)
                {
                    AddContent(HTML.InputHidden("HiddenMode",""));
                    AddrEntry.GetHtmlInEditMode();
                    VerticalPanel vp = new VerticalPanel();
                    vp.AddAttribute("width","100%");
                    vp.Add(AddrEntry);
                    AddContent(vp);

                    string url = "javascript:document.EntryForm.HiddenMode.value='Save';";
                    AddSubmitButton("Save","Save.gif",url);
                    AddUrlButton("Cancel", "cancel.gif", UrlDotNet(ThisDotNetDll, "RunAddressList") + "&comp_companyid=" + compid + "&J=Summary&T=CompanySummary");
                }

            }
            catch (Exception ex)
            {
                AddError(ex.Message + "AddressAddPage");
            }
        }
       
    }
}
