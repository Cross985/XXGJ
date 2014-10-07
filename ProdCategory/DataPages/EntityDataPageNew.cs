using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace ProdCategory.DataPages {
    public class ProdCategoryDataPageNew : DataPageNew {
        public ProdCategoryDataPageNew()
            : base("ProdCategory", "pcat_ProdCategoryId", "ProdCategoryNewEntry") {
        }

        public override void BuildContents() {
            try {

                /* Add your code here */
                this.EntryGroups[0].Title = "ProdCategory";
                base.BuildContents();
           
            } catch (Exception error) {
                this.AddError(error.Message);
            }
        }
    }
}