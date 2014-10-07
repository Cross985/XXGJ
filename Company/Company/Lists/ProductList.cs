using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;

namespace Company
{
    class ProdList : ListPage
    {
        public ProdList()
            : base("Product", "ProductGrid", "ProductSearchScreen")
        {
            string compid = this.FindCurrentRecord("Company").RecordId.ToString();
            this.ResultsGrid.Filter = "prod_deleted is null and prod_companyid=" + compid;
        }
        public override void BuildContents()
        {
            base.BuildContents();
        }

        public override void AddNewButton()
        {
        }
    }
}
