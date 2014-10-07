using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace DecorateComp.DataPages {
    public class DecorateCompDataPage : Web {

        public override void PreBuildContents() {
            GetTabs("DecorateComp", "Summary");
            AddTopContent(GetCustomEntityTopFrame("DecorateComp"));
            base.PreBuildContents();
        }
        public override void BuildContents() {
            try {
                string dcom_DecorateCompId = Dispatch.EitherField("dcom_decoratecompId");
                if (string.IsNullOrEmpty(dcom_DecorateCompId)) {
                    dcom_DecorateCompId = Dispatch.EitherField("key58");
                }

                Record DecorateComp = FindRecord("DecorateComp", "dcom_DecorateCompId=" + dcom_DecorateCompId);
                EntryGroup screenBusReport = new EntryGroup("DecorateCompNewEntry");
                screenBusReport.Title = "DecorateComp";
                screenBusReport.Fill(DecorateComp);

                // string status = Competitor.GetFieldAsString("cept_status");

                VerticalPanel vpMainPanel = new VerticalPanel();
                vpMainPanel.AddAttribute("width", "100%");
                vpMainPanel.Add(screenBusReport);

                List DecoratePersonGrid = new List("DecoratePersonGrid");
                DecoratePersonGrid.Filter = "dper_deleted is null and dper_decoratecompid=" + dcom_DecorateCompId;
                DecoratePersonGrid.RowsPerScreen = 500;
                DecoratePersonGrid.ShowNavigationButtons = true;
                DecoratePersonGrid.PadBottom = false;
                vpMainPanel.Add(DecoratePersonGrid);

                AddContent(vpMainPanel);
                AddUrlButton("Edit", "Edit.gif", UrlDotNet(ThisDotNetDll, "RunDataPageEdit") + "&dcom_decoratecompId=" + dcom_DecorateCompId);
                AddUrlButton("Delete", "Delete.gif", UrlDotNet(ThisDotNetDll, "RunDataPageDelete") + "&dcom_decoratecompId=" + dcom_DecorateCompId);
                AddUrlButton("Add Person", "new.gif", UrlDotNet(ThisDotNetDll, "RunPersonAdd") + "&dcom_decoratecompId=" + dcom_DecorateCompId);
                AddUrlButton("Continue", "Continue.gif", UrlDotNet(ThisDotNetDll, "RunListPage"));
            } catch (Exception error) {
                this.AddError(error.Message);
            }
        }
    }
}