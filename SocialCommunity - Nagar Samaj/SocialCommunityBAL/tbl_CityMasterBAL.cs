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
    public class tbl_CityMasterBAL
    {
        public int InsertUpdate_Data(tbl_CityMasterProp Objtbl_CityMasterProp)
        {
            try
            {
                tbl_CityMasterDAL Objtbl_CityMasterDAL = new tbl_CityMasterDAL();
                return Objtbl_CityMasterDAL.InsertUpdate_Data(Objtbl_CityMasterProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete_Data(tbl_CityMasterProp Objtbl_CityMasterProp)
        {
            try
            {
                tbl_CityMasterDAL Objtbl_CityMasterDAL = new tbl_CityMasterDAL();
                return Objtbl_CityMasterDAL.Delete_Data(Objtbl_CityMasterProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_Data(tbl_CityMasterProp Objtbl_CityMasterProp, ref int PageCount)
        {
            try
            {
                if (Objtbl_CityMasterProp.CityCode != 0)
                {
                    Objtbl_CityMasterProp.PageNo = 1;
                    Objtbl_CityMasterProp.RecordCount = 1;
                }
                int RecordCount = 0;
                tbl_CityMasterDAL Objtbl_CityMasterDAL = new tbl_CityMasterDAL();
                DataSet dsData = Objtbl_CityMasterDAL.Select_Data(Objtbl_CityMasterProp, ref RecordCount);
                double Page = Convert.ToDouble(RecordCount) / Convert.ToDouble(Objtbl_CityMasterProp.RecordCount);
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
        public DataSet Search_Data(tbl_CityMasterProp Objtbl_CityMasterProp)
        {
            try
            {
                tbl_CityMasterDAL Objtbl_CityMasterDAL = new tbl_CityMasterDAL();
                return Objtbl_CityMasterDAL.Search_Data(Objtbl_CityMasterProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SelectCombo_Data(tbl_CityMasterProp Objtbl_CityMasterProp)
        {
            try
            {
                tbl_CityMasterDAL Objtbl_CityMasterDAL = new tbl_CityMasterDAL();
                return Objtbl_CityMasterDAL.SelectCombo_Data(Objtbl_CityMasterProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
