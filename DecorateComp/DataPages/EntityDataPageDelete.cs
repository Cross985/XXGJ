using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace DecorateComp.DataPages {
    public class DecorateCompDataPageDelete : DataPageDelete {
        public DecorateCompDataPageDelete()
            : base("DecorateComp", "dcom_DecorateCompId", "DecorateCompNewEntry") {
        }
    }
}