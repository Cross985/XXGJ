using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace OppoTrack.DataPages {
    public class OppoTrackListPage : ListPage {
        public OppoTrackListPage()
            : base("OppoTrack", "OppoTrackGrid", "OppoTrackFilterBox") {
            //FilterByField = "";
            //FilterByContextId = (int)Sage.KeyList.UserId;
            string oppo_opportunityid = Dispatch.EitherField("oppo_opportunityid");
            if (string.IsNullOrEmpty(oppo_opportunityid)) {
                oppo_opportunityid = Dispatch.EitherField("Key7");
            }
            this.ResultsGrid.RowsPerScreen = 25;
            this.ResultsGrid.Filter = "optr_deleted is null and optr_opportunityid=" + oppo_opportunityid;
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