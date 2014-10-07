using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace ProdCategory.DataPages {
    public class ProdCategoryDataPage : DataPage {

        public ProdCategoryDataPage()
            : base("ProdCategory", "pcat_ProdCategoryId", "ProdCategoryNewEntry") {
        }

        public override void BuildContents() {
            try {

                /* Add your code here */
                AddTabHead("ProdCategory");
                base.BuildContents();
            } catch (Exception error) {
                this.AddError(error.Message);
            }
        }
    }
}