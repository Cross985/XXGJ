using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace ServiceAccept.DataPages {
    public class ServiceAcceptDataPageEdit : DataPageEdit {
        public ServiceAcceptDataPageEdit()
            : base("ServiceAccept", "seac_ServiceAcceptId", "ServiceAcceptNewEntry") {
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