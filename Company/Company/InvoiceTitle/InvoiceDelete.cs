using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;

namespace Company.DataPages
{
    public class InvoiceDelete : Web
    {
        //    public InvoiceDataPageDelete()
        //        : base("Invoice", "inti_InvoiceID", "InvoiceNewEntry")
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
                string Invoiceid = Dispatch.EitherField("inti_InvoiceTitleID");
                Record rec = FindRecord("InvoiceTitle", "inti_InvoiceTitleID=" + Invoiceid);
                EntryGroup Invoiceentry = new EntryGroup("InvoiceTitleNewEntry");
                Invoiceentry.Fill(rec);
                AddTabHead("Invoice");
                string hMode = Dispatch.EitherField("HiddenMode");
                if (hMode == "Save")
                {
                    rec.DeleteRecord = true;
                    rec.SaveChanges();
                    Dispatch.Redirect(UrlDotNet("Company", "RunInvoiceTitleList") + "&comp_companyid=" + compid);
                }


                /* Add your code here */
                compid = Dispatch.EitherField("comp_companyid");
                if (string.IsNullOrEmpty(compid))
                    compid = Dispatch.EitherField("key1");
                /* Add your code here */
                AddContent(HTML.InputHidden("HiddenMode", ""));
                Invoiceentry.GetHtmlInViewMode(rec);
                AddContent(Invoiceentry);
                AddSubmitButton("确认删除", "delete.gif", "javascript:document.EntryForm.HiddenMode.value='Save';");
                AddUrlButton("Cancel", "Cancel.gif", UrlDotNet("Company", "RunInvoiceTitleList") + "&comp_companyid=" + compid);

            }
            catch (Exception error)
            {
                this.AddError(error.Message);
            }
        }

    }
}