using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Controls;
using Sage.CRM.Data;
using Sage.CRM.UI;


namespace Company
{
    public class USEdit : Web
    {
        public override void BuildContents()
        {
            try
            {
                AddContent(HTML.Form());
                string compid = Dispatch.EitherField("comp_companyid");
                if (string.IsNullOrEmpty(compid))
                    compid = Dispatch.EitherField("key1");
                string usid = Dispatch.EitherField("usst_UseSituationID");
                string hMode = Dispatch.EitherField("HiddenMode");
                EntryGroup USEntry = new EntryGroup("UseSituationNewEntry");
                USEntry.Title = "使用情况";
                Record USRec = FindRecord("UseSituation", "usst_UseSituationID="+usid);
                int errflag = 0;
                AddTabHead("UseSituation");
                if (hMode == "Save")
                {                    
                    USEntry.Fill(USRec);
                    if (USEntry.Validate() == true)
                    {
                        USRec.SetField("usst_companyid", compid);
                        USRec.SaveChanges();
                        Dispatch.Redirect(UrlDotNet(ThisDotNetDll, "RunUSList") + "&comp_companyid=" + compid + "&J=Summary&T=CompanySummary");
                    }

                }
                if (errflag != -1)
                {
                    AddContent(HTML.InputHidden("HiddenMode", ""));
                    USEntry.GetHtmlInEditMode(USRec);
                    VerticalPanel vp = new VerticalPanel();
                    vp.AddAttribute("width", "100%");
                    vp.Add(USEntry);
                    AddContent(vp);

                    string url = "javascript:document.EntryForm.HiddenMode.value='Save';";
                    AddSubmitButton("Save", "Save.gif", url);
                    AddUrlButton("Delete", "Delete.gif", UrlDotNet(ThisDotNetDll, "RunUSDelete") + "&comp_companyid=" + compid + "&usst_UseSituationID=" + usid);
                    AddUrlButton("Cancel", "cancel.gif", UrlDotNet(ThisDotNetDll, "RunUSList") + "&comp_companyid=" + compid + "&J=Summary&T=CompanySummary");
                }

            }
            catch (Exception ex)
            {
                AddError(ex.Message + "USAddPage");
            }
        }

    }
}
