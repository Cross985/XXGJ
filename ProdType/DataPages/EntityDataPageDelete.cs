using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace ProdType.DataPages {
    public class ProdTypeDataPageDelete : DataPageDelete {
        public ProdTypeDataPageDelete()
            : base("ProdType", "ptyp_ProdTypeId", "ProdTypeNewEntry") {
        }
    }
}