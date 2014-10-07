using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace Competitor
{
    public class CpetProductSummary : Web
    {
        string cpet_competitorid = string.Empty;
        string cppr_CpetProductid = string.Empty;
        public override void PreBuildContents()
        {
            GetTabs("Competitor", "Summary");
            AddTopContent(GetCustomEntityTopFrame("CpetProduct"));
            base.PreBuildContents();
        }
        public override void BuildContents()
        {
            try
            {
                string cppr_CpetProductid = Dispatch.EitherField("cppr_CpetProductid");

                Record CpetProduct = FindRecord("CpetProduct", "cppr_CpetProductid=" + cppr_CpetProductid);
                cpet_competitorid = CpetProduct.GetFieldAsString("cppr_competitorid");

                Record order = FindRecord("Competitor", "cpet_competitorid=" + cpet_competitorid);
                int userid = CurrentUser.UserId;

                    string urledit = base.UrlDotNet(base.ThisDotNetDll, "RunCpetProductEdit") + "&cppr_CpetProductid=" + cppr_CpetProductid;
                    Dispatch.Redirect(urledit);

                EntryGroup CpetProductNewEntry = new EntryGroup("CpetProductNewEntry");

                CpetProductNewEntry.Title = "CpetProduct";
                CpetProductNewEntry.Fill(CpetProduct);

                VerticalPanel vpMainPanel = new VerticalPanel();
                vpMainPanel.AddAttribute("width", "100%");
                vpMainPanel.Add(CpetProductNewEntry);
                AddContent(vpMainPanel);
                if (userid == 137 || userid == 43 || userid == 130 || CurrentUser.IsAdmin())
                {
                    string urldelete = base.UrlDotNet(base.ThisDotNetDll, "RunCpetProductDelete") + "&cppr_CpetProductid=" + cppr_CpetProductid;
                    base.AddUrlButton("Delete", "Delete.gif", urldelete);
                }

                string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&cpet_competitorid=" + cpet_competitorid;
                url = url.Replace("Key37", "CpetProductid");
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