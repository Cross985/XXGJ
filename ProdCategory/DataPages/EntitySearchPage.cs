using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace ProdCategory.DataPages {
    public class ProdCategorySearchPage : SearchPage {
        public ProdCategorySearchPage()
            : base("ProdCategorySearchBox", "ProdCategoryGrid") {
        }
    }
}