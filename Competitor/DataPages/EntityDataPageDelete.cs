using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace Competitor.DataPages
{
    public class CompetitorDataPageDelete : DataPageDelete
    {
        public CompetitorDataPageDelete()
            : base("Competitor", "cpet_competitorid", "CompetitorNewEntry")
        {
        }
    }
}