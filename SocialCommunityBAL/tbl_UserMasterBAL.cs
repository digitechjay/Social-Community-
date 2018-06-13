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
    public class tbl_UserMasterBAL
    {
        public int InsertUpdate_Data(tbl_UserMasterProp Objtbl_UserMasterProp)
        {
            try
            {
                tbl_UserMasterDAL Objtbl_UserMasterDAL = new tbl_UserMasterDAL();
                return Objtbl_UserMasterDAL.InsertUpdate_Data(Objtbl_UserMasterProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete_Data(tbl_UserMasterProp Objtbl_UserMasterProp)
        {
            try
            {
                tbl_UserMasterDAL Objtbl_UserMasterDAL = new tbl_UserMasterDAL();
                return Objtbl_UserMasterDAL.Delete_Data(Objtbl_UserMasterProp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_Data(tbl_UserMasterProp Objtbl_UserMasterProp)
        {
            try
            {
              
                tbl_UserMasterDAL Objtbl_UserMasterDAL = new tbl_UserMasterDAL();
                DataSet dsData = Objtbl_UserMasterDAL.Select_Data(Objtbl_UserMasterProp);
               
                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Search_Data(tbl_UserMasterProp Objtbl_UserMasterProp)
        {
            try
            {
                tbl_UserMasterDAL Objtbl_UserMasterDAL = new tbl_UserMasterDAL();
                return Objtbl_UserMasterDAL.Search_Data(Objtbl_UserMasterProp);
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
                tbl_UserMasterDAL Objtbl_UserMasterDAL = new tbl_UserMasterDAL();
                return Objtbl_UserMasterDAL.SelectCombo_Data();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
