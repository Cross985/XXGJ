using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace MarActPlan
{
    public class DisplayContentDelete : Web
    {
        public override void BuildContents()
        {
            AddContent(HTML.Form());
            try
            {
                string hMode = Dispatch.EitherField("HiddenMode");
                string id = Dispatch.EitherField("dico_displaycontentid");
                int errorflag = 0;
                string errormessage = string.Empty;
                Record DisplayContent = FindRecord("DisplayContent", "dico_displaycontentid=" + id);
                string dico_maractplanid = DisplayContent.GetFieldAsString("dico_maractplanid");
                EntryGroup DecoratePersonNewEntry = new EntryGroup("DisplayContentNewEntry");
                DecoratePersonNewEntry.Fill(DisplayContent);

                AddTabHead("Delete Person");
                if (hMode == "Delete")
                {
                    DisplayContent.DeleteRecord = true;
                    DisplayContent.SaveChanges();
                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mapl_MarActPlanId=" + dico_maractplanid + "&J=Summary";
                    url = url.Replace("Key37", "DisplayContentid");
                    url = url + "&Key37=" + dico_maractplanid;
                    Dispatch.Redirect(url);
                }
                if (errorflag != -1)
                {

                    AddContent(HTML.InputHidden("HiddenMode", ""));
                    VerticalPanel vpMainPanel = new VerticalPanel();
                    vpMainPanel.AddAttribute("width", "100%");
                    string sUrl = "javascript:document.EntryForm.HiddenMode.value='Delete';";
                    DecoratePersonNewEntry.GetHtmlInViewMode(DisplayContent);
                    vpMainPanel.Add(DecoratePersonNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("ConfirmDelete", "Delete.gif", sUrl);
                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mapl_MarActPlanId=" + dico_maractplanid + "&J=Summary";
                    url = url.Replace("Key37", "Personid");
                    url = url + "&Key37=" + dico_maractplanid;
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
