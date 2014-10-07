using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.UI;
using Sage.CRM.Data;

namespace Contract.DataPages
{
    public class ContractDataPageEdit : DataPageEdit
    {
        public ContractDataPageEdit()
            : base("Contract", "cont_ContractId", "ContractNewEntry")
        {
            GetTabs("Contract", "Summary");
            this.CancelMethod = "RunDataPage";
        }

        public override void BuildContents()
        {
            try
            {

                /* Add your code here */
                this.EntryGroups[0].Title = "Contract";
                base.BuildContents();

                string cont_ContractId = Dispatch.EitherField("cont_ContractId");
                Record Contract = FindRecord("Contract", "cont_ContractId=" + cont_ContractId);
                double cont_amount = Contract.GetFieldAsDouble("cont_amount");
                double cont_discount = Contract.GetFieldAsDouble("cont_discount");
                double cont_discountamount = cont_amount - cont_discount;
                Contract.SetField("cont_discountamount", cont_discountamount);
                Contract.SaveChanges();
            }
            catch (Exception error)
            {
                this.AddError(error.Message);
            }
        }

    }
}