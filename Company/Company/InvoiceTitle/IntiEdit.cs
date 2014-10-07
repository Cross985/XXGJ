using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Controls;
using Sage.CRM.Data;
using Sage.CRM.UI;


namespace Company
{
    public class InvoiceEdit : Web
    {
        public override void BuildContents()
        {
            try
            {
                AddContent(HTML.Form());
                string compid = Dispatch.EitherField("comp_companyid");
                if (string.IsNullOrEmpty(compid))
                    compid = Dispatch.EitherField("key1");
                string intiid = Dispatch.EitherField("inti_InvoiceTitleID");
                string hMode = Dispatch.EitherField("HiddenMode");
                EntryGroup IntiEntry = new EntryGroup("InvoiceTitleNewEntry");
                IntiEntry.Title = "发票抬头";
                Record IntiRec = FindRecord("InvoiceTitle", "inti_InvoiceTitleID=" + intiid);
                int errflag = 0;
                AddTabHead("InvoiceTitle");
                if (hMode == "Save")
                {                    
                    IntiEntry.Fill(IntiRec);
                    if (IntiEntry.Validate() == true)
                    {
                        IntiRec.SetField("inti_companyid", compid);
                        IntiRec.SaveChanges();
                        Dispatch.Redirect(UrlDotNet(ThisDotNetDll, "RunInvoiceTitleList") + "&comp_companyid=" + compid + "&J=Summary&T=CompanySummary");
                    }

                }
                if (errflag != -1)
                {
                    AddContent(HTML.InputHidden("HiddenMode", ""));
                    IntiEntry.GetHtmlInEditMode(IntiRec);
                    VerticalPanel vp = new VerticalPanel();
                    vp.AddAttribute("width", "100%");
                    vp.Add(IntiEntry);
                    AddContent(vp);

                    string url = "javascript:document.EntryForm.HiddenMode.value='Save';";
                    AddSubmitButton("Save", "Save.gif", url);
                    AddUrlButton("Delete", "Delete.gif", UrlDotNet(ThisDotNetDll, "RunInvoiceDelete") + "&comp_companyid=" + compid + "&inti_InvoiceTitleID=" + intiid);
                    AddUrlButton("Cancel", "cancel.gif", UrlDotNet(ThisDotNetDll, "RunInvoiceTitleList") + "&comp_companyid=" + compid + "&J=Summary&T=CompanySummary");
                }

            }
            catch (Exception ex)
            {
                AddError(ex.Message + "IntiEditPage");
            }
        }

    }
}
