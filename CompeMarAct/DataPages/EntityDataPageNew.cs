using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace CompeMarAct.DataPages {
    public class CompeMarActDataPageNew : DataPageNew {
        public CompeMarActDataPageNew()
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