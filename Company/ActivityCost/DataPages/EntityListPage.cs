using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace ActivityIncome.DataPages
{
    public class ActivityIncomeListPage : ListPage
    {
        public ActivityIncomeListPage()
            : base("ActivityIncome", "ActivityIncomeList", "ActivityIncomeFilterBox")
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