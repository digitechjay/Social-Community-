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

public partial class Admin_CityMaster : System.Web.UI.Page
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
                FillStateCode();
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
            tbl_CityMasterProp Objtbl_CityMasterProp = new tbl_CityMasterProp();
            Objtbl_CityMasterProp.CityCode = 0;
            Objtbl_CityMasterProp.PageNo = Convert.ToInt32(txtCurPage.Text);
            Objtbl_CityMasterProp.RecordCount = Convert.ToInt32(20);

            tbl_CityMasterBAL Objtbl_CityMasterBAL = new tbl_CityMasterBAL();
            DataSet dsData = Objtbl_CityMasterBAL.Select_Data(Objtbl_CityMasterProp, ref PageCount);

            lblTotalPage.Text = Convert.ToString(PageCount);

            grdData.DataSource = dsData.Tables[0];
            grdData.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void FillStateCode()
    {
        try
        {
            tbl_StateMasterProp Objtbl_StateMasterProp = new tbl_StateMasterProp();
            Objtbl_StateMasterProp.CountryCode = 0;

            tbl_StateMasterBAL Objtbl_StateMasterBAL = new tbl_StateMasterBAL();
            DataSet dsData = Objtbl_StateMasterBAL.SelectCombo_Data(Objtbl_StateMasterProp);

            DataRow dr = dsData.Tables[0].NewRow();
            dr["StateName"] = "--- Select Any ---";
            dr["StateCode"] = 0;

            dsData.Tables[0].Rows.InsertAt(dr, 0);

            ddlStateCode.DataSource = dsData.Tables[0];
            ddlStateCode.DataTextField = "StateName";
            ddlStateCode.DataValueField = "StateCode";
            ddlStateCode.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void EditData(int CityCode)
    {
        try
        {
            tbl_CityMasterProp Objtbl_CityMasterProp = new tbl_CityMasterProp();
            Objtbl_CityMasterProp.CityCode = CityCode;

            int PageCount = 0;
            tbl_CityMasterBAL Objtbl_CityMasterBAL = new tbl_CityMasterBAL();
            DataSet dsData = Objtbl_CityMasterBAL.Select_Data(Objtbl_CityMasterProp, ref PageCount);

            txtCityName.Text = Convert.ToString(dsData.Tables[0].Rows[0]["CityName"]);
            ddlStateCode.SelectedValue = Convert.ToString(dsData.Tables[0].Rows[0]["StateCode"]);
            ViewState["EditCode"] = CityCode;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    private void DeleteData(int CityCode)
    {
        try
        {
            tbl_CityMasterProp Objtbl_CityMasterProp = new tbl_CityMasterProp();
            Objtbl_CityMasterProp.CityCode = CityCode;

            tbl_CityMasterBAL Objtbl_CityMasterBAL = new tbl_CityMasterBAL();
            Objtbl_CityMasterBAL.Delete_Data(Objtbl_CityMasterProp);

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
            txtCityName.Text = "";
            ddlStateCode.SelectedValue = "0";
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
            tbl_CityMasterProp Objtbl_CityMasterProp = new tbl_CityMasterProp();
            Objtbl_CityMasterProp.CityCode = Convert.ToInt32(ViewState["EditCode"]);
            Objtbl_CityMasterProp.CityName = txtCityName.Text;
            Objtbl_CityMasterProp.StateCode = Convert.ToInt32(ddlStateCode.SelectedValue);

            tbl_CityMasterBAL Objtbl_CityMasterBAL = new tbl_CityMasterBAL();
            Objtbl_CityMasterBAL.InsertUpdate_Data(Objtbl_CityMasterProp);
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