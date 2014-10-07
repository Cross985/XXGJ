using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace ActivityIncome.DataPages
{
    public class ActivityIncomeDataPage : DataPage
    {

        public ActivityIncomeDataPage()
            : base("ActivityIncome", "acin_ActivityIncomeID", "ActivityIncomeNewEntry")
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