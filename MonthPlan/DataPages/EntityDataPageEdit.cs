using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace MonthPlan.DataPages {
    public class MonthPlanDataPageEdit : DataPageEdit {
        public MonthPlanDataPageEdit()
            : base("MonthPlan", "mopl_MonthPlanId", "MonthPlanNewEntry") {
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