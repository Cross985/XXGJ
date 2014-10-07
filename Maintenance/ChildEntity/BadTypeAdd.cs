using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Controls;
using Sage.CRM.UI;
using Sage.CRM.Data;

namespace Maintenance
{
    public class BadTypeAdd : Web
    {
        public override void BuildContents()
        {
            AddContent(HTML.Form());

            try
            {
                string hMode = Dispatch.EitherField("HiddenMode");
                string mate_MaintenanceId = Dispatch.EitherField("mate_MaintenanceId");
                int errorflag = 0;
                string errormessage = string.Empty;
                EntryGroup BadTypeNewEntry = new EntryGroup("BadTypeNewEntry");
                //CostAdjustmentProductNewEntry.Title = "Add CostAdjustmentProduct"; 
                Entry bred_busreportidEntry = BadTypeNewEntry.GetEntry("badt_maintenanceid");
                if (bred_busreportidEntry != null)
                {
                    bred_busreportidEntry.DefaultValue = mate_MaintenanceId;
                    bred_busreportidEntry.ReadOnly = true;
                }

                AddTabHead("DecoratePerson");
                if (hMode == "Save")
                {
                    Record BadType = new Record("BadType");
                    BadTypeNewEntry.Fill(BadType);
                    if (BadTypeNewEntry.Validate())
                    {
                        BadType.SaveChanges();
                        string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mate_MaintenanceId=" + mate_MaintenanceId + "&J=Summary";
                        url = url.Replace("Key37", "DecorateCompid");
                        url = url + "&Key37=" + mate_MaintenanceId;
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
                    BadTypeNewEntry.GetHtmlInEditMode();
                    vpMainPanel.Add(BadTypeNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("Save", "Save.gif", sUrl);
                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mate_MaintenanceId=" + mate_MaintenanceId + "&J=Summary";
                    url = url.Replace("Key37", "DecoratePersonid");
                    url = url + "&Key37=" + mate_MaintenanceId;
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
