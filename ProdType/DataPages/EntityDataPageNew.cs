using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace ProdType.DataPages {
    public class ProdTypeDataPageNew : DataPageNew {
        public ProdTypeDataPageNew()
            : base("ProdType", "ptyp_ProdTypeId", "ProdTypeNewEntry") {
        }

        public override void BuildContents() {
            try {

                /* Add your code here */
                this.EntryGroups[0].Title = "ProdType";
                base.BuildContents();
            } catch (Exception error) {
                this.AddError(error.Message);
            }
        }
    }
}