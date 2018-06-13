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
    public class tbl_FeedbackMasterBAL
    {
        public int InsertUpdate_Data(tbl_FeedbackMasterProp Objtbl_FeedbackMasterProp)
        {
            try
            {
                tbl_FeedbackMasterDAL Objtbl_FeedbackMasterDAL = new tbl_FeedbackMasterDAL();
                return Objtbl_FeedbackMasterDAL.InsertUpdate_Data(Objtbl_FeedbackMasterProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete_Data(tbl_FeedbackMasterProp Objtbl_FeedbackMasterProp)
        {
            try
            {
                tbl_FeedbackMasterDAL Objtbl_FeedbackMasterDAL = new tbl_FeedbackMasterDAL();
                return Objtbl_FeedbackMasterDAL.Delete_Data(Objtbl_FeedbackMasterProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_Data(tbl_FeedbackMasterProp Objtbl_FeedbackMasterProp, ref int PageCount)
        {
            try
            {
                if (Objtbl_FeedbackMasterProp.MessageCode != 0)
                {
                    Objtbl_FeedbackMasterProp.PageNo = 1;
                    Objtbl_FeedbackMasterProp.RecordCount = 1;
                }
                int RecordCount = 0;
                tbl_FeedbackMasterDAL Objtbl_FeedbackMasterDAL = new tbl_FeedbackMasterDAL();
                DataSet dsData = Objtbl_FeedbackMasterDAL.Select_Data(Objtbl_FeedbackMasterProp, ref RecordCount);
                double Page = Convert.ToDouble(RecordCount) / Convert.ToDouble(Objtbl_FeedbackMasterProp.RecordCount);
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
        public DataSet Search_Data(tbl_FeedbackMasterProp Objtbl_FeedbackMasterProp)
        {
            try
            {
                tbl_FeedbackMasterDAL Objtbl_FeedbackMasterDAL = new tbl_FeedbackMasterDAL();
                return Objtbl_FeedbackMasterDAL.Search_Data(Objtbl_FeedbackMasterProp);
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
                tbl_FeedbackMasterDAL Objtbl_FeedbackMasterDAL = new tbl_FeedbackMasterDAL();
                return Objtbl_FeedbackMasterDAL.SelectCombo_Data();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
