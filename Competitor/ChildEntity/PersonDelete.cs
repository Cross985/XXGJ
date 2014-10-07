using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace Competitor
{
    public class PersonDelete : Web
    {
        public override void BuildContents()
        {
            AddContent(HTML.Form());
            try
            {
                string hMode = Dispatch.EitherField("HiddenMode");
                string id = Dispatch.EitherField("dper_decoratepersonid");
                int errorflag = 0;
                string errormessage = string.Empty;
                Record DecoratePerson = FindRecord("DecoratePerson", "dper_decoratepersonid=" + id);
                string dper_competitorid = DecoratePerson.GetFieldAsString("dper_competitorid");

                EntryGroup CompetitionPersonNewEntry = new EntryGroup("CompetitionPersonNewEntry");
                CompetitionPersonNewEntry.Fill(DecoratePerson);

                AddTabHead("Delete Person");
                if (hMode == "Delete")
                {
                    DecoratePerson.DeleteRecord = true;
                    DecoratePerson.SaveChanges();

                    ////double  =Person.GetFieldAsDouble("");
                    ////Record BusReport= FindRecord("BusReport", "cpet_competitorid=" + cpet_competitorid);
                    ////double  = BusReport.GetFieldAsDouble("");                        
                    //// =  - ;
                    ////BusReport.SetField("", );
                    ////BusReport.SaveChanges();

                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&cpet_competitorid=" + dper_competitorid + "&J=Summary";
                    url = url.Replace("Key37", "DecoratePersonid");
                    url = url + "&Key37=" + dper_competitorid;
                    Dispatch.Redirect(url);
                }
                if (errorflag != -1)
                {

                    AddContent(HTML.InputHidden("HiddenMode", ""));
                    VerticalPanel vpMainPanel = new VerticalPanel();
                    vpMainPanel.AddAttribute("width", "100%");
                    string sUrl = "javascript:document.EntryForm.HiddenMode.value='Delete';";
                    CompetitionPersonNewEntry.GetHtmlInViewMode(DecoratePerson);
                    vpMainPanel.Add(CompetitionPersonNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("ConfirmDelete", "Delete.gif", sUrl);
                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&cpet_competitorid=" + dper_competitorid + "&J=Summary";
                    url = url.Replace("Key37", "DecoratePersonid");
                    url = url + "&Key37=" + dper_competitorid;
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
