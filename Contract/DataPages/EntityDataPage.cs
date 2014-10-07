using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace Contract.DataPages
{
    public class ContractDataPage : Web
    {

        public override void PreBuildContents()
        {
           GetTabs("Contract", "Summary");
            //AddTabHead("新建合同");
            AddTopContent(GetCustomEntityTopFrame("Contract"));
            base.PreBuildContents();
        }
        public override void BuildContents()
        {
            try
            {
                string cont_ContractId = Dispatch.EitherField("cont_ContractId");
                if (string.IsNullOrEmpty(cont_ContractId))
                {
                    cont_ContractId = Dispatch.EitherField("key58");
                }

                Record Contract = FindRecord("Contract", "cont_ContractId=" + cont_ContractId);

                EntryGroup screenContract = new EntryGroup("ContractNewEntry");
                screenContract.Title = "Contract";
                screenContract.Fill(Contract);
                string cont_name=Contract.GetFieldAsString("cont_name");

                VerticalPanel vpMainPanel = new VerticalPanel();
                vpMainPanel.AddAttribute("width", "100%");
                vpMainPanel.Add(screenContract);

                List ContractDetailGrid = new List("ContractDetailGrid");
                ContractDetailGrid.Filter = "code_deleted is null and code_contractid=" + cont_ContractId;
                ContractDetailGrid.RowsPerScreen = 500;
                ContractDetailGrid.ShowNavigationButtons = true;
                ContractDetailGrid.PadBottom = false;
                vpMainPanel.Add(ContractDetailGrid);

                

                AddContent(vpMainPanel);
                
                    AddUrlButton("Edit", "Edit.gif", UrlDotNet(ThisDotNetDll, "RunDataPageEdit") + "&cont_ContractId=" + cont_ContractId);
                    AddUrlButton("Delete", "Delete.gif", UrlDotNet(ThisDotNetDll, "RunDataPageDelete") + "&cont_ContractId=" + cont_ContractId);
                   
                        AddUrlButton("Add ContractDetail", "new.gif", UrlDotNet(ThisDotNetDll, "RunContractDetailAdd") + "&cont_ContractId=" + cont_ContractId);
                       // AddUrlButton("Print", "Print.gif", Url("freport/QuotationReport.aspx") + "&quotationid=" + cont_ContractId + "&cont_name=" + cont_name + "&type=1");
                    
                    
                    AddUrlButton("Continue", "Continue.gif", UrlDotNet(ThisDotNetDll, "RunListPage"));
                //AddWorkflowButtons("Contract");
            }
            catch (Exception error)
            {
                this.AddError(error.Message);
            }
        }
    }
}