using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace OppoCompetitor.DataPages {
    public class CompetitorListPage : ListPage {
        public CompetitorListPage()
            : base("OppoCompetitor", "OppoCompetitorGrid1", "OppoCompetitorFilterBox") {
            //FilterByField = "";
            //FilterByContextId = (int)Sage.KeyList.UserId;
            string cpet_competitorid = Dispatch.EitherField("cpet_competitorid");
            if (string.IsNullOrEmpty(cpet_competitorid)) {
                cpet_competitorid = Dispatch.EitherField("Key58");
            }
            this.ResultsGrid.RowsPerScreen = 25;
            this.ResultsGrid.Filter = "opco_deleted is null and opco_competitorid=" + cpet_competitorid;
     

        }

        public override void BuildContents() {
            try {

                /* Add your code here */

                base.BuildContents();
            } catch (Exception error) {
                this.AddError(error.Message);
            }
        }
        public override void AddNewButton() {

        }
    }
}