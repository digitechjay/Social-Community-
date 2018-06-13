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
using System.Drawing;
using Encrypt;

public partial class MatrimonialSignUp : System.Web.UI.Page
{
    #region "--------------- Variable Declaration ---------------"

    #endregion

    #region "--------------- Form Construnction & Events ---------------"

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCountry();
            ErrorPart.Visible = false;
        }
        if (Convert.ToString(Session["LoginName"]) != "")
        {
            Response.Redirect("Default.aspx");
        }
        if (Convert.ToString(Request.QueryString["msg"]) == "invalidid")
        {
            ErrorPart.Visible = true;
            ErrorImage.InnerHtml = "<img src=\"../Images/Error.png\" alt=\"Error\" />";
            tdError.InnerText = "Invalid Login ID! Sign up for Login";
        }
        else if (Convert.ToString(Request.QueryString["msg"]) == "invalidpwd")
        {
            ErrorPart.Visible = true;
            ErrorImage.InnerHtml = "<img src=\"../Images/Error.png\" alt=\"Error\" />";
            tdError.InnerText = "Invalid Password!";
        }
    }

    #endregion

    #region "--------------- User Functions ---------------"

    private void LoadCountry()
    {
        tbl_CountryMasterBAL Objtbl_CountryMasterBAL = new tbl_CountryMasterBAL();
        DataSet dsData = Objtbl_CountryMasterBAL.SelectCombo_Data();
        ddlLivingIn.DataSource = dsData.Tables[0];
        ddlLivingIn.DataTextField = "CountryName";
        ddlLivingIn.DataValueField = "CountryCode";
        ddlLivingIn.DataBind();
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

    public bool ThumbnailCallback()
    {
        return false;
    }

    private void ClearPageData()
    {
        try
        {
            txtMemberName.Text = "";
            txtDOB.Text = "";
            rdbtnGender.SelectedValue = "0";
            ddlGotra.SelectedItem.Text = "0";
            ddlLivingIn.SelectedValue = "0";
            txtEmailID.Text = "";
            txtContactNo.Text = "";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region "--------------- Buttons Events ---------------"

    protected void btnSignup_Click(object sender, EventArgs e)
    {
        string sSavePath = "";
        string sFilename = "";

        try
        {
            //if (chkDeleteFilePath.Checked == false)
            //{
            // Set constant values
            sSavePath = "MembersPhotos/";

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
                //System.Drawing.Image.GetThumbnailImageAbort myCallBack =
                //               new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
                //Bitmap myBitmap;
                //try
                //{
                //    myBitmap = new Bitmap(Server.MapPath(sSavePath + sFilename));

                //    tdUploadedFile.Visible = true;
                //    tdUploadedFile.InnerHtml = "<a href=\"" + sSavePath + sFilename + "\">Download Attachment</a>";

                //    // Displaying success information
                //    //tdError.InnerText = "File uploaded successfully!";

                //    // Destroy objects
                //    myBitmap.Dispose();
                //}
                //catch
                //{
                //    // The file wasn't a valid jpg file
                //    System.IO.File.Delete(Server.MapPath(sSavePath + sFilename));
                //    ShowGuidMessage(0, new Exception("The file wasn't a valid jpg file"));
                //    return;
                //}
            }
            //}
            if (sFilename == "" && Convert.ToInt32(ViewState["EditCode"]) > 0)
                sFilename = Convert.ToString(ViewState["PhotoPath"]);
            else if (sFilename == "" && Convert.ToInt32(ViewState["EditCode"]) <= 0)
                sFilename = "noimage.jpg";
            //else if (chkDeleteFilePath.Checked == true)
            //{
            //    if (Convert.ToInt32(ViewState["EditCode"]) > 0)
            //    {
            //        System.IO.File.Delete(Server.MapPath(sSavePath + Convert.ToString(ViewState["PhotoPath"])));
            //    }
            //    sFilename = "noimage.jpg";
            //}

            tbl_MatrimonialMemberProp Objtbl_MatrimonialMemberProp = new tbl_MatrimonialMemberProp();
            Objtbl_MatrimonialMemberProp.MemberName = Convert.ToString(txtMemberName.Text);
            Objtbl_MatrimonialMemberProp.DOB = new DateTime(Convert.ToInt32(txtDOB.Text.Split('/')[2]), Convert.ToInt32(txtDOB.Text.Split('/')[1]), Convert.ToInt32(txtDOB.Text.Split('/')[0]));
            Objtbl_MatrimonialMemberProp.Gender = Convert.ToInt32(rdbtnGender.SelectedValue);
            Objtbl_MatrimonialMemberProp.Gotra = Convert.ToString(ddlGotra.SelectedItem.Text);
            Objtbl_MatrimonialMemberProp.LivingIn = Convert.ToInt32(ddlLivingIn.SelectedValue);
            Objtbl_MatrimonialMemberProp.EmailID = txtEmailID.Text;
            Objtbl_MatrimonialMemberProp.ContactNo = txtContactNo.Text;

            Encrypting ObjEncrypting = new Encrypting();
            string DataPassword = ObjEncrypting.Encrypt(Convert.ToString(txtPassword.Text));

            Objtbl_MatrimonialMemberProp.Password = DataPassword;
            Objtbl_MatrimonialMemberProp.MemberPhoto = sFilename;

            tbl_MatrimonialMemberBAL Objtbl_MatrimonialMemberBAL = new tbl_MatrimonialMemberBAL();
            Objtbl_MatrimonialMemberBAL.InsertUpdate_Data(Objtbl_MatrimonialMemberProp);

            //CommonClass ObjCommonClass = new CommonClass();
            //ObjCommonClass.SendMail(txtEmailID.Text, txtPassword.Text, MailMessage());

            ClearPageData();
        }
        catch (Exception ex)
        {
            ShowGuidMessage(0, ex);
        }
    }

    private string MailMessage()
    {
        string body = "";
        //body = "<html><body>";
        //body += "<table rules=\"all\" style=\"border-color: #666;\" cellpadding=\"10\">";
        //body += "<tr style='background: #eee;'><td><strong>Name:</strong> </td><td>" + Name + "</td></tr>";
        //body += "<tr><td><strong>Email ID:</strong> </td><td>" + toEmail + "</td></tr>";
        //body += "<tr><td><strong>Contact No:</strong> </td><td>" + Password + "</td></tr>";
        //body += "<tr><td><strong>Address:</strong> </td><td>" + Password + "</td></tr>";
        //body += "<tr><td><strong>Product Name:</strong> </td><td>" + Password + "</td></tr>";
        //body += "<tr><td><strong>Remarks:</strong> </td><td>" + Password + "</td></tr>";
        //body += "</table>";
        //body += "</body></html>";
        return body;
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        tbl_MatrimonialMemberProp Objtbl_MatrimonialMemberProp = new tbl_MatrimonialMemberProp();
        Objtbl_MatrimonialMemberProp.EmailID = txtLoginEmailID.Text;

        tbl_MatrimonialMemberBAL Objtbl_MatrimonialMemberBAL = new tbl_MatrimonialMemberBAL();
        DataSet dsData = Objtbl_MatrimonialMemberBAL.CheckLogin(Objtbl_MatrimonialMemberProp);
        if (dsData.Tables[0].Rows.Count > 0)
        {
            Encrypting ObjEncrypting = new Encrypting();
            string DataPassword = ObjEncrypting.Encrypt(Convert.ToString(dsData.Tables[0].Rows[0]["Password"]));
            if (txtLoginPassword.Text == DataPassword)
            {
                Session["LoginName"] = Convert.ToString(dsData.Tables[0].Rows[0]["MemberName"]);
                Session["LoginID"] = Convert.ToString(dsData.Tables[0].Rows[0]["MemberCode"]);

                Master.FindControl("memberlist").Visible = true;
                Master.FindControl("matrimonialmemberlist").Visible = true;

                Master.FindControl("Welcome").Visible = true;
                Master.FindControl("LoginForm").Visible = false;

                if (Convert.ToString(Request.QueryString["msg"]) == "MatrimonialList")
                {
                    Response.Redirect("MatrimonialMembersList.aspx");
                }
                else if (Convert.ToString(Request.QueryString["msg"]) == "MemberList")
                {
                    Response.Redirect("MembersList.aspx");
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
                //memberlist.Visible = true;
                //matrimonialmemberlist.Visible = true;

                //Welcome.Visible = true;
                //LoginForm.Visible = false;
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

    #endregion
}
