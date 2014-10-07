using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace ProdType.DataPages {
    public class ProdTypeDataPage : DataPage {

        public ProdTypeDataPage()
            : base("ProdType", "ptyp_ProdTypeId", "ProdTypeNewEntry") {
        }

        public override void BuildContents() {
            try {

                /* Add your code here */
                AddTabHead("ProdType");
                base.BuildContents();
            } catch (Exception error) {
                this.AddError(error.Message);
            }
        }
    }
}