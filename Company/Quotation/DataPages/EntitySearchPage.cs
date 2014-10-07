using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace Quotation.DataPages
{
    public class QuotationSearchPage : SearchPage
    {
        public QuotationSearchPage()
            : base("QuotationSearchBox", "QuotationGrid")
        {
        }
    }
}