using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace CompeMarAct.DataPages {
    public class CompeMarActDataPageDelete : DataPageDelete {
        public CompeMarActDataPageDelete()
            : base("CompeMarAct", "cmac_CompeMarActId", "CompeMarActNewEntry") {
        }
    }
}