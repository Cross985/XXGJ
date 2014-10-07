using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace Contract.DataPages
{
    public class ContractListPage : ListPage
    {
        public ContractListPage()
            : base("Contract", "ContractGrid", "ContractFilterBox")
        {

        }

        public override void BuildContents()
        {
            try
            {
                base.BuildContents();
            }
            catch (Exception error)
            {
                this.AddError(error.Message);
            }
        }
        public override void AddNewButton()
        {
            AddUrlButton("New", "New.gif", UrlDotNet(ThisDotNetDll, "RunDataPageNew") + "&J=Contract&T=new");
        }

    }
}