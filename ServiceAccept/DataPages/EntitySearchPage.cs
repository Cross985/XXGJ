using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace ServiceAccept.DataPages {
    public class ServiceAcceptSearchPage : SearchPage {
        public ServiceAcceptSearchPage()
            : base("ServiceAcceptSearchBox", "ServiceAcceptGrid") {
        }
    }
}