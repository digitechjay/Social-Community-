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
    public class tbl_StateMasterBAL
    {
        public int InsertUpdate_Data(tbl_StateMasterProp Objtbl_StateMasterProp)
        {
            try
            {
                tbl_StateMasterDAL Objtbl_StateMasterDAL = new tbl_StateMasterDAL();
                return Objtbl_StateMasterDAL.InsertUpdate_Data(Objtbl_StateMasterProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete_Data(tbl_StateMasterProp Objtbl_StateMasterProp)
        {
            try
            {
                tbl_StateMasterDAL Objtbl_StateMasterDAL = new tbl_StateMasterDAL();
                return Objtbl_StateMasterDAL.Delete_Data(Objtbl_StateMasterProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_Data(tbl_StateMasterProp Objtbl_StateMasterProp, ref int PageCount)
        {
            try
            {
                if (Objtbl_StateMasterProp.StateCode != 0)
                {
                    Objtbl_StateMasterProp.PageNo = 1;
                    Objtbl_StateMasterProp.RecordCount = 1;
                }
                int RecordCount = 0;
                tbl_StateMasterDAL Objtbl_StateMasterDAL = new tbl_StateMasterDAL();
                DataSet dsData = Objtbl_StateMasterDAL.Select_Data(Objtbl_StateMasterProp, ref RecordCount);
                double Page = Convert.ToDouble(RecordCount) / Convert.ToDouble(Objtbl_StateMasterProp.RecordCount);
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

        public DataSet Search_Data(tbl_StateMasterProp Objtbl_StateMasterProp)
        {
            try
            {
                tbl_StateMasterDAL Objtbl_StateMasterDAL = new tbl_StateMasterDAL();
                return Objtbl_StateMasterDAL.Search_Data(Objtbl_StateMasterProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SelectCombo_Data(tbl_StateMasterProp Objtbl_StateMasterProp)
        {
            try
            {
                tbl_StateMasterDAL Objtbl_StateMasterDAL = new tbl_StateMasterDAL();
                return Objtbl_StateMasterDAL.SelectCombo_Data(Objtbl_StateMasterProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
