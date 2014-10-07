using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace MonthPlan
{
    public class DealerDetailDelete : Web
    {
        public override void BuildContents()
        {
            AddContent(HTML.Form());
            try
            {
                string hMode = Dispatch.EitherField("HiddenMode");
                string id = Dispatch.EitherField("ddet_DealerDetailid");
                int errorflag = 0;
                string errormessage = string.Empty;
                Record DealerDetail = FindRecord("DealerDetail", "ddet_DealerDetailid=" + id);
                string ddet_monthplanid = DealerDetail.GetFieldAsString("ddet_monthplanid");
                EntryGroup DecoratePersonNewEntry = new EntryGroup("DealerDetailNewEntry");
                DecoratePersonNewEntry.Fill(DealerDetail);

                AddTabHead("Delete DealerDetail");
                if (hMode == "Delete")
                {
                    DealerDetail.DeleteRecord = true;
                    DealerDetail.SaveChanges();
                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mopl_MonthPlanId=" + ddet_monthplanid + "&J=Summary";
                    url = url.Replace("Key37", "DealerDetailid");
                    url = url + "&Key37=" + ddet_monthplanid;
                    Dispatch.Redirect(url);
                }
                if (errorflag != -1)
                {

                    AddContent(HTML.InputHidden("HiddenMode", ""));
                    VerticalPanel vpMainPanel = new VerticalPanel();
                    vpMainPanel.AddAttribute("width", "100%");
                    string sUrl = "javascript:document.EntryForm.HiddenMode.value='Delete';";
                    DecoratePersonNewEntry.GetHtmlInViewMode(DealerDetail);
                    vpMainPanel.Add(DecoratePersonNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("ConfirmDelete", "Delete.gif", sUrl);
                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mopl_MonthPlanId=" + ddet_monthplanid + "&J=Summary";
                    url = url.Replace("Key37", "DealerDetailid");
                    url = url + "&Key37=" + ddet_monthplanid;
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
