using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace Maintenance.DataPages {
    public class MaintenanceListPage : ListPage {
        public MaintenanceListPage()
            : base("Maintenance", "MaintenanceGrid", "MaintenanceFilterBox") {
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