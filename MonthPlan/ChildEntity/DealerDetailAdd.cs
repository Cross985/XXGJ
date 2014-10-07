using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Controls;
using Sage.CRM.UI;
using Sage.CRM.Data;

namespace MonthPlan
{
    public class DealerDetailAdd : Web
    {
        public override void BuildContents()
        {
            AddContent(HTML.Form());

            try
            {
                string hMode = Dispatch.EitherField("HiddenMode");
                string mopl_MonthPlanId = Dispatch.EitherField("mopl_MonthPlanId");
                int errorflag = 0;
                string errormessage = string.Empty;
                EntryGroup DealerDetailNewEntry = new EntryGroup("DealerDetailNewEntry");
                //CostAdjustmentProductNewEntry.Title = "Add CostAdjustmentProduct"; 
                Entry bred_busreportidEntry = DealerDetailNewEntry.GetEntry("ddet_monthplanid");
                if (bred_busreportidEntry != null)
                {
                    bred_busreportidEntry.DefaultValue = mopl_MonthPlanId;
                    bred_busreportidEntry.ReadOnly = true;
                }

                AddTabHead("DecoratePerson");
                if (hMode == "Save")
                {
                    Record DealerDetail = new Record("DealerDetail");
                    DealerDetailNewEntry.Fill(DealerDetail);
                    if (DealerDetailNewEntry.Validate())
                    {
                        DealerDetail.SaveChanges();
                        string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mopl_MonthPlanId=" + mopl_MonthPlanId + "&J=Summary";
                        url = url.Replace("Key37", "DecorateCompid");
                        url = url + "&Key37=" + mopl_MonthPlanId;
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
                    DealerDetailNewEntry.GetHtmlInEditMode();
                    vpMainPanel.Add(DealerDetailNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("Save", "Save.gif", sUrl);
                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mopl_MonthPlanId=" + mopl_MonthPlanId + "&J=Summary";
                    url = url.Replace("Key37", "DecoratePersonid");
                    url = url + "&Key37=" + mopl_MonthPlanId;
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
