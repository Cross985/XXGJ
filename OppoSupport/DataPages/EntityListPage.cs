using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace OppoSupport.DataPages {
    public class OppoSupportListPage : ListPage {
        public OppoSupportListPage()
            : base("OppoSupport", "OppoSupportGrid", "OppoSupportFilterBox") {
            //FilterByField = "";
            //FilterByContextId = (int)Sage.KeyList.UserId;
            string oppo_opportunityid = Dispatch.EitherField("oppo_opportunityid");
            if (string.IsNullOrEmpty(oppo_opportunityid)) {
                oppo_opportunityid = Dispatch.EitherField("Key7");
            }
            this.ResultsGrid.RowsPerScreen = 25;
            this.ResultsGrid.Filter = "opsu_deleted is null and opsu_opportunityid=" + oppo_opportunityid;

        }

        public override void BuildContents() {
            try {

                /* Add your code here */

                base.BuildContents();
            } catch (Exception error) {
                this.AddError(error.Message);
            }
        }
        public override void AddNewButton()
        {
            AddUrlButton("New","New.gif",UrlDotNet(ThisDotNetDll,"RunDataPageNew"));
            //base.AddNewButton();
        }
    }
}