using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace MarActPool.DataPages {
    public class MarActPoolDataPageDelete : DataPageDelete {
        public MarActPoolDataPageDelete()
            : base("MarActPool", "mapo_MarActPoolId", "MarActPoolNewEntry") {
        }
    }
}