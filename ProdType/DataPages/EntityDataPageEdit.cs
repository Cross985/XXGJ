using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace ProdType.DataPages {
    public class ProdTypeDataPageEdit : DataPageEdit {
        public ProdTypeDataPageEdit()
            : base("ProdType", "ptyp_ProdTypeId", "ProdTypeNewEntry") {
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