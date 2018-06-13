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

public partial class Admin_ChangePassword : System.Web.UI.Page
{
    #region "--------------- Variable Declaration ---------------"

    #endregion

    #region "--------------- Form Construnction & Events ---------------"

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ErrorPart.Visible = false;
            }
        }
        catch (Exception ex)
        {
            tdError.InnerText = ex.Message;
        }
    }

    #endregion

    #region "--------------- User Functions ---------------"

    private void ShowGuidMessage(int MsgType, Exception ex)
    {
        try
        {
            ErrorPart.Visible = true;
            byte[] imgbyte = null;
            if (MsgType == 1)
            {
                //imgbyte = System.IO.File.ReadAllBytes(Application.StartupPath + "\\Images\\Done.png");
                ErrorImage.InnerHtml = "<img src=\"../Images/Done.png\" alt=\"Save\" />";
                tdError.InnerText = "Data Saved Successfully!";
                //lblMsg.ForeColor = Color.Green;
            }
            else if (MsgType == 2)
            {
                //imgbyte = System.IO.File.ReadAllBytes(Application.StartupPath + "\\Images\\Information.png");
                ErrorImage.InnerHtml = "<img src=\"../Images/Information.png\" alt=\"Delete\" />";
                tdError.InnerText = "Data Deleted Successfully!";
                //lblMsg.ForeColor = Color.Green;
            }
            else if (MsgType == 0 && ex != null)
            {
                //imgbyte = System.IO.File.ReadAllBytes(Application.StartupPath + "\\Images\\Error.png");
                ErrorImage.InnerHtml = "<img src=\"../Images/Error.png\" alt=\"Error\" />";
                tdError.InnerText = ex.Message;
                //lblMsg.ForeColor = Color.Red;
            }
            System.IO.MemoryStream msimg = new System.IO.MemoryStream(imgbyte);
            //ErrorImage = Image.FromStream(msimg);
        }
        catch
        {
        }
    }

    private void ClearPageData()
    {
        try
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region "--------------- Buttons Events ---------------"

    protected void imgbtnSave_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Encrypting ObjEncrypting = new Encrypting();


            tbl_UserMasterProp Objtbl_UserMasterProp = new tbl_UserMasterProp();
            Objtbl_UserMasterProp.UserName = ObjEncrypting.Encrypt(txtUserName.Text);
            Objtbl_UserMasterProp.Password = ObjEncrypting.Encrypt(txtPassword.Text);

            tbl_UserMasterBAL Objtbl_UserMasterBAL = new tbl_UserMasterBAL();
            Objtbl_UserMasterBAL.InsertUpdate_Data(Objtbl_UserMasterProp);
            ShowGuidMessage(1, null);
        }
        catch (Exception ex)
        {
            ShowGuidMessage(0, ex); //MessageBox.Show(ex.Message);
        }
    }

    #endregion
}
