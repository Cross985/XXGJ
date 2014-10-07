using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;
using Sage.CRM.Utils;

namespace ServiceAccept
{
    public class CusUseStatusEdit : Web
    {
        public override void BuildContents()
        {
            AddContent(HTML.Form());

            try
            {
                string hMode = Dispatch.EitherField("HiddenMode");
                string cust_cususestatusid = Dispatch.EitherField("cust_cususestatusid");
                int errorflag = 0;
                string errormessage = string.Empty;
                Record CusUseStatus = FindRecord("CusUseStatus", "cust_cususestatusid=" + cust_cususestatusid);
                string cust_serviceacceptid = CusUseStatus.GetFieldAsString("cust_serviceacceptid");
                EntryGroup CusUseStatusNewEntry = new EntryGroup("CusUseStatusNewEntry");
                CusUseStatusNewEntry.Fill(CusUseStatus);
                Entry IntentionOrderidEntry = CusUseStatusNewEntry.GetEntry("cust_serviceacceptid");

                IntentionOrderidEntry.ReadOnly = true;

                //AddTabHead("Person");
                //GetTabs("Person", "Person Summary");
                AddTabHead("CusUseStatus");
                if (hMode == "Save")
                {

                    ////double original =Person.GetFieldAsDouble("");		    
                    CusUseStatusNewEntry.Fill(CusUseStatus);
                    ////double  =Person.GetFieldAsDouble("");

                    if (CusUseStatusNewEntry.Validate())
                    {
                        CusUseStatus.SaveChanges();

                        ////Record BusReport= FindRecord("BusReport", "cpet_competitorid=" + cpet_competitorid);
                        ////double  = BusReport.GetFieldAsDouble("");                        
                        //// =  + - original;
                        ////BusReport.SetField("", );
                        ////BusReport.SaveChanges();

                        string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&seac_ServiceAcceptId=" + cust_serviceacceptid + "&J=Summary";
                        url = url.Replace("Key37", "CusUseStatusid");
                        url = url + "&Key37=" + cust_serviceacceptid;
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
                    CusUseStatusNewEntry.GetHtmlInEditMode(CusUseStatus);
                    vpMainPanel.Add(CusUseStatusNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("Save", "Save.gif", sUrl);
                    string urldelete = base.UrlDotNet(base.ThisDotNetDll, "RunCusUseStatusDelete") + "&cust_cususestatusid=" + cust_cususestatusid;
                    base.AddUrlButton("Delete", "Delete.gif", urldelete);
                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&seac_ServiceAcceptId=" + cust_serviceacceptid + "&J=Summary";
                    url = url.Replace("Key37", "CusUseStatusid");
                    url = url + "&Key37=" + cust_serviceacceptid;
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
