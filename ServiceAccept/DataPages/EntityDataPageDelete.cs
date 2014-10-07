using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace ServiceAccept.DataPages {
    public class ServiceAcceptDataPageDelete : DataPageDelete {
        public ServiceAcceptDataPageDelete()
            : base("ServiceAccept", "seac_ServiceAcceptId", "ServiceAcceptNewEntry") {
        }
    }
}