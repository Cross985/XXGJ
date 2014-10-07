using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace MarketInfo
{
    public class BrandRateSummary : Web
    {
        string maif_MarketInfoId = string.Empty;
        string brra_BrandRateId = string.Empty;
        public override void PreBuildContents()
        {
            GetTabs("BrandRate", "Summary");
            AddTopContent(GetCustomEntityTopFrame("BrandRate"));
            base.PreBuildContents();
        }
        public override void BuildContents()
        {
            try
            {
                string brra_BrandRateId = Dispatch.EitherField("brra_BrandRateId");

                Record BrandRate = FindRecord("BrandRate", "brra_BrandRateId=" + brra_BrandRateId);
                maif_MarketInfoId = BrandRate.GetFieldAsString("brra_marketinfoid");

                Record order = FindRecord("MarketInfo", "maif_MarketInfoId=" + maif_MarketInfoId);
                string status = order.GetFieldAsString("maif_status");
               // if (status == "draft")
                //{
                    string urledit = base.UrlDotNet(base.ThisDotNetDll, "RunBrandRateEdit") + "&brra_BrandRateId=" + brra_BrandRateId;
                    Dispatch.Redirect(urledit);
                //}

                EntryGroup BrandRateNewEntry = new EntryGroup("BrandRateNewEntry");

                BrandRateNewEntry.Title = "BrandRate";
                BrandRateNewEntry.Fill(BrandRate);

                VerticalPanel vpMainPanel = new VerticalPanel();
                vpMainPanel.AddAttribute("width", "100%");
                vpMainPanel.Add(BrandRateNewEntry);
                AddContent(vpMainPanel);
                string urldelete = base.UrlDotNet(base.ThisDotNetDll, "RunBrandRateDelete") + "&brra_BrandRateId=" + brra_BrandRateId;
                base.AddUrlButton("Delete", "Delete.gif", urldelete);

                string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&maif_MarketInfoId=" + maif_MarketInfoId;
                url = url.Replace("Key37", "BrandRateid");
                url = url + "&Key37=" + maif_MarketInfoId;
                this.AddUrlButton("cancel", "PrevCircle.gif", url);
                AddWorkflowButtons("BrandRate");
            }
            catch (Exception error)
            {
                this.AddError(error.Message);
            }
        }
    }
}