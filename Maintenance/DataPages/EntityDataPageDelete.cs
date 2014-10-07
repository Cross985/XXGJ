using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace Maintenance.DataPages {
    public class MaintenanceDataPageDelete : DataPageDelete {
        public MaintenanceDataPageDelete()
            : base("Maintenance", "mate_MaintenanceId", "MaintenanceDetailBox") {
        }
    }
}