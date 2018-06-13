using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data.Common;

using SocialCommunityProp;
namespace SocialCommunityDAL
{
    public class tbl_MatrimonialMemberDAL
    {
        public int InsertUpdate_Data(tbl_MatrimonialMemberProp Objtbl_MatrimonialMemberProp)
        {
            try
            {
                Database DB = DatabaseFactory.CreateDatabase("AppConNagar");
                DbCommand DBCmd = DB.GetStoredProcCommand("InsertUpdate_tbl_MatrimonialMember");
                DB.AddInParameter(DBCmd, "@MemberCode", DbType.Int32, Objtbl_MatrimonialMemberProp.MemberCode);
                DB.AddInParameter(DBCmd, "@MemberName", DbType.String, Objtbl_MatrimonialMemberProp.MemberName);
                DB.AddInParameter(DBCmd, "@DOB", DbType.DateTime, Objtbl_MatrimonialMemberProp.DOB);
                DB.AddInParameter(DBCmd, "@Gender", DbType.Int32, Objtbl_MatrimonialMemberProp.Gender);
                DB.AddInParameter(DBCmd, "@Gotra", DbType.String, Objtbl_MatrimonialMemberProp.Gotra);
                DB.AddInParameter(DBCmd, "@LivingIn", DbType.Int32, Objtbl_MatrimonialMemberProp.LivingIn);
                DB.AddInParameter(DBCmd, "@EmailID", DbType.String, Objtbl_MatrimonialMemberProp.EmailID);
                DB.AddInParameter(DBCmd, "@ContactNo", DbType.String, Objtbl_MatrimonialMemberProp.ContactNo);
                DB.AddInParameter(DBCmd, "@Password", DbType.String, Objtbl_MatrimonialMemberProp.Password);
                DB.AddInParameter(DBCmd, "@MemberPhoto", DbType.String, Objtbl_MatrimonialMemberProp.MemberPhoto);
                DB.AddOutParameter(DBCmd, "@RetVal", DbType.Int32, 18);
                DB.ExecuteNonQuery(DBCmd);
                return Convert.ToInt32(DBCmd.Parameters["@RetVal"].Value);
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
                Database DB = DatabaseFactory.CreateDatabase("AppConNagar");
                DbCommand DBCmd = DB.GetStoredProcCommand("Delete_tbl_MatrimonialMember");
                DB.AddInParameter(DBCmd, "@MemberCode", DbType.Int32, Objtbl_MatrimonialMemberProp.MemberCode);
                return DB.ExecuteNonQuery(DBCmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_Data(tbl_MatrimonialMemberProp Objtbl_MatrimonialMemberProp, ref int TotalCount)
        {
            try
            {
                Database DB = DatabaseFactory.CreateDatabase("AppConNagar");
                DbCommand DBCmd = DB.GetStoredProcCommand("Select_tbl_MatrimonialMember");
                DB.AddInParameter(DBCmd, "@MemberCode", DbType.Int32, Objtbl_MatrimonialMemberProp.MemberCode);
                DB.AddInParameter(DBCmd, "@PageNo", DbType.Int32, Objtbl_MatrimonialMemberProp.PageNo);
                DB.AddInParameter(DBCmd, "@RecordCount", DbType.Int32, Objtbl_MatrimonialMemberProp.RecordCount);
                DB.AddOutParameter(DBCmd, "@TotalCount", DbType.Int32, 18);
                DataSet dsData = DB.ExecuteDataSet(DBCmd);
                TotalCount = Convert.ToInt32(DBCmd.Parameters["@TotalCount"].Value);
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
                Database DB = DatabaseFactory.CreateDatabase("AppConNagar");
                DbCommand DBCmd = DB.GetStoredProcCommand("Check_MatrimonialMember_Login");
                DB.AddInParameter(DBCmd, "@EmailID", DbType.String, Objtbl_MatrimonialMemberProp.EmailID);
                DataSet dsData = DB.ExecuteDataSet(DBCmd);
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
                Database DB = DatabaseFactory.CreateDatabase("AppConNagar");
                DbCommand DBCmd = DB.GetStoredProcCommand("Search_tbl_MatrimonialMember");
                DB.AddInParameter(DBCmd, "@SearchBy", DbType.String, Objtbl_MatrimonialMemberProp.SearchBy);
                DB.AddInParameter(DBCmd, "@SearchVal", DbType.String, Objtbl_MatrimonialMemberProp.SearchVal);
                return DB.ExecuteDataSet(DBCmd);
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
                Database DB = DatabaseFactory.CreateDatabase("AppConNagar");
                DbCommand DBCmd = DB.GetStoredProcCommand("SelectCombo_tbl_MatrimonialMember");
                return DB.ExecuteDataSet(DBCmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
