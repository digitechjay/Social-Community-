using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using SocialCommunityProp;
using SocialCommunityBAL;

public partial class mstClientPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            FillLatestNews();
        }
        catch
        {

        }
    }

    private void FillLatestNews()
    {
        try
        {
            int PageCount = 0;
            tbl_NewsMasterProp Objtbl_NewsMasterProp = new tbl_NewsMasterProp();
            Objtbl_NewsMasterProp.NewsCode = 0;
            Objtbl_NewsMasterProp.PageNo = 1; //Convert.ToInt32(txtCurPage.Text);
            Objtbl_NewsMasterProp.RecordCount = 10;

            tbl_NewsMasterBAL Objtbl_NewsMasterBAL = new tbl_NewsMasterBAL();
            DataSet dsData = Objtbl_NewsMasterBAL.Select_Data(Objtbl_NewsMasterProp, ref PageCount);
            rptLatestNews.DataSource = dsData.Tables[0];
            rptLatestNews.DataBind();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected string ProcessNewsHead(object val)
    {
        if (val != null)
        {
            return val.ToString().Length > 60 ? val.ToString().Substring(0, 60) + ".." : val.ToString();
        }
        return "";
    }

    protected string ProcessNewsData(object val)
    {
        if (val != null)
        {
            return val.ToString().Length > 90 ? val.ToString().Substring(0, 90) + ".." : val.ToString();
        }
        return "";
    }

    protected string ThumbImage(object val)
    {
        if (val != null)
        {
            return "NewsImage/" + val.ToString().Split('.')[0] + "_thumb.jpg";
        }
        return "";
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        CheckLogin();
    }
    private void CheckLogin()
    {
        try
        {

        }
        catch (Exception ex)
        {
        }
    }
}
