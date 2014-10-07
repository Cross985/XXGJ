using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace MonthPlan
{
    public class SalePlanDetailSummary : Web
    {
        public override void PreBuildContents()
        {
            GetTabs("SalePlanDetail", "Summary");
            AddTopContent(GetCustomEntityTopFrame("SalePlanDetail"));
            base.PreBuildContents();
        }
        public override void BuildContents()
        {
            try
            {
                string spde_SalePlanDetailid = Dispatch.EitherField("spde_SalePlanDetailid");

                Record SalePlanDetail = FindRecord("SalePlanDetail", "spde_SalePlanDetailid=" + spde_SalePlanDetailid);
                string spde_monthplanid = SalePlanDetail.GetFieldAsString("spde_monthplanid");

               
                int userid = CurrentUser.UserId;

                string urledit = base.UrlDotNet(base.ThisDotNetDll, "RunSalePlanDetailEdit") + "&spde_SalePlanDetailid=" + spde_SalePlanDetailid;
                    Dispatch.Redirect(urledit);


                    EntryGroup DecoratePersonNewEntry = new EntryGroup("SalePlanDetailNewEntry");

                DecoratePersonNewEntry.Title = "SalePlanDetail";
                DecoratePersonNewEntry.Fill(SalePlanDetail);

                VerticalPanel vpMainPanel = new VerticalPanel();
                vpMainPanel.AddAttribute("width", "100%");
                vpMainPanel.Add(DecoratePersonNewEntry);
                AddContent(vpMainPanel);

                string urldelete = base.UrlDotNet(base.ThisDotNetDll, "RunSalePlanDetailDelete") + "&spde_SalePlanDetailid=" + spde_SalePlanDetailid;
                    base.AddUrlButton("Delete", "Delete.gif", urldelete);


                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mopl_MonthPlanId=" + spde_monthplanid;
                    url = url.Replace("Key37", "SalePlanDetailid");
                url = url + "&Key37=" + spde_monthplanid;
                this.AddUrlButton("cancel", "PrevCircle.gif", url);
                
            }
            catch (Exception error)
            {
                this.AddError(error.Message);
            }
        }
    }
}