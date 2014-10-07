using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace Equipment.DataPages {
    public class EquipmentDataPageDelete : DataPageDelete {
        public EquipmentDataPageDelete()
            : base("Equipment", "equi_EquipmentId", "EquipmentNewEntry") {
        }
    }
}