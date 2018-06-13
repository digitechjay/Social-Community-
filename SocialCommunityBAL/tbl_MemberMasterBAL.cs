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
    public class tbl_MemberMasterBAL
    {
        public int InsertUpdate_Data(tbl_MemberMasterProp Objtbl_MemberMasterProp)
        {
            try
            {
                tbl_MemberMasterDAL Objtbl_MemberMasterDAL = new tbl_MemberMasterDAL();
                return Objtbl_MemberMasterDAL.InsertUpdate_Data(Objtbl_MemberMasterProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete_Data(tbl_MemberMasterProp Objtbl_MemberMasterProp)
        {
            try
            {
                tbl_MemberMasterDAL Objtbl_MemberMasterDAL = new tbl_MemberMasterDAL();
                return Objtbl_MemberMasterDAL.Delete_Data(Objtbl_MemberMasterProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_Data(tbl_MemberMasterProp Objtbl_MemberMasterProp, ref int PageCount)
        {
            try
            {
                if (Objtbl_MemberMasterProp.MemberCode != 0)
                {
                    Objtbl_MemberMasterProp.PageNo = 1;
                    Objtbl_MemberMasterProp.RecordCount = 1;
                }
                int RecordCount = 0;
                tbl_MemberMasterDAL Objtbl_MemberMasterDAL = new tbl_MemberMasterDAL();
                DataSet dsData = Objtbl_MemberMasterDAL.Select_Data(Objtbl_MemberMasterProp, ref RecordCount);
                double Page = Convert.ToDouble(RecordCount) / Convert.ToDouble(Objtbl_MemberMasterProp.RecordCount);
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
        public DataSet Search_Data(tbl_MemberMasterProp Objtbl_MemberMasterProp)
        {
            try
            {
                tbl_MemberMasterDAL Objtbl_MemberMasterDAL = new tbl_MemberMasterDAL();
                return Objtbl_MemberMasterDAL.Search_Data(Objtbl_MemberMasterProp);
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
                tbl_MemberMasterDAL Objtbl_MemberMasterDAL = new tbl_MemberMasterDAL();
                return Objtbl_MemberMasterDAL.SelectCombo_Data();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
