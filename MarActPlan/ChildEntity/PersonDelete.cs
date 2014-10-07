using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace MarActPlan
{
    public class PersonDelete : Web
    {
        public override void BuildContents()
        {
            AddContent(HTML.Form());
            try
            {
                string hMode = Dispatch.EitherField("HiddenMode");
                string id = Dispatch.EitherField("dper_decoratepersonid");
                int errorflag = 0;
                string errormessage = string.Empty;
                Record DecoratePerson = FindRecord("DecoratePerson", "dper_decoratepersonid=" + id);
                string dcom_decoratecompId = DecoratePerson.GetFieldAsString("dper_decoratecompId");

                EntryGroup DecoratePersonNewEntry = new EntryGroup("MarActPlanPerson");
                DecoratePersonNewEntry.Fill(DecoratePerson);

                AddTabHead("Delete Person");
                if (hMode == "Delete")
                {
                    DecoratePerson.DeleteRecord = true;
                    DecoratePerson.SaveChanges();
                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&dcom_decoratecompId=" + dcom_decoratecompId + "&J=Summary";
                    url = url.Replace("Key37", "DecoratePersonid");
                    url = url + "&Key37=" + dcom_decoratecompId;
                    Dispatch.Redirect(url);
                }
                if (errorflag != -1)
                {

                    AddContent(HTML.InputHidden("HiddenMode", ""));
                    VerticalPanel vpMainPanel = new VerticalPanel();
                    vpMainPanel.AddAttribute("width", "100%");
                    string sUrl = "javascript:document.EntryForm.HiddenMode.value='Delete';";
                    DecoratePersonNewEntry.GetHtmlInViewMode(DecoratePerson);
                    vpMainPanel.Add(DecoratePersonNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("ConfirmDelete", "Delete.gif", sUrl);
                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&dcom_decoratecompId=" + dcom_decoratecompId + "&J=Summary";
                    url = url.Replace("Key37", "Personid");
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
