using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace Competitor
{
    public class MarketActivitySummary : Web
    {
        string cpet_competitorid = string.Empty;
        string mact_MarketActivityid = string.Empty;
        public override void PreBuildContents()
        {
            GetTabs("Competitor", "Summary");
            AddTopContent(GetCustomEntityTopFrame("MarketActivity"));
            base.PreBuildContents();
        }
        public override void BuildContents()
        {
            try
            {
                string mact_MarketActivityid = Dispatch.EitherField("mact_MarketActivityid");

                Record MarketActivity = FindRecord("MarketActivity", "mact_MarketActivityid=" + mact_MarketActivityid);
                cpet_competitorid = MarketActivity.GetFieldAsString("mact_competitorid");

                Record order = FindRecord("Competitor", "cpet_competitorid=" + cpet_competitorid);
                int userid = CurrentUser.UserId;
                if (userid == 137 || userid == 43 || userid == 130 || CurrentUser.IsAdmin())
                {
                    string urledit = base.UrlDotNet(base.ThisDotNetDll, "RunMarketActivityEdit") + "&mact_MarketActivityid=" + mact_MarketActivityid;
                    Dispatch.Redirect(urledit);
                }

                EntryGroup MarketActivityNewEntry = new EntryGroup("MarketActivityNewEntry");

                MarketActivityNewEntry.Title = "MarketActivity";
                MarketActivityNewEntry.Fill(MarketActivity);

                VerticalPanel vpMainPanel = new VerticalPanel();
                vpMainPanel.AddAttribute("width", "100%");
                vpMainPanel.Add(MarketActivityNewEntry);
                AddContent(vpMainPanel);
                if (userid == 137 || userid == 43 || userid == 130 || CurrentUser.IsAdmin())
                {
                    string urldelete = base.UrlDotNet(base.ThisDotNetDll, "RunMarketActivityDelete") + "&mact_MarketActivityid=" + mact_MarketActivityid;
                    base.AddUrlButton("Delete", "Delete.gif", urldelete);
                }

                string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&cpet_competitorid=" + cpet_competitorid;
                url = url.Replace("Key37", "MarketActivityid");
                url = url + "&Key37=" + cpet_competitorid;
                this.AddUrlButton("cancel", "PrevCircle.gif", url);
                
            }
            catch (Exception error)
            {
                this.AddError(error.Message);
            }
        }
    }
}