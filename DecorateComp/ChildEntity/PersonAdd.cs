using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Controls;
using Sage.CRM.UI;
using Sage.CRM.Data;

namespace DecorateComp
{
    public class PersonAdd : Web
    {
        public override void BuildContents()
        {
            AddContent(HTML.Form());

            try
            {
                string hMode = Dispatch.EitherField("HiddenMode");
                string dcom_decoratecompId = Dispatch.EitherField("dcom_decoratecompId");
                int errorflag = 0;
                string errormessage = string.Empty;
                EntryGroup DecoratePersonNewEntry = new EntryGroup("DecoratePersonNewEntry");
                //CostAdjustmentProductNewEntry.Title = "Add CostAdjustmentProduct"; 
                Entry bred_busreportidEntry = DecoratePersonNewEntry.GetEntry("dper_decoratecompid");
                if (bred_busreportidEntry != null)
                {
                    bred_busreportidEntry.DefaultValue = dcom_decoratecompId;
                    bred_busreportidEntry.ReadOnly = true;
                }

                AddTabHead("DecoratePerson");
                if (hMode == "Save")
                {
                    Record DecoratePerson = new Record("DecoratePerson");
                    DecoratePersonNewEntry.Fill(DecoratePerson);
                    if (DecoratePersonNewEntry.Validate())
                    {
                        DecoratePerson.SaveChanges();
                        string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&dcom_DecorateCompId=" + dcom_decoratecompId + "&J=Summary";
                        url = url.Replace("Key37", "DecorateCompid");
                        url = url + "&Key37=" + dcom_decoratecompId;
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
                    DecoratePersonNewEntry.GetHtmlInEditMode();
                    vpMainPanel.Add(DecoratePersonNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("Save", "Save.gif", sUrl);
                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&dcom_DecorateCompId=" + dcom_decoratecompId + "&J=Summary";
                    url = url.Replace("Key37", "DecorateCompid");
                    url = url + "&Key37=" + dcom_decoratecompId;
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
