using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace MarketInfo.DataPages
{
    public class MarketInfoDataPage : Web
    {

        public override void PreBuildContents()
        {
            GetTabs("MarketInfo", "Summary");
            AddTopContent(GetCustomEntityTopFrame("MarketInfo"));
            base.PreBuildContents();
        }
        public override void BuildContents()
        {
            try
            {
                string maif_MarketInfoId = Dispatch.EitherField("maif_MarketInfoId");
                if (string.IsNullOrEmpty(maif_MarketInfoId))
                {
                    maif_MarketInfoId = Dispatch.EitherField("key58");
                }

                Record MarketInfo = FindRecord("MarketInfo", "maif_MarketInfoId=" + maif_MarketInfoId);

                EntryGroup screenMarketInfo = new EntryGroup("MarketInfoNewEntry");
                screenMarketInfo.Title = "MarketInfo";
                screenMarketInfo.Fill(MarketInfo);

                string status = MarketInfo.GetFieldAsString("maif_status");

                VerticalPanel vpMainPanel = new VerticalPanel();
                vpMainPanel.AddAttribute("width", "100%");
                vpMainPanel.Add(screenMarketInfo);

                List BrandRateGrid = new List("BrandRateGrid");
                BrandRateGrid.Filter = "brra_deleted is null and brra_marketinfoid=" + maif_MarketInfoId;
                BrandRateGrid.RowsPerScreen = 500;
                BrandRateGrid.ShowNavigationButtons = true;
                BrandRateGrid.PadBottom = false;
                vpMainPanel.Add(BrandRateGrid);

                AddContent(vpMainPanel);
               // if (status.ToLower() == "draft")
                //{
                    AddUrlButton("Edit", "Edit.gif", UrlDotNet(ThisDotNetDll, "RunDataPageEdit") + "&maif_MarketInfoId=" + maif_MarketInfoId);
                    AddUrlButton("Delete", "Delete.gif", UrlDotNet(ThisDotNetDll, "RunDataPageDelete") + "&maif_MarketInfoId=" + maif_MarketInfoId);
                    AddUrlButton("Add BrandRate", "new.gif", UrlDotNet(ThisDotNetDll, "RunBrandRateAdd") + "&maif_MarketInfoId=" + maif_MarketInfoId);
               // }

                    AddUrlButton("Continue", "Continue.gif", UrlDotNet(ThisDotNetDll, "RunListPage"));
                    //AddWorkflowButtons("MarketInfo");
            }
            catch (Exception error)
            {
                this.AddError(error.Message);
            }
        }
    }
}