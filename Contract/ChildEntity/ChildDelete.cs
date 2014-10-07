using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace Contract
{
    public class ContractDetailDelete : Web
    {
        public override void BuildContents()
        {
            AddContent(HTML.Form());
            try
            {
                string hMode = Dispatch.EitherField("HiddenMode");
                string id = Dispatch.EitherField("code_ContractDetailId");
                int errorflag = 0;
                string errormessage = string.Empty;
                Record ContractDetail = FindRecord("ContractDetail", "code_ContractDetailId=" + id);
                double code_money = ContractDetail.GetFieldAsDouble("code_money");
                double code_qty = ContractDetail.GetFieldAsDouble("code_qty");

                string cont_ContractId = ContractDetail.GetFieldAsString("code_contractid");
                EntryGroup ContractDetailNewEntry = new EntryGroup("ContractDetailNewEntry");
                ContractDetailNewEntry.Fill(ContractDetail);

                Entry IntentionOrderidEntry = ContractDetailNewEntry.GetEntry("code_contractid");

                AddTabHead("Delete ContractDetail");
                if (hMode == "Delete")
                {                   
                    
                    Record Contract = FindRecord("Contract", "cont_ContractId=" + cont_ContractId);
                    double cont_amount = Contract.GetFieldAsDouble("cont_amount");
                    double cont_qty = Contract.GetFieldAsDouble("cont_qty");
                    cont_amount = cont_amount - code_money;
                    cont_qty = cont_qty - code_qty;

                    Contract.SetField("cont_amount", cont_amount);
                    Contract.SetField("cont_qty", cont_qty);
                    Contract.SaveChanges();

                    ContractDetail.DeleteRecord = true;
                    ContractDetail.SaveChanges();


                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&cont_ContractId=" + cont_ContractId + "&J=Summary";
                    url = url.Replace("Key37", "ContractDetailid");
                    url = url + "&Key37=" + cont_ContractId;
                    Dispatch.Redirect(url);
                }
                if (errorflag != -1)
                {

                    AddContent(HTML.InputHidden("HiddenMode", ""));
                    VerticalPanel vpMainPanel = new VerticalPanel();
                    vpMainPanel.AddAttribute("width", "100%");
                    string sUrl = "javascript:document.EntryForm.HiddenMode.value='Delete';";
                    ContractDetailNewEntry.GetHtmlInViewMode(ContractDetail);
                    vpMainPanel.Add(ContractDetailNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("ConfirmDelete", "Delete.gif", sUrl);
                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&cont_ContractId=" + cont_ContractId + "&J=Summary";
                    url = url.Replace("Key37", "ContractDetailid");
                    url = url + "&Key37=" + cont_ContractId;
                    AddUrlButton("Cancel", "cancel.gif", url);
                }

            }
            catch (Exception e)
            {
                AddError(e.Message);
            }
        }
    }
}
