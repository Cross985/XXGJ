using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace OppoSupport.DataPages {
    public class OppoSupportDataPageDelete : Web {
        public override void BuildContents() {
            AddContent(HTML.Form());
            try {
                string hMode = Dispatch.EitherField("HiddenMode");
                string id = Dispatch.EitherField("opsu_OppoSupportId");
                int errorflag = 0;
                string errormessage = string.Empty;
                Record OppoSupport = FindRecord("OppoSupport", "opsu_OppoSupportId=" + id);
                string opsu_opportunityid = OppoSupport.GetFieldAsString("opsu_opportunityid");
                EntryGroup OppoSupportNewEntry = new EntryGroup("OppoSupportNewEntry");
                OppoSupportNewEntry.Fill(OppoSupport);

                AddTabHead("Delete OppoSupport");
                if (hMode == "Delete") {
                    OppoSupport.DeleteRecord = true;
                    OppoSupport.SaveChanges();

                    ////double  =OppoSupport.GetFieldAsDouble("");
                    ////Record BusReport= FindRecord("BusReport", "cpet_competitorid=" + cpet_competitorid);
                    ////double  = BusReport.GetFieldAsDouble("");                        
                    //// =  - ;
                    ////BusReport.SetField("", );
                    ////BusReport.SaveChanges();

                    string url = UrlDotNet(ThisDotNetDll, "RunListPage") + "&J=OppoSupport&T=Opportunity";
                    Dispatch.Redirect(url);
                }
                if (errorflag != -1) {

                    AddContent(HTML.InputHidden("HiddenMode", ""));
                    VerticalPanel vpMainPanel = new VerticalPanel();
                    vpMainPanel.AddAttribute("width", "100%");
                    string sUrl = "javascript:document.EntryForm.HiddenMode.value='Delete';";
                    OppoSupportNewEntry.GetHtmlInViewMode(OppoSupport);
                    vpMainPanel.Add(OppoSupportNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("ConfirmDelete", "Delete.gif", sUrl);
                    string url = UrlDotNet(ThisDotNetDll, "RunListPage") + "&J=OppoSupport&T=Opportunity";
                    AddUrlButton("Cancel", "cancel.gif", url);
                }

            } catch (Exception e) {
                AddError(e.Message);
            }
        }
    }
}
