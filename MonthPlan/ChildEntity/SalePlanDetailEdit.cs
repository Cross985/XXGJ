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
    public class SalePlanDetailEdit : Web
    {
        public override void BuildContents()
        {
            AddContent(HTML.Form());

            try
            {
                string hMode = Dispatch.EitherField("HiddenMode");
                string spde_SalePlanDetailid = Dispatch.EitherField("spde_SalePlanDetailid");
                int errorflag = 0;
                string errormessage = string.Empty;
                Record SalePlanDetail = FindRecord("SalePlanDetail", "spde_SalePlanDetailid=" + spde_SalePlanDetailid);
                string spde_monthplanid = SalePlanDetail.GetFieldAsString("spde_monthplanid");
                EntryGroup SalePlanDetailNewEntry = new EntryGroup("SalePlanDetailNewEntry");
                SalePlanDetailNewEntry.Fill(SalePlanDetail);
                Entry IntentionOrderidEntry = SalePlanDetailNewEntry.GetEntry("spde_monthplanid");

                IntentionOrderidEntry.ReadOnly = true;

                //AddTabHead("Person");
                //GetTabs("Person", "Person Summary");
                AddTabHead("SalePlanDetail");
                if (hMode == "Save")
                {

                    ////double original =Person.GetFieldAsDouble("");		    
                    SalePlanDetailNewEntry.Fill(SalePlanDetail);
                    ////double  =Person.GetFieldAsDouble("");

                    if (SalePlanDetailNewEntry.Validate())
                    {
                        SalePlanDetail.SaveChanges();

                        ////Record BusReport= FindRecord("BusReport", "cpet_competitorid=" + cpet_competitorid);
                        ////double  = BusReport.GetFieldAsDouble("");                        
                        //// =  + - original;
                        ////BusReport.SetField("", );
                        ////BusReport.SaveChanges();

                        string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mopl_MonthPlanId=" + spde_monthplanid + "&J=Summary";
                        url = url.Replace("Key37", "Personid");
                        url = url + "&Key37=" + spde_monthplanid;
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
                    SalePlanDetailNewEntry.GetHtmlInEditMode(SalePlanDetail);
                    vpMainPanel.Add(SalePlanDetailNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("Save", "Save.gif", sUrl);
                    string urldelete = base.UrlDotNet(base.ThisDotNetDll, "RunSalePlanDetailDelete") + "&spde_SalePlanDetailid=" + spde_SalePlanDetailid;
                    base.AddUrlButton("Delete", "Delete.gif", urldelete);
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
