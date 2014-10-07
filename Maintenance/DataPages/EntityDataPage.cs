using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace Maintenance.DataPages {
    public class MaintenanceDataPage : Web {

        public override void PreBuildContents() {
            GetTabs("Maintenance", "Summary");
            AddTopContent(GetCustomEntityTopFrame("Maintenance"));
            base.PreBuildContents();
        }
        public override void BuildContents() {
            try {
                string mate_MaintenanceId = Dispatch.EitherField("mate_MaintenanceId");
                if (string.IsNullOrEmpty(mate_MaintenanceId)) {
                    mate_MaintenanceId = Dispatch.EitherField("key58");
                }

                Record Maintenance = FindRecord("Maintenance", "mate_MaintenanceId=" + mate_MaintenanceId);

                EntryGroup screenMaintenance = new EntryGroup("MaintenanceNewEntry");
                screenMaintenance.Title = "Maintenance";
                screenMaintenance.Fill(Maintenance);

                string status = Maintenance.GetFieldAsString("mate_status");


                VerticalPanel vpMainPanel = new VerticalPanel();
                vpMainPanel.AddAttribute("width", "100%");
                vpMainPanel.Add(screenMaintenance);

                List MainteDetailGrid = new List("MainteDetailGrid");
                MainteDetailGrid.Filter = "mtde_deleted is null and mtde_maintenanceid=" + mate_MaintenanceId;
                MainteDetailGrid.RowsPerScreen = 500;
                MainteDetailGrid.ShowNavigationButtons = true;
                MainteDetailGrid.PadBottom = false;
                vpMainPanel.Add(MainteDetailGrid);

                List BadTypeGrid = new List("BadTypeGrid");
                BadTypeGrid.Filter = "badt_deleted is null and badt_Maintenanceid=" + mate_MaintenanceId;
                BadTypeGrid.RowsPerScreen = 500;
                BadTypeGrid.ShowNavigationButtons = true;
                BadTypeGrid.PadBottom = false;
                vpMainPanel.Add(BadTypeGrid);

                AddContent(vpMainPanel);
                AddUrlButton("Edit", "Edit.gif", UrlDotNet(ThisDotNetDll, "RunDataPageEdit") + "&mate_MaintenanceId=" + mate_MaintenanceId);
                AddUrlButton("Delete", "Delete.gif", UrlDotNet(ThisDotNetDll, "RunDataPageDelete") + "&mate_MaintenanceId=" + mate_MaintenanceId);
                AddUrlButton("Add MainteDetail", "new.gif", UrlDotNet(ThisDotNetDll, "RunMainteDetailAdd") + "&mate_MaintenanceId=" + mate_MaintenanceId);
                AddUrlButton("Add BadType", "new.gif", UrlDotNet(ThisDotNetDll, "RunBadTypeAdd") + "&mate_MaintenanceId=" + mate_MaintenanceId);
                AddUrlButton("Continue", "Continue.gif", UrlDotNet(ThisDotNetDll, "RunListPage"));
            } catch (Exception error) {
                this.AddError(error.Message);
            }
        }
    }
}