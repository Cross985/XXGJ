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
    public class BadTypeEdit : Web
    {
        public override void BuildContents()
        {
            AddContent(HTML.Form());

            try
            {
                string hMode = Dispatch.EitherField("HiddenMode");
                string badt_BadTypeid = Dispatch.EitherField("badt_BadTypeid");
                int errorflag = 0;
                string errormessage = string.Empty;
                Record BadType = FindRecord("BadType", "badt_BadTypeid=" + badt_BadTypeid);
                string badt_maintenanceid = BadType.GetFieldAsString("badt_maintenanceid");
                EntryGroup BadTypeNewEntry = new EntryGroup("BadTypeNewEntry");
                BadTypeNewEntry.Fill(BadType);
                Entry IntentionOrderidEntry = BadTypeNewEntry.GetEntry("badt_maintenanceid");

                IntentionOrderidEntry.ReadOnly = true;

                //AddTabHead("Person");
                //GetTabs("Person", "Person Summary");
                AddTabHead("BadType");
                if (hMode == "Save")
                {

                    ////double original =Person.GetFieldAsDouble("");		    
                    BadTypeNewEntry.Fill(BadType);
                    ////double  =Person.GetFieldAsDouble("");

                    if (BadTypeNewEntry.Validate())
                    {
                        BadType.SaveChanges();

                        ////Record BusReport= FindRecord("BusReport", "cpet_competitorid=" + cpet_competitorid);
                        ////double  = BusReport.GetFieldAsDouble("");                        
                        //// =  + - original;
                        ////BusReport.SetField("", );
                        ////BusReport.SaveChanges();

                        string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mate_MaintenanceId=" + badt_maintenanceid + "&J=Summary";
                        url = url.Replace("Key37", "Personid");
                        url = url + "&Key37=" + badt_maintenanceid;
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
                    BadTypeNewEntry.GetHtmlInEditMode(BadType);
                    vpMainPanel.Add(BadTypeNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("Save", "Save.gif", sUrl);
                    string urldelete = base.UrlDotNet(base.ThisDotNetDll, "RunBadTypeDelete") + "&badt_BadTypeid=" + badt_BadTypeid;
                    base.AddUrlButton("Delete", "Delete.gif", urldelete);
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
