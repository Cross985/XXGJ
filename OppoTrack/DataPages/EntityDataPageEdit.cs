using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;
using Sage.CRM.Utils;

namespace OppoTrack.DataPages {
    public class OppoTrackDataPageEdit : Web {
        public override void BuildContents() {
            AddContent(HTML.Form());

            try {
                string hMode = Dispatch.EitherField("HiddenMode");
                string optr_OppoTrackId = Dispatch.EitherField("optr_OppoTrackId");
                int errorflag = 0;
                string errormessage = string.Empty;
                Record OppoTrack = FindRecord("OppoTrack", "optr_OppoTrackId=" + optr_OppoTrackId);
                string optr_opportunityid = OppoTrack.GetFieldAsString("optr_opportunityid");
                EntryGroup OppoTrackNewEntry = new EntryGroup("OppoTrackNewEntry");
                OppoTrackNewEntry.Fill(OppoTrack);
                Entry optr_opportunityidEntry = OppoTrackNewEntry.GetEntry("optr_opportunityid");

                optr_opportunityidEntry.ReadOnly = true;

                //AddTabHead("CpetProduct");
                GetTabs("OppoTrack", "Summary");
                if (hMode == "Save") {

                    ////double original =CpetProduct.GetFieldAsDouble("");		    
                    OppoTrackNewEntry.Fill(OppoTrack);
                    ////double  =CpetProduct.GetFieldAsDouble("");

                    if (OppoTrackNewEntry.Validate()) {
                        OppoTrack.SaveChanges();

                        ////Record BusReport= FindRecord("BusReport", "cpet_competitorid=" + cpet_competitorid);
                        ////double  = BusReport.GetFieldAsDouble("");                        
                        //// =  + - original;
                        ////BusReport.SetField("", );
                        ////BusReport.SaveChanges();

                        string url =UrlDotNet(ThisDotNetDll, "RunListPage") + "&J=OppoTrack&T=Opportunity";
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
                    OppoTrackNewEntry.GetHtmlInEditMode(OppoTrack);
                    vpMainPanel.Add(OppoTrackNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("Save", "Save.gif", sUrl);
                    string urldelete = base.UrlDotNet(base.ThisDotNetDll, "RunDataPageDelete") + "&optr_OppoTrackId=" + optr_OppoTrackId;
                    base.AddUrlButton("Delete", "Delete.gif", urldelete);
                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&optr_OppoTrackId=" + optr_OppoTrackId + "&J=Summary";
                    AddUrlButton("Cancel", "cancel.gif", url);
                }

            } catch (Exception e) {
                AddError(e.Message);
            }
        }
    }
}
