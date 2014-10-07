using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace MarActPlan
{
    public class DisplayContentSummary : Web
    {
        public override void PreBuildContents()
        {
            GetTabs("DisplayContent", "Summary");
            AddTopContent(GetCustomEntityTopFrame("DisplayContent"));
            base.PreBuildContents();
        }
        public override void BuildContents()
        {
            try
            {
                string dico_displaycontentid = Dispatch.EitherField("dico_displaycontentid");

                Record DisplayContent = FindRecord("DisplayContent", "dico_displaycontentid=" + dico_displaycontentid);
                string dico_maractplanid = DisplayContent.GetFieldAsString("dico_maractplanid");

               
                int userid = CurrentUser.UserId;

                string urledit = base.UrlDotNet(base.ThisDotNetDll, "RunDisplayContentEdit") + "&dico_displaycontentid=" + dico_displaycontentid;
                    Dispatch.Redirect(urledit);


                    EntryGroup DecoratePersonNewEntry = new EntryGroup("DisplayContentNewEntry");

                DecoratePersonNewEntry.Title = "DisplayContent";
                DecoratePersonNewEntry.Fill(DisplayContent);

                VerticalPanel vpMainPanel = new VerticalPanel();
                vpMainPanel.AddAttribute("width", "100%");
                vpMainPanel.Add(DecoratePersonNewEntry);
                AddContent(vpMainPanel);

                string urldelete = base.UrlDotNet(base.ThisDotNetDll, "RunDisplayContentDelete") + "&dico_displaycontentid=" + dico_displaycontentid;
                    base.AddUrlButton("Delete", "Delete.gif", urldelete);


                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mapl_MarActPlanId=" + dico_maractplanid;
                url = url.Replace("Key37", "Personid");
                url = url + "&Key37=" + dico_maractplanid;
                this.AddUrlButton("cancel", "PrevCircle.gif", url);
                
            }
            catch (Exception error)
            {
                this.AddError(error.Message);
            }
        }
    }
}