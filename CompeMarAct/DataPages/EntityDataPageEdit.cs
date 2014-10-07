using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace CompeMarAct.DataPages {
    public class CompeMarActDataPageEdit : DataPageEdit {
        public CompeMarActDataPageEdit()
            : base("CompeMarAct", "cmac_CompeMarActId", "CompeMarActNewEntry") {
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