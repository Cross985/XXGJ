using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Controls;
using Sage.CRM.UI;
using Sage.CRM.Data;

namespace Maintenance
{
    public class MainteDetailAdd : Web
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
                EntryGroup MainteDetailNewEntry = new EntryGroup("MainteDetailNewEntry");
                //CostAdjustmentProductNewEntry.Title = "Add CostAdjustmentProduct"; 
                Entry bred_busreportidEntry = MainteDetailNewEntry.GetEntry("mtde_maintenanceid");
                if (bred_busreportidEntry != null)
                {
                    bred_busreportidEntry.DefaultValue = mate_MaintenanceId;
                    bred_busreportidEntry.ReadOnly = true;
                }

                AddTabHead("MainteDetail");
                if (hMode == "Save")
                {
                    Record MainteDetail = new Record("MainteDetail");
                    MainteDetailNewEntry.Fill(MainteDetail);
                    if (MainteDetailNewEntry.Validate())
                    {
                        MainteDetail.SaveChanges();
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
                    MainteDetailNewEntry.GetHtmlInEditMode();
                    vpMainPanel.Add(MainteDetailNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("Save", "Save.gif", sUrl);
                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mate_MaintenanceId=" + mate_MaintenanceId + "&J=Summary";
                    url = url.Replace("Key37", "MainteDetailid");
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
