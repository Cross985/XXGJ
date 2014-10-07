using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace CompRate.DataPages
{
    public class CompRateListPage : ListPage
    {
        public CompRateListPage()
            : base("CompRate", "CompRateList", "CompRateFilterBox")
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