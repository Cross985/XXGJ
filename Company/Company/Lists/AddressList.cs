using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;

namespace Company
{
    class AddressList : ListPage
    {
        public AddressList()
            : base("Address", "CompanyAddressGrid", "AddressSearchBox")
        {
            string compid = this.FindCurrentRecord("Company").RecordId.ToString();
            this.ResultsGrid.Filter = "addr_deleted is null and addr_companyid=" + compid;
        }
        public override void BuildContents()
        {
            base.BuildContents();
        }

        public override void AddNewButton()
        {
            string compid = this.FindCurrentRecord("Company").RecordId.ToString();
            AddUrlButton("New", "New.gif", UrlDotNet("Company", "RunAddressAdd") + "&comp_companyid=" + compid);
            //base.AddNewButton();
        }
    }
}
