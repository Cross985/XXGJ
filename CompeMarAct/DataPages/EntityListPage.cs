using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace CompeMarAct.DataPages {
    public class CompeMarActListPage : ListPage {
        public CompeMarActListPage()
            : base("CompeMarAct", "CompeMarActGrid", "CompeMarActFilterBox") {
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