using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Controls;
using Sage.CRM.UI;
using Sage.CRM.Data;

namespace OppoTrack.DataPages {
    public class OppoTrackDataPageNew : Web {
        public override void BuildContents() {
            AddContent(HTML.Form());

            try {
                string hMode = Dispatch.EitherField("HiddenMode");
                string optr_opportunityid = Dispatch.EitherField("Key7");
                int errorflag = 0;
                string errormessage = string.Empty;
                EntryGroup OppoTrackNewEntry = new EntryGroup("OppoTrackNewEntry");
                //CostAdjustmentProductNewEntry.Title = "Add CostAdjustmentProduct"; 
                Entry optr_opportunityidEntry = OppoTrackNewEntry.GetEntry("optr_opportunityid");
                if (optr_opportunityidEntry != null) {
                    optr_opportunityidEntry.DefaultValue = optr_opportunityid;
                    optr_opportunityidEntry.ReadOnly = true;
                }

                AddTabHead("OppoTrack");
                if (hMode == "Save") {
                    Record OppoTrack = new Record("OppoTrack");
                    OppoTrackNewEntry.Fill(OppoTrack);
                    if (OppoTrackNewEntry.Validate()) {

                        OppoTrack.SaveChanges();
                        QuerySelect qs = this.GetQuery();
                        qs.SQLCommand = @"Update Opportunity set oppo_nexttrackdate = (select MAX(optr_nexttrackdate) from OppoTrack where optr_deleted is null and optr_opportunityid=" + optr_opportunityid + @")
                        ,oppo_trackdate = (select MAX(optr_date) from OppoTrack where optr_deleted is null and optr_opportunityid=" + optr_opportunityid + @" ) where oppo_opportunityid=" + optr_opportunityid;
                        qs.ExecuteNonQuery();

                        string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&optr_oppotrackid=" + OppoTrack.GetFieldAsString("optr_oppotrackid") + "&J=Summary";
                        Dispatch.Redirect(url);
                        errorflag = -1;
                    } else {
                        errorflag = 1;
                    }
                }
                if (errorflag != -1) {
                    if (errorflag == 2) {
                        AddError(errormessage);
                    }

                    AddContent(HTML.InputHidden("HiddenMode", ""));
                    VerticalPanel vpMainPanel = new VerticalPanel();
                    vpMainPanel.AddAttribute("width", "100%");
                    string sUrl = "javascript:document.EntryForm.HiddenMode.value='Save';";
                    OppoTrackNewEntry.GetHtmlInEditMode();
                    vpMainPanel.Add(OppoTrackNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("Save", "Save.gif", sUrl);
                    AddUrlButton("Cancel", "cancel.gif", UrlDotNet(ThisDotNetDll, "RunListPage") + "&J=OppoTrack&T=Opportunity");
                }

            } catch (Exception e) {
                AddError(e.Message);
            }
        }

    }
}
