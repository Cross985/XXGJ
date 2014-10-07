using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace DecorateComp.DataPages {
    public class DecorateCompListPage : ListPage {
        public DecorateCompListPage()
            : base("DecorateComp", "DecorateCompGridt", "DecorateCompFilterBox") {
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