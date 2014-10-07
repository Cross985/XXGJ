using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace Equipment.DataPages {
    public class EquipmentDataPageEdit : DataPageEdit {
        public EquipmentDataPageEdit()
            : base("Equipment", "equi_EquipmentId", "EquipmentNewEntry") {
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