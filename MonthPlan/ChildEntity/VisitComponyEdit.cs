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
    public class VisitComponyEdit : Web
    {
        public override void BuildContents()
        {
            AddContent(HTML.Form());

            try
            {
                string hMode = Dispatch.EitherField("HiddenMode");
                string vico_VisitComponyid = Dispatch.EitherField("vico_VisitComponyid");
                int errorflag = 0;
                string errormessage = string.Empty;
                Record VisitCompony = FindRecord("VisitCompony", "vico_VisitComponyid=" + vico_VisitComponyid);
                string vico_monthplanid = VisitCompony.GetFieldAsString("vico_monthplanid");
                EntryGroup VisitComponyNewEntry = new EntryGroup("VisitComponyNewEntry");
                VisitComponyNewEntry.Fill(VisitCompony);
                Entry IntentionOrderidEntry = VisitComponyNewEntry.GetEntry("vico_monthplanid");

                IntentionOrderidEntry.ReadOnly = true;

                //AddTabHead("Person");
                //GetTabs("Person", "Person Summary");
                AddTabHead("VisitCompony");
                if (hMode == "Save")
                {

                    ////double original =Person.GetFieldAsDouble("");		    
                    VisitComponyNewEntry.Fill(VisitCompony);
                    ////double  =Person.GetFieldAsDouble("");

                    if (VisitComponyNewEntry.Validate())
                    {
                        VisitCompony.SaveChanges();

                        ////Record BusReport= FindRecord("BusReport", "cpet_competitorid=" + cpet_competitorid);
                        ////double  = BusReport.GetFieldAsDouble("");                        
                        //// =  + - original;
                        ////BusReport.SetField("", );
                        ////BusReport.SaveChanges();

                        string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mopl_MonthPlanId=" + vico_monthplanid + "&J=Summary";
                        url = url.Replace("Key37", "VisitComponyid");
                        url = url + "&Key37=" + vico_monthplanid;
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
                    VisitComponyNewEntry.GetHtmlInEditMode(VisitCompony);
                    vpMainPanel.Add(VisitComponyNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("Save", "Save.gif", sUrl);
                    string urldelete = base.UrlDotNet(base.ThisDotNetDll, "RunVisitComponyDelete") + "&vico_VisitComponyid=" + vico_VisitComponyid;
                    base.AddUrlButton("Delete", "Delete.gif", urldelete);
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
