using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace MonthPlan
{
    public class ProcessMethodSummary : Web
    {
        public override void PreBuildContents()
        {
            GetTabs("ProcessMethod", "Summary");
            AddTopContent(GetCustomEntityTopFrame("ProcessMethod"));
            base.PreBuildContents();
        }
        public override void BuildContents()
        {
            try
            {
                string pmet_ProcessMethodid = Dispatch.EitherField("pmet_ProcessMethodid");

                Record ProcessMethod = FindRecord("ProcessMethod", "pmet_ProcessMethodid=" + pmet_ProcessMethodid);
                string pmet_monthplanid = ProcessMethod.GetFieldAsString("pmet_monthplanid");

               
                int userid = CurrentUser.UserId;

                string urledit = base.UrlDotNet(base.ThisDotNetDll, "RunProcessMethodEdit") + "&pmet_ProcessMethodid=" + pmet_ProcessMethodid;
                    Dispatch.Redirect(urledit);


                    EntryGroup DecoratePersonNewEntry = new EntryGroup("ProcessMethodNewEntry");

                DecoratePersonNewEntry.Title = "ProcessMethod";
                DecoratePersonNewEntry.Fill(ProcessMethod);

                VerticalPanel vpMainPanel = new VerticalPanel();
                vpMainPanel.AddAttribute("width", "100%");
                vpMainPanel.Add(DecoratePersonNewEntry);
                AddContent(vpMainPanel);

                string urldelete = base.UrlDotNet(base.ThisDotNetDll, "RunProcessMethodDelete") + "&pmet_ProcessMethodid=" + pmet_ProcessMethodid;
                    base.AddUrlButton("Delete", "Delete.gif", urldelete);


                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mopl_MonthPlanId=" + pmet_monthplanid;
                    url = url.Replace("Key37", "ProcessMethodid");
                url = url + "&Key37=" + pmet_monthplanid;
                this.AddUrlButton("cancel", "PrevCircle.gif", url);
                
            }
            catch (Exception error)
            {
                this.AddError(error.Message);
            }
        }
    }
}