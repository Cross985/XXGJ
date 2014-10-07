using System;
using System.Collections.Generic;
using System.Text;
using Sage.CRM.WebObject;
using Sage.CRM.Data;

namespace Company.DataPages
{
    public class CompanyListPage : ListPage
    {
        public override void  GetTabs()
        {
            string strTopContent = "<TABLE WIDTH=100%><TR><TD CLASS=TOPHEADING WIDTH=60><IMG SRC='" + CurrentUser.VirtualImgPath() + "Icons/Company.png' BORDER=0 ALIGN=MIDDLE></td><td CLASS=VIEWBOXCAPTION><font color='black'>客户列表</font></td></tr></table>";
            AddTopContent(strTopContent);

            this.UseEntityTabs = false;
            this.GetTabs("CompanyMangement", "CompanyList");
 	        
        }
        
        public CompanyListPage()
            : base("Company", "NewCompanyList", "NewCompanyFilterEntry")
        {
            //string userid = CurrentUser.UserId.ToString();
            //Record AccessRec = FindRecord("UserAccess", "usac_userid=" + userid);
            //string filter = "comp_deleted is null and ( comp_cityid is not null and comp_promaryid is not null) ";
            //string filter2 = string.Empty;
            //while (!AccessRec.Eof())
            //{
            //    string access = AccessRec.GetFieldAsString("usac_access");
            //    string promaryid = AccessRec.GetFieldAsString("usac_promaryid");
            //    string cityid = AccessRec.GetFieldAsString("usac_cityid");
            //    switch (access)
            //    {
            //        case "P": filter2 = filter2 + "or comp_promaryid=" + promaryid; break;
            //        case "C": filter2 = filter2+ "or (comp_promaryid = "+ promaryid +" and comp_cityid=" + cityid +")"; break;
            //        default: break;
            //    }
            //    AccessRec.GoToNext();
            //}
            //string result = filter + " and " + filter2;
            
            //this.ResultsGrid.Filter =result.Replace("and or","and");// "comp_deleted is null and comp_SecTerr = -1073741819";
            ///* Add your code here */
            //AddInfo(result);
            //AddTabHead("Company");
            this.ResultsGrid.RowsPerScreen = 30;
            this.ResultsGrid.Filter = "comp_deleted is null ";
        }

        public override void BuildContents()
        {
            try
            {
                
                base.BuildContents();
            }
            catch (Exception error)
            {
                this.AddError(error.Message);
            }
        }
        public override void AddNewButton()
        {
            //base.AddNewButton();
            AddUrlButton("New","New.gif",UrlDotNet(ThisDotNetDll,"RunDataPageNew"));
        }
    }
}