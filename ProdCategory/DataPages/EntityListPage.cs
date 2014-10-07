using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace ProdCategory.DataPages {
    public class ProdCategoryListPage : ListPage {
        public ProdCategoryListPage()
            : base("ProdCategory", "ProdCategoryGrid", "ProdCategoryFilterBox") {
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