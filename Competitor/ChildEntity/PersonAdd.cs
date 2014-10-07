using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Controls;
using Sage.CRM.UI;
using Sage.CRM.Data;

namespace Competitor
{
    public class PersonAdd : Web
    {
        public override void BuildContents()
        {
            AddContent(HTML.Form());

            try
            {
                string hMode = Dispatch.EitherField("HiddenMode");
                string cpet_competitorid = Dispatch.EitherField("cpet_competitorid");
                int errorflag = 0;
                string errormessage = string.Empty;
                EntryGroup CompetitionPersonNewEntry = new EntryGroup("CompetitionPersonNewEntry");
                //CostAdjustmentProductNewEntry.Title = "Add CostAdjustmentProduct"; 
                Entry bred_busreportidEntry = CompetitionPersonNewEntry.GetEntry("dper_competitorid");
                if (bred_busreportidEntry != null)
                {
                    bred_busreportidEntry.DefaultValue = cpet_competitorid;
                    bred_busreportidEntry.ReadOnly = true;
                }

                AddTabHead("DecoratePerson");
                if (hMode == "Save")
                {
                    Record DecoratePerson = new Record("DecoratePerson");
                    CompetitionPersonNewEntry.Fill(DecoratePerson);
                    if (CompetitionPersonNewEntry.Validate())
                    {
                        DecoratePerson.SaveChanges();
                        string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&cpet_competitorid=" + cpet_competitorid + "&J=Summary";
                        url = url.Replace("Key37", "DecoratePersonid");
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
                    if (errorflag == 2)
                    {
                        AddError(errormessage);
                    }

                    AddContent(HTML.InputHidden("HiddenMode", ""));
                    VerticalPanel vpMainPanel = new VerticalPanel();
                    vpMainPanel.AddAttribute("width", "100%");
                    string sUrl = "javascript:document.EntryForm.HiddenMode.value='Save';";
                    CompetitionPersonNewEntry.GetHtmlInEditMode();
                    vpMainPanel.Add(CompetitionPersonNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("Save", "Save.gif", sUrl);
                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&cpet_competitorid=" + cpet_competitorid + "&J=Summary";
                    url = url.Replace("Key37", "Personid");
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
