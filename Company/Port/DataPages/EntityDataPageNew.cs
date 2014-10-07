using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Controls;
using Sage.CRM.Data;

namespace Port.DataPages
{
    public class PortDataPageNew : DataPageNew
    {
        public PortDataPageNew()
            : base("Port", "port_PortID", "PortNewEntry")
        {
            this.CancelButton = false;
        }
        string compid = string.Empty;
        public override void BuildContents()
        {
            try
            {
                //GetTabs("Port", "Port");
                base.AddTabHead("Port");
                compid = Dispatch.EitherField("comp_companyid");
                if (string.IsNullOrEmpty(compid))
                    compid = Dispatch.EitherField("key1");
                /* Add your code here */
                base.BuildContents();
                AddUrlButton("Cancel", "Cancel.gif", UrlDotNet("Company", "RunDataPage") + "&comp_companyid=" + compid + "&J=Summary&T=CompanySummary");

               
            }
            catch (Exception error)
            {
                this.AddError(error.Message);
            }
        }
        public override void AfterSave(EntryGroup screen)
        {
            //Entry comp = screen.GetEntry("port_companyid");
            
            //comp.DefaultValue = compid;
            //Record portRec = base.FindCurrentRecord("Port");
            //portRec.SetField("port_companyid",compid);
            //portRec.SaveChanges();
            //base.AfterSave(screen);
            Dispatch.Redirect(UrlDotNet("Company", "RunPortList") + "&comp_companyid=" + compid + "&J=Summary");
        }
    }
}