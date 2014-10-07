using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace MonthPlan
{
    public class PlanDetailDelete : Web
    {
        public override void BuildContents()
        {
            AddContent(HTML.Form());
            try
            {
                string hMode = Dispatch.EitherField("HiddenMode");
                string id = Dispatch.EitherField("plde_PlanDetailid");
                int errorflag = 0;
                string errormessage = string.Empty;
                Record PlanDetail = FindRecord("PlanDetail", "plde_PlanDetailid=" + id);
                string plde_monthplanid = PlanDetail.GetFieldAsString("plde_monthplanid");
                EntryGroup DecoratePersonNewEntry = new EntryGroup("PlanDetailNewEntry");
                DecoratePersonNewEntry.Fill(PlanDetail);

                AddTabHead("Delete PlanDetail");
                if (hMode == "Delete")
                {
                    PlanDetail.DeleteRecord = true;
                    PlanDetail.SaveChanges();
                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mopl_MonthPlanId=" + plde_monthplanid + "&J=Summary";
                    url = url.Replace("Key37", "PlanDetailid");
                    url = url + "&Key37=" + plde_monthplanid;
                    Dispatch.Redirect(url);
                }
                if (errorflag != -1)
                {

                    AddContent(HTML.InputHidden("HiddenMode", ""));
                    VerticalPanel vpMainPanel = new VerticalPanel();
                    vpMainPanel.AddAttribute("width", "100%");
                    string sUrl = "javascript:document.EntryForm.HiddenMode.value='Delete';";
                    DecoratePersonNewEntry.GetHtmlInViewMode(PlanDetail);
                    vpMainPanel.Add(DecoratePersonNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("ConfirmDelete", "Delete.gif", sUrl);
                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mopl_MonthPlanId=" + plde_monthplanid + "&J=Summary";
                    url = url.Replace("Key37", "PlanDetailid");
                    url = url + "&Key37=" + plde_monthplanid;
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
