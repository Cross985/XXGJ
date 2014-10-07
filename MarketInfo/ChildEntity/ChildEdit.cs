using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;
using Sage.CRM.Utils;

namespace MarketInfo
{
    public class BrandRateEdit : Web
    {
        public override void BuildContents()
        {
            AddContent(HTML.Form());

            try
            {
                string hMode = Dispatch.EitherField("HiddenMode");
                string brra_BrandRateId = Dispatch.EitherField("brra_BrandRateId");
                int errorflag = 0;
                string errormessage = string.Empty;
                Record BrandRate = FindRecord("BrandRate", "brra_BrandRateId=" + brra_BrandRateId);
                string maif_MarketInfoId = BrandRate.GetFieldAsString("brra_marketinfoid");
                EntryGroup BrandRateNewEntry = new EntryGroup("BrandRateNewEntry");
                BrandRateNewEntry.Fill(BrandRate);
                Entry IntentionOrderidEntry = BrandRateNewEntry.GetEntry("brra_marketinfoid");

                IntentionOrderidEntry.ReadOnly = true;

                AddTabHead("BrandRate");
                if (hMode == "Save")
                {

                    ////double original =BrandRate.GetFieldAsDouble("");		    
                    BrandRateNewEntry.Fill(BrandRate);
                    ////double  =BrandRate.GetFieldAsDouble("");

                    if (BrandRateNewEntry.Validate())
                    {
                        BrandRate.SaveChanges();

                        ////Record MarketInfo= FindRecord("MarketInfo", "maif_MarketInfoId=" + maif_MarketInfoId);
                        ////double  = MarketInfo.GetFieldAsDouble("");                        
                        //// =  + - original;
                        ////MarketInfo.SetField("", );
                        ////MarketInfo.SaveChanges();

                        string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&maif_MarketInfoId=" + maif_MarketInfoId + "&J=Summary";
                        url = url.Replace("Key37", "BrandRateid");
                        url = url + "&Key37=" + maif_MarketInfoId;
                        Dispatch.Redirect(url);
                        errorflag = -1;
                    }
                    else
                    {
                        errorflag = 1;
                    }

                }
                if (errorflag != -1)
                {

                    AddContent(HTML.InputHidden("HiddenMode", ""));
                    VerticalPanel vpMainPanel = new VerticalPanel();
                    vpMainPanel.AddAttribute("width", "100%");
                    string sUrl = "javascript:document.EntryForm.HiddenMode.value='Save';";
                    BrandRateNewEntry.GetHtmlInEditMode(BrandRate);
                    vpMainPanel.Add(BrandRateNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("Save", "Save.gif", sUrl);
                    string urldelete = base.UrlDotNet(base.ThisDotNetDll, "RunBrandRateDelete") + "&brra_BrandRateId=" + brra_BrandRateId;
                    base.AddUrlButton("Delete", "Delete.gif", urldelete);
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
