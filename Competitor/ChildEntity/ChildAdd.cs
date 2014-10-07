using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Controls;
using Sage.CRM.UI;
using Sage.CRM.Data;

namespace Competitor
{
    public class CpetProductAdd : Web
    {
        public override void BuildContents()
        {
            AddContent(HTML.Form());

            try
            {
                string hMode = Dispatch.EitherField("HiddenMode");
                string cpet_competitorid = Dispatch.EitherField("cpet_competitorid");
                int errorflag = 0;
                string errormessage = string.Empty;
                EntryGroup CpetProductNewEntry = new EntryGroup("CpetProductNewEntry");
                //CostAdjustmentProductNewEntry.Title = "Add CostAdjustmentProduct"; 
                Entry bred_busreportidEntry = CpetProductNewEntry.GetEntry("cppr_competitorid");
                if (bred_busreportidEntry != null)
                {
                    bred_busreportidEntry.DefaultValue = cpet_competitorid;
                    bred_busreportidEntry.ReadOnly = true;
                }

                AddTabHead("CpetProduct");
                if (hMode == "Save")
                {
                    Record CpetProduct = new Record("CpetProduct");
                    CpetProductNewEntry.Fill(CpetProduct);
                    if (CpetProductNewEntry.Validate())
                    {
                        //QuerySelect s = new QuerySelect();
                        //string prefix = "bred" + DateTime.Now.ToString("yyyyMMdd");
                        //s.SQLCommand = "select count(*) as count from CpetProduct where bred_name like '" + prefix + "%'";
                        //s.ExecuteReader();
                        //int cnt = 0;
                        //if (!s.Eof())
                        //{
                        //    cnt = Convert.ToInt32(s.FieldValue("count"));
                        //}
                        //string code = string.Empty;
                        //code = prefix + (cnt + 1).ToString().PadLeft(4, '0');
                        //CpetProduct.SetField("bred_name", code);
                        CpetProduct.SaveChanges();
                        ////Record BusReport= FindRecord("BusReport", "cpet_competitorid=" + cpet_competitorid);
                        ////double  = BusReport.GetFieldAsDouble("");
                        ////double  =CpetProduct.GetFieldAsDouble("");
                        //// =  + ;
                        ////BusReport.SetField("", );
                        ////BusReport.SaveChanges();
                        string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&cpet_competitorid=" + cpet_competitorid + "&J=Summary";
                        url = url.Replace("Key37", "CpetProductid");
                        url = url + "&Key37=" + cpet_competitorid;
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
                    CpetProductNewEntry.GetHtmlInEditMode();
                    vpMainPanel.Add(CpetProductNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("Save", "Save.gif", sUrl);
                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&cpet_competitorid=" + cpet_competitorid + "&J=Summary";
                    url = url.Replace("Key37", "CpetProductid");
                    url = url + "&Key37=" + cpet_competitorid;
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
