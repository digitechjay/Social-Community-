using System;
using System.Data;
using System.Configuration;
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

using System.Net;
using System.Net.Mail;


/// <summary>
/// Summary description for CommonClass
/// </summary>
public class CommonClass
{
    public CommonClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string LoadMenus()
    {
        try
        {
            string HTMLMenu = "";
            //DataSet dsCategoryData = LoadCategory();
            //DataSet dsDataProduct = LoadProducts();
            CommonClassBAL ObjCommonClassBAL = new CommonClassBAL();
            DataSet dsDataMenu = ObjCommonClassBAL.Select_MenuList();

            DataRow[] drCategoryList = dsDataMenu.Tables[0].Select("ParentCategoryCode = 0");

            foreach (DataRow drCategory in drCategoryList)
            {
                HTMLMenu = HTMLMenu + "<li><a href=\"ProductCategory.aspx?CategoryCode=" + Convert.ToString(drCategory["CategoryCode"]) + "\">" + Convert.ToString(drCategory["CategoryName"]) + "</a></li>";
                HTMLMenu = HTMLMenu + "<ul>";
                DataRow[] drProductList = dsDataMenu.Tables[0].Select("ParentCategoryCode = " + Convert.ToString(drCategory["CategoryCode"]));
                foreach (DataRow drProduct in drProductList)
                {
                    HTMLMenu = HTMLMenu + "<li><a href=\"Product.aspx?ProductCode=" + Convert.ToString(drProduct["CategoryCode"]) + "\">" + Convert.ToString(drProduct["CategoryName"]) + "</a></li>";
                }
                HTMLMenu = HTMLMenu + "</ul>";
            }
            return HTMLMenu;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void SendMail(string toEmail, string Password, string Message)
    {
        // Gmail Address from where you send the mail
        var fromAddress = "info@nagarbandhara.com";
        // any address where the email will be sending
        var toAddress = toEmail;
        //Password of your gmail address
        const string fromPassword = "changeme123";
        // Passing the values and make a email formate to display
        string subject = "Register Successfully to NagarBandhara.com";

        string body = Message;

        MailMessage mail = new MailMessage(fromAddress, toAddress, subject, body);
        mail.IsBodyHtml = true;

        // smtp settings
        var smtp = new System.Net.Mail.SmtpClient();
        {
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
            smtp.Timeout = 20000;
        }
        // Passing values to smtp object
        smtp.Send(mail); //(fromAddress, toAddress, subject, body);
    }

}