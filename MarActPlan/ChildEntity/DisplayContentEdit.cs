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
    public class DisplayContentEdit : Web
    {
        public override void BuildContents()
        {
            AddContent(HTML.Form());

            try
            {
                string hMode = Dispatch.EitherField("HiddenMode");
                string dico_displaycontentid = Dispatch.EitherField("dico_displaycontentid");
                int errorflag = 0;
                string errormessage = string.Empty;
                Record DisplayContent = FindRecord("DisplayContent", "dico_displaycontentid=" + dico_displaycontentid);
                string dico_maractplanid = DisplayContent.GetFieldAsString("dico_maractplanid");
                EntryGroup DisplayContentNewEntry = new EntryGroup("DisplayContentNewEntry");
                DisplayContentNewEntry.Fill(DisplayContent);
                Entry IntentionOrderidEntry = DisplayContentNewEntry.GetEntry("dico_maractplanid");

                IntentionOrderidEntry.ReadOnly = true;

                //AddTabHead("Person");
                //GetTabs("Person", "Person Summary");
                AddTabHead("DisplayContent");
                if (hMode == "Save")
                {

                    ////double original =Person.GetFieldAsDouble("");		    
                    DisplayContentNewEntry.Fill(DisplayContent);
                    ////double  =Person.GetFieldAsDouble("");

                    if (DisplayContentNewEntry.Validate())
                    {
                        DisplayContent.SaveChanges();

                        ////Record BusReport= FindRecord("BusReport", "cpet_competitorid=" + cpet_competitorid);
                        ////double  = BusReport.GetFieldAsDouble("");                        
                        //// =  + - original;
                        ////BusReport.SetField("", );
                        ////BusReport.SaveChanges();

                        string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mapl_MarActPlanId=" + dico_maractplanid + "&J=Summary";
                        url = url.Replace("Key37", "Personid");
                        url = url + "&Key37=" + dico_maractplanid;
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
                    DisplayContentNewEntry.GetHtmlInEditMode(DisplayContent);
                    vpMainPanel.Add(DisplayContentNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("Save", "Save.gif", sUrl);
                    string urldelete = base.UrlDotNet(base.ThisDotNetDll, "RunDisplayContentDelete") + "&dico_displaycontentid=" + dico_displaycontentid;
                    base.AddUrlButton("Delete", "Delete.gif", urldelete);
                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mapl_MarActPlanId=" + dico_maractplanid + "&J=Summary";
                    url = url.Replace("Key37", "DisplayContentid");
                    url = url + "&Key37=" + dico_maractplanid;
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
