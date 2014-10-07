using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace Company.DataPages
{
    public class CompanyDataPageDelete : DataPageDelete
    {
        public CompanyDataPageDelete()
            : base("Company", "comp_companyid", "CompanyDetailBox")
        {
        }
    }
}