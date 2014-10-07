using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Blocks;
using Sage.CRM.Controls;
using Sage.CRM.Data;
using Sage.CRM.Errors;
using Sage.CRM.HTML;
using Sage.CRM.UI;
using Sage.CRM.Utils;
using Sage.CRM.Wrapper;

namespace Contract.DataPages
{
   // public class ContractDataPageDelete : DataPageDelete
    public class ContractDataPageDelete : Web
    {
        //public ContractDataPageDelete()
        //    : base("Contract", "cont_ContractId", "ContractNewEntry")
        //{
        //    this.EntryGroups[0].Title = "Contract";
        //    this.CancelMethod = "RunDataPage";
        //}
        public override void BuildContents()
        {
            AddContent(HTML.Form());
            try
            {
                string hMode = Dispatch.EitherField("HiddenMode");
                string cont_ContractId = Dispatch.EitherField("cont_ContractId");
                int errorflag = 0;
                string errormessage = string.Empty;
                Record Contract = FindRecord("Contract", "cont_ContractId=" + cont_ContractId);
                string type = Contract.GetFieldAsString("cont_type");
                EntryGroup ContractNewEntry = new EntryGroup("ContractNewEntry");
                ContractNewEntry.Fill(Contract);

                AddTabHead("Delete Contract");
                if (hMode == "Delete")
                {


                    Contract.DeleteRecord = true;
                    Contract.SaveChanges();
                    QuerySelect check = new QuerySelect();
                    check.SQLCommand = "delete contractdetail where code_contractid=" + cont_ContractId;
                    check.ExecuteNonQuery();

                    string url = UrlDotNet(ThisDotNetDll, "RunListPage");
                    Dispatch.Redirect(url);
                }
                if (errorflag != -1)
                {

                    AddContent(HTML.InputHidden("HiddenMode", ""));
                    VerticalPanel vpMainPanel = new VerticalPanel();
                    vpMainPanel.AddAttribute("width", "100%");
                    
                    string sUrl = "javascript:document.EntryForm.HiddenMode.value='Delete';";
                    ContractNewEntry.GetHtmlInViewMode(Contract);
                    vpMainPanel.Add(ContractNewEntry);
                    if (type.ToLower() != "product")
                    {
                        List ContractDetailGrid = new List("ContractDetailGrid");
                        ContractDetailGrid.Filter = "code_deleted is null and code_contractid=" + cont_ContractId + " and  code_isproduct='1'";
                        ContractDetailGrid.RowsPerScreen = 500;
                        ContractDetailGrid.ShowNavigationButtons = true;
                        ContractDetailGrid.PadBottom = false;
                        vpMainPanel.Add(ContractDetailGrid);
                    }
                    else
                    {

                        List ContractDetailProduct = new List("ContractDetailProduct");
                        ContractDetailProduct.Filter = "code_deleted is null and code_contractid=" + cont_ContractId + " and code_isproduct='2'";
                        ContractDetailProduct.RowsPerScreen = 500;
                        ContractDetailProduct.ShowNavigationButtons = true;
                        ContractDetailProduct.PadBottom = false;
                        vpMainPanel.Add(ContractDetailProduct);
                    }
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