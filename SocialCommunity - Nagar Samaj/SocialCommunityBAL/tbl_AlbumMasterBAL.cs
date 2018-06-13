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
    public class tbl_AlbumMasterBAL
    {
        public int InsertUpdate_Data(tbl_AlbumMasterProp Objtbl_AlbumMasterProp)
        {
            try
            {
                tbl_AlbumMasterDAL Objtbl_AlbumMasterDAL = new tbl_AlbumMasterDAL();
                return Objtbl_AlbumMasterDAL.InsertUpdate_Data(Objtbl_AlbumMasterProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete_Data(tbl_AlbumMasterProp Objtbl_AlbumMasterProp)
        {
            try
            {
                tbl_AlbumMasterDAL Objtbl_AlbumMasterDAL = new tbl_AlbumMasterDAL();
                return Objtbl_AlbumMasterDAL.Delete_Data(Objtbl_AlbumMasterProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_Data(tbl_AlbumMasterProp Objtbl_AlbumMasterProp, ref int PageCount)
        {
            try
            {
                if (Objtbl_AlbumMasterProp.AlbumCode != 0)
                {
                    Objtbl_AlbumMasterProp.PageNo = 1;
                    Objtbl_AlbumMasterProp.RecordCount = 1;
                }
                int RecordCount = 0;
                tbl_AlbumMasterDAL Objtbl_AlbumMasterDAL = new tbl_AlbumMasterDAL();
                DataSet dsData = Objtbl_AlbumMasterDAL.Select_Data(Objtbl_AlbumMasterProp, ref RecordCount);
                double Page = Convert.ToDouble(RecordCount) / Convert.ToDouble(Objtbl_AlbumMasterProp.RecordCount);
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
        public DataSet Search_Data(tbl_AlbumMasterProp Objtbl_AlbumMasterProp)
        {
            try
            {
                tbl_AlbumMasterDAL Objtbl_AlbumMasterDAL = new tbl_AlbumMasterDAL();
                return Objtbl_AlbumMasterDAL.Search_Data(Objtbl_AlbumMasterProp);
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
                tbl_AlbumMasterDAL Objtbl_AlbumMasterDAL = new tbl_AlbumMasterDAL();
                return Objtbl_AlbumMasterDAL.SelectCombo_Data();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
