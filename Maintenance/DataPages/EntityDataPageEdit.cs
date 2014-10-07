using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace Maintenance.DataPages {
    public class MaintenanceDataPageEdit : DataPageEdit {
        public MaintenanceDataPageEdit()
            : base("Maintenance", "mate_MaintenanceId", "MaintenanceDetailBox") {
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