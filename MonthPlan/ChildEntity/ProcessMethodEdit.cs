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
    public class ProcessMethodEdit : Web
    {
        public override void BuildContents()
        {
            AddContent(HTML.Form());

            try
            {
                string hMode = Dispatch.EitherField("HiddenMode");
                string pmet_ProcessMethodid = Dispatch.EitherField("pmet_ProcessMethodid");
                int errorflag = 0;
                string errormessage = string.Empty;
                Record ProcessMethod = FindRecord("ProcessMethod", "pmet_ProcessMethodid=" + pmet_ProcessMethodid);
                string pmet_monthplanid = ProcessMethod.GetFieldAsString("pmet_monthplanid");
                EntryGroup ProcessMethodNewEntry = new EntryGroup("ProcessMethodNewEntry");
                ProcessMethodNewEntry.Fill(ProcessMethod);
                Entry IntentionOrderidEntry = ProcessMethodNewEntry.GetEntry("pmet_monthplanid");

                IntentionOrderidEntry.ReadOnly = true;

                //AddTabHead("Person");
                //GetTabs("Person", "Person Summary");
                AddTabHead("ProcessMethod");
                if (hMode == "Save")
                {

                    ////double original =Person.GetFieldAsDouble("");		    
                    ProcessMethodNewEntry.Fill(ProcessMethod);
                    ////double  =Person.GetFieldAsDouble("");

                    if (ProcessMethodNewEntry.Validate())
                    {
                        ProcessMethod.SaveChanges();

                        ////Record BusReport= FindRecord("BusReport", "cpet_competitorid=" + cpet_competitorid);
                        ////double  = BusReport.GetFieldAsDouble("");                        
                        //// =  + - original;
                        ////BusReport.SetField("", );
                        ////BusReport.SaveChanges();

                        string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mopl_MonthPlanId=" + pmet_monthplanid + "&J=Summary";
                        url = url.Replace("Key37", "Personid");
                        url = url + "&Key37=" + pmet_monthplanid;
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
                    ProcessMethodNewEntry.GetHtmlInEditMode(ProcessMethod);
                    vpMainPanel.Add(ProcessMethodNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("Save", "Save.gif", sUrl);
                    string urldelete = base.UrlDotNet(base.ThisDotNetDll, "RunProcessMethodDelete") + "&pmet_ProcessMethodid=" + pmet_ProcessMethodid;
                    base.AddUrlButton("Delete", "Delete.gif", urldelete);
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
