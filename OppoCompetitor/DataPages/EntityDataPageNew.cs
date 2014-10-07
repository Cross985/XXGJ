//using System;
//using System.Collections.Generic;
//using System.Text;
//using Sage.CRM.WebObject;

//namespace OppoCompetitor.DataPages {
//    public class OppoCompetitorDataPageNew : DataPageNew {
//        public OppoCompetitorDataPageNew()
//            : base("OppoCompetitor", "opco_OppoCompetitorId", "OppoCompetitorDetailBox") {
//        }

//        public override void BuildContents() {
//            try {

//                /* Add your code here */

//                base.BuildContents();
//            } catch (Exception error) {
//                this.AddError(error.Message);
//            }
//        }
//    }
//}
using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Controls;
using Sage.CRM.UI;
using Sage.CRM.Data;

namespace OppoCompetitor.DataPages {
    public class OppoCompetitorDataPageNew : Web {
        public override void BuildContents() {
            AddContent(HTML.Form());

            try {
                string hMode = Dispatch.EitherField("HiddenMode");
                string opco_opportunityid = Dispatch.EitherField("Key7");
                string opportunityid = Dispatch.EitherField("Key7");
                //string opco_OppoCompetitorId = Dispatch.EitherField("opco_OppoCompetitorId");
                int errorflag = 0;
                string errormessage = string.Empty;
                EntryGroup OppoCompetitorNewEntry = new EntryGroup("OppoCompetitorNewEntry");
                //CostAdjustmentProductNewEntry.Title = "Add CostAdjustmentProduct"; 
                Entry opco_opportunityidEntry = OppoCompetitorNewEntry.GetEntry("opco_opportunityid");
                if (opco_opportunityidEntry != null) {
                    opco_opportunityidEntry.DefaultValue = opco_opportunityid;
                    //opco_opportunityidEntry.ReadOnly = true;
                }
                //Entry opco_competitoridEntry = OppoCompetitorNewEntry.GetEntry("opco_competitorid");
                //if (opco_competitoridEntry != null) {
                //    opco_competitoridEntry.DefaultValue = opco_OppoCompetitorId;
                //    //opco_opportunityidEntry.ReadOnly = true;
                //}

                AddTabHead("OppoCompetitor");
                if (hMode == "Save") {
                    Record OppoCompetitor = new Record("OppoCompetitor");
                    OppoCompetitorNewEntry.Fill(OppoCompetitor);
                    if (OppoCompetitorNewEntry.Validate()) {

                        OppoCompetitor.SaveChanges();
                        string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&opco_OppoCompetitorid=" + OppoCompetitor.GetFieldAsString("opco_OppoCompetitorid") + "&J=Summary";
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
                    OppoCompetitorNewEntry.GetHtmlInEditMode();
                    vpMainPanel.Add(OppoCompetitorNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("Save", "Save.gif", sUrl);

                    string url = string.Empty;

                    if (!string.IsNullOrEmpty(opportunityid)) {
                        AddUrlButton("Cancel", "cancel.gif", UrlDotNet(ThisDotNetDll, "RunListPage") + "&J=OppoCompetitor&T=Opportunity");
                    } else {
                        AddUrlButton("Cancel", "cancel.gif", UrlDotNet(ThisDotNetDll, "RunCompetitorListPage") + "&J=OppoCompetitor&T=Opportunity");

                    } 
                }

            } catch (Exception e) {
                AddError(e.Message);
            }
        }

    }
}
