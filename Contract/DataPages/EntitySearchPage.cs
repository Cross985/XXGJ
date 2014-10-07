using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace Contract.DataPages
{
    public class ContractSearchPage : SearchPage
    {
        public ContractSearchPage()
            : base("ContractSearchBox", "ContractGrid")
        {
        }
    }
}