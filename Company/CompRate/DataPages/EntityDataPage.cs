using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace CompRate.DataPages
{
    public class CompRateDataPage : DataPage
    {

        public CompRateDataPage()
            : base("CompRate", "cprt_CompRateID", "CompRateNewEntry")
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