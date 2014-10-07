using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;

namespace Port.DataPages
{
    public class PortDataPageDelete : Web
    {
    //    public PortDataPageDelete()
    //        : base("Port", "port_PortID", "PortNewEntry")
    //    {
    //        this.CancelButton = false;
    //        this.DeleteButton = false;
    //    }
        string compid = string.Empty;
        public override void BuildContents()
        {
            try
            {
                AddContent(HTML.Form());
                string Portid = Dispatch.EitherField("port_PortID");
                Record rec = FindRecord("Port","port_PortID="+Portid );
                EntryGroup Portentry = new EntryGroup("PortNewEntry");
                Portentry.Fill(rec);
                AddTabHead("Port");
                string hMode = Dispatch.EitherField("HiddenMode");
                if (hMode == "Save")
                {
                   
                   //Record rec =  base.FindCurrentRecord("Port");
                   rec.DeleteRecord = true;
                   rec.SaveChanges();
                   Dispatch.Redirect(UrlDotNet("Company", "RunDataPage") + "&comp_companyid=" + compid);
                }
                
                            
                /* Add your code here */
                compid = Dispatch.EitherField("comp_companyid");
                if (string.IsNullOrEmpty(compid))
                    compid = Dispatch.EitherField("key1");
                /* Add your code here */
                AddContent(HTML.InputHidden("HiddenMode", ""));
                Portentry.GetHtmlInViewMode(rec);
                AddContent(Portentry);
                AddSubmitButton("确认删除", "delete.gif", "javascript:document.EntryForm.HiddenMode.value='Save';");
                AddUrlButton("Cancel", "Cancel.gif", UrlDotNet("Company", "RunDataPage") + "&comp_companyid=" + compid);

            }
            catch (Exception error)
            {
                this.AddError(error.Message);
            }
        }
       
    }
}