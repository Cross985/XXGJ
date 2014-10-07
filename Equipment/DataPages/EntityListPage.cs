using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace Equipment.DataPages {
    public class EquipmentListPage : ListPage {
        public EquipmentListPage()
            : base("Equipment", "EquipmentGrid", "EquipmentFilterBox") {
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