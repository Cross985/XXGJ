using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace MarActPlan.DataPages {
    public class MarActPlanListPage : ListPage {
        public MarActPlanListPage()
            : base("MarActPlan", "MarActPlanGrid", "MarActPlanFilterBox") {
            //FilterByField = "";
            //FilterByContextId = (int)Sage.KeyList.UserId;

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