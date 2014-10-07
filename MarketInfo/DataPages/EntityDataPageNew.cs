using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;

namespace MarketInfo.DataPages
{
    public class MarketInfoDataPageNew : DataPageNew
    {
        public MarketInfoDataPageNew()
            : base("MarketInfo", "maif_MarketInfoId", "MarketInfoNewEntry")
        {
            UseTabs = false;
        }

        public override void BuildContents()
        {
            try
            {

                /* Add your code here */
                AddTabHead("新建市场情报");
                this.EntryGroups[0].Title = "MarketInfo";
                
                base.BuildContents();                
            }
            catch (Exception error)
            {
                this.AddError(error.Message);
            }
        }
        public override void AfterSave(Sage.CRM.Controls.EntryGroup screen)
        {
            Record order = screen.getRecord;
            QuerySelect s = new QuerySelect();
            string prefix = "M" + DateTime.Now.ToString("yyyyMMdd");
            s.SQLCommand = "select count(*) as count from MarketInfo where maif_name like '" + prefix + "%'";
            s.ExecuteReader();
            int cnt = 0;
            if (!s.Eof())
            {
                cnt = Convert.ToInt32(s.FieldValue("count"));
            }
            string code = string.Empty;
            code = prefix + (cnt + 1).ToString().PadLeft(2, '0');
            order.SetField("maif_name", code);
            order.SaveChanges();
            base.AfterSave(screen);
        }
    }
}