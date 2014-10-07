using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Controls;
using Sage.CRM.Data;
using Sage.CRM.UI;

namespace Company.DataPages
{
    public class CompanyDataPage : Web
    {
        public override void BuildContents()
        {
            try
            {
                AddContent(HTML.Form());
                string compid = Dispatch.EitherField("comp_companyid");
                if (string.IsNullOrEmpty(compid))
                    compid = Dispatch.EitherField("key1");
                EntryGroup CompEntry = new EntryGroup("CompanyBoxLong");
                CompEntry.Title = "基础信息";
                EntryGroup DealEntry = new EntryGroup("CompanyDealEntry");
                DealEntry.Title = "交易信息";
                EntryGroup StatusEntry = new EntryGroup("CompanyStatusEntry");
                StatusEntry.Title = "状态信息";
                Record CompRec = FindRecord("Company","comp_companyid=" + compid);
                CompEntry.Fill(CompRec);
                DealEntry.Fill(CompRec);
                StatusEntry.Fill(CompRec);
                GetTabs("CompanySummary", "Summary");

                //Entry userid = CompEntry.GetEntry("comp");
                //userid.OnChangeScript = "";
                List UseList = new List("UseSituationGrid");
                UseList.Filter = "usst_deleted is null and usst_companyid =" + compid;
                UseList.PadBottom = false;
                List AddressList = new List("CompanyAddressGrid");
                AddressList.Filter = "addr_deleted is null and addr_companyid ="+compid;
                AddressList.PadBottom = false;
                List InvoceList = new List("InvoiceTitleGrid");
                InvoceList.Filter = "inti_deleted is null and inti_companyid="+compid;
                InvoceList.PadBottom = false;
                //FollowGrid
                //List FollowList = new List("FollowGrid");
                //FollowList.Filter = "foll_deleted is null and foll_companyid=" + compid;
                //FollowList.PadBottom = false;

                CompEntry.GetHtmlInViewMode(CompRec);
                DealEntry.GetHtmlInViewMode(CompRec);
                StatusEntry.GetHtmlInViewMode(CompRec);
                VerticalPanel vp = new VerticalPanel();
                vp.AddAttribute("width", "100%");
                vp.Add(CompEntry);
                vp.Add(DealEntry);
                vp.Add(StatusEntry);
                vp.Add(UseList);
                vp.Add(AddressList);
                vp.Add(InvoceList);
                //vp.Add(FollowList);
                AddContent(vp);

                AddUrlButton("Edit","Edit.gif",UrlDotNet(ThisDotNetDll,"RunDataPageEdit") + "&comp_companyid=" + compid);
                AddUrlButton("添加销售情况", "New.gif", UrlDotNet(ThisDotNetDll, "RunUSAdd") + "&comp_companyid=" + compid + "&J=UseSituation Summary");
                AddUrlButton("添加地址", "New.gif", UrlDotNet(ThisDotNetDll, "RunAddressAdd") + "&comp_companyid=" + compid + "&J=Address");
                AddUrlButton("添加抬头", "New.gif", UrlDotNet(ThisDotNetDll, "RunInvoiceAdd") + "&comp_companyid=" + compid +"&J=InvoiceTitle");
                AddUrlButton("添加跟进", "New.gif", UrlDotNet("Follow", "RunDataPageNew") + "&key1=" + compid + "&J=follow");
                
                AddUrlButton("Cancel", "Cancel.gif", UrlDotNet(ThisDotNetDll, "RunListPage") + "&T=CompanyList");
            }
            catch (Exception error)
            {
                this.AddError(error.Message);
            }
        }
    }
}