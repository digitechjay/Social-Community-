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

public partial class Admin_AlbumMaster : System.Web.UI.Page
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
                txtCurPage.Text = "1";
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
            tbl_AlbumMasterProp Objtbl_AlbumMasterProp = new tbl_AlbumMasterProp();
            Objtbl_AlbumMasterProp.AlbumCode = 0;
            Objtbl_AlbumMasterProp.PageNo = Convert.ToInt32(txtCurPage.Text);
            Objtbl_AlbumMasterProp.RecordCount = Convert.ToInt32(20);

            tbl_AlbumMasterBAL Objtbl_AlbumMasterBAL = new tbl_AlbumMasterBAL();
            DataSet dsData = Objtbl_AlbumMasterBAL.Select_Data(Objtbl_AlbumMasterProp, ref PageCount);

            lblTotalPage.Text = Convert.ToString(PageCount);

            grdData.DataSource = dsData.Tables[0];
            grdData.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void EditData(int AlbumCode)
    {
        try
        {
            tbl_AlbumMasterProp Objtbl_AlbumMasterProp = new tbl_AlbumMasterProp();
            Objtbl_AlbumMasterProp.AlbumCode = AlbumCode;

            int PageCount = 0;
            tbl_AlbumMasterBAL Objtbl_AlbumMasterBAL = new tbl_AlbumMasterBAL();
            DataSet dsData = Objtbl_AlbumMasterBAL.Select_Data(Objtbl_AlbumMasterProp, ref PageCount);

            txtAlbumName.Text = Convert.ToString(dsData.Tables[0].Rows[0]["AlbumName"]);
            ViewState["EditCode"] = AlbumCode;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void DeleteData(int AlbumCode)
    {
        try
        {
            tbl_AlbumMasterProp Objtbl_AlbumMasterProp = new tbl_AlbumMasterProp();
            Objtbl_AlbumMasterProp.AlbumCode = AlbumCode;

            tbl_AlbumMasterBAL Objtbl_AlbumMasterBAL = new tbl_AlbumMasterBAL();
            Objtbl_AlbumMasterBAL.Delete_Data(Objtbl_AlbumMasterProp);

            FillData();
        }
        catch (Exception ex)
        {
            throw ex;
        }
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

    private void ClearPageData()
    {
        try
        {
            ViewState["EditCode"] = 0;
            txtAlbumName.Text = "";
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
            tbl_AlbumMasterProp Objtbl_AlbumMasterProp = new tbl_AlbumMasterProp();
            Objtbl_AlbumMasterProp.AlbumCode = Convert.ToInt32(ViewState["EditCode"]);
            Objtbl_AlbumMasterProp.AlbumName = txtAlbumName.Text;

            tbl_AlbumMasterBAL Objtbl_AlbumMasterBAL = new tbl_AlbumMasterBAL();
            Objtbl_AlbumMasterBAL.InsertUpdate_Data(Objtbl_AlbumMasterProp);
            ShowGuidMessage(1, null);
            mdlPopupNewEntry.Hide();
            FillData();
        }
        catch (Exception ex)
        {
            ShowGuidMessage(0, ex); //MessageBox.Show(ex.Message);
        }
    }

    protected void imgbtnPrev_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (Convert.ToInt32(txtCurPage.Text) > 1)
            {
                txtCurPage.Text = Convert.ToString(Convert.ToInt32(txtCurPage.Text) - 1);
                FillData();
            }
        }
        catch (Exception ex)
        {
            ShowGuidMessage(0, ex); //MessageBox.Show(ex.Message);
        }
    }

    protected void imgbtnNext_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (Convert.ToInt32(txtCurPage.Text) < Convert.ToInt32(lblTotalPage.Text))
            {
                txtCurPage.Text = Convert.ToString(Convert.ToInt32(txtCurPage.Text) + 1);
                FillData();
            }
        }
        catch (Exception ex)
        {
            ShowGuidMessage(0, ex); //MessageBox.Show(ex.Message);
        }
    }

    protected void imgbtnEdit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImageButton btnEdit = (ImageButton)sender;
            EditData(Convert.ToInt32(btnEdit.CommandArgument));
            mdlPopupNewEntry.Show();
        }
        catch (Exception ex)
        {
            ShowGuidMessage(0, ex);
        }
    }

    protected void imgbtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImageButton btnEdit = (ImageButton)sender;
            DeleteData(Convert.ToInt32(btnEdit.CommandArgument));
            FillData();
            ShowGuidMessage(2, null);
        }
        catch (Exception ex)
        {
            ShowGuidMessage(0, ex);
        }
    }

    protected void imgbtnAddNew_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ClearPageData();

            mdlPopupNewEntry.Show();
        }
        catch (Exception ex)
        {
            ShowGuidMessage(0, ex);
        }
    }

    protected void imgbtnPrint_Click(object sender, ImageClickEventArgs e)
    {

    }

    #endregion
}