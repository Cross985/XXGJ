using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Controls;
using Sage.CRM.Data;
using Sage.CRM.UI;

namespace Quotation.DataPages
{
    public class QuotationDataPageNew : Web
    {

        public override void BuildContents()
        {
            try
            {

                AddContent(HTML.Form());

                EntryGroup qutacompEntry = new EntryGroup("QuotationCompanyEntry");
                qutacompEntry.Title = "商机客户";
                EntryGroup qutaEntry = new EntryGroup("QuotationNewEntry");
                qutaEntry.Title = "报价信息";

                AddTabHead("Quotation");
                int errflag = 0;
                string hMode = Dispatch.EitherField("HiddenMode");
                if (hMode == "Save")
                {
                    Record QutaRec = new Record("Quotation");
                    qutacompEntry.Fill(QutaRec);
                    qutaEntry.Fill(QutaRec);
                    if (qutaEntry.Validate() == true && qutacompEntry.Validate())
                    {
                        string oppoid = Dispatch.EitherField("oppo_OpportunityId");
                        if (string.IsNullOrEmpty(oppoid))
                            oppoid = Dispatch.EitherField("key7");
                        QutaRec.SetField("quta_OpportunityId",oppoid);
                        QutaRec.SaveChanges();
                        Dispatch.Redirect(UrlDotNet(ThisDotNetDll, "RunDataPage") + "&quta_Quotationid=" + QutaRec.RecordId.ToString());
                    }

                }
                if (errflag != -1)
                {
                    AddContent(HTML.InputHidden("HiddenMode", ""));
                    qutacompEntry.GetHtmlInEditMode();
                    qutaEntry.GetHtmlInEditMode();
                    VerticalPanel vp = new VerticalPanel();
                    vp.AddAttribute("width", "100%");
                    vp.Add(qutacompEntry);
                    vp.Add(qutaEntry);
                    AddContent(vp);
                    AddSubmitButton("Save", "Save.gif", "javascript:document.EntryForm.HiddenMode.value='Save';");
                    AddUrlButton("Cancel", "Cancel.gif", UrlDotNet(ThisDotNetDll, "RunListPage") + "&J=Quotation&T=Opportunity");
                }
            }
            catch (Exception error)
            {
                this.AddError(error.Message);
            }
        }
    }
}