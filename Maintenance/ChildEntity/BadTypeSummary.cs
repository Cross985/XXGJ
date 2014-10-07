using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace Maintenance
{
    public class BadTypeSummary : Web
    {
        public override void PreBuildContents()
        {
            GetTabs("BadType", "Summary");
            AddTopContent(GetCustomEntityTopFrame("BadType"));
            base.PreBuildContents();
        }
        public override void BuildContents()
        {
            try
            {
                string badt_BadTypeid = Dispatch.EitherField("badt_BadTypeid");

                Record BadType = FindRecord("BadType", "badt_BadTypeid=" + badt_BadTypeid);
                string badt_maintenanceid = BadType.GetFieldAsString("badt_maintenanceid");

               
                int userid = CurrentUser.UserId;

                string urledit = base.UrlDotNet(base.ThisDotNetDll, "RunBadTypeEdit") + "&badt_BadTypeid=" + badt_BadTypeid;
                    Dispatch.Redirect(urledit);


                    EntryGroup DecoratePersonNewEntry = new EntryGroup("BadTypeNewEntry");

                DecoratePersonNewEntry.Title = "BadType";
                DecoratePersonNewEntry.Fill(BadType);

                VerticalPanel vpMainPanel = new VerticalPanel();
                vpMainPanel.AddAttribute("width", "100%");
                vpMainPanel.Add(DecoratePersonNewEntry);
                AddContent(vpMainPanel);

                string urldelete = base.UrlDotNet(base.ThisDotNetDll, "RunBadTypeDelete") + "&badt_BadTypeid=" + badt_BadTypeid;
                    base.AddUrlButton("Delete", "Delete.gif", urldelete);


                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mate_MaintenanceId=" + badt_maintenanceid;
                    url = url.Replace("Key37", "BadTypeid");
                url = url + "&Key37=" + badt_maintenanceid;
                this.AddUrlButton("cancel", "PrevCircle.gif", url);
                
            }
            catch (Exception error)
            {
                this.AddError(error.Message);
            }
        }
    }
}