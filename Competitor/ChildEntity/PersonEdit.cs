using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;
using Sage.CRM.Utils;

namespace Competitor
{
    public class PersonEdit : Web
    {
        public override void BuildContents()
        {
            AddContent(HTML.Form());

            try
            {
                string hMode = Dispatch.EitherField("HiddenMode");
                string dper_decoratepersonid = Dispatch.EitherField("dper_decoratepersonid");
                int errorflag = 0;
                string errormessage = string.Empty;
                Record DecoratePerson = FindRecord("DecoratePerson", "dper_decoratepersonid=" + dper_decoratepersonid);
                string cpet_competitorid = DecoratePerson.GetFieldAsString("dper_competitorid");
                EntryGroup CompetitionPersonNewEntry = new EntryGroup("CompetitionPersonNewEntry");
                CompetitionPersonNewEntry.Fill(DecoratePerson);
                Entry IntentionOrderidEntry = CompetitionPersonNewEntry.GetEntry("dper_competitorid");

                IntentionOrderidEntry.ReadOnly = true;

                //AddTabHead("Person");
                //GetTabs("Person", "Person Summary");
                AddTabHead("DecoratePerson");
                if (hMode == "Save")
                {

                    ////double original =Person.GetFieldAsDouble("");		    
                    CompetitionPersonNewEntry.Fill(DecoratePerson);
                    ////double  =Person.GetFieldAsDouble("");

                    if (CompetitionPersonNewEntry.Validate())
                    {
                        DecoratePerson.SaveChanges();

                        ////Record BusReport= FindRecord("BusReport", "cpet_competitorid=" + cpet_competitorid);
                        ////double  = BusReport.GetFieldAsDouble("");                        
                        //// =  + - original;
                        ////BusReport.SetField("", );
                        ////BusReport.SaveChanges();

                        string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&cpet_competitorid=" + cpet_competitorid + "&J=Summary";
                        url = url.Replace("Key37", "Personid");
                        url = url + "&Key37=" + cpet_competitorid;
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
                    CompetitionPersonNewEntry.GetHtmlInEditMode(DecoratePerson);
                    vpMainPanel.Add(CompetitionPersonNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("Save", "Save.gif", sUrl);
                    string urldelete = base.UrlDotNet(base.ThisDotNetDll, "RunPersonDelete") + "&dper_decoratepersonid=" + dper_decoratepersonid;
                    base.AddUrlButton("Delete", "Delete.gif", urldelete);
                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&cpet_competitorid=" + cpet_competitorid + "&J=Summary";
                    url = url.Replace("Key37", "DecoratePersonid");
                    url = url + "&Key37=" + cpet_competitorid;
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
