using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace MarActPlan
{
    public class ActualCostSummary : Web
    {
        public override void PreBuildContents()
        {
            GetTabs("ActualCost", "Summary");
            AddTopContent(GetCustomEntityTopFrame("ActualCost"));
            base.PreBuildContents();
        }
        public override void BuildContents()
        {
            try
            {
                string acco_ActualCostid = Dispatch.EitherField("acco_ActualCostid");

                Record ActualCost = FindRecord("ActualCost", "acco_ActualCostid=" + acco_ActualCostid);
                string acco_maractplanid = ActualCost.GetFieldAsString("acco_maractplanid");

               
                int userid = CurrentUser.UserId;

                string urledit = base.UrlDotNet(base.ThisDotNetDll, "RunActualCostEdit") + "&acco_ActualCostid=" + acco_ActualCostid;
                    Dispatch.Redirect(urledit);


                    EntryGroup DecoratePersonNewEntry = new EntryGroup("ActualCostNewEntry");

                DecoratePersonNewEntry.Title = "ActualCost";
                DecoratePersonNewEntry.Fill(ActualCost);

                VerticalPanel vpMainPanel = new VerticalPanel();
                vpMainPanel.AddAttribute("width", "100%");
                vpMainPanel.Add(DecoratePersonNewEntry);
                AddContent(vpMainPanel);

                string urldelete = base.UrlDotNet(base.ThisDotNetDll, "RunActualCostDelete") + "&acco_ActualCostid=" + acco_ActualCostid;
                    base.AddUrlButton("Delete", "Delete.gif", urldelete);


                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mapl_MarActPlanId=" + acco_maractplanid;
                url = url.Replace("Key37", "Personid");
                url = url + "&Key37=" + acco_maractplanid;
                this.AddUrlButton("cancel", "PrevCircle.gif", url);
                
            }
            catch (Exception error)
            {
                this.AddError(error.Message);
            }
        }
    }
}