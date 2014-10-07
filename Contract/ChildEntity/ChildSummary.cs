using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace Contract
{
    public class ContractDetailSummary : Web
    {
        string cont_ContractId = string.Empty;
        string code_ContractDetailId = string.Empty;
        public override void PreBuildContents()
        {
            GetTabs("ContractDetail", "Summary");
            AddTopContent(GetCustomEntityTopFrame("ContractDetail"));
            base.PreBuildContents();
        }
        public override void BuildContents()
        {
            try
            {
                string code_ContractDetailId = Dispatch.EitherField("code_ContractDetailId");

                Record ContractDetail = FindRecord("ContractDetail", "code_ContractDetailId=" + code_ContractDetailId);
                cont_ContractId = ContractDetail.GetFieldAsString("code_contractid");

                Record order = FindRecord("Contract", "cont_ContractId=" + cont_ContractId);
                string status = order.GetFieldAsString("cont_status");
                if (status == "draft")
                {
                    string urledit = base.UrlDotNet(base.ThisDotNetDll, "RunContractDetailEdit") + "&code_ContractDetailId=" + code_ContractDetailId;
                    Dispatch.Redirect(urledit);
                }


                EntryGroup ContractDetailNewEntry = new EntryGroup("ContractDetailNewEntry");

                ContractDetailNewEntry.Title = "ContractDetail";
                ContractDetailNewEntry.Fill(ContractDetail);

                VerticalPanel vpMainPanel = new VerticalPanel();
                vpMainPanel.AddAttribute("width", "100%");
                vpMainPanel.Add(ContractDetailNewEntry);
                AddContent(vpMainPanel);
                string urldelete = base.UrlDotNet(base.ThisDotNetDll, "RunContractDetailDelete") + "&code_ContractDetailId=" + code_ContractDetailId;
                base.AddUrlButton("Delete", "Delete.gif", urldelete);

                string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&cont_ContractId=" + cont_ContractId;
                url = url.Replace("Key37", "ContractDetailid");
                url = url + "&Key37=" + cont_ContractId;
                this.AddUrlButton("cancel", "PrevCircle.gif", url);
                AddWorkflowButtons("ContractDetail");
            }
            catch (Exception error)
            {
                this.AddError(error.Message);
            }
        }
    }
}