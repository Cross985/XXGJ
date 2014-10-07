//using System;
//using System.Collections.Generic;
//using System.Text;
//using Sage.CRM.WebObject;

//namespace OppoCompetitor.DataPages {
//    public class OppoCompetitorDataPageDelete : DataPageDelete {
//        public OppoCompetitorDataPageDelete()
//            : base("OppoCompetitor", "opco_OppoCompetitorId", "OppoCompetitorDetailBox") {
//        }
//    }
//}
using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace OppoCompetitor.DataPages {
    public class OppoCompetitorDataPageDelete : Web {
        public override void BuildContents() {
            AddContent(HTML.Form());
            try {
                string hMode = Dispatch.EitherField("HiddenMode");
                string id = Dispatch.EitherField("opco_OppoCompetitorId");
                int errorflag = 0;
                string errormessage = string.Empty;
                Record OppoCompetitor = FindRecord("OppoCompetitor", "opco_OppoCompetitorId=" + id);
                string opco_opportunityid = OppoCompetitor.GetFieldAsString("opco_opportunityid");
                EntryGroup OppoCompetitorNewEntry = new EntryGroup("OppoCompetitorNewEntry");
                OppoCompetitorNewEntry.Fill(OppoCompetitor);

                AddTabHead("Delete OppoCompetitor");
                if (hMode == "Delete") {
                    OppoCompetitor.DeleteRecord = true;
                    OppoCompetitor.SaveChanges();

                    ////double  =OppoCompetitor.GetFieldAsDouble("");
                    ////Record BusReport= FindRecord("BusReport", "cpet_competitorid=" + cpet_competitorid);
                    ////double  = BusReport.GetFieldAsDouble("");                        
                    //// =  - ;
                    ////BusReport.SetField("", );
                    ////BusReport.SaveChanges();

                    string opportunityid = Dispatch.EitherField("Key7");
                    string url = string.Empty;

                    if (!string.IsNullOrEmpty(opportunityid)) {
                        url = UrlDotNet(ThisDotNetDll, "RunListPage") + "&J=OppoCompetitor&T=Opportunity";
                    } else {
                        url = UrlDotNet(ThisDotNetDll, "RunCompetitorListPage") + "&J=OppoCompetitor&T=Competitor";
                    }

                    Dispatch.Redirect(url);
                }
                if (errorflag != -1) {

                    AddContent(HTML.InputHidden("HiddenMode", ""));
                    VerticalPanel vpMainPanel = new VerticalPanel();
                    vpMainPanel.AddAttribute("width", "100%");
                    string sUrl = "javascript:document.EntryForm.HiddenMode.value='Delete';";
                    OppoCompetitorNewEntry.GetHtmlInViewMode(OppoCompetitor);
                    vpMainPanel.Add(OppoCompetitorNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("ConfirmDelete", "Delete.gif", sUrl);
                    string url = UrlDotNet(ThisDotNetDll, "RunListPage") + "&J=OppoCompetitor&T=Opportunity";
                    AddUrlButton("Cancel", "cancel.gif", url);
                }

            } catch (Exception e) {
                AddError(e.Message);
            }
        }
    }
}
