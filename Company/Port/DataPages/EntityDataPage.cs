using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace Port.DataPages
{
    public class PortDataPage : DataPage
    {

        public PortDataPage()
            : base("Port", "port_PortID", "PortDetailBox")
        {
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