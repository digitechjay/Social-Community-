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
    public class tbl_NewsMasterBAL
    {
        public int InsertUpdate_Data(tbl_NewsMasterProp Objtbl_NewsMasterProp)
        {
            try
            {
                tbl_NewsMasterDAL Objtbl_NewsMasterDAL = new tbl_NewsMasterDAL();
                return Objtbl_NewsMasterDAL.InsertUpdate_Data(Objtbl_NewsMasterProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete_Data(tbl_NewsMasterProp Objtbl_NewsMasterProp)
        {
            try
            {
                tbl_NewsMasterDAL Objtbl_NewsMasterDAL = new tbl_NewsMasterDAL();
                return Objtbl_NewsMasterDAL.Delete_Data(Objtbl_NewsMasterProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_Data(tbl_NewsMasterProp Objtbl_NewsMasterProp, ref int PageCount)
        {
            try
            {
                if (Objtbl_NewsMasterProp.NewsCode != 0)
                {
                    Objtbl_NewsMasterProp.PageNo = 1;
                    Objtbl_NewsMasterProp.RecordCount = 1;
                }
                int RecordCount = 0;
                tbl_NewsMasterDAL Objtbl_NewsMasterDAL = new tbl_NewsMasterDAL();
                DataSet dsData = Objtbl_NewsMasterDAL.Select_Data(Objtbl_NewsMasterProp, ref RecordCount);
                double Page = Convert.ToDouble(RecordCount) / Convert.ToDouble(Objtbl_NewsMasterProp.RecordCount);
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
        public DataSet Search_Data(tbl_NewsMasterProp Objtbl_NewsMasterProp)
        {
            try
            {
                tbl_NewsMasterDAL Objtbl_NewsMasterDAL = new tbl_NewsMasterDAL();
                return Objtbl_NewsMasterDAL.Search_Data(Objtbl_NewsMasterProp);
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
                tbl_NewsMasterDAL Objtbl_NewsMasterDAL = new tbl_NewsMasterDAL();
                return Objtbl_NewsMasterDAL.SelectCombo_Data();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
