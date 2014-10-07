using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace MonthPlan
{
    public class VisitComponyDelete : Web
    {
        public override void BuildContents()
        {
            AddContent(HTML.Form());
            try
            {
                string hMode = Dispatch.EitherField("HiddenMode");
                string id = Dispatch.EitherField("vico_VisitComponyid");
                int errorflag = 0;
                string errormessage = string.Empty;
                Record VisitCompony = FindRecord("VisitCompony", "vico_VisitComponyid=" + id);
                string vico_monthplanid = VisitCompony.GetFieldAsString("vico_monthplanid");
                EntryGroup VisitComponyNewEntry = new EntryGroup("VisitComponyNewEntry");
                VisitComponyNewEntry.Fill(VisitCompony);

                AddTabHead("Delete VisitCompony");
                if (hMode == "Delete")
                {
                    VisitCompony.DeleteRecord = true;
                    VisitCompony.SaveChanges();
                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mopl_MonthPlanId=" + vico_monthplanid + "&J=Summary";
                    url = url.Replace("Key37", "VisitComponyid");
                    url = url + "&Key37=" + vico_monthplanid;
                    Dispatch.Redirect(url);
                }
                if (errorflag != -1)
                {

                    AddContent(HTML.InputHidden("HiddenMode", ""));
                    VerticalPanel vpMainPanel = new VerticalPanel();
                    vpMainPanel.AddAttribute("width", "100%");
                    string sUrl = "javascript:document.EntryForm.HiddenMode.value='Delete';";
                    VisitComponyNewEntry.GetHtmlInViewMode(VisitCompony);
                    vpMainPanel.Add(VisitComponyNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("ConfirmDelete", "Delete.gif", sUrl);
                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mopl_MonthPlanId=" + vico_monthplanid + "&J=Summary";
                    url = url.Replace("Key37", "VisitComponyid");
                    url = url + "&Key37=" + vico_monthplanid;
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
