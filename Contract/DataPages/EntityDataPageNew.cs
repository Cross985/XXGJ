using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;

namespace Contract.DataPages
{
    public class ContractDataPageNew : DataPageNew
    {
        public ContractDataPageNew()
            : base("Contract", "cont_ContractId", "ContractNewEntry")
        {
        }

        public override void BuildContents()
        {
            try
            {

                /* Add your code here */
                this.EntryGroups[0].Title = "Contract";
                //QuerySelect s = new QuerySelect();
                //string prefix = "CO" + DateTime.Now.ToString("yyyyMMdd");
                //s.SQLCommand = "update Person set pers_address=Addr_Address1, pers_postcode=Addr_PostCode, pers_fax=(RTRIM(ISNULL(pers_faxcountrycode, '')) + ' ' + RTRIM(ISNULL(pers_faxareacode, '')) + ' ' + RTRIM(ISNULL(pers_faxnumber, ''))),Pers_Phone=(RTRIM(ISNULL(Pers_PhoneCountryCode, '')) + ' ' + RTRIM(ISNULL(Pers_PhoneAreaCode, '')) + ' ' + RTRIM(ISNULL(Pers_PhoneNumber, ''))) from Person  left join Address_Link on AdLi_PersonID=Pers_PersonId left join Address on Addr_AddressId=AdLi_AddressId left join Email on Emai_CompanyID=Pers_CompanyId where AdLi_Type='Business'";
                //s.ExecuteNonQuery();
                base.BuildContents();
            }
            catch (Exception error)
            {
                this.AddError(error.Message);
            }
        }
        public override void AfterSave(Sage.CRM.Controls.EntryGroup screen)
        {
           //合同编码规则 CH+年+月+4码流水
            Record order = screen.getRecord;
            QuerySelect s = new QuerySelect();
            string username = CurrentUser.UserName;
            string prefix = "CH" + DateTime.Now.ToString("yyyyMM");
            s.SQLCommand = "select count(*) as count from Contract where cont_name like '" + prefix + "%'";
            s.ExecuteReader();
            int cnt = 0;
            if (!s.Eof())
            {
                cnt = Convert.ToInt32(s.FieldValue("count"));
            }
            string code = string.Empty;
            code = prefix + (cnt + 1).ToString().PadLeft(4, '0');
            order.SetField("cont_name", code);
            order.SaveChanges();
            base.AfterSave(screen);
        }
    }
}