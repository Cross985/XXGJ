using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;
using Sage.CRM.Utils;

namespace MonthPlan
{
    public class PlanDetailEdit : Web
    {
        public override void BuildContents()
        {
            AddContent(HTML.Form());

            try
            {
                string hMode = Dispatch.EitherField("HiddenMode");
                string plde_PlanDetailid = Dispatch.EitherField("plde_PlanDetailid");
                int errorflag = 0;
                string errormessage = string.Empty;
                Record PlanDetail = FindRecord("PlanDetail", "plde_PlanDetailid=" + plde_PlanDetailid);
                string plde_monthplanid = PlanDetail.GetFieldAsString("plde_monthplanid");
                EntryGroup PlanDetailNewEntry = new EntryGroup("PlanDetailNewEntry");
                PlanDetailNewEntry.Fill(PlanDetail);
                Entry IntentionOrderidEntry = PlanDetailNewEntry.GetEntry("plde_monthplanid");

                IntentionOrderidEntry.ReadOnly = true;

                //AddTabHead("Person");
                //GetTabs("Person", "Person Summary");
                AddTabHead("PlanDetail");
                if (hMode == "Save")
                {

                    ////double original =Person.GetFieldAsDouble("");		    
                    PlanDetailNewEntry.Fill(PlanDetail);
                    ////double  =Person.GetFieldAsDouble("");

                    if (PlanDetailNewEntry.Validate())
                    {
                        PlanDetail.SaveChanges();

                        ////Record BusReport= FindRecord("BusReport", "cpet_competitorid=" + cpet_competitorid);
                        ////double  = BusReport.GetFieldAsDouble("");                        
                        //// =  + - original;
                        ////BusReport.SetField("", );
                        ////BusReport.SaveChanges();

                        string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mopl_MonthPlanId=" + plde_monthplanid + "&J=Summary";
                        url = url.Replace("Key37", "Personid");
                        url = url + "&Key37=" + plde_monthplanid;
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
                    PlanDetailNewEntry.GetHtmlInEditMode(PlanDetail);
                    vpMainPanel.Add(PlanDetailNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("Save", "Save.gif", sUrl);
                    string urldelete = base.UrlDotNet(base.ThisDotNetDll, "RunPlanDetailDelete") + "&plde_PlanDetailid=" + plde_PlanDetailid;
                    base.AddUrlButton("Delete", "Delete.gif", urldelete);
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
