using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Controls;
using Sage.CRM.UI;
using Sage.CRM.Data;

namespace OppoSupport.DataPages {
    public class OppoSupportDataPageNew : Web {
        public override void BuildContents() {
            AddContent(HTML.Form());

            try {
                string hMode = Dispatch.EitherField("HiddenMode");
                string opsu_opportunityid = Dispatch.EitherField("Key7");
                int errorflag = 0;
                string errormessage = string.Empty;
                EntryGroup OppoSupportNewEntry = new EntryGroup("OppoSupportNewEntry");
                //CostAdjustmentProductNewEntry.Title = "Add CostAdjustmentProduct"; 
                Entry opsu_opportunityidEntry = OppoSupportNewEntry.GetEntry("opsu_opportunityid");
                if (opsu_opportunityidEntry != null) {
                    opsu_opportunityidEntry.DefaultValue = opsu_opportunityid;
                    opsu_opportunityidEntry.ReadOnly = true;
                }

                AddTabHead("OppoSupport");
                if (hMode == "Save") {
                    Record OppoSupport = new Record("OppoSupport");
                    OppoSupportNewEntry.Fill(OppoSupport);
                    if (OppoSupportNewEntry.Validate()) {

                        OppoSupport.SaveChanges();
                        string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&opsu_OppoSupportid=" + OppoSupport.GetFieldAsString("opsu_OppoSupportid") + "&J=Summary";
                        Dispatch.Redirect(url);
                        errorflag = -1;
                    } else {
                        errorflag = 1;
                    }
                }
                if (errorflag != -1) {
                    if (errorflag == 2) {
                        AddError(errormessage);
                    }

                    AddContent(HTML.InputHidden("HiddenMode", ""));
                    VerticalPanel vpMainPanel = new VerticalPanel();
                    vpMainPanel.AddAttribute("width", "100%");
                    string sUrl = "javascript:document.EntryForm.HiddenMode.value='Save';";
                    OppoSupportNewEntry.GetHtmlInEditMode();
                    vpMainPanel.Add(OppoSupportNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("Save", "Save.gif", sUrl);
                    AddUrlButton("Cancel", "cancel.gif", UrlDotNet(ThisDotNetDll, "RunListPage") + "&J=OppoSupport&T=Opportunity");
                }

            } catch (Exception e) {
                AddError(e.Message);
            }
        }

    }
}
