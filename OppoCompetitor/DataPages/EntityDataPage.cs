using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace OppoCompetitor.DataPages {
    public class OppoCompetitorDataPage : Web {

        public override void PreBuildContents() {
            GetTabs("OppoCompetitor", "Summary");
            AddTopContent(GetCustomEntityTopFrame("OppoCompetitor"));
            base.PreBuildContents();
        }
        public override void BuildContents() {
            try {
                string opco_OppoCompetitorId = Dispatch.EitherField("opco_OppoCompetitorId");
                if (string.IsNullOrEmpty(opco_OppoCompetitorId)) {
                    opco_OppoCompetitorId = Dispatch.EitherField("key58");
                }

                Record OppoCompetitor = FindRecord("OppoCompetitor", "opco_OppoCompetitorId=" + opco_OppoCompetitorId);

                EntryGroup screenOppoCompetitor = new EntryGroup("OppoCompetitorNewEntry");
                screenOppoCompetitor.Title = "OppoCompetitor";
                screenOppoCompetitor.Fill(OppoCompetitor);

                string status = OppoCompetitor.GetFieldAsString("opco_status");

                VerticalPanel vpMainPanel = new VerticalPanel();
                vpMainPanel.AddAttribute("width", "100%");
                vpMainPanel.Add(screenOppoCompetitor);

                AddContent(vpMainPanel);
                AddUrlButton("Edit", "Edit.gif", UrlDotNet(ThisDotNetDll, "RunDataPageEdit") + "&opco_OppoCompetitorId=" + opco_OppoCompetitorId);
                AddUrlButton("Delete", "Delete.gif", UrlDotNet(ThisDotNetDll, "RunDataPageDelete") + "&opco_OppoCompetitorId=" + opco_OppoCompetitorId);
               string opportunityid=Dispatch.EitherField("Key7");
               if (!string.IsNullOrEmpty(opportunityid)) {
                   AddUrlButton("Continue", "Continue.gif", UrlDotNet(ThisDotNetDll, "RunListPage") + "&J=OppoCompetitor&T=Opportunity");
               } else {
                   AddUrlButton("Continue", "Continue.gif", UrlDotNet(ThisDotNetDll, "RunCompetitorListPage") + "&J=OppoCompetitor&T=Competitor");
               }
               } catch (Exception error) {
                this.AddError(error.Message);
            }
        }
    }
}