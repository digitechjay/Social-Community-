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
using SocialCommunityBAL;
using SocialCommunityProp;
using System.Drawing;

public partial class MembersList : System.Web.UI.Page
{
    #region "--------------- Variable Declaration ---------------"

    #endregion

    #region "--------------- Form Construnction & Events ---------------"

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToString(Session["LoginName"]) == "" && Convert.ToString(Session["LoginID"]) == "")
            {
                Response.Redirect("MatrimonialSignUp.aspx?msg=MatrimonialList");
            }

            if (!IsPostBack)
            {
                FillData();
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

    private void FillData()
    {
        try
        {
            int PageCount = 0;
            tbl_MatrimonialMemberProp Objtbl_MatrimonialMemberProp = new tbl_MatrimonialMemberProp();
            Objtbl_MatrimonialMemberProp.MemberCode = 0;
            Objtbl_MatrimonialMemberProp.PageNo = Convert.ToInt32(1);
            Objtbl_MatrimonialMemberProp.RecordCount = Convert.ToInt32(20);

            tbl_MatrimonialMemberBAL Objtbl_MatrimonialMemberBAL = new tbl_MatrimonialMemberBAL();
            DataSet dsData = Objtbl_MatrimonialMemberBAL.Select_Data(Objtbl_MatrimonialMemberProp, ref PageCount);

            rptData.DataSource = dsData.Tables[0];
            rptData.DataBind();

            for (int i = 0; i < dsData.Tables[0].Columns.Count; i++)
            {
                ddlSelect.Items.Add(dsData.Tables[0].Columns[i].ColumnName);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public bool ThumbnailCallback()
    {
        return false;
    }

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

    protected string ThumbImage(object val)
    {
        if (val != null)
        {
            return "MembersPhotos/" + val.ToString().Split('.')[0] + ".jpg";
        }
        return "";
    }

    #endregion

    #region "--------------- Buttons Events ---------------"

    protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
    {

        try
        {
            ImageButton btnSearch = (ImageButton)sender;

        }
        catch (Exception ex)
        {
            ShowGuidMessage(0, ex);

        }

    }

    #endregion

    #region "--------------- Other Control Events ---------------"

    #endregion
}