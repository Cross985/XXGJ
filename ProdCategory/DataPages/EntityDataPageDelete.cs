using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace ProdCategory.DataPages {
    public class ProdCategoryDataPageDelete : DataPageDelete {
        public ProdCategoryDataPageDelete()
            : base("ProdCategory", "pcat_ProdCategoryId", "ProdCategoryNewEntry") {
        }
    }
}