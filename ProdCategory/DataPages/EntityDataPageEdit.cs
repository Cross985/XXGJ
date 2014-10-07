using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace ProdCategory.DataPages {
    public class ProdCategoryDataPageEdit : DataPageEdit {
        public ProdCategoryDataPageEdit()
            : base("ProdCategory", "pcat_ProdCategoryId", "ProdCategoryNewEntry") {
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