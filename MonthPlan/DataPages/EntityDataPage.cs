using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace MonthPlan.DataPages {
    public class MonthPlanDataPage : Web {

        public override void PreBuildContents() {
            GetTabs("MonthPlan", "Summary");
            AddTopContent(GetCustomEntityTopFrame("MonthPlan"));
            base.PreBuildContents();
        }
        public override void BuildContents() {
            try {
                string mopl_MonthPlanId = Dispatch.EitherField("mopl_monthplanid");
                if (string.IsNullOrEmpty(mopl_MonthPlanId)) {
                    mopl_MonthPlanId = Dispatch.EitherField("Key58");
                }

                Record MonthPlan = FindRecord("MonthPlan", "mopl_MonthPlanId=" + mopl_MonthPlanId);

                EntryGroup screenMonthPlan = new EntryGroup("MonthPlanNewEntry");
                screenMonthPlan.Title = "MonthPlan";
                screenMonthPlan.Fill(MonthPlan);

                string status = MonthPlan.GetFieldAsString("mopl_status");


                VerticalPanel vpMainPanel = new VerticalPanel();
                vpMainPanel.AddAttribute("width", "100%");
                vpMainPanel.Add(screenMonthPlan);

                List NewIndustyPlan = new List("NewIndustyPlanGrid");
                NewIndustyPlan.Filter = " nipl_deleted is null and nipl_monthplanid=" + mopl_MonthPlanId;
                NewIndustyPlan.RowsPerScreen = 500;
                NewIndustyPlan.ShowNavigationButtons = true;
                NewIndustyPlan.PadBottom = false;
                vpMainPanel.Add(NewIndustyPlan);

                List PlanDetailGrid = new List("PlanDetailGrid");
                PlanDetailGrid.Filter = "plde_deleted is null and plde_monthplanid=" + mopl_MonthPlanId;
                PlanDetailGrid.RowsPerScreen = 500;
                PlanDetailGrid.ShowNavigationButtons = true;
                PlanDetailGrid.PadBottom = false;
                vpMainPanel.Add(PlanDetailGrid);

                List VisitComponyGrid = new List("VisitComponyGrid");
                VisitComponyGrid.Filter = "vico_deleted is null and vico_monthplanid=" + mopl_MonthPlanId;
                VisitComponyGrid.RowsPerScreen = 500;
                VisitComponyGrid.ShowNavigationButtons = true;
                VisitComponyGrid.PadBottom = false;
                vpMainPanel.Add(VisitComponyGrid);

                List SalePlanDetailGrid = new List("SalePlanDetailGrid");
                SalePlanDetailGrid.Filter = "spde_deleted is null and spde_monthplanid=" + mopl_MonthPlanId;
                SalePlanDetailGrid.RowsPerScreen = 500;
                SalePlanDetailGrid.ShowNavigationButtons = true;
                SalePlanDetailGrid.PadBottom = false;
                vpMainPanel.Add(SalePlanDetailGrid);


                List DealerDetailGrid = new List("DealerDetailGrid");
                DealerDetailGrid.Filter = "ddet_deleted is null and ddet_monthplanid=" + mopl_MonthPlanId;
                DealerDetailGrid.RowsPerScreen = 500;
                DealerDetailGrid.ShowNavigationButtons = true;
                DealerDetailGrid.PadBottom = false;
                vpMainPanel.Add(DealerDetailGrid);

                List ProcessMethodGrid = new List("ProcessMethodGrid");
                ProcessMethodGrid.Filter = "pmet_deleted is null and pmet_monthplanid=" + mopl_MonthPlanId;
                ProcessMethodGrid.RowsPerScreen = 500;
                ProcessMethodGrid.ShowNavigationButtons = true;
                ProcessMethodGrid.PadBottom = false;
                vpMainPanel.Add(ProcessMethodGrid);


                AddContent(vpMainPanel);
                AddUrlButton("Edit", "Edit.gif", UrlDotNet(ThisDotNetDll, "RunDataPageEdit") + "&mopl_MonthPlanId=" + mopl_MonthPlanId);
                AddUrlButton("Delete", "Delete.gif", UrlDotNet(ThisDotNetDll, "RunDataPageDelete") + "&mopl_MonthPlanId=" + mopl_MonthPlanId);
                AddUrlButton("Add PlanDetail", "new.gif", UrlDotNet(ThisDotNetDll, "RunPlanDetailAdd") + "&mopl_MonthPlanId=" + mopl_MonthPlanId);
                AddUrlButton("Add VisitCompony", "new.gif", UrlDotNet(ThisDotNetDll, "RunVisitComponyAdd") + "&mopl_MonthPlanId=" + mopl_MonthPlanId);
                AddUrlButton("Add SalePlanDetail", "new.gif", UrlDotNet(ThisDotNetDll, "RunSalePlanDetailAdd") + "&mopl_MonthPlanId=" + mopl_MonthPlanId);
                AddUrlButton("Add DealerDetail", "new.gif", UrlDotNet(ThisDotNetDll, "RunDealerDetailAdd") + "&mopl_MonthPlanId=" + mopl_MonthPlanId);
                AddUrlButton("Add ProcessMethod", "new.gif", UrlDotNet(ThisDotNetDll, "RunProcessMethodAdd") + "&mopl_MonthPlanId=" + mopl_MonthPlanId);
                AddUrlButton("Continue", "Continue.gif", UrlDotNet(ThisDotNetDll, "RunListPage"));
            } catch (Exception error) {
                this.AddError(error.Message);
            }
        }
    }
}