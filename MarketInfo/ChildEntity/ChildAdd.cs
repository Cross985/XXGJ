using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Controls;
using Sage.CRM.UI;
using Sage.CRM.Data;

namespace MarketInfo
{
    public class BrandRateAdd : Web
    {
        public override void BuildContents()
        {
            AddContent(HTML.Form());

            try
            {
                string hMode = Dispatch.EitherField("HiddenMode");
                string maif_MarketInfoId = Dispatch.EitherField("maif_MarketInfoId");
                int errorflag = 0;
                string errormessage = string.Empty;
                EntryGroup BrandRateNewEntry = new EntryGroup("BrandRateNewEntry");
                //CostAdjustmentProductNewEntry.Title = "Add CostAdjustmentProduct"; 
                Entry brra_marketinfoidEntry = BrandRateNewEntry.GetEntry("brra_marketinfoid");
                if (brra_marketinfoidEntry != null)
                {
                    brra_marketinfoidEntry.DefaultValue = maif_MarketInfoId;
                    brra_marketinfoidEntry.ReadOnly = true;
                }

                AddTabHead("BrandRate");
                if (hMode == "Save")
                {
                    Record BrandRate = new Record("BrandRate");
                    BrandRateNewEntry.Fill(BrandRate);
                    if (BrandRateNewEntry.Validate())
                    {
                        //QuerySelect s = new QuerySelect();
                        //string prefix = "bred" + DateTime.Now.ToString("yyyyMMdd");
                        //s.SQLCommand = "select count(*) as count from BrandRate where brra_name like '" + prefix + "%'";
                        //s.ExecuteReader();
                        //int cnt = 0;
                        //if (!s.Eof())
                        //{
                        //    cnt = Convert.ToInt32(s.FieldValue("count"));
                        //}
                        //string code = string.Empty;
                        //code = prefix + (cnt + 1).ToString().PadLeft(4, '0');
                        //BrandRate.SetField("brra_name", code);
                        BrandRate.SaveChanges();
                        ////Record MarketInfo= FindRecord("MarketInfo", "maif_MarketInfoId=" + maif_MarketInfoId);
                        ////double  = MarketInfo.GetFieldAsDouble("");
                        ////double  =BrandRate.GetFieldAsDouble("");
                        //// =  + ;
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
                    if (errorflag == 2)
                    {
                        AddError(errormessage);
                    }

                    AddContent(HTML.InputHidden("HiddenMode", ""));
                    VerticalPanel vpMainPanel = new VerticalPanel();
                    vpMainPanel.AddAttribute("width", "100%");
                    string sUrl = "javascript:document.EntryForm.HiddenMode.value='Save';";
                    BrandRateNewEntry.GetHtmlInEditMode();
                    vpMainPanel.Add(BrandRateNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("Save", "Save.gif", sUrl);
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
