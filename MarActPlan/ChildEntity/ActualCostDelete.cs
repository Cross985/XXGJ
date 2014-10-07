using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace MarActPlan
{
    public class ActualCostDelete : Web
    {
        public override void BuildContents()
        {
            AddContent(HTML.Form());
            try
            {
                string hMode = Dispatch.EitherField("HiddenMode");
                string id = Dispatch.EitherField("acco_ActualCostid");
                int errorflag = 0;
                string errormessage = string.Empty;
                Record ActualCost = FindRecord("ActualCost", "acco_ActualCostid=" + id);
                string acco_maractplanid = ActualCost.GetFieldAsString("acco_maractplanid");
                EntryGroup DecoratePersonNewEntry = new EntryGroup("ActualCostNewEntry");
                DecoratePersonNewEntry.Fill(ActualCost);

                AddTabHead("Delete Person");
                if (hMode == "Delete")
                {
                    ActualCost.DeleteRecord = true;
                    ActualCost.SaveChanges();
                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mapl_MarActPlanId=" + acco_maractplanid + "&J=Summary";
                    url = url.Replace("Key37", "ActualCostid");
                    url = url + "&Key37=" + acco_maractplanid;
                    Dispatch.Redirect(url);
                }
                if (errorflag != -1)
                {

                    AddContent(HTML.InputHidden("HiddenMode", ""));
                    VerticalPanel vpMainPanel = new VerticalPanel();
                    vpMainPanel.AddAttribute("width", "100%");
                    string sUrl = "javascript:document.EntryForm.HiddenMode.value='Delete';";
                    DecoratePersonNewEntry.GetHtmlInViewMode(ActualCost);
                    vpMainPanel.Add(DecoratePersonNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("ConfirmDelete", "Delete.gif", sUrl);
                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mapl_MarActPlanId=" + acco_maractplanid + "&J=Summary";
                    url = url.Replace("Key37", "Personid");
                    url = url + "&Key37=" + acco_maractplanid;
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
