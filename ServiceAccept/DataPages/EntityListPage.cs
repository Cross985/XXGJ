using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace ServiceAccept.DataPages {
    public class ServiceAcceptListPage : ListPage {
        public ServiceAcceptListPage()
            : base("ServiceAccept", "ServiceAcceptGrid", "ServiceAcceptFilterBox") {
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