using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;


namespace Maintenance.DataPages {
    public class MaintenanceDataPageNew : DataPageNew {
        public MaintenanceDataPageNew()
            : base("Maintenance", "mate_MaintenanceId", "MaintenanceNewEntry") {
        }

        public override void BuildContents() {
            try {

                /* Add your code here */

                base.BuildContents();
            } catch (Exception error) {
                this.AddError(error.Message);
            }
        }
        public override void AfterSave(Sage.CRM.Controls.EntryGroup screen) {
            //维修单编码规则 R+年月日+2码流水
            Record order = screen.getRecord;
            QuerySelect s = new QuerySelect();
            string username = CurrentUser.UserName;
            string prefix = "R" + DateTime.Now.ToString("yyyyMMDD");
            s.SQLCommand = "select count(*) as count from Maintenance where mate_name like '" + prefix + "%'";
            s.ExecuteReader();
            int cnt = 0;
            if (!s.Eof()) {
                cnt = Convert.ToInt32(s.FieldValue("count"));
            }
            string code = string.Empty;
            code = prefix + (cnt + 1).ToString().PadLeft(2, '0');
            order.SetField("mate_name", code);
            order.SaveChanges();
            base.AfterSave(screen);
        }
    }
}