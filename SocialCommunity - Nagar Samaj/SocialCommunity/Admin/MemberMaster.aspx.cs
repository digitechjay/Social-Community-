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

public partial class Admin_MemberMaster : System.Web.UI.Page
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
                FillCountryCode();
                FillMemberData();
                FillNativePlace();
                FillNationality();

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
            tbl_MemberMasterProp Objtbl_MemberMasterProp = new tbl_MemberMasterProp();
            Objtbl_MemberMasterProp.MemberCode = 0;
            Objtbl_MemberMasterProp.PageNo = Convert.ToInt32(txtCurPage.Text);
            Objtbl_MemberMasterProp.RecordCount = Convert.ToInt32(20);

            tbl_MemberMasterBAL Objtbl_MemberMasterBAL = new tbl_MemberMasterBAL();
            DataSet dsData = Objtbl_MemberMasterBAL.Select_Data(Objtbl_MemberMasterProp, ref PageCount);

            lblTotalPage.Text = Convert.ToString(PageCount);

            grdData.DataSource = dsData.Tables[0];
            grdData.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void FillMemberData()
    {
        try
        {
            int PageCount = 0;
            tbl_MemberMasterProp Objtbl_MemberMasterProp = new tbl_MemberMasterProp();
            Objtbl_MemberMasterProp.MemberCode = 0;
            Objtbl_MemberMasterProp.PageNo = 1;
            Objtbl_MemberMasterProp.RecordCount = 1;

            tbl_MemberMasterBAL Objtbl_MemberMasterBAL = new tbl_MemberMasterBAL();
            DataSet dsData = Objtbl_MemberMasterBAL.Select_Data(Objtbl_MemberMasterProp, ref PageCount);

            DataRow dr = dsData.Tables[0].NewRow();
            dr["MemberName"] = "--- Primary ---";
            dr["MemberCode"] = 0;

            dsData.Tables[0].Rows.InsertAt(dr, 0);

            lblTotalPage.Text = Convert.ToString(PageCount);

            ddlParentCode.DataSource = dsData.Tables[0];
            ddlParentCode.DataTextField = "MemberName";
            ddlParentCode.DataValueField = "MemberCode";
            ddlParentCode.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void EditData(int MemberCode)
    {
        try
        {
            tbl_MemberMasterProp Objtbl_MemberMasterProp = new tbl_MemberMasterProp();
            Objtbl_MemberMasterProp.MemberCode = MemberCode;

            int PageCount = 0;
            tbl_MemberMasterBAL Objtbl_MemberMasterBAL = new tbl_MemberMasterBAL();
            DataSet dsData = Objtbl_MemberMasterBAL.Select_Data(Objtbl_MemberMasterProp, ref PageCount);

            txtMemberName.Text = Convert.ToString(dsData.Tables[0].Rows[0]["MemberName"]);
            txtCurrentAddress.Text = Convert.ToString(dsData.Tables[0].Rows[0]["CurrentAddress"]);
            ddlCountryCode.SelectedValue = Convert.ToString(dsData.Tables[0].Rows[0]["CountryCode"]);
            FillStateCode(Convert.ToInt32(ddlCountryCode.SelectedValue));
            ddlStateCode.SelectedValue = Convert.ToString(dsData.Tables[0].Rows[0]["StateCode"]);
            FillCityCode(Convert.ToInt32(ddlStateCode.SelectedValue));
            ddlCityCode.SelectedValue = Convert.ToString(dsData.Tables[0].Rows[0]["CityCode"]);
            txtPermanentAddress.Text = Convert.ToString(dsData.Tables[0].Rows[0]["PermanentAddress"]);
            txtContactNo.Text = Convert.ToString(dsData.Tables[0].Rows[0]["ContactNo"]);
            txtEmailID.Text = Convert.ToString(dsData.Tables[0].Rows[0]["EmailID"]);
            txtDOB.Text = Convert.ToString(dsData.Tables[0].Rows[0]["DOB"]);
            ddlQualificationCode.SelectedValue = Convert.ToString(dsData.Tables[0].Rows[0]["QualificationCode"]);
            ddlOccupationCode.SelectedIndex = Convert.ToInt32(dsData.Tables[0].Rows[0]["OccupationCode"]);
            ddlMaritalStatus.SelectedIndex = Convert.ToInt32(dsData.Tables[0].Rows[0]["MaritalStatusCode"]);
            ddlGender.SelectedIndex = Convert.ToInt32(dsData.Tables[0].Rows[0]["Gender"]);
            ddlNativePlace.SelectedIndex = Convert.ToInt32(dsData.Tables[0].Rows[0]["NativePlaceCode"]);
            ddlNationality.SelectedIndex = Convert.ToInt32(dsData.Tables[0].Rows[0]["NationalityCode"]);
            ddlPhysicallyChallanged.SelectedIndex = Convert.ToInt32(dsData.Tables[0].Rows[0]["PhysicalChallangedCode"]);
            ddlRelationshipCode.SelectedIndex = Convert.ToInt32(dsData.Tables[0].Rows[0]["RelationshipCode"]);
            ddlParentCode.SelectedValue = Convert.ToString(dsData.Tables[0].Rows[0]["ParentCode"]);

            tdUploadedFile.Visible = true;
            imgPhotos.ImageUrl = "~/MembersPhotos/" + Convert.ToString(dsData.Tables[0].Rows[0]["PhotoPath"]).Split('.')[0] + ".jpg";


            ViewState["PhotoPath"] = Convert.ToString(dsData.Tables[0].Rows[0]["PhotoPath"]);

            ViewState["EditCode"] = MemberCode;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void DeleteData(int MemberCode)
    {
        try
        {
            tbl_MemberMasterProp Objtbl_MemberMasterProp = new tbl_MemberMasterProp();
            Objtbl_MemberMasterProp.MemberCode = MemberCode;

            tbl_MemberMasterBAL Objtbl_MemberMasterBAL = new tbl_MemberMasterBAL();
            Objtbl_MemberMasterBAL.Delete_Data(Objtbl_MemberMasterProp);

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
            txtMemberName.Text = "";
            txtCurrentAddress.Text = "";
            ddlCountryCode.SelectedValue = "0";
            ddlStateCode.SelectedValue = "0";
            ddlCityCode.SelectedValue = "0";
            txtPermanentAddress.Text = "";
            txtContactNo.Text = "";
            txtEmailID.Text = "";
            txtDOB.Text = "";
            ddlQualificationCode.SelectedValue = "0";
            ddlOccupationCode.SelectedIndex = 0;
            ddlMaritalStatus.SelectedIndex = 0;
            ddlGender.SelectedIndex = 0;
            ddlNativePlace.SelectedIndex = 0;
            ddlNationality.SelectedIndex = 0;
            ddlPhysicallyChallanged.SelectedIndex = 0;
            ddlRelationshipCode.SelectedIndex = 0;
            ddlParentCode.SelectedValue = "0";

            tdUploadedFile.Visible = false;
            imgPhotos.ImageUrl = "";

            ViewState["PhotoPath"] = "";
            ViewState["EditCode"] = 0;

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

    private void FillCountryCode()
    {
        try
        {
            tbl_CountryMasterBAL Objtbl_CountryMasterBAL = new tbl_CountryMasterBAL();
            DataSet dsData = Objtbl_CountryMasterBAL.SelectCombo_Data();

            DataRow dr = dsData.Tables[0].NewRow();
            dr["CountryName"] = "--- Select Any ---";
            dr["CountryCode"] = 0;

            dsData.Tables[0].Rows.InsertAt(dr, 0);

            ddlCountryCode.DataSource = dsData.Tables[0];
            ddlCountryCode.DataTextField = "CountryName";
            ddlCountryCode.DataValueField = "CountryCode";
            ddlCountryCode.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void FillStateCode(int CountryCode)
    {
        try
        {
            tbl_StateMasterProp Objtbl_StateMasterProp = new tbl_StateMasterProp();
            Objtbl_StateMasterProp.CountryCode = CountryCode;

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

    private void FillCityCode(int StateCode)
    {
        try
        {
            tbl_CityMasterProp Objtbl_CityMasterProp = new tbl_CityMasterProp();
            Objtbl_CityMasterProp.StateCode = StateCode;

            tbl_CityMasterBAL Objtbl_CityMasterBAL = new tbl_CityMasterBAL();
            DataSet dsData = Objtbl_CityMasterBAL.SelectCombo_Data(Objtbl_CityMasterProp);

            DataRow dr = dsData.Tables[0].NewRow();
            dr["CityName"] = "--- Select Any ---";
            dr["CityCode"] = 0;

            dsData.Tables[0].Rows.InsertAt(dr, 0);

            ddlCityCode.DataSource = dsData.Tables[0];
            ddlCityCode.DataTextField = "CityName";
            ddlCityCode.DataValueField = "CityCode";
            ddlCityCode.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //private void FillMemberCode(int MemberCode)
    //{
    //    try
    //    {
    //        tbl_MemberMasterProp Objtbl_MemberMasterProp = new tbl_MemberMasterProp();
    //        Objtbl_MemberMasterProp.MemberCode = MemberCode;

    //        int PageCount = 0;
    //        tbl_MemberMasterBAL Objtbl_MemberMasterBAL = new tbl_MemberMasterBAL();
    //        DataSet dsData = Objtbl_MemberMasterBAL.Select_Data(Objtbl_MemberMasterProp, ref PageCount);

    //        txtMemberName.Text = Convert.ToString(dsData.Tables[0].Rows[0]["MemberName"]);
    //        txtCurrentAddress.Text = Convert.ToString(dsData.Tables[0].Rows[0]["CurrentAddress"]);
    //        ddlCountryCode.SelectedValue = Convert.ToString(dsData.Tables[0].Rows[0]["CountryCode"]);
    //        ddlStateCode.SelectedValue = Convert.ToString(dsData.Tables[0].Rows[0]["StateCode"]);
    //        ddlCityCode.SelectedValue = Convert.ToString(dsData.Tables[0].Rows[0]["CityCode"]);
    //        txtPermanentAddress.Text = Convert.ToString(dsData.Tables[0].Rows[0]["PermanentAddress"]);
    //        txtContactNo.Text = Convert.ToString(dsData.Tables[0].Rows[0]["ContactNo"]);
    //        txtEmailID.Text = Convert.ToString(dsData.Tables[0].Rows[0]["EmailID"]);
    //        txtDOB.Text = Convert.ToString(dsData.Tables[0].Rows[0]["DOB"]);
    //        ddlQualificationCode.SelectedValue = Convert.ToString(dsData.Tables[0].Rows[0]["QualificationCode"]);
    //        ddlOccupationCode.SelectedIndex = Convert.ToInt32(dsData.Tables[0].Rows[0]["OccupationCode"]);
    //        ddlMaritalStatus.SelectedIndex = Convert.ToInt32(dsData.Tables[0].Rows[0]["MaritalStatusCode"]);
    //        ddlGender.SelectedIndex = Convert.ToInt32(dsData.Tables[0].Rows[0]["Gender"]);
    //        ddlNativePlace.SelectedIndex = Convert.ToInt32(dsData.Tables[0].Rows[0]["NativePlaceCode"]);
    //        ddlNationality.SelectedIndex = Convert.ToInt32(dsData.Tables[0].Rows[0]["NationalityCode"]);
    //        ddlPhysicallyChallanged.SelectedIndex = Convert.ToInt32(dsData.Tables[0].Rows[0]["PhysicallyChallangedCode"]);
    //        ddlRelationshipCode.SelectedIndex = Convert.ToInt32(dsData.Tables[0].Rows[0]["RelationshipCode"]);
    //        ddlParentCode.SelectedValue = Convert.ToString(dsData.Tables[0].Rows[0]["ParentCode"]);

    //        Objtbl_MemberMasterProp.PhotoPath = sFilename;

    //        ViewState["EditCode"] = MemberCode;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}

    private void FillNativePlace()
    {
        try
        {
            tbl_CityMasterProp Objtbl_CityMasterProp = new tbl_CityMasterProp();
            Objtbl_CityMasterProp.StateCode = 0;

            tbl_CityMasterBAL Objtbl_CityMasterBAL = new tbl_CityMasterBAL();
            DataSet dsData = Objtbl_CityMasterBAL.SelectCombo_Data(Objtbl_CityMasterProp);

            DataRow dr = dsData.Tables[0].NewRow();
            dr["CityName"] = "--- Select Any ---";
            dr["CityCode"] = 0;

            dsData.Tables[0].Rows.InsertAt(dr, 0);

            ddlNativePlace.DataSource = dsData.Tables[0];
            ddlNativePlace.DataTextField = "CityName";
            ddlNativePlace.DataValueField = "CityCode";
            ddlNativePlace.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void FillNationality()
    {
        try
        {
            tbl_CountryMasterProp Objtbl_CountryMasterProp = new tbl_CountryMasterProp();
            Objtbl_CountryMasterProp.CountryCode = 0;

            tbl_CountryMasterBAL Objtbl_CountryMasterBAL = new tbl_CountryMasterBAL();
            DataSet dsData = Objtbl_CountryMasterBAL.SelectCombo_Data();

            DataRow dr = dsData.Tables[0].NewRow();
            dr["CountryName"] = "--- Select Any ---";
            dr["CountryCode"] = 0;

            dsData.Tables[0].Rows.InsertAt(dr, 0);

            ddlNationality.DataSource = dsData.Tables[0];
            ddlNationality.DataTextField = "CountryName";
            ddlNationality.DataValueField = "CountryCode";
            ddlNationality.DataBind();
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
        string sSavePath = "";
        string sFilename = "";

        try
        {
            if (chkDeleteFilePath.Checked == false)
            {
                // Set constant values
                sSavePath = "../MembersPhotos/";

                // If file field isn’t empty
                if (flFilePath.PostedFile != null && flFilePath.PostedFile.ContentLength > 0)
                {
                    // Check file size (mustn’t be 0)
                    HttpPostedFile myFile = flFilePath.PostedFile;
                    int nFileLen = myFile.ContentLength;
                    if (nFileLen == 0)
                    {
                        ShowGuidMessage(0, new Exception("No file was uploaded."));
                        return;
                    }

                    // Check file extension (must be JPG or pdf)
                    if (System.IO.Path.GetExtension(myFile.FileName).ToLower() != ".jpg")
                    {
                        ShowGuidMessage(0, new Exception("The file must have an extension of JPG or pdf"));
                        return;
                    }

                    // Read file into a data stream
                    byte[] myData = new Byte[nFileLen];
                    myFile.InputStream.Read(myData, 0, nFileLen);

                    // Make sure a duplicate file doesn’t exist.  If it does, keep on appending an 
                    // incremental numeric until it is unique
                    sFilename = System.IO.Path.GetFileName(myFile.FileName);
                    int file_append = 0;
                    while (System.IO.File.Exists(Server.MapPath(sSavePath + sFilename)))
                    {
                        file_append++;
                        sFilename = System.IO.Path.GetFileNameWithoutExtension(myFile.FileName)
                                         + file_append.ToString() + System.IO.Path.GetExtension(myFile.FileName).ToLower();
                    }

                    // Save the stream to disk
                    System.IO.FileStream newFile = new System.IO.FileStream(Server.MapPath(sSavePath + sFilename),
                                                       System.IO.FileMode.Create);
                    newFile.Write(myData, 0, myData.Length);
                    newFile.Close();

                    // Check whether the file is really a JPEG by opening it
                    System.Drawing.Image.GetThumbnailImageAbort myCallBack =
                                   new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
                    Bitmap myBitmap;
                    try
                    {
                        myBitmap = new Bitmap(Server.MapPath(sSavePath + sFilename));

                        tdUploadedFile.Visible = true;
                        tdUploadedFile.InnerHtml = "<a href=\"" + sSavePath + sFilename + "\">Download Attachment</a>";

                        // Displaying success information
                        //tdError.InnerText = "File uploaded successfully!";

                        // Destroy objects
                        myBitmap.Dispose();
                    }
                    catch
                    {
                        // The file wasn't a valid jpg file
                        System.IO.File.Delete(Server.MapPath(sSavePath + sFilename));
                        ShowGuidMessage(0, new Exception("The file wasn't a valid jpg file"));
                        return;
                    }
                }
            }

            if (sFilename == "" && Convert.ToInt32(ViewState["EditCode"]) > 0)
                sFilename = Convert.ToString(ViewState["PhotoPath"]);
            else if (sFilename == "" && Convert.ToInt32(ViewState["EditCode"]) <= 0)
                sFilename = "noimage.jpg";
            else if (chkDeleteFilePath.Checked == true)
            {
                if (Convert.ToInt32(ViewState["EditCode"]) > 0)
                {
                    System.IO.File.Delete(Server.MapPath(sSavePath + Convert.ToString(ViewState["PhotoPath"])));
                }
                sFilename = "noimage.jpg";
            }
            tbl_MemberMasterProp Objtbl_MemberMasterProp = new tbl_MemberMasterProp();
            Objtbl_MemberMasterProp.MemberCode = Convert.ToInt32(ViewState["EditCode"]);
            Objtbl_MemberMasterProp.MemberName = txtMemberName.Text;
            Objtbl_MemberMasterProp.CurrentAddress = txtCurrentAddress.Text;
            Objtbl_MemberMasterProp.CountryCode = Convert.ToInt32(ddlCountryCode.SelectedValue);
            Objtbl_MemberMasterProp.StateCode = Convert.ToInt32(ddlStateCode.SelectedValue);
            Objtbl_MemberMasterProp.CityCode = Convert.ToInt32(ddlCityCode.SelectedValue);
            Objtbl_MemberMasterProp.PermanentAddress = txtPermanentAddress.Text;
            Objtbl_MemberMasterProp.ContactNo = txtContactNo.Text;
            Objtbl_MemberMasterProp.EmailID = txtEmailID.Text;
            Objtbl_MemberMasterProp.Password = "Random";
            Objtbl_MemberMasterProp.DOB = new DateTime(Convert.ToInt32(txtDOB.Text.Split('/')[2]), Convert.ToInt32(txtDOB.Text.Split('/')[1]), Convert.ToInt32(txtDOB.Text.Split('/')[0]));
            Objtbl_MemberMasterProp.QualificationCode = Convert.ToInt32(ddlQualificationCode.SelectedValue);
            Objtbl_MemberMasterProp.OccupationCode = Convert.ToInt32(ddlOccupationCode.Text);
            Objtbl_MemberMasterProp.MaritalStatusCode = Convert.ToInt32(ddlMaritalStatus.SelectedIndex);
            Objtbl_MemberMasterProp.Gender = Convert.ToBoolean(ddlGender.SelectedIndex);
            Objtbl_MemberMasterProp.NativePlaceCode = Convert.ToInt32(ddlNativePlace.SelectedValue);
            Objtbl_MemberMasterProp.NationalityCode = Convert.ToInt32(ddlNationality.SelectedValue);
            Objtbl_MemberMasterProp.PhysicalChallangedCode = Convert.ToInt32(ddlPhysicallyChallanged.SelectedIndex);
            Objtbl_MemberMasterProp.RelationshipCode = Convert.ToInt32(ddlRelationshipCode.SelectedIndex);
            Objtbl_MemberMasterProp.ParentCode = Convert.ToInt32(ddlParentCode.SelectedValue);
            Objtbl_MemberMasterProp.PhotoPath = sFilename;

            tbl_MemberMasterBAL Objtbl_MemberMasterBAL = new tbl_MemberMasterBAL();
            Objtbl_MemberMasterBAL.InsertUpdate_Data(Objtbl_MemberMasterProp);
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

    #region "--------------- Other Control Events ---------------"

    protected void ddlCountryCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillStateCode(Convert.ToInt32(ddlCountryCode.SelectedValue));
            mdlPopupNewEntry.Show();
        }
        catch
        {
        }
    }

    protected void ddlStateCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillCityCode(Convert.ToInt32(ddlStateCode.SelectedValue));
            mdlPopupNewEntry.Show();
        }
        catch
        {
        }
    }

    #endregion

}