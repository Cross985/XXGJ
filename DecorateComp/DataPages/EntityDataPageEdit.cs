using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace DecorateComp.DataPages {
    public class DecorateCompDataPageEdit : DataPageEdit {
        public DecorateCompDataPageEdit()
            : base("DecorateComp", "dcom_DecorateCompId", "DecorateCompNewEntry") {
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