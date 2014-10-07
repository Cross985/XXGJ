using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;
using Sage.CRM.Utils;

namespace OppoSupport.DataPages {
    public class OppoSupportDataPageEdit : Web {
        public override void BuildContents() {
            AddContent(HTML.Form());

            try {
                string hMode = Dispatch.EitherField("HiddenMode");
                string opsu_OppoSupportId = Dispatch.EitherField("opsu_OppoSupportId");
                int errorflag = 0;
                string errormessage = string.Empty;
                Record OppoSupport = FindRecord("OppoSupport", "opsu_OppoSupportId=" + opsu_OppoSupportId);
                string opsu_opportunityid = OppoSupport.GetFieldAsString("opsu_opportunityid");
                EntryGroup OppoSupportNewEntry = new EntryGroup("OppoSupportNewEntry");
                OppoSupportNewEntry.Fill(OppoSupport);
                Entry opsu_opportunityidEntry = OppoSupportNewEntry.GetEntry("opsu_opportunityid");

                opsu_opportunityidEntry.ReadOnly = true;

                //AddTabHead("CpetProduct");
                GetTabs("OppoSupport", "Summary");
                if (hMode == "Save") {

                    ////double original =CpetProduct.GetFieldAsDouble("");		    
                    OppoSupportNewEntry.Fill(OppoSupport);
                    ////double  =CpetProduct.GetFieldAsDouble("");

                    if (OppoSupportNewEntry.Validate()) {
                        OppoSupport.SaveChanges();

                        ////Record BusReport= FindRecord("BusReport", "cpet_competitorid=" + cpet_competitorid);
                        ////double  = BusReport.GetFieldAsDouble("");                        
                        //// =  + - original;
                        ////BusReport.SetField("", );
                        ////BusReport.SaveChanges();

                        string url = UrlDotNet(ThisDotNetDll, "RunListPage") + "&J=OppoSupport&T=Opportunity";
                        Dispatch.Redirect(url);
                        errorflag = -1;
                    } else {
                        errorflag = 1;
                    }

                }
                if (errorflag != -1) {

                    AddContent(HTML.InputHidden("HiddenMode", ""));
                    VerticalPanel vpMainPanel = new VerticalPanel();
                    vpMainPanel.AddAttribute("width", "100%");
                    string sUrl = "javascript:document.EntryForm.HiddenMode.value='Save';";
                    OppoSupportNewEntry.GetHtmlInEditMode(OppoSupport);
                    vpMainPanel.Add(OppoSupportNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("Save", "Save.gif", sUrl);
                    string urldelete = base.UrlDotNet(base.ThisDotNetDll, "RunDataPageDelete") + "&opsu_OppoSupportId=" + opsu_OppoSupportId;
                    base.AddUrlButton("Delete", "Delete.gif", urldelete);
                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&opsu_OppoSupportId=" + opsu_OppoSupportId + "&J=Summary";
                    AddUrlButton("Cancel", "cancel.gif", url);
                }

            } catch (Exception e) {
                AddError(e.Message);
            }
        }
    }
}
