using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using SocialCommunityProp;
using SocialCommunityBAL;
using Encrypt;

public partial class Admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                tdError.Visible = false;
            }
        }
        catch (Exception ex)
        {
            tdError.Visible = true;
            tdError.InnerText = ex.Message;
        }
    }
    protected void btnLogin_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Encrypting ObjEncrypting = new Encrypting();

            tbl_UserMasterProp Objtbl_UserMasterProp = new tbl_UserMasterProp();
            Objtbl_UserMasterProp.UserName = ObjEncrypting.Encrypt(txtUserName.Text);
            Objtbl_UserMasterProp.Password = ObjEncrypting.Encrypt(txtPassword.Text);

            tbl_UserMasterBAL Objtbl_UserMasterBAL = new tbl_UserMasterBAL();
            DataSet dsData = Objtbl_UserMasterBAL.Select_Data(Objtbl_UserMasterProp);
            if (dsData.Tables[0].Rows.Count > 0)
            {
                Session["UserName"] = txtUserName.Text;
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                tdError.Visible = true;
                tdError.InnerText = "Invalid Username/Password";
            }
        }
        catch (Exception ex)
        {
            tdError.Visible = true;
            tdError.InnerText = ex.Message;
        }
    }
}
