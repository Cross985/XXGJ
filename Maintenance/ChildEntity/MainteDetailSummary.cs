using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace Maintenance
{
    public class MainteDetailSummary : Web
    {
        public override void PreBuildContents()
        {
            GetTabs("MainteDetail", "Summary");
            AddTopContent(GetCustomEntityTopFrame("MainteDetail"));
            base.PreBuildContents();
        }
        public override void BuildContents()
        {
            try
            {
                string mtde_MainteDetailid = Dispatch.EitherField("mtde_MainteDetailid");

                Record MainteDetail = FindRecord("MainteDetail", "mtde_MainteDetailid=" + mtde_MainteDetailid);
                string mtde_Maintenanceid = MainteDetail.GetFieldAsString("mtde_maintenanceid");

               
                int userid = CurrentUser.UserId;

                string urledit = base.UrlDotNet(base.ThisDotNetDll, "RunMainteDetailEdit") + "&mtde_MainteDetailid=" + mtde_MainteDetailid;
                    Dispatch.Redirect(urledit);


                    EntryGroup MainteDetailNewEntry = new EntryGroup("MainteDetailNewEntry");

                MainteDetailNewEntry.Title = "MainteDetail";
                MainteDetailNewEntry.Fill(MainteDetail);

                VerticalPanel vpMainPanel = new VerticalPanel();
                vpMainPanel.AddAttribute("width", "100%");
                vpMainPanel.Add(MainteDetailNewEntry);
                AddContent(vpMainPanel);

                string urldelete = base.UrlDotNet(base.ThisDotNetDll, "RunMainteDetailDelete") + "&mtde_MainteDetailid=" + mtde_MainteDetailid;
                    base.AddUrlButton("Delete", "Delete.gif", urldelete);


                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mate_MaintenanceId=" + mtde_Maintenanceid;
                    url = url.Replace("Key37", "MainteDetailid");
                url = url + "&Key37=" + mtde_Maintenanceid;
                this.AddUrlButton("cancel", "PrevCircle.gif", url);
                
            }
            catch (Exception error)
            {
                this.AddError(error.Message);
            }
        }
    }
}