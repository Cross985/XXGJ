using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace Maintenance
{
    public class BadTypeDelete : Web
    {
        public override void BuildContents()
        {
            AddContent(HTML.Form());
            try
            {
                string hMode = Dispatch.EitherField("HiddenMode");
                string id = Dispatch.EitherField("badt_BadTypeid");
                int errorflag = 0;
                string errormessage = string.Empty;
                Record BadType = FindRecord("BadType", "badt_BadTypeid=" + id);
                string badt_maintenanceid = BadType.GetFieldAsString("badt_maintenanceid");
                EntryGroup DecoratePersonNewEntry = new EntryGroup("BadTypeNewEntry");
                DecoratePersonNewEntry.Fill(BadType);

                AddTabHead("Delete BadType");
                if (hMode == "Delete")
                {
                    BadType.DeleteRecord = true;
                    BadType.SaveChanges();
                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mate_MaintenanceId=" + badt_maintenanceid + "&J=Summary";
                    url = url.Replace("Key37", "BadTypeid");
                    url = url + "&Key37=" + badt_maintenanceid;
                    Dispatch.Redirect(url);
                }
                if (errorflag != -1)
                {

                    AddContent(HTML.InputHidden("HiddenMode", ""));
                    VerticalPanel vpMainPanel = new VerticalPanel();
                    vpMainPanel.AddAttribute("width", "100%");
                    string sUrl = "javascript:document.EntryForm.HiddenMode.value='Delete';";
                    DecoratePersonNewEntry.GetHtmlInViewMode(BadType);
                    vpMainPanel.Add(DecoratePersonNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("ConfirmDelete", "Delete.gif", sUrl);
                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mate_MaintenanceId=" + badt_maintenanceid + "&J=Summary";
                    url = url.Replace("Key37", "BadTypeid");
                    url = url + "&Key37=" + badt_maintenanceid;
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
