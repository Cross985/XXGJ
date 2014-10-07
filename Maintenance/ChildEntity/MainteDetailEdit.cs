using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;
using Sage.CRM.Utils;

namespace Maintenance
{
    public class MainteDetailEdit : Web
    {
        public override void BuildContents()
        {
            AddContent(HTML.Form());

            try
            {
                string hMode = Dispatch.EitherField("HiddenMode");
                string mtde_MainteDetailid = Dispatch.EitherField("mtde_MainteDetailid");
                int errorflag = 0;
                string errormessage = string.Empty;
                Record MainteDetail = FindRecord("MainteDetail", "mtde_MainteDetailid=" + mtde_MainteDetailid);
                string mtde_Maintenanceid = MainteDetail.GetFieldAsString("mtde_Maintenanceid");
                EntryGroup MainteDetailNewEntry = new EntryGroup("MainteDetailNewEntry");
                MainteDetailNewEntry.Fill(MainteDetail);
                Entry IntentionOrderidEntry = MainteDetailNewEntry.GetEntry("mtde_maintenanceid");

                IntentionOrderidEntry.ReadOnly = true;

                //AddTabHead("Person");
                //GetTabs("Person", "Person Summary");
                AddTabHead("MainteDetail");
                if (hMode == "Save")
                {

                    ////double original =Person.GetFieldAsDouble("");		    
                    MainteDetailNewEntry.Fill(MainteDetail);
                    ////double  =Person.GetFieldAsDouble("");

                    if (MainteDetailNewEntry.Validate())
                    {
                        MainteDetail.SaveChanges();

                        ////Record BusReport= FindRecord("BusReport", "cpet_competitorid=" + cpet_competitorid);
                        ////double  = BusReport.GetFieldAsDouble("");                        
                        //// =  + - original;
                        ////BusReport.SetField("", );
                        ////BusReport.SaveChanges();

                        string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mate_MaintenanceId=" + mtde_Maintenanceid + "&J=Summary";
                        url = url.Replace("Key37", "MainteDetailid");
                        url = url + "&Key37=" + mtde_Maintenanceid;
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

                    AddContent(HTML.InputHidden("HiddenMode", ""));
                    VerticalPanel vpMainPanel = new VerticalPanel();
                    vpMainPanel.AddAttribute("width", "100%");
                    string sUrl = "javascript:document.EntryForm.HiddenMode.value='Save';";
                    MainteDetailNewEntry.GetHtmlInEditMode(MainteDetail);
                    vpMainPanel.Add(MainteDetailNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("Save", "Save.gif", sUrl);
                    string urldelete = base.UrlDotNet(base.ThisDotNetDll, "RunMainteDetailDelete") + "&mtde_MainteDetailid=" + mtde_MainteDetailid;
                    base.AddUrlButton("Delete", "Delete.gif", urldelete);
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
