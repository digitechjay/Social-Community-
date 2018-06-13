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
using Encrypt;

public partial class mstClientPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                FillLatestNews();
            }
            if (Convert.ToString(Session["LoginName"]) == "" && Convert.ToString(Session["LoginID"]) == "")
            {
                Welcome.Visible = false;
                LoginForm.Visible = true;

                //memberlist.Visible = false;
                matrimonialmemberlist.Visible = false;
            }
            else
            {
                Welcome.Visible = true;
                LoginForm.Visible = false;

                lblUserName.Text = Convert.ToString(Session["LoginName"]);

                //memberlist.Visible = true;
                matrimonialmemberlist.Visible = true;
            }
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
        catch
        {

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
        tbl_MatrimonialMemberProp Objtbl_MatrimonialMemberProp = new tbl_MatrimonialMemberProp();
        Objtbl_MatrimonialMemberProp.EmailID = txtEmailID.Text;

        tbl_MatrimonialMemberBAL Objtbl_MatrimonialMemberBAL = new tbl_MatrimonialMemberBAL();
        DataSet dsData = Objtbl_MatrimonialMemberBAL.CheckLogin(Objtbl_MatrimonialMemberProp);
        if (dsData.Tables[0].Rows.Count > 0)
        {
            Encrypting ObjEncrypting = new Encrypting();
            string DataPassword = ObjEncrypting.Encrypt(Convert.ToString(dsData.Tables[0].Rows[0]["Password"]));
            if (txtPassword.Text == DataPassword)
            {
                Session["LoginName"] = Convert.ToString(dsData.Tables[0].Rows[0]["MemberName"]);
                Session["LoginID"] = Convert.ToString(dsData.Tables[0].Rows[0]["MemberCode"]);

                //memberlist.Visible = true;
                matrimonialmemberlist.Visible = true;

                Welcome.Visible = true;
                LoginForm.Visible = false;
                lblUserName.Text = Convert.ToString(dsData.Tables[0].Rows[0]["MemberName"]);
            }
            else
            {
                Response.Redirect("MatrimonialSignUp.aspx?msg=invalidpwd");
            }
        }
        else
        {
            Response.Redirect("MatrimonialSignUp.aspx?msg=invalidid");
        }
    }
    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        Session["LoginName"] = "";
        Session["LoginID"] = "";

        lblUserName.Text = "";

        //memberlist.Visible = false;
        matrimonialmemberlist.Visible = false;

        Welcome.Visible = false;
        LoginForm.Visible = true;
        Response.Redirect("Default.aspx");

    }
}
