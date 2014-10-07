using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace MarActPool.DataPages {
    public class MarActPoolListPage : ListPage {
        public MarActPoolListPage()
            : base("MarActPool", "MarActPoolGrid", "MarActPoolFilterBox") {
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