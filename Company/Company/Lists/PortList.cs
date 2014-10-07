using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;

namespace Company
{
    class PortList : ListPage
    {
        public PortList()
            : base("Port", "PortGrid", "PortSearchBox")
        {
            string compid = this.FindCurrentRecord("Company").RecordId.ToString();
            this.ResultsGrid.Filter = "port_deleted is null and port_companyid=" + compid;
        }
        public override void BuildContents()
        {
            base.BuildContents();
        }

        public override void AddNewButton()
        {
            string compid = this.FindCurrentRecord("Company").RecordId.ToString();
            AddUrlButton("New", "New.gif", UrlDotNet("Port", "RunDataPageNew") + "&comp_companyid=" + compid);
            //base.AddNewButton();
        }
    }
}
