using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Controls;
using Sage.CRM.Data;
using Sage.CRM.UI;

namespace Company.DataPages
{
    public class CompanyDataPageNew : Web
    {

        public override void BuildContents()
        {
            try
            {

                AddContent(HTML.Form());
                //string compid = Dispatch.EitherField("comp_companyid");
                EntryGroup CompEntry = new EntryGroup("CompanyBoxLong");
                CompEntry.Title = "基础信息";
                EntryGroup DealEntry = new EntryGroup("CompanyDealEntry");
                DealEntry.Title = "交易信息";
                EntryGroup StatusEntry = new EntryGroup("CompanyStatusEntry");
                StatusEntry.Title = "状态信息";

                GetTabs("CompanySummary", "Summary");
                int errflag = 0;
                string hMode = Dispatch.EitherField("HiddenMode");
                if (hMode == "Save")
                {
                    Record CompRec = new Record("Company");
                    CompEntry.Fill(CompRec);
                    DealEntry.Fill(CompRec);
                    StatusEntry.Fill(CompRec);
                    if (CompEntry.Validate() == true  && DealEntry.Validate() && DealEntry.Validate() == true && StatusEntry.Validate())
                    {
                        
                        CompRec.SaveChanges();
                        Dispatch.Redirect(UrlDotNet(ThisDotNetDll, "RunDataPage") + "&comp_companyid=" + CompRec.RecordId.ToString());
                    }

                }
                if (errflag != -1)
                {
                    AddContent(HTML.InputHidden("HiddenMode",""));
                    CompEntry.GetHtmlInEditMode();
                    DealEntry.GetHtmlInEditMode();
                    //StatusEntry.GetHtmlInEditMode();
                    VerticalPanel vp = new VerticalPanel();
                    vp.AddAttribute("width", "100%");
                    vp.Add(CompEntry);
                    vp.Add(DealEntry);
                    //vp.Add(StatusEntry);
                    AddContent(vp);
                    AddSubmitButton("Save", "Save.gif", "javascript:document.EntryForm.HiddenMode.value='Save';");
                    AddUrlButton("Cancel", "Cancel.gif", UrlDotNet(ThisDotNetDll, "RunListPage") + "&T=CompanyList");
                }
            }
            catch (Exception error)
            {
                this.AddError(error.Message);
            }
        }
    }
}