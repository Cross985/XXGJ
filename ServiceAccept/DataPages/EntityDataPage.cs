using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace ServiceAccept.DataPages {
    public class ServiceAcceptDataPage : Web {

        public override void PreBuildContents() {
            GetTabs("ServiceAccept", "Summary");
            AddTopContent(GetCustomEntityTopFrame("ServiceAccept"));
            base.PreBuildContents();
        }
        public override void BuildContents() {
            try {
                string seac_ServiceAcceptId = Dispatch.EitherField("seac_ServiceAcceptId");
                if (string.IsNullOrEmpty(seac_ServiceAcceptId)) {
                    seac_ServiceAcceptId = Dispatch.EitherField("key58");
                }

                Record ServiceAccept = FindRecord("ServiceAccept", "seac_ServiceAcceptId=" + seac_ServiceAcceptId);

                EntryGroup screenServiceAccept = new EntryGroup("ServiceAcceptNewEntry");
                screenServiceAccept.Title = "ServiceAccept";
                screenServiceAccept.Fill(ServiceAccept);

                string status = ServiceAccept.GetFieldAsString("seac_status");


                VerticalPanel vpMainPanel = new VerticalPanel();
                vpMainPanel.AddAttribute("width", "100%");
                vpMainPanel.Add(screenServiceAccept);

                List CusUseStatusGrid = new List("CusUseStatusGrid");
                CusUseStatusGrid.Filter = "cust_deleted is null and cust_serviceacceptid=" + seac_ServiceAcceptId;
                CusUseStatusGrid.RowsPerScreen = 500;
                CusUseStatusGrid.ShowNavigationButtons = true;
                CusUseStatusGrid.PadBottom = false;
                vpMainPanel.Add(CusUseStatusGrid);

                List ServiceDealGrid = new List("ServiceDealGrid");
                ServiceDealGrid.Filter = "sede_deleted is null and sede_serviceacceptid=" + seac_ServiceAcceptId;
                ServiceDealGrid.RowsPerScreen = 500;
                ServiceDealGrid.ShowNavigationButtons = true;
                ServiceDealGrid.PadBottom = false;
                vpMainPanel.Add(ServiceDealGrid);

                AddContent(vpMainPanel);
                AddUrlButton("Edit", "Edit.gif", UrlDotNet(ThisDotNetDll, "RunDataPageEdit") + "&seac_ServiceAcceptId=" + seac_ServiceAcceptId);
                AddUrlButton("Delete", "Delete.gif", UrlDotNet(ThisDotNetDll, "RunDataPageDelete") + "&seac_ServiceAcceptId=" + seac_ServiceAcceptId);
                AddUrlButton("Add CusUseStatus", "new.gif", UrlDotNet(ThisDotNetDll, "RunCusUseStatusAdd") + "&seac_ServiceAcceptId=" + seac_ServiceAcceptId);
                AddUrlButton("Add ServiceDeal", "new.gif", UrlDotNet(ThisDotNetDll, "RunServiceDealAdd") + "&seac_ServiceAcceptId=" + seac_ServiceAcceptId);
                AddUrlButton("Continue", "Continue.gif", UrlDotNet(ThisDotNetDll, "RunListPage"));
            } catch (Exception error) {
                this.AddError(error.Message);
            }
        }
    }
}