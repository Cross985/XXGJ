using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Controls;
using Sage.CRM.Data;
using Sage.CRM.UI;

namespace Quotation.DataPages
{
    public class QuotationDataPageEdit : Web
    {

        public override void BuildContents()
        {
            try
            {

                AddContent(HTML.Form());
                string qutaid = Dispatch.EitherField("quta_Quotationid");
                EntryGroup qutacompEntry = new EntryGroup("QuotationCompanyEntry");
                qutacompEntry.Title = "商机客户";
                EntryGroup qutaEntry = new EntryGroup("QuotationNewEntry");
                qutaEntry.Title = "报价信息";
                Record qutaRec = FindRecord("Quotation", "quta_Quotationid=" + qutaid);
                qutacompEntry.Fill(qutaRec);
                qutaEntry.Fill(qutaRec);
                AddTabHead("Quotation");
                int errflag = 0;
                string hMode = Dispatch.EitherField("HiddenMode");
                if (hMode == "Save")
                {
                    if (qutaEntry.Validate() == true && qutacompEntry.Validate())
                    {
                        qutaEntry.Fill(qutaRec);
                        qutacompEntry.Fill(qutaRec);
                        qutaRec.SaveChanges();
                        Dispatch.Redirect(UrlDotNet(ThisDotNetDll, "RunDataPage") + "&quta_Quotationid=" + qutaid);
                    }

                }
                if (errflag != -1)
                {
                    AddContent(HTML.InputHidden("HiddenMode", ""));
                    qutacompEntry.GetHtmlInEditMode(qutaRec);
                    qutaEntry.GetHtmlInEditMode(qutaRec);
                    VerticalPanel vp = new VerticalPanel();
                    vp.AddAttribute("width", "100%");
                    vp.Add(qutacompEntry);
                    vp.Add(qutaEntry);
                    AddContent(vp);
                    AddSubmitButton("Save", "Save.gif", "javascript:document.EntryForm.HiddenMode.value='Save';");
                    AddUrlButton("Cancel", "Cancel.gif", UrlDotNet(ThisDotNetDll, "RunDataPage") + "&quta_Quotationid=" + qutaid);
                }
            }
            catch (Exception error)
            {
                this.AddError(error.Message);
            }
        }
    }
}