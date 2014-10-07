//using System;
//using System.Collections.Generic;
//using System.Text;
//using Sage.CRM.WebObject;

//namespace MarActPlan.DataPages {
//    public class MarActPlanDataPageNew : DataPageNew {
//        public MarActPlanDataPageNew()
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
using Sage.CRM.Controls;
using Sage.CRM.UI;
using Sage.CRM.Data;

namespace MarActPlan.DataPages {
    public class MarActPlanDataPageNew : Web {
        public override void BuildContents() {
            AddContent(HTML.Form());

            try {
                string hMode = Dispatch.EitherField("HiddenMode");
                string mapl_maractpoolid = Dispatch.EitherField("mapl_maractpoolid");
                if (string.IsNullOrEmpty(mapl_maractpoolid)) {
                    mapl_maractpoolid = Dispatch.EitherField("Key58");
                }
                int errorflag = 0;
                string errormessage = string.Empty;
                EntryGroup MarActPlanNewEntry = new EntryGroup("MarActPlanNewEntry");
                //CostAdjustmentProductNewEntry.Title = "Add CostAdjustmentProduct"; 
                Entry mapl_maractpoolidEntry = MarActPlanNewEntry.GetEntry("mapl_maractpoolid");
                if (mapl_maractpoolidEntry != null) {
                    mapl_maractpoolidEntry.DefaultValue = mapl_maractpoolid;
                    mapl_maractpoolidEntry.ReadOnly = true;
                }

                AddTabHead("MarActPlan");
                if (hMode == "Save") {
                    Record MarActPlan = new Record("MarActPlan");
                    MarActPlanNewEntry.Fill(MarActPlan);
                    if (MarActPlanNewEntry.Validate()) {

                        MarActPlan.SaveChanges();

                        string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mapl_maractplanid=" + MarActPlan.RecordId + "&J=Summary";
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
                    MarActPlanNewEntry.GetHtmlInEditMode();
                    vpMainPanel.Add(MarActPlanNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("Save", "Save.gif", sUrl);
                    AddUrlButton("Cancel", "cancel.gif", UrlDotNet(ThisDotNetDll, "RunListPage"));
                }

            } catch (Exception e) {
                AddError(e.Message);
            }
        }

    }
}