using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace Maintenance.DataPages {
    public class MaintenanceSearchPage : SearchPage {
        public MaintenanceSearchPage()
            : base("MaintenanceSearchBox", "MaintenanceGrid") {
        }
    }
}