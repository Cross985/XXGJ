using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace MonthPlan
{
    public class SalePlanDetailDelete : Web
    {
        public override void BuildContents()
        {
            AddContent(HTML.Form());
            try
            {
                string hMode = Dispatch.EitherField("HiddenMode");
                string id = Dispatch.EitherField("spde_SalePlanDetailid");
                int errorflag = 0;
                string errormessage = string.Empty;
                Record SalePlanDetail = FindRecord("SalePlanDetail", "spde_SalePlanDetailid=" + id);
                string spde_monthplanid = SalePlanDetail.GetFieldAsString("spde_monthplanid");
                EntryGroup DecoratePersonNewEntry = new EntryGroup("SalePlanDetailNewEntry");
                DecoratePersonNewEntry.Fill(SalePlanDetail);

                AddTabHead("Delete SalePlanDetail");
                if (hMode == "Delete")
                {
                    SalePlanDetail.DeleteRecord = true;
                    SalePlanDetail.SaveChanges();
                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mopl_MonthPlanId=" + spde_monthplanid + "&J=Summary";
                    url = url.Replace("Key37", "SalePlanDetailid");
                    url = url + "&Key37=" + spde_monthplanid;
                    Dispatch.Redirect(url);
                }
                if (errorflag != -1)
                {

                    AddContent(HTML.InputHidden("HiddenMode", ""));
                    VerticalPanel vpMainPanel = new VerticalPanel();
                    vpMainPanel.AddAttribute("width", "100%");
                    string sUrl = "javascript:document.EntryForm.HiddenMode.value='Delete';";
                    DecoratePersonNewEntry.GetHtmlInViewMode(SalePlanDetail);
                    vpMainPanel.Add(DecoratePersonNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("ConfirmDelete", "Delete.gif", sUrl);
                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mopl_MonthPlanId=" + spde_monthplanid + "&J=Summary";
                    url = url.Replace("Key37", "SalePlanDetailid");
                    url = url + "&Key37=" + spde_monthplanid;
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
