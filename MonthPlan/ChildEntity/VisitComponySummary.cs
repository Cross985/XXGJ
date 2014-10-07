using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;
using Sage.CRM.Controls;
using Sage.CRM.UI;

namespace MonthPlan
{
    public class VisitComponySummary : Web
    {
        public override void PreBuildContents()
        {
            GetTabs("VisitCompony", "Summary");
            AddTopContent(GetCustomEntityTopFrame("VisitCompony"));
            base.PreBuildContents();
        }
        public override void BuildContents()
        {
            try
            {
                string vico_VisitComponyid = Dispatch.EitherField("vico_VisitComponyid");

                Record VisitCompony = FindRecord("VisitCompony", "vico_VisitComponyid=" + vico_VisitComponyid);
                string vico_monthplanid = VisitCompony.GetFieldAsString("vico_monthplanid");

               
                int userid = CurrentUser.UserId;

                string urledit = base.UrlDotNet(base.ThisDotNetDll, "RunVisitComponyEdit") + "&vico_VisitComponyid=" + vico_VisitComponyid;
                    Dispatch.Redirect(urledit);


                    EntryGroup VisitComponyNewEntry = new EntryGroup("VisitComponyNewEntry");

                VisitComponyNewEntry.Title = "VisitCompony";
                VisitComponyNewEntry.Fill(VisitCompony);

                VerticalPanel vpMainPanel = new VerticalPanel();
                vpMainPanel.AddAttribute("width", "100%");
                vpMainPanel.Add(VisitComponyNewEntry);
                AddContent(vpMainPanel);

                string urldelete = base.UrlDotNet(base.ThisDotNetDll, "RunVisitComponyDelete") + "&vico_VisitComponyid=" + vico_VisitComponyid;
                    base.AddUrlButton("Delete", "Delete.gif", urldelete);


                    string url = UrlDotNet(ThisDotNetDll, "RunDataPage") + "&mopl_MonthPlanId=" + vico_monthplanid;
                    url = url.Replace("Key37", "VisitComponyid");
                url = url + "&Key37=" + vico_monthplanid;
                this.AddUrlButton("cancel", "PrevCircle.gif", url);
                
            }
            catch (Exception error)
            {
                this.AddError(error.Message);
            }
        }
    }
}