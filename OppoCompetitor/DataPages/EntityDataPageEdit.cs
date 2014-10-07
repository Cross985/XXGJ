//using System;
//using System.Collections.Generic;
//using System.Text;
//using Sage.CRM.WebObject;

//namespace OppoCompetitor.DataPages {
//    public class OppoCompetitorDataPageEdit : DataPageEdit {
//        public OppoCompetitorDataPageEdit()
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
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;
using Sage.CRM.Utils;

namespace OppoCompetitor.DataPages {
    public class OppoCompetitorDataPageEdit : Web {
        public override void BuildContents() {
            AddContent(HTML.Form());

            try {
                string hMode = Dispatch.EitherField("HiddenMode");
                string opco_OppoCompetitorId = Dispatch.EitherField("opco_OppoCompetitorId");
                int errorflag = 0;
                string errormessage = string.Empty;
                Record OppoCompetitor = FindRecord("OppoCompetitor", "opco_OppoCompetitorId=" + opco_OppoCompetitorId);
                string opco_opportunityid = OppoCompetitor.GetFieldAsString("opco_opportunityid");
                EntryGroup OppoCompetitorNewEntry = new EntryGroup("OppoCompetitorNewEntry");
                OppoCompetitorNewEntry.Fill(OppoCompetitor);
                Entry opco_opportunityidEntry = OppoCompetitorNewEntry.GetEntry("opco_opportunityid");

                //opco_opportunityidEntry.ReadOnly = true;

                //AddTabHead("CpetProduct");
                GetTabs("OppoCompetitor", "Summary");
                if (hMode == "Save") {

                    ////double original =CpetProduct.GetFieldAsDouble("");		    
                    OppoCompetitorNewEntry.Fill(OppoCompetitor);
                    ////double  =CpetProduct.GetFieldAsDouble("");

                    if (OppoCompetitorNewEntry.Validate()) {
                        OppoCompetitor.SaveChanges();

                        ////Record BusReport= FindRecord("BusReport", "cpet_competitorid=" + cpet_competitorid);
                        ////double  = BusReport.GetFieldAsDouble("");                        
                        //// =  + - original;
                        ////BusReport.SetField("", );
                        ////BusReport.SaveChanges();
                        string opportunityid = Dispatch.EitherField("Key7");
                        string url = string.Empty;

                        if (!string.IsNullOrEmpty(opportunityid)) {
                            url=UrlDotNet(ThisDotNetDll, "RunListPage") + "&J=OppoCompetitor&T=Opportunity";
                        } else {
                            url=UrlDotNet(ThisDotNetDll, "RunCompetitorListPage") + "&J=OppoCompetitor&T=Competitor";
                        }
                        Dispatch.Redirect(url);
                        errorflag = -1;
                    } else {
                        errorflag = 1;
                    }

                }
                if (errorflag != -1) {

                    AddContent(HTML.InputHidden("HiddenMode", ""));
                    VerticalPanel vpMainPanel = new VerticalPanel();
                    vpMainPanel.AddAttribute("width", "100%");
                    string sUrl = "javascript:document.EntryForm.HiddenMode.value='Save';";
                    OppoCompetitorNewEntry.GetHtmlInEditMode(OppoCompetitor);
                    vpMainPanel.Add(OppoCompetitorNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("Save", "Save.gif", sUrl);
                    string urldelete = base.UrlDotNet(base.ThisDotNetDll, "RunDataPageDelete") + "&opco_OppoCompetitorId=" + opco_OppoCompetitorId;
                    base.AddUrlButton("Delete", "Delete.gif", urldelete);

                    string opportunityid = Dispatch.EitherField("Key7");
                    string url = string.Empty;

                    if (!string.IsNullOrEmpty(opportunityid)) {
                        url = UrlDotNet(ThisDotNetDll, "RunListPage") + "&J=OppoCompetitor&T=Opportunity";
                    } else {
                        url = UrlDotNet(ThisDotNetDll, "RunCompetitorListPage") + "&J=OppoCompetitor&T=Competitor";
                    } 
                    AddUrlButton("Cancel", "cancel.gif", url);
                }

            } catch (Exception e) {
                AddError(e.Message);
            }
        }
    }
}
