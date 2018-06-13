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

public partial class Admin_NewsMaster : System.Web.UI.Page
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
            tbl_NewsMasterProp Objtbl_NewsMasterProp = new tbl_NewsMasterProp();
            Objtbl_NewsMasterProp.NewsCode = 0;
            Objtbl_NewsMasterProp.PageNo = Convert.ToInt32(txtCurPage.Text);
            Objtbl_NewsMasterProp.RecordCount = Convert.ToInt32(20);

            tbl_NewsMasterBAL Objtbl_NewsMasterBAL = new tbl_NewsMasterBAL();
            DataSet dsData = Objtbl_NewsMasterBAL.Select_Data(Objtbl_NewsMasterProp, ref PageCount);

            lblTotalPage.Text = Convert.ToString(PageCount);

            grdData.DataSource = dsData.Tables[0];
            grdData.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void EditData(int NewsCode)
    {
        try
        {
            tbl_NewsMasterProp Objtbl_NewsMasterProp = new tbl_NewsMasterProp();
            Objtbl_NewsMasterProp.NewsCode = NewsCode;

            int PageCount = 0;
            tbl_NewsMasterBAL Objtbl_NewsMasterBAL = new tbl_NewsMasterBAL();
            DataSet dsData = Objtbl_NewsMasterBAL.Select_Data(Objtbl_NewsMasterProp, ref PageCount);

            txtNewsHead.Text = Convert.ToString(dsData.Tables[0].Rows[0]["NewsHead"]);
            txtNewsDescription.Text = Convert.ToString(dsData.Tables[0].Rows[0]["NewsDescription"]);
            tdUploadedImage.Visible = true;
            imgPhotos.ImageUrl = "~/NewsImage/" + Convert.ToString(dsData.Tables[0].Rows[0]["PhotoPath"]).Split('.')[0] + "_thumb.jpg";

            ViewState["PhotoPath"] = Convert.ToString(dsData.Tables[0].Rows[0]["PhotoPath"]);
            ViewState["EditCode"] = NewsCode;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void DeleteData(int NewsCode)
    {
        try
        {
            tbl_NewsMasterProp Objtbl_NewsMasterProp = new tbl_NewsMasterProp();
            Objtbl_NewsMasterProp.NewsCode = NewsCode;

            tbl_NewsMasterBAL Objtbl_NewsMasterBAL = new tbl_NewsMasterBAL();
            Objtbl_NewsMasterBAL.Delete_Data(Objtbl_NewsMasterProp);

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
            tdUploadedImage.Visible = false;
            imgPhotos.ImageUrl = null;
            txtNewsHead.Text = "";
            txtNewsDescription.Text = "";
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

    #endregion

    #region "--------------- Buttons Events ---------------"

    protected void imgbtnSave_Click(object sender, ImageClickEventArgs e)
    {
        string sSavePath = "";
        string sThumbExtension = "";

        string sFilename = "";
        string sThumbFile = "";

        int intThumbWidth;
        int intThumbHeight;

        try
        {
            if (chkDeletePhotoPath.Checked == false)
            {
                // Set constant values
                sSavePath = "../NewsImage/";
                sThumbExtension = "_thumb";
                intThumbWidth = 160;
                intThumbHeight = 120;

                // If file field isn’t empty
                if (flPhotos.PostedFile != null && flPhotos.PostedFile.ContentLength > 0)
                {
                    // Check file size (mustn’t be 0)
                    HttpPostedFile myFile = flPhotos.PostedFile;
                    int nFileLen = myFile.ContentLength;
                    if (nFileLen == 0)
                    {
                        ShowGuidMessage(0, new Exception("No file was uploaded."));
                        return;
                    }

                    // Check file extension (must be JPG)
                    if (System.IO.Path.GetExtension(myFile.FileName).ToLower() != ".jpg")
                    {
                        ShowGuidMessage(0, new Exception("The file must have an extension of JPG"));
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
                                         + file_append.ToString() + ".jpg";
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

                        // If jpg file is a jpeg, create a thumbnail filename that is unique.
                        file_append = 0;
                        sThumbFile = System.IO.Path.GetFileNameWithoutExtension(myFile.FileName)
                                                                + sThumbExtension + ".jpg";
                        while (System.IO.File.Exists(Server.MapPath(sSavePath + sThumbFile)))
                        {
                            file_append++;
                            sThumbFile = System.IO.Path.GetFileNameWithoutExtension(myFile.FileName) +
                                           file_append.ToString() + sThumbExtension + ".jpg";
                        }

                        // Save thumbnail and output it onto the webpage
                        System.Drawing.Image myThumbnail
                                = myBitmap.GetThumbnailImage(intThumbWidth,
                                                             intThumbHeight, myCallBack, IntPtr.Zero);
                        myThumbnail.Save(Server.MapPath(sSavePath + sThumbFile));
                        tdUploadedImage.Visible = true;
                        imgPhotos.ImageUrl = sSavePath + sThumbFile;

                        // Displaying success information
                        //tdError.InnerText = "File uploaded successfully!";

                        // Destroy objects
                        myThumbnail.Dispose();
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
                sFilename = "NoImage.jpg";
            else if (chkDeletePhotoPath.Checked == true)
            {
                if (Convert.ToInt32(ViewState["EditCode"]) > 0)
                {
                    System.IO.File.Delete(Server.MapPath(sSavePath + Convert.ToString(ViewState["PhotoPath"])));
                    System.IO.File.Delete(Server.MapPath(sSavePath + Convert.ToString(ViewState["PhotoPath"]) + sThumbExtension + ".jpg"));
                }
                //else
                //{
                //    System.IO.File.Delete(Server.MapPath(sSavePath + sFilename));
                //    System.IO.File.Delete(Server.MapPath(sSavePath + sThumbFile));
                //}
                sFilename = "NoImage.jpg";
            }

            tbl_NewsMasterProp Objtbl_NewsMasterProp = new tbl_NewsMasterProp();
            Objtbl_NewsMasterProp.NewsCode = Convert.ToInt32(ViewState["EditCode"]);
            Objtbl_NewsMasterProp.NewsHead = txtNewsHead.Text;
            Objtbl_NewsMasterProp.NewsDescription = txtNewsDescription.Text;
            Objtbl_NewsMasterProp.PhotoPath = sFilename;
            Objtbl_NewsMasterProp.CreatedDate = System.DateTime.Now.Date;
            Objtbl_NewsMasterProp.isActive = true;

            tbl_NewsMasterBAL Objtbl_NewsMasterBAL = new tbl_NewsMasterBAL();
            Objtbl_NewsMasterBAL.InsertUpdate_Data(Objtbl_NewsMasterProp);
            ShowGuidMessage(1, null);
            mdlPopupNewEntry.Hide();
            FillData();
        }
        catch (Exception ex)
        {
            System.IO.File.Delete(Server.MapPath(sSavePath + sFilename));
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