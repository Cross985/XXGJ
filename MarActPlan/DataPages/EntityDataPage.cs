using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace MarActPlan.DataPages {
    public class MarActPlanDataPage : Web {

        public override void PreBuildContents() {
            GetTabs("MarActPlan", "Summary");
            AddTopContent(GetCustomEntityTopFrame("MarActPlan"));
            base.PreBuildContents();
        }
        public override void BuildContents() {
            try {
                string mapl_MarActPlanId = Dispatch.EitherField("mapl_MarActPlanId");
                if (string.IsNullOrEmpty(mapl_MarActPlanId)) {
                    mapl_MarActPlanId = Dispatch.EitherField("key58");
                }

                Record MarActPlan = FindRecord("MarActPlan", "mapl_MarActPlanId=" + mapl_MarActPlanId);

                EntryGroup screenMarActPlan = new EntryGroup("MarActPlanNewEntry");
                screenMarActPlan.Title = "MarActPlan";
                screenMarActPlan.Fill(MarActPlan);

                string status = MarActPlan.GetFieldAsString("mapl_status");


                VerticalPanel vpMainPanel = new VerticalPanel();
                vpMainPanel.AddAttribute("width", "100%");
                vpMainPanel.Add(screenMarActPlan);

                List MarActPlanPersonList = new List("MarActPlanPersonList");
                MarActPlanPersonList.Filter = "dper_deleted is null and dper_maractplanid=" + mapl_MarActPlanId;
                MarActPlanPersonList.RowsPerScreen = 500;
                MarActPlanPersonList.ShowNavigationButtons = true;
                MarActPlanPersonList.PadBottom = false;
                vpMainPanel.Add(MarActPlanPersonList);

                List DisplayContentGrid = new List("DisplayContentGrid");
                DisplayContentGrid.Filter = "dico_deleted is null and dico_maractplanid=" + mapl_MarActPlanId;
                DisplayContentGrid.RowsPerScreen = 500;
                DisplayContentGrid.ShowNavigationButtons = true;
                DisplayContentGrid.PadBottom = false;
                vpMainPanel.Add(DisplayContentGrid);

                List ActualCostGrid = new List("ActualCostGrid");
                ActualCostGrid.Filter = "acco_deleted is null and acco_maractplanid=" + mapl_MarActPlanId;
                ActualCostGrid.RowsPerScreen = 500;
                ActualCostGrid.ShowNavigationButtons = true;
                ActualCostGrid.PadBottom = false;
                vpMainPanel.Add(ActualCostGrid);

                AddContent(vpMainPanel);
                AddUrlButton("Edit", "Edit.gif", UrlDotNet(ThisDotNetDll, "RunDataPageEdit") + "&mapl_MarActPlanId=" + mapl_MarActPlanId);
                AddUrlButton("Delete", "Delete.gif", UrlDotNet(ThisDotNetDll, "RunDataPageDelete") + "&mapl_MarActPlanId=" + mapl_MarActPlanId);
                AddUrlButton("Add Person", "new.gif", UrlDotNet(ThisDotNetDll, "RunPersonAdd") + "&mapl_MarActPlanId=" + mapl_MarActPlanId);
                AddUrlButton("Add DisplayContent", "new.gif", UrlDotNet(ThisDotNetDll, "RunDisplayContentAdd") + "&mapl_MarActPlanId=" + mapl_MarActPlanId);
                AddUrlButton("Add ActualCost", "new.gif", UrlDotNet(ThisDotNetDll, "RunActualCostAdd") + "&mapl_MarActPlanId=" + mapl_MarActPlanId);
                AddUrlButton("Continue", "Continue.gif", UrlDotNet(ThisDotNetDll, "RunListPage"));
            } catch (Exception error) {
                this.AddError(error.Message);
            }
        }
    }
}