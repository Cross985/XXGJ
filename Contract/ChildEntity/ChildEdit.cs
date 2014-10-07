using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;
using Sage.CRM.Utils;

namespace Contract
{
    public class ContractDetailEdit : Web
    {
        public override void BuildContents()
        {
            AddContent(HTML.Form());

            try
            {
                string hMode = Dispatch.EitherField("HiddenMode");
                string code_ContractDetailId = Dispatch.EitherField("code_ContractDetailId");
                int errorflag = 0;
                string errormessage = string.Empty;
                Record ContractDetail = FindRecord("ContractDetail", "code_ContractDetailId=" + code_ContractDetailId);
                double originalcode_money = ContractDetail.GetFieldAsDouble("code_money");
                double originalcode_qty = ContractDetail.GetFieldAsDouble("code_qty");

                string cont_ContractId = ContractDetail.GetFieldAsString("code_contractid");
                EntryGroup ContractDetailNewEntry = new EntryGroup("ContractDetailNewEntry");
                ContractDetailNewEntry.Fill(ContractDetail);
                Entry IntentionOrderidEntry = ContractDetailNewEntry.GetEntry("code_contractid");
                IntentionOrderidEntry.ReadOnly = true;

                AddTabHead("ContractDetail");
                if (hMode == "Save")
                {

                    
                    ContractDetailNewEntry.Fill(ContractDetail);
                    double code_money = ContractDetail.GetFieldAsDouble("code_money");
                    double code_qty = ContractDetail.GetFieldAsDouble("code_qty");

                    if (ContractDetailNewEntry.Validate())
                    {
                        ContractDetail.SaveChanges();

                        Record Contract = FindRecord("Contract", "cont_ContractId=" + cont_ContractId);
                        double cont_amount = Contract.GetFieldAsDouble("cont_amount");
                        double cont_qty = Contract.GetFieldAsDouble("cont_qty");

                        cont_amount = cont_amount + code_money - originalcode_money;
                        cont_qty = cont_qty + code_qty - originalcode_qty;

                        Contract.SetField("cont_amount", cont_amount);
                        Contract.SetField("cont_qty", cont_qty);
                        Contract.SaveChanges();

                        double code_targetmoney = ContractDetail.GetFieldAsDouble("code_targetmoney");
                        if (code_targetmoney == 0) { code_targetmoney = 1; }
                        double code_targetqty = ContractDetail.GetFieldAsDouble("code_targetqty");
                        if (code_targetqty == 0) { code_targetqty = 1; }

                        ContractDetail.SetField("code_moneyrate", code_money / code_targetmoney);
                        ContractDetail.SetField("code_qtyrate", code_qty / code_targetqty);
                        ContractDetail.SaveChanges();

                        string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&cont_ContractId=" + cont_ContractId + "&J=Summary";
                        url = url.Replace("Key37", "ContractDetailid");
                        url = url + "&Key37=" + cont_ContractId;
                        Dispatch.Redirect(url);
                        errorflag = -1;
                    }
                    else
                    {
                        errorflag = 1;
                    }

                }
                if (errorflag != -1)
                {

                    AddContent(HTML.InputHidden("HiddenMode", ""));
                    VerticalPanel vpMainPanel = new VerticalPanel();
                    vpMainPanel.AddAttribute("width", "100%");
                    string sUrl = "javascript:document.EntryForm.HiddenMode.value='Save';";
                    ContractDetailNewEntry.GetHtmlInEditMode(ContractDetail);
                    vpMainPanel.Add(ContractDetailNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("Save", "Save.gif", sUrl);
                    string urldelete = base.UrlDotNet(base.ThisDotNetDll, "RunContractDetailDelete") + "&code_ContractDetailId=" + code_ContractDetailId;
                    base.AddUrlButton("Delete", "Delete.gif", urldelete);
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
