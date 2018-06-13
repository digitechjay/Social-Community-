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

using SocialCommunityBAL;
using SocialCommunityProp;

public partial class PhotoGallery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            FillAlbumList();
        }
        catch
        {
        }
    }

    private void FillAlbumList()
    {
        try
        {
            tbl_AlbumMasterBAL Objtbl_AlbumMasterBAL = new tbl_AlbumMasterBAL();
            DataSet dsData = Objtbl_AlbumMasterBAL.SelectCombo_Data();
            rptPhotoAlbum.DataSource = dsData.Tables[0];
            rptPhotoAlbum.DataBind();

            if (dsData.Tables[0].Rows.Count > 0)
            {
                FillAlbumImages(Convert.ToInt32(dsData.Tables[0].Rows[0]["AlbumCode"]));
            }
        }
        catch
        {
        }
    }

    private void FillAlbumImages(int AlbumCode)
    {
        try
        {
            tbl_PhotoGalleryMasterProp Objtbl_PhotoGalleryMasterProp = new tbl_PhotoGalleryMasterProp();
            Objtbl_PhotoGalleryMasterProp.SearchBy = "AlbumCode";
            Objtbl_PhotoGalleryMasterProp.SearchVal = Convert.ToString(AlbumCode);

            tbl_PhotoGalleryMasterBAL Objtbl_PhotoGalleryMasterBAL = new tbl_PhotoGalleryMasterBAL();
            DataSet dsData = Objtbl_PhotoGalleryMasterBAL.Search_Data(Objtbl_PhotoGalleryMasterProp);
            rptImageThumbnail.DataSource = dsData.Tables[0];
            rptImageThumbnail.DataBind();
        }
        catch
        {
        }
    }

    protected string ProcessAlbumName(object val)
    {
        if (val != null)
        {
            return val.ToString().Length > 30 ? val.ToString().Substring(0, 30) + "..." : val.ToString();
        }
        return "";
    }

    protected void lnkAlbum_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lnkAlbumBtn = (LinkButton)sender;
            FillAlbumImages(Convert.ToInt32(lnkAlbumBtn.CommandArgument));
        }
        catch
        {
        }
    }
}
