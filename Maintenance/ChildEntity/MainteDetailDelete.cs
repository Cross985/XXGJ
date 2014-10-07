using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace Maintenance
{
    public class MainteDetailDelete : Web
    {
        public override void BuildContents()
        {
            AddContent(HTML.Form());
            try
            {
                string hMode = Dispatch.EitherField("HiddenMode");
                string id = Dispatch.EitherField("mtde_MainteDetailid");
                int errorflag = 0;
                string errormessage = string.Empty;
                Record MainteDetail = FindRecord("MainteDetail", "mtde_MainteDetailid=" + id);
                string mtde_Maintenanceid = MainteDetail.GetFieldAsString("mtde_Maintenanceid");
                EntryGroup MainteDetailNewEntry = new EntryGroup("MainteDetailNewEntry");
                MainteDetailNewEntry.Fill(MainteDetail);

                AddTabHead("Delete MainteDetail");
                if (hMode == "Delete")
                {
                    MainteDetail.DeleteRecord = true;
                    MainteDetail.SaveChanges();
                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mate_MaintenanceId=" + mtde_Maintenanceid + "&J=Summary";
                    url = url.Replace("Key37", "MainteDetailid");
                    url = url + "&Key37=" + mtde_Maintenanceid;
                    Dispatch.Redirect(url);
                }
                if (errorflag != -1)
                {

                    AddContent(HTML.InputHidden("HiddenMode", ""));
                    VerticalPanel vpMainPanel = new VerticalPanel();
                    vpMainPanel.AddAttribute("width", "100%");
                    string sUrl = "javascript:document.EntryForm.HiddenMode.value='Delete';";
                    MainteDetailNewEntry.GetHtmlInViewMode(MainteDetail);
                    vpMainPanel.Add(MainteDetailNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("ConfirmDelete", "Delete.gif", sUrl);
                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mate_MaintenanceId=" + mtde_Maintenanceid + "&J=Summary";
                    url = url.Replace("Key37", "MainteDetailid");
                    url = url + "&Key37=" + mtde_Maintenanceid;
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
