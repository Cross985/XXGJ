using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace MarketInfo
{
    public class BrandRateDelete : Web
    {
        public override void BuildContents()
        {
            AddContent(HTML.Form());
            try
            {
                string hMode = Dispatch.EitherField("HiddenMode");
                string id = Dispatch.EitherField("brra_BrandRateId");
                int errorflag = 0;
                string errormessage = string.Empty;
                Record BrandRate = FindRecord("BrandRate", "brra_BrandRateId=" + id);
                string maif_MarketInfoId = BrandRate.GetFieldAsString("brra_marketinfoid");
                EntryGroup BrandRateNewEntry = new EntryGroup("BrandRateNewEntry");
                BrandRateNewEntry.Fill(BrandRate);

                AddTabHead("Delete BrandRate");
                if (hMode == "Delete")
                {
                    BrandRate.DeleteRecord = true;
                    BrandRate.SaveChanges();

                    ////double  =BrandRate.GetFieldAsDouble("");
                    ////Record MarketInfo= FindRecord("MarketInfo", "maif_MarketInfoId=" + maif_MarketInfoId);
                    ////double  = MarketInfo.GetFieldAsDouble("");                        
                    //// =  - ;
                    ////MarketInfo.SetField("", );
                    ////MarketInfo.SaveChanges();

                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&maif_MarketInfoId=" + maif_MarketInfoId + "&J=Summary";
                    url = url.Replace("Key37", "BrandRateid");
                    url = url + "&Key37=" + maif_MarketInfoId;
                    Dispatch.Redirect(url);
                }
                if (errorflag != -1)
                {

                    AddContent(HTML.InputHidden("HiddenMode", ""));
                    VerticalPanel vpMainPanel = new VerticalPanel();
                    vpMainPanel.AddAttribute("width", "100%");
                    string sUrl = "javascript:document.EntryForm.HiddenMode.value='Delete';";
                    BrandRateNewEntry.GetHtmlInViewMode(BrandRate);
                    vpMainPanel.Add(BrandRateNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("ConfirmDelete", "Delete.gif", sUrl);
                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&maif_MarketInfoId=" + maif_MarketInfoId + "&J=Summary";
                    url = url.Replace("Key37", "BrandRateid");
                    url = url + "&Key37=" + maif_MarketInfoId;
                    AddUrlButton("Cancel", "cancel.gif", url);
                }

            }
            catch (Exception e)
            {
                AddError(e.Message);
            }
        }
    }
}
