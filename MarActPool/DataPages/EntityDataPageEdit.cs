using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace MarActPool.DataPages {
    public class MarActPoolDataPageEdit : DataPageEdit {
        public MarActPoolDataPageEdit()
            : base("MarActPool", "mapo_MarActPoolId", "MarActPoolNewEntry") {
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