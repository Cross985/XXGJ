using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;

namespace Competitor.DataPages
{
    public class CompetitorSearchPage : SearchPage
    {
        public CompetitorSearchPage()
            : base("CompetitorSearchBox", "CompetitorGrid")
        {
        }
    }
}