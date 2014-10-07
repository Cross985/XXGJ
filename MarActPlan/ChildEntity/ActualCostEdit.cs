using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;
using Sage.CRM.Utils;

namespace MarActPlan
{
    public class ActualCostEdit : Web
    {
        public override void BuildContents()
        {
            AddContent(HTML.Form());

            try
            {
                string hMode = Dispatch.EitherField("HiddenMode");
                string acco_ActualCostid = Dispatch.EitherField("acco_ActualCostid");
                int errorflag = 0;
                string errormessage = string.Empty;
                Record ActualCost = FindRecord("ActualCost", "acco_ActualCostid=" + acco_ActualCostid);
                string acco_maractplanid = ActualCost.GetFieldAsString("acco_maractplanid");
                EntryGroup ActualCostNewEntry = new EntryGroup("ActualCostNewEntry");
                ActualCostNewEntry.Fill(ActualCost);
                Entry IntentionOrderidEntry = ActualCostNewEntry.GetEntry("acco_maractplanid");

                IntentionOrderidEntry.ReadOnly = true;

                //AddTabHead("Person");
                //GetTabs("Person", "Person Summary");
                AddTabHead("ActualCost");
                if (hMode == "Save")
                {

                    ////double original =Person.GetFieldAsDouble("");		    
                    ActualCostNewEntry.Fill(ActualCost);
                    ////double  =Person.GetFieldAsDouble("");

                    if (ActualCostNewEntry.Validate())
                    {
                        ActualCost.SaveChanges();

                        ////Record BusReport= FindRecord("BusReport", "cpet_competitorid=" + cpet_competitorid);
                        ////double  = BusReport.GetFieldAsDouble("");                        
                        //// =  + - original;
                        ////BusReport.SetField("", );
                        ////BusReport.SaveChanges();

                        string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mapl_MarActPlanId=" + acco_maractplanid + "&J=Summary";
                        url = url.Replace("Key37", "Personid");
                        url = url + "&Key37=" + acco_maractplanid;
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
                    ActualCostNewEntry.GetHtmlInEditMode(ActualCost);
                    vpMainPanel.Add(ActualCostNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("Save", "Save.gif", sUrl);
                    string urldelete = base.UrlDotNet(base.ThisDotNetDll, "RunActualCostDelete") + "&acco_ActualCostid=" + acco_ActualCostid;
                    base.AddUrlButton("Delete", "Delete.gif", urldelete);
                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mapl_MarActPlanId=" + acco_maractplanid + "&J=Summary";
                    url = url.Replace("Key37", "ActualCostid");
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
