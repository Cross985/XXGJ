using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace Follow.DataPages
{
    public class FollowDataPage : DataPage
    {

        public FollowDataPage()
            : base("Follow", "foll_FollowID", "FollowNewEntry")
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