using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace Competitor
{
    public class PersonSummary : Web
    {
        string cpet_competitorid = string.Empty;
        public override void PreBuildContents()
        {
            GetTabs("Competitor", "Summary");
            AddTopContent(GetCustomEntityTopFrame("DecoratePerson"));
            base.PreBuildContents();
        }
        public override void BuildContents()
        {
            try
            {
                string dper_decoratepersonid = Dispatch.EitherField("dper_decoratepersonid");

                Record DecoratePerson = FindRecord("DecoratePerson", "dper_decoratepersonid=" + dper_decoratepersonid);
                cpet_competitorid = DecoratePerson.GetFieldAsString("dper_competitorid");

                Record order = FindRecord("Competitor", "cpet_competitorid=" + cpet_competitorid);
                int userid = CurrentUser.UserId;

                string urledit = base.UrlDotNet(base.ThisDotNetDll, "RunPersonEdit") + "&dper_decoratepersonid=" + dper_decoratepersonid;
                    Dispatch.Redirect(urledit);


                EntryGroup CompetitionPersonNewEntry = new EntryGroup("CompetitionPersonNewEntry");

                CompetitionPersonNewEntry.Title = "DecoratePerson";
                CompetitionPersonNewEntry.Fill(DecoratePerson);

                VerticalPanel vpMainPanel = new VerticalPanel();
                vpMainPanel.AddAttribute("width", "100%");
                vpMainPanel.Add(CompetitionPersonNewEntry);
                AddContent(vpMainPanel);

                string urldelete = base.UrlDotNet(base.ThisDotNetDll, "RunPersonDelete") + "&dper_decoratepersonid=" + dper_decoratepersonid;
                    base.AddUrlButton("Delete", "Delete.gif", urldelete);


                string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&cpet_competitorid=" + cpet_competitorid;
                url = url.Replace("Key37", "Personid");
                url = url + "&Key37=" + cpet_competitorid;
                this.AddUrlButton("cancel", "PrevCircle.gif", url);
                
            }
            catch (Exception error)
            {
                this.AddError(error.Message);
            }
        }
    }
}