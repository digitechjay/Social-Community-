using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

using SocialCommunityProp;
using SocialCommunityDAL;

namespace SocialCommunityBAL
{
    public class tbl_PhotoGalleryMasterBAL
    {
        public int InsertUpdate_Data(tbl_PhotoGalleryMasterProp Objtbl_PhotoGalleryMasterProp)
        {
            try
            {
                tbl_PhotoGalleryMasterDAL Objtbl_PhotoGalleryMasterDAL = new tbl_PhotoGalleryMasterDAL();
                return Objtbl_PhotoGalleryMasterDAL.InsertUpdate_Data(Objtbl_PhotoGalleryMasterProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete_Data(tbl_PhotoGalleryMasterProp Objtbl_PhotoGalleryMasterProp)
        {
            try
            {
                tbl_PhotoGalleryMasterDAL Objtbl_PhotoGalleryMasterDAL = new tbl_PhotoGalleryMasterDAL();
                return Objtbl_PhotoGalleryMasterDAL.Delete_Data(Objtbl_PhotoGalleryMasterProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_Data(tbl_PhotoGalleryMasterProp Objtbl_PhotoGalleryMasterProp, ref int PageCount)
        {
            try
            {
                if (Objtbl_PhotoGalleryMasterProp.PhotoCode != 0)
                {
                    Objtbl_PhotoGalleryMasterProp.PageNo = 1;
                    Objtbl_PhotoGalleryMasterProp.RecordCount = 1;
                }
                int RecordCount = 0;
                tbl_PhotoGalleryMasterDAL Objtbl_PhotoGalleryMasterDAL = new tbl_PhotoGalleryMasterDAL();
                DataSet dsData = Objtbl_PhotoGalleryMasterDAL.Select_Data(Objtbl_PhotoGalleryMasterProp, ref RecordCount);
                double Page = Convert.ToDouble(RecordCount) / Convert.ToDouble(Objtbl_PhotoGalleryMasterProp.RecordCount);
                if (dsData.Tables[0].Rows.Count > 0)
                {
                    string[] PageDecimal = Page.ToString().Split('.');
                    if (PageDecimal.Length > 1 && Convert.ToInt32(PageDecimal[1]) > 0)
                    {
                        PageCount = Convert.ToInt32(Page.ToString().Split('.')[0]) + 1;
                    }
                    else
                    {
                        PageCount = Convert.ToInt32(Page);
                    }
                }
                else
                {
                    PageCount = 0;
                }
                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Search_Data(tbl_PhotoGalleryMasterProp Objtbl_PhotoGalleryMasterProp)
        {
            try
            {
                tbl_PhotoGalleryMasterDAL Objtbl_PhotoGalleryMasterDAL = new tbl_PhotoGalleryMasterDAL();
                return Objtbl_PhotoGalleryMasterDAL.Search_Data(Objtbl_PhotoGalleryMasterProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SelectCombo_Data()
        {
            try
            {
                tbl_PhotoGalleryMasterDAL Objtbl_PhotoGalleryMasterDAL = new tbl_PhotoGalleryMasterDAL();
                return Objtbl_PhotoGalleryMasterDAL.SelectCombo_Data();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
