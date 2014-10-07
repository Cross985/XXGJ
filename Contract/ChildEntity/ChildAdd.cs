using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Controls;
using Sage.CRM.UI;
using Sage.CRM.Data;

namespace Contract
{
    public class ContractDetailAdd : Web
    {
        public override void BuildContents()
        {
            AddContent(HTML.Form());

            try
            {
                string hMode = Dispatch.EitherField("HiddenMode");
                string cont_ContractId = Dispatch.EitherField("cont_ContractId");
                int errorflag = 0;
                string errormessage = string.Empty;
                EntryGroup ContractDetailNewEntry = new EntryGroup("ContractDetailNewEntry");
                //CostAdjustmentProductNewEntry.Title = "Add CostAdjustmentProduct"; 
                Entry code_contractidEntry = ContractDetailNewEntry.GetEntry("code_contractid");


                if (code_contractidEntry != null)
                {
                    code_contractidEntry.DefaultValue = cont_ContractId;
                    code_contractidEntry.ReadOnly = true;
                    //code_contractidEntry.Hidden = true;

                }
                AddTabHead("ContractDetail");
                if (hMode == "Save")
                {
                    Record ContractDetail = new Record("ContractDetail");
                    ContractDetailNewEntry.Fill(ContractDetail);
                    if (ContractDetailNewEntry.Validate()) {

                        //int cnt = 0;
                        //QuerySelect check = new QuerySelect();
                        //check.SQLCommand = "select COUNT(*) as cnt from ContractDetail where (code_contractid=" + cont_ContractId + " and code_productname='" + ContractDetail.GetFieldAsString("code_productname") + "' and code_price = '" + ContractDetail.GetFieldAsString("code_price") + "' and code_day = '" + ContractDetail.GetFieldAsString("code_day") + "' and code_time ='" + ContractDetail.GetFieldAsString("code_time") + "' and code_money ='" + ContractDetail.GetFieldAsString("code_money") + "'and code_lecturer = '" + ContractDetail.GetFieldAsString("code_lecturer") + "' and code_lecturername ='" + ContractDetail.GetFieldAsString("code_lecturername") + "' and code_students = '" + ContractDetail.GetFieldAsString("code_students") + "' and code_place ='" + ContractDetail.GetFieldAsString("code_place") + "' and code_startdate = '" + ContractDetail.GetFieldAsString("code_startdate") + "' and code_enddate = '" + ContractDetail.GetFieldAsString("code_enddate") + "'and code_deleted is null) or (code_contractid=" + cont_ContractId + "and code_lecturername='" + ContractDetail.GetFieldAsString("code_lecturername") + "'and code_startdate = '" + ContractDetail.GetFieldAsString("code_startdate") + "'and code_enddate = '" + ContractDetail.GetFieldAsString("code_enddate") + "'and code_deleted is null) or (code_contractid=" + cont_ContractId + " and code_lecturername='" + ContractDetail.GetFieldAsString("code_lecturername") + "'and ((code_startdate>'" + ContractDetail.GetFieldAsString("code_startdate") + "'and code_startdate<'" + ContractDetail.GetFieldAsString("code_enddate") + "') or(code_enddate>'" + ContractDetail.GetFieldAsString("code_startdate") + "'and code_enddate<'" + ContractDetail.GetFieldAsString("code_enddate") + "'))and code_deleted is null) or (code_contractid=" + cont_ContractId + "and code_lecturername='" + ContractDetail.GetFieldAsString("code_lecturername") + "'and (code_startdate between '" + ContractDetail.GetFieldAsString("code_startdate") + "' and '" + ContractDetail.GetFieldAsString("code_enddate") + "'or code_enddate between '" + ContractDetail.GetFieldAsString("code_startdate") + "' and '" + ContractDetail.GetFieldAsString("code_enddate") + "')and code_deleted is null)";
                        //check.ExecuteReader();
                        //if (!check.Eof())
                        //{
                        //    cnt = Convert.ToInt32(check.FieldValue("cnt"));
                        //}
                        //if (cnt > 0)
                        //{
                        //    errorflag = 2;
                        //    errormessage = "与上一条明细完全一致或老师日期有重叠！";
                        //}
                        //else
                        //{
                        ContractDetail.SaveChanges();
                        Record Contract = FindRecord("Contract", "cont_ContractId=" + cont_ContractId);
                        double cont_amount = Contract.GetFieldAsDouble("cont_amount");
                        double cont_qty = Contract.GetFieldAsDouble("cont_qty");
                        double cont_discount = Contract.GetFieldAsDouble("cont_discount");
                        double cont_salediscount = Contract.GetFieldAsDouble("cont_salediscount");

                        double code_money = ContractDetail.GetFieldAsDouble("code_money");
                        double code_qty = ContractDetail.GetFieldAsDouble("code_qty");
                        double code_targetmoney=ContractDetail.GetFieldAsDouble("code_targetmoney");
                        if(code_targetmoney==0){ code_targetmoney=1;}
                        double code_targetqty=ContractDetail.GetFieldAsDouble("code_targetqty");
                        if(code_targetqty==0){code_targetqty=1;}
                        cont_amount = cont_amount + code_money;
                        cont_qty = cont_qty + code_qty;
                        //double cont_discountamount = cont_amount - cont_discount;
                        Contract.SetField("cont_amount", cont_amount);
                        Contract.SetField("cont_qty", cont_qty);
                        //Contract.SetField("cont_discountamount", cont_discountamount);
                        ContractDetail.SetField("code_moneyrate", code_money / code_targetmoney);
                        ContractDetail.SetField("code_qtyrate", code_qty / code_targetqty);
                        ContractDetail.SaveChanges();
                        Contract.SaveChanges();
                        string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&cont_ContractId=" + cont_ContractId + "&J=Summary";
                        url = url.Replace("Key37", "ContractDetailid");
                        url = url + "&Key37=" + cont_ContractId;
                        Dispatch.Redirect(url);
                        errorflag = -1;
                        //}
                    }
                    else
                    {
                        errorflag = 1;
                    }
                }
                if (errorflag != -1)
                {
                    if (errorflag == 2)
                    {
                        AddError(errormessage);
                    }

                    AddContent(HTML.InputHidden("HiddenMode", ""));
                    VerticalPanel vpMainPanel = new VerticalPanel();
                    vpMainPanel.AddAttribute("width", "100%");
                    string sUrl = "javascript:document.EntryForm.HiddenMode.value='Save';";
                    ContractDetailNewEntry.GetHtmlInEditMode();
                    vpMainPanel.Add(ContractDetailNewEntry);
                    AddContent(vpMainPanel);
                    AddSubmitButton("Save", "Save.gif", sUrl);
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
