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

public partial class Admin_EventMaster : System.Web.UI.Page
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
            tbl_EventMasterProp Objtbl_EventMasterProp = new tbl_EventMasterProp();
            Objtbl_EventMasterProp.EventCode = 0;
            Objtbl_EventMasterProp.PageNo = Convert.ToInt32(txtCurPage.Text);
            Objtbl_EventMasterProp.RecordCount = Convert.ToInt32(20);

            tbl_EventMasterBAL Objtbl_EventMasterBAL = new tbl_EventMasterBAL();
            DataSet dsData = Objtbl_EventMasterBAL.Select_Data(Objtbl_EventMasterProp, ref PageCount);

            lblTotalPage.Text = Convert.ToString(PageCount);

            grdData.DataSource = dsData.Tables[0];
            grdData.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void EditData(int EventCode)
    {
        try
        {
            tbl_EventMasterProp Objtbl_EventMasterProp = new tbl_EventMasterProp();
            Objtbl_EventMasterProp.EventCode = EventCode;

            int PageCount = 0;
            tbl_EventMasterBAL Objtbl_EventMasterBAL = new tbl_EventMasterBAL();
            DataSet dsData = Objtbl_EventMasterBAL.Select_Data(Objtbl_EventMasterProp, ref PageCount);

            txtEventName.Text = Convert.ToString(dsData.Tables[0].Rows[0]["EventName"]);
            ViewState["EditCode"] = EventCode;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void DeleteData(int EventCode)
    {
        try
        {
            tbl_EventMasterProp Objtbl_EventMasterProp = new tbl_EventMasterProp();
            Objtbl_EventMasterProp.EventCode = EventCode;

            tbl_EventMasterBAL Objtbl_EventMasterBAL = new tbl_EventMasterBAL();
            Objtbl_EventMasterBAL.Delete_Data(Objtbl_EventMasterProp);

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
            txtEventName.Text = "";
            txtEventStartDate.Text = "";
            txtEventEndDate.Text = "";
            txtEventDescription.Text = "";
            txtCharges.Text = "";
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
        string sFilename = "";

        try
        {
            if (chkDeleteFilePath.Checked == false)
            {
                // Set constant values
                sSavePath = "../EventsFiles/";

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
                    if (System.IO.Path.GetExtension(myFile.FileName).ToLower() != ".jpg" || System.IO.Path.GetExtension(myFile.FileName).ToLower() != ".pdf")
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
                        tdUploadedFile.InnerHtml = "<a href=\"..\\EventsFiles\\" + "\"" + sSavePath + sFilename + ">Download Attachment</a>";

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
                sFilename = Convert.ToString(ViewState["FilePath"]);
            else if (sFilename == "" && Convert.ToInt32(ViewState["EditCode"]) <= 0)
                sFilename = "-";
            else if (chkDeleteFilePath.Checked == true)
            {
                if (Convert.ToInt32(ViewState["EditCode"]) > 0)
                {
                    System.IO.File.Delete(Server.MapPath(sSavePath + Convert.ToString(ViewState["FilePath"])));
                }
                sFilename = "-";
            }
            tbl_EventMasterProp Objtbl_EventMasterProp = new tbl_EventMasterProp();
            Objtbl_EventMasterProp.EventCode = Convert.ToInt32(ViewState["EditCode"]);
            Objtbl_EventMasterProp.EventName = txtEventName.Text;
            Objtbl_EventMasterProp.EventStartDate = Convert.ToDateTime(txtEventStartDate.Text);
            Objtbl_EventMasterProp.EventEndDate = Convert.ToDateTime(txtEventEndDate.Text);
            Objtbl_EventMasterProp.EventDescription = txtEventDescription.Text;
            Objtbl_EventMasterProp.Charges = Convert.ToDouble(txtCharges.Text);
            Objtbl_EventMasterProp.FilePath = sFilename;

            tbl_EventMasterBAL Objtbl_EventMasterBAL = new tbl_EventMasterBAL();
            Objtbl_EventMasterBAL.InsertUpdate_Data(Objtbl_EventMasterProp);
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