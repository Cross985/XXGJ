using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace ServiceAccept
{
    public class CusUseStatusDelete : Web
    {
        public override void BuildContents()
        {
            AddContent(HTML.Form());
            try
            {
                string hMode = Dispatch.EitherField("HiddenMode");
                string id = Dispatch.EitherField("cust_cususestatusid");
                int errorflag = 0;
                string errormessage = string.Empty;
                Record CusUseStatus = FindRecord("CusUseStatus", "cust_cususestatusid=" + id);
                string cust_serviceacceptid = CusUseStatus.GetFieldAsString("cust_serviceacceptid");
                EntryGroup CusUseStatusNewEntry = new EntryGroup("CusUseStatusNewEntry");
                CusUseStatusNewEntry.Fill(CusUseStatus);

                AddTabHead("Delete CusUseStatus");
                if (hMode == "Delete")
                {
                    CusUseStatus.DeleteRecord = true;
                    CusUseStatus.SaveChanges();
                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&seac_ServiceAcceptId=" + cust_serviceacceptid + "&J=Summary";
                    url = url.Replace("Key37", "CusUseStatusid");
                    url = url + "&Key37=" + cust_serviceacceptid;
                    Dispatch.Redirect(url);
                }
                if (errorflag != -1)
                {

                    AddContent(HTML.InputHidden("HiddenMode", ""));
                    VerticalPanel vpMainPanel = new VerticalPanel();
                    vpMainPanel.AddAttribute("width", "100%");
                    string sUrl = "javascript:document.EntryForm.HiddenMode.value='Delete';";
                    CusUseStatusNewEntry.GetHtmlInViewMode(CusUseStatus);
                    vpMainPanel.Add(CusUseStatusNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("ConfirmDelete", "Delete.gif", sUrl);
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
