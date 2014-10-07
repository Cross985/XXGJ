using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Controls;
using Sage.CRM.UI;
using Sage.CRM.Data;

namespace MarActPlan
{
    public class DisplayContentAdd : Web
    {
        public override void BuildContents()
        {
            AddContent(HTML.Form());

            try
            {
                string hMode = Dispatch.EitherField("HiddenMode");
                string mapl_MarActPlanId = Dispatch.EitherField("mapl_MarActPlanId");
                int errorflag = 0;
                string errormessage = string.Empty;
                EntryGroup DisplayContentNewEntry = new EntryGroup("DisplayContentNewEntry");
                //CostAdjustmentProductNewEntry.Title = "Add CostAdjustmentProduct"; 
                Entry bred_busreportidEntry = DisplayContentNewEntry.GetEntry("dico_maractplanid");
                if (bred_busreportidEntry != null)
                {
                    bred_busreportidEntry.DefaultValue = mapl_MarActPlanId;
                    bred_busreportidEntry.ReadOnly = true;
                }

                AddTabHead("DecoratePerson");
                if (hMode == "Save")
                {
                    Record DisplayContent = new Record("DisplayContent");
                    DisplayContentNewEntry.Fill(DisplayContent);
                    if (DisplayContentNewEntry.Validate())
                    {
                        DisplayContent.SaveChanges();
                        string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mapl_MarActPlanId=" + mapl_MarActPlanId + "&J=Summary";
                        url = url.Replace("Key37", "DecorateCompid");
                        url = url + "&Key37=" + mapl_MarActPlanId;
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
                    DisplayContentNewEntry.GetHtmlInEditMode();
                    vpMainPanel.Add(DisplayContentNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("Save", "Save.gif", sUrl);
                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mapl_MarActPlanId=" + mapl_MarActPlanId + "&J=Summary";
                    url = url.Replace("Key37", "DecoratePersonid");
                    url = url + "&Key37=" + mapl_MarActPlanId;
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
