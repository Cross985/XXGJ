//using System;
//using System.Collections.Generic;
//using System.Text;
//using Sage.CRM.WebObject;

//namespace CompeMarAct.DataPages {
//    public class CompeMarActDataPage : DataPage {

//        public CompeMarActDataPage()
//            : base("CompeMarAct", "cmac_CompeMarActId", "CompeMarActNewEntry") {
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

namespace CompeMarAct.DataPages {
    public class CompeMarActDataPage : Web {

        public override void PreBuildContents() {
            GetTabs("CompeMarAct", "Summary");
            AddTopContent(GetCustomEntityTopFrame("CompeMarAct"));
            base.PreBuildContents();
        }
        public override void BuildContents() {
            try {
                string cmac_CompeMarActid = Dispatch.EitherField("cmac_CompeMarActid");
                if (string.IsNullOrEmpty(cmac_CompeMarActid)) {
                    cmac_CompeMarActid = Dispatch.EitherField("key58");
                }

                Record CompeMarAct = FindRecord("CompeMarAct", "cmac_CompeMarActid=" + cmac_CompeMarActid);

                EntryGroup screenBusReport = new EntryGroup("CompeMarActNewEntry");
                screenBusReport.Title = "CompeMarAct";
                screenBusReport.Fill(CompeMarAct);

                // string status = CompeMarAct.GetFieldAsString("cept_status");

                VerticalPanel vpMainPanel = new VerticalPanel();
                vpMainPanel.AddAttribute("width", "100%");
                vpMainPanel.Add(screenBusReport);


                AddContent(vpMainPanel);
                AddUrlButton("Edit", "Edit.gif", UrlDotNet(ThisDotNetDll, "RunDataPageEdit") + "&cmac_CompeMarActid=" + cmac_CompeMarActid);
                AddUrlButton("Delete", "Delete.gif", UrlDotNet(ThisDotNetDll, "RunDataPageDelete") + "&cmac_CompeMarActid=" + cmac_CompeMarActid);
                AddUrlButton("Continue", "Continue.gif", UrlDotNet(ThisDotNetDll, "RunListPage"));
            } catch (Exception error) {
                this.AddError(error.Message);
            }
        }
    }
}