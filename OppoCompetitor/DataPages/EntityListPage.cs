using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace OppoCompetitor.DataPages {
    public class OppoCompetitorListPage : ListPage {
        public OppoCompetitorListPage()
            : base("OppoCompetitor", "OppoCompetitorGrid", "OppoCompetitorFilterBox") {
            //FilterByField = "";
            //FilterByContextId = (int)Sage.KeyList.UserId;
            string oppo_opportunityid = Dispatch.EitherField("oppo_opportunityid");
            if (string.IsNullOrEmpty(oppo_opportunityid)) {
                oppo_opportunityid = Dispatch.EitherField("Key7");
            }
            this.ResultsGrid.RowsPerScreen = 25;
            this.ResultsGrid.Filter = "opco_deleted is null and opco_opportunityid=" + oppo_opportunityid;

        }

        public override void BuildContents() {
            try {

                /* Add your code here */

                base.BuildContents();
            } catch (Exception error) {
                this.AddError(error.Message);
            }
        }
    }
}