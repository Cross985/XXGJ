using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace MonthPlan
{
    public class PlanDetailSummary : Web
    {
        public override void PreBuildContents()
        {
            GetTabs("PlanDetail", "Summary");
            AddTopContent(GetCustomEntityTopFrame("PlanDetail"));
            base.PreBuildContents();
        }
        public override void BuildContents()
        {
            try
            {
                string plde_PlanDetailid = Dispatch.EitherField("plde_PlanDetailid");

                Record PlanDetail = FindRecord("PlanDetail", "plde_PlanDetailid=" + plde_PlanDetailid);
                string plde_monthplanid = PlanDetail.GetFieldAsString("plde_monthplanid");

               
                int userid = CurrentUser.UserId;

                string urledit = base.UrlDotNet(base.ThisDotNetDll, "RunPlanDetailEdit") + "&plde_PlanDetailid=" + plde_PlanDetailid;
                    Dispatch.Redirect(urledit);


                    EntryGroup DecoratePersonNewEntry = new EntryGroup("PlanDetailNewEntry");

                DecoratePersonNewEntry.Title = "PlanDetail";
                DecoratePersonNewEntry.Fill(PlanDetail);

                VerticalPanel vpMainPanel = new VerticalPanel();
                vpMainPanel.AddAttribute("width", "100%");
                vpMainPanel.Add(DecoratePersonNewEntry);
                AddContent(vpMainPanel);

                string urldelete = base.UrlDotNet(base.ThisDotNetDll, "RunPlanDetailDelete") + "&plde_PlanDetailid=" + plde_PlanDetailid;
                    base.AddUrlButton("Delete", "Delete.gif", urldelete);


                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mopl_MonthPlanId=" + plde_monthplanid;
                    url = url.Replace("Key37", "PlanDetailid");
                url = url + "&Key37=" + plde_monthplanid;
                this.AddUrlButton("cancel", "PrevCircle.gif", url);
                
            }
            catch (Exception error)
            {
                this.AddError(error.Message);
            }
        }
    }
}