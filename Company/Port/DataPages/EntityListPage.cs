using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace Port.DataPages
{
    public class PortListPage : ListPage
    {
        public PortListPage()
            : base("Port", "PortList", "PortFilterBox")
        {
            //FilterByField = "";
            //FilterByContextId = (int)Sage.KeyList.UserId;

        }

        public override void BuildContents()
        {
            try
            {

                /* Add your code here */

                base.BuildContents();
            }
            catch (Exception error)
            {
                this.AddError(error.Message);
            }
        }
    }
}