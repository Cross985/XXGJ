using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace OppoTrack.DataPages {
    public class OppoTrackDataPage : Web {

        public override void PreBuildContents() {
            GetTabs("OppoTrack", "Summary");
            AddTopContent(GetCustomEntityTopFrame("OppoTrack"));
            base.PreBuildContents();
        }
        public override void BuildContents() {
            try {
                string optr_OppoTrackId = Dispatch.EitherField("optr_OppoTrackId");
                if (string.IsNullOrEmpty(optr_OppoTrackId)) {
                    optr_OppoTrackId = Dispatch.EitherField("key58");
                }

                Record OppoTrack = FindRecord("OppoTrack", "optr_OppoTrackId=" + optr_OppoTrackId);

                EntryGroup screenOppoTrack = new EntryGroup("OppoTrackNewEntry");
                screenOppoTrack.Title = "OppoTrack";
                screenOppoTrack.Fill(OppoTrack);

                string status = OppoTrack.GetFieldAsString("optr_status");

                VerticalPanel vpMainPanel = new VerticalPanel();
                vpMainPanel.AddAttribute("width", "100%");
                vpMainPanel.Add(screenOppoTrack);

                AddContent(vpMainPanel);
                AddUrlButton("Edit", "Edit.gif", UrlDotNet(ThisDotNetDll, "RunDataPageEdit") + "&optr_OppoTrackId=" + optr_OppoTrackId);
                AddUrlButton("Delete", "Delete.gif", UrlDotNet(ThisDotNetDll, "RunDataPageDelete") + "&optr_OppoTrackId=" + optr_OppoTrackId);
                AddUrlButton("Continue", "Continue.gif", UrlDotNet(ThisDotNetDll, "RunListPage") + "&J=OppoTrack&T=Opportunity");
            } catch (Exception error) {
                this.AddError(error.Message);
            }
        }
    }
}