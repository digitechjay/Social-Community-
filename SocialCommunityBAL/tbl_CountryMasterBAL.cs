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
    public class tbl_CountryMasterBAL
    {
        public int InsertUpdate_Data(tbl_CountryMasterProp Objtbl_CountryMasterProp)
        {
            try
            {
                tbl_CountryMasterDAL Objtbl_CountryMasterDAL = new tbl_CountryMasterDAL();
                return Objtbl_CountryMasterDAL.InsertUpdate_Data(Objtbl_CountryMasterProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete_Data(tbl_CountryMasterProp Objtbl_CountryMasterProp)
        {
            try
            {
                tbl_CountryMasterDAL Objtbl_CountryMasterDAL = new tbl_CountryMasterDAL();
                return Objtbl_CountryMasterDAL.Delete_Data(Objtbl_CountryMasterProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_Data(tbl_CountryMasterProp Objtbl_CountryMasterProp, ref int PageCount)
        {
            try
            {
                if (Objtbl_CountryMasterProp.CountryCode != 0)
                {
                    Objtbl_CountryMasterProp.PageNo = 1;
                    Objtbl_CountryMasterProp.RecordCount = 1;
                }
                int RecordCount = 0;
                tbl_CountryMasterDAL Objtbl_CountryMasterDAL = new tbl_CountryMasterDAL();
                DataSet dsData = Objtbl_CountryMasterDAL.Select_Data(Objtbl_CountryMasterProp, ref RecordCount);
                double Page = Convert.ToDouble(RecordCount) / Convert.ToDouble(Objtbl_CountryMasterProp.RecordCount);
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
        public DataSet Search_Data(tbl_CountryMasterProp Objtbl_CountryMasterProp)
        {
            try
            {
                tbl_CountryMasterDAL Objtbl_CountryMasterDAL = new tbl_CountryMasterDAL();
                return Objtbl_CountryMasterDAL.Search_Data(Objtbl_CountryMasterProp);
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
                tbl_CountryMasterDAL Objtbl_CountryMasterDAL = new tbl_CountryMasterDAL();
                return Objtbl_CountryMasterDAL.SelectCombo_Data();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
