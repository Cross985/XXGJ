using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace MarActPlan.DataPages {
    public class MarActPlanDataPageDelete : DataPageDelete {
        public MarActPlanDataPageDelete()
            : base("MarActPlan", "mapl_MarActPlanId", "MarActPlanDetailBox") {
        }
    }
}