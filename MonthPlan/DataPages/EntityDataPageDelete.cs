using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace MonthPlan.DataPages {
    public class MonthPlanDataPageDelete : DataPageDelete {
        public MonthPlanDataPageDelete()
            : base("MonthPlan", "mopl_MonthPlanId", "MonthPlanNewEntry") {
        }
    }
}