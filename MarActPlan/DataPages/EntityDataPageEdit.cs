//using System;
//using System.Collections.Generic;
//using System.Text;
//using Sage.CRM.WebObject;

//namespace MarActPlan.DataPages {
//    public class MarActPlanDataPageEdit : DataPageEdit {
//        public MarActPlanDataPageEdit()
//            : base("MarActPlan", "mapl_MarActPlanId", "MarActPlanNewEntry") {
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

namespace MarActPlan.DataPages {
    public class MarActPlanDataPageEdit : Web {
        public override void BuildContents() {
            AddContent(HTML.Form());

            try {
                string hMode = Dispatch.EitherField("HiddenMode");
                string mapl_MarActPlanId = Dispatch.EitherField("mapl_MarActPlanId");
                int errorflag = 0;
                string errormessage = string.Empty;
                Record MarActPlan = FindRecord("MarActPlan", "mapl_MarActPlanId=" + mapl_MarActPlanId);
                string mapl_opportunityid = MarActPlan.GetFieldAsString("mapl_opportunityid");
                EntryGroup MarActPlanNewEntry = new EntryGroup("MarActPlanNewEntry");
                MarActPlanNewEntry.Fill(MarActPlan);
                Entry mapl_opportunityidEntry = MarActPlanNewEntry.GetEntry("mapl_opportunityid");

                mapl_opportunityidEntry.ReadOnly = true;

                //AddTabHead("CpetProduct");
                GetTabs("MarActPlan", "Summary");
                if (hMode == "Save") {

                    ////double original =CpetProduct.GetFieldAsDouble("");		    
                    MarActPlanNewEntry.Fill(MarActPlan);
                    ////double  =CpetProduct.GetFieldAsDouble("");

                    if (MarActPlanNewEntry.Validate()) {
                        MarActPlan.SaveChanges();

                        ////Record BusReport= FindRecord("BusReport", "cpet_competitorid=" + cpet_competitorid);
                        ////double  = BusReport.GetFieldAsDouble("");                        
                        //// =  + - original;
                        ////BusReport.SetField("", );
                        ////BusReport.SaveChanges();

                        string url = UrlDotNet(ThisDotNetDll, "RunListPage") ;
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
                    MarActPlanNewEntry.GetHtmlInEditMode(MarActPlan);
                    vpMainPanel.Add(MarActPlanNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("Save", "Save.gif", sUrl);
                    string urldelete = base.UrlDotNet(base.ThisDotNetDll, "RunDataPageDelete") + "&mapl_MarActPlanId=" + mapl_MarActPlanId;
                    base.AddUrlButton("Delete", "Delete.gif", urldelete);
                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mapl_MarActPlanId=" + mapl_MarActPlanId + "&J=Summary";
                    AddUrlButton("Cancel", "cancel.gif", url);
                }

            } catch (Exception e) {
                AddError(e.Message);
            }
        }
    }
}
