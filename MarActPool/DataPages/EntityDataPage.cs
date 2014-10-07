using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace MarActPool.DataPages {
    public class MarActPoolDataPage : Web {

        public override void PreBuildContents() {
            GetTabs("MarActPool", "Summary");
            AddTopContent(GetCustomEntityTopFrame("MarActPool"));
            base.PreBuildContents();
        }
        public override void BuildContents() {
            try {
                string mapo_MarActPoolId = Dispatch.EitherField("mapo_MarActPoolId");
                if (string.IsNullOrEmpty(mapo_MarActPoolId)) {
                    mapo_MarActPoolId = Dispatch.EitherField("key58");
                }

                Record MarActPool = FindRecord("MarActPool", "mapo_MarActPoolId=" + mapo_MarActPoolId);
                EntryGroup screenBusReport = new EntryGroup("MarActPoolNewEntry");
                screenBusReport.Title = "MarActPool";
                screenBusReport.Fill(MarActPool);

                // string status = Competitor.GetFieldAsString("cept_status");

                VerticalPanel vpMainPanel = new VerticalPanel();
                vpMainPanel.AddAttribute("width", "100%");
                vpMainPanel.Add(screenBusReport);

                AddContent(vpMainPanel);
                AddUrlButton("Edit", "Edit.gif", UrlDotNet(ThisDotNetDll, "RunDataPageEdit") + "&mapo_MarActPoolId=" + mapo_MarActPoolId);
                AddUrlButton("Delete", "Delete.gif", UrlDotNet(ThisDotNetDll, "RunDataPageDelete") + "&mapo_MarActPoolId=" + mapo_MarActPoolId);
                AddUrlButton("Add MarActPlan", "New.gif", UrlDotNet("MarActPlan", "RunDataPageNew") + "&mapo_MarActPoolId=" + mapo_MarActPoolId);

                AddUrlButton("Continue", "Continue.gif", UrlDotNet(ThisDotNetDll, "RunListPage"));
            } catch (Exception error) {
                this.AddError(error.Message);
            }
        }
    }
}