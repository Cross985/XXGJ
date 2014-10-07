using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace MonthPlan.DataPages {
    public class MonthPlanListPage : ListPage {
        public MonthPlanListPage()
            : base("MonthPlan", "MonthPlanGrid", "MonthPlanFilterBox") {
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