using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace OppoTrack.DataPages {
    public class OppoTrackDataPageDelete : Web {
        public override void BuildContents() {
            AddContent(HTML.Form());
            try {
                string hMode = Dispatch.EitherField("HiddenMode");
                string id = Dispatch.EitherField("optr_OppoTrackId");
                int errorflag = 0;
                string errormessage = string.Empty;
                Record OppoTrack = FindRecord("OppoTrack", "optr_OppoTrackId=" + id);
                string optr_opportunityid = OppoTrack.GetFieldAsString("optr_opportunityid");
                EntryGroup OppoTrackNewEntry = new EntryGroup("OppoTrackNewEntry");
                OppoTrackNewEntry.Fill(OppoTrack);

                AddTabHead("Delete OppoTrack");
                if (hMode == "Delete") {
                    OppoTrack.DeleteRecord = true;
                    OppoTrack.SaveChanges();

                    ////double  =OppoTrack.GetFieldAsDouble("");
                    ////Record BusReport= FindRecord("BusReport", "cpet_competitorid=" + cpet_competitorid);
                    ////double  = BusReport.GetFieldAsDouble("");                        
                    //// =  - ;
                    ////BusReport.SetField("", );
                    ////BusReport.SaveChanges();

                    string url = UrlDotNet(ThisDotNetDll, "RunListPage") + "&J=OppoTrack&T=Opportunity";
                    Dispatch.Redirect(url);
                }
                if (errorflag != -1) {

                    AddContent(HTML.InputHidden("HiddenMode", ""));
                    VerticalPanel vpMainPanel = new VerticalPanel();
                    vpMainPanel.AddAttribute("width", "100%");
                    string sUrl = "javascript:document.EntryForm.HiddenMode.value='Delete';";
                    OppoTrackNewEntry.GetHtmlInViewMode(OppoTrack);
                    vpMainPanel.Add(OppoTrackNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("ConfirmDelete", "Delete.gif", sUrl);
                    string url = UrlDotNet(ThisDotNetDll, "RunListPage") + "&J=OppoTrack&T=Opportunity";
                    AddUrlButton("Cancel", "cancel.gif", url);
                }

            } catch (Exception e) {
                AddError(e.Message);
            }
        }
    }
}
