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
    public class tbl_MatrimonialMemberBAL
    {
        public int InsertUpdate_Data(tbl_MatrimonialMemberProp Objtbl_MatrimonialMemberProp)
        {
            try
            {
                tbl_MatrimonialMemberDAL Objtbl_MatrimonialMemberDAL = new tbl_MatrimonialMemberDAL();
                return Objtbl_MatrimonialMemberDAL.InsertUpdate_Data(Objtbl_MatrimonialMemberProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete_Data(tbl_MatrimonialMemberProp Objtbl_MatrimonialMemberProp)
        {
            try
            {
                tbl_MatrimonialMemberDAL Objtbl_MatrimonialMemberDAL = new tbl_MatrimonialMemberDAL();
                return Objtbl_MatrimonialMemberDAL.Delete_Data(Objtbl_MatrimonialMemberProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_Data(tbl_MatrimonialMemberProp Objtbl_MatrimonialMemberProp, ref int PageCount)
        {
            try
            {
                if (Objtbl_MatrimonialMemberProp.MemberCode != 0)
                {
                    Objtbl_MatrimonialMemberProp.PageNo = 1;
                    Objtbl_MatrimonialMemberProp.RecordCount = 1;
                }
                int RecordCount = 0;
                tbl_MatrimonialMemberDAL Objtbl_MatrimonialMemberDAL = new tbl_MatrimonialMemberDAL();
                DataSet dsData = Objtbl_MatrimonialMemberDAL.Select_Data(Objtbl_MatrimonialMemberProp, ref RecordCount);
                double Page = Convert.ToDouble(RecordCount) / Convert.ToDouble(Objtbl_MatrimonialMemberProp.RecordCount);
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

        public DataSet CheckLogin(tbl_MatrimonialMemberProp Objtbl_MatrimonialMemberProp)
        {
            try
            {
                tbl_MatrimonialMemberDAL Objtbl_MatrimonialMemberDAL = new tbl_MatrimonialMemberDAL();
                DataSet dsData = Objtbl_MatrimonialMemberDAL.CheckLogin(Objtbl_MatrimonialMemberProp);
                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Search_Data(tbl_MatrimonialMemberProp Objtbl_MatrimonialMemberProp)
        {
            try
            {
                tbl_MatrimonialMemberDAL Objtbl_MatrimonialMemberDAL = new tbl_MatrimonialMemberDAL();
                return Objtbl_MatrimonialMemberDAL.Search_Data(Objtbl_MatrimonialMemberProp);
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
                tbl_MatrimonialMemberDAL Objtbl_MatrimonialMemberDAL = new tbl_MatrimonialMemberDAL();
                return Objtbl_MatrimonialMemberDAL.SelectCombo_Data();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
