using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace Follow.DataPages
{
    public class FollowListPage : ListPage
    {
        public FollowListPage()
            : base("Follow", "FollowList", "FollowFilterBox")
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