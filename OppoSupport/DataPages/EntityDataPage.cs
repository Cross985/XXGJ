using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace OppoSupport.DataPages {
    public class OppoSupportDataPage : Web {

        public override void PreBuildContents() {
            GetTabs("OppoSupport", "Summary");
            AddTopContent(GetCustomEntityTopFrame("OppoSupport"));
            base.PreBuildContents();
        }
        public override void BuildContents() {
            try {
                string opsu_OppoSupportId = Dispatch.EitherField("opsu_OppoSupportId");
                if (string.IsNullOrEmpty(opsu_OppoSupportId)) {
                    opsu_OppoSupportId = Dispatch.EitherField("key58");
                }

                Record OppoSupport = FindRecord("OppoSupport", "opsu_OppoSupportId=" + opsu_OppoSupportId);

                EntryGroup screenOppoSupport = new EntryGroup("OppoSupportNewEntry");
                screenOppoSupport.Title = "OppoSupport";
                screenOppoSupport.Fill(OppoSupport);

                string status = OppoSupport.GetFieldAsString("opsu_status");

                VerticalPanel vpMainPanel = new VerticalPanel();
                vpMainPanel.AddAttribute("width", "100%");
                vpMainPanel.Add(screenOppoSupport);

                AddContent(vpMainPanel);
                AddUrlButton("Edit", "Edit.gif", UrlDotNet(ThisDotNetDll, "RunDataPageEdit") + "&opsu_OppoSupportId=" + opsu_OppoSupportId);
                AddUrlButton("Delete", "Delete.gif", UrlDotNet(ThisDotNetDll, "RunDataPageDelete") + "&opsu_OppoSupportId=" + opsu_OppoSupportId);
                AddUrlButton("Continue", "Continue.gif", UrlDotNet(ThisDotNetDll, "RunListPage") + "&J=OppoSupport&T=Opportunity");
            } catch (Exception error) {
                this.AddError(error.Message);
            }
        }
    }
}