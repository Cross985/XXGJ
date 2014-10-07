using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace Company.DataPages
{
    public class CompanySearchPage : SearchPage
    {
        public CompanySearchPage()
            : base("CompanySearchBox", "CompanyGrid")
        {
        }
    }
}