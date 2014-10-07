using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace MonthPlan
{
    public class ProcessMethodDelete : Web
    {
        public override void BuildContents()
        {
            AddContent(HTML.Form());
            try
            {
                string hMode = Dispatch.EitherField("HiddenMode");
                string id = Dispatch.EitherField("pmet_ProcessMethodid");
                int errorflag = 0;
                string errormessage = string.Empty;
                Record ProcessMethod = FindRecord("ProcessMethod", "pmet_ProcessMethodid=" + id);
                string pmet_monthplanid = ProcessMethod.GetFieldAsString("pmet_monthplanid");
                EntryGroup DecoratePersonNewEntry = new EntryGroup("ProcessMethodNewEntry");
                DecoratePersonNewEntry.Fill(ProcessMethod);

                AddTabHead("Delete ProcessMethod");
                if (hMode == "Delete")
                {
                    ProcessMethod.DeleteRecord = true;
                    ProcessMethod.SaveChanges();
                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mopl_MonthPlanId=" + pmet_monthplanid + "&J=Summary";
                    url = url.Replace("Key37", "ProcessMethodid");
                    url = url + "&Key37=" + pmet_monthplanid;
                    Dispatch.Redirect(url);
                }
                if (errorflag != -1)
                {

                    AddContent(HTML.InputHidden("HiddenMode", ""));
                    VerticalPanel vpMainPanel = new VerticalPanel();
                    vpMainPanel.AddAttribute("width", "100%");
                    string sUrl = "javascript:document.EntryForm.HiddenMode.value='Delete';";
                    DecoratePersonNewEntry.GetHtmlInViewMode(ProcessMethod);
                    vpMainPanel.Add(DecoratePersonNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("ConfirmDelete", "Delete.gif", sUrl);
                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mopl_MonthPlanId=" + pmet_monthplanid + "&J=Summary";
                    url = url.Replace("Key37", "ProcessMethodid");
                    url = url + "&Key37=" + pmet_monthplanid;
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
