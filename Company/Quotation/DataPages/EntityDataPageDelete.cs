using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace Quotation.DataPages
{
    public class QuotationDataPageDelete : DataPageDelete
    {
        public QuotationDataPageDelete()
            : base("Quotation", "quta_quotationid", "QuotationDetailBox")
        {
        }
    }
}