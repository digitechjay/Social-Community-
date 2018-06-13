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
    public class tbl_MemberMasterDAL
    {
        public int InsertUpdate_Data(tbl_MemberMasterProp Objtbl_MemberMasterProp)
        {
            try
            {
                Database DB = DatabaseFactory.CreateDatabase("AppConNagar");
                DbCommand DBCmd = DB.GetStoredProcCommand("InsertUpdate_tbl_MemberMaster");
                DB.AddInParameter(DBCmd, "@MemberCode", DbType.Int32, Objtbl_MemberMasterProp.MemberCode);
                DB.AddInParameter(DBCmd, "@MemberName", DbType.String, Objtbl_MemberMasterProp.MemberName);
                DB.AddInParameter(DBCmd, "@CurrentAddress", DbType.String, Objtbl_MemberMasterProp.CurrentAddress);
                DB.AddInParameter(DBCmd, "@CountryCode", DbType.Int32, Objtbl_MemberMasterProp.CountryCode);
                DB.AddInParameter(DBCmd, "@StateCode", DbType.Int32, Objtbl_MemberMasterProp.StateCode);
                DB.AddInParameter(DBCmd, "@CityCode", DbType.Int32, Objtbl_MemberMasterProp.CityCode);
                DB.AddInParameter(DBCmd, "@PermanentAddress", DbType.String, Objtbl_MemberMasterProp.PermanentAddress);
                DB.AddInParameter(DBCmd, "@ContactNo", DbType.String, Objtbl_MemberMasterProp.ContactNo);
                DB.AddInParameter(DBCmd, "@EmailID", DbType.String, Objtbl_MemberMasterProp.EmailID);
                DB.AddInParameter(DBCmd, "@Password", DbType.String, Objtbl_MemberMasterProp.Password);
                DB.AddInParameter(DBCmd, "@DOB", DbType.DateTime, Objtbl_MemberMasterProp.DOB);
                DB.AddInParameter(DBCmd, "@QualificationCode", DbType.Int32, Objtbl_MemberMasterProp.QualificationCode);
                DB.AddInParameter(DBCmd, "@OccupationCode", DbType.Int32, Objtbl_MemberMasterProp.OccupationCode);
                DB.AddInParameter(DBCmd, "@MaritalStatusCode", DbType.Int32, Objtbl_MemberMasterProp.MaritalStatusCode);
                DB.AddInParameter(DBCmd, "@Gender", DbType.Boolean, Objtbl_MemberMasterProp.Gender);
                DB.AddInParameter(DBCmd, "@NativePlaceCode", DbType.Int32, Objtbl_MemberMasterProp.NativePlaceCode);
                DB.AddInParameter(DBCmd, "@NationalityCode", DbType.Int32, Objtbl_MemberMasterProp.NationalityCode);
                DB.AddInParameter(DBCmd, "@PhysicalChallangedCode", DbType.Int32, Objtbl_MemberMasterProp.PhysicalChallangedCode);
                DB.AddInParameter(DBCmd, "@ParentCode", DbType.Int32, Objtbl_MemberMasterProp.ParentCode);
                DB.AddInParameter(DBCmd, "@RelationshipCode", DbType.Int32, Objtbl_MemberMasterProp.RelationshipCode);
                DB.AddInParameter(DBCmd, "@PhotoPath", DbType.String, Objtbl_MemberMasterProp.PhotoPath);

                DB.AddOutParameter(DBCmd, "@RetVal", DbType.Int32, 18);

                DB.ExecuteNonQuery(DBCmd);
                return Convert.ToInt32(DBCmd.Parameters["@RetVal"].Value);
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
                Database DB = DatabaseFactory.CreateDatabase("AppConNagar");
                DbCommand DBCmd = DB.GetStoredProcCommand("Delete_tbl_MemberMaster");
                DB.AddInParameter(DBCmd, "@MemberCode", DbType.Int32, Objtbl_MemberMasterProp.MemberCode);
                return DB.ExecuteNonQuery(DBCmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_Data(tbl_MemberMasterProp Objtbl_MemberMasterProp, ref int TotalCount)
        {
            try
            {
                Database DB = DatabaseFactory.CreateDatabase("AppConNagar");
                DbCommand DBCmd = DB.GetStoredProcCommand("Select_tbl_MemberMaster");
                DB.AddInParameter(DBCmd, "@MemberCode", DbType.Int32, Objtbl_MemberMasterProp.MemberCode);
                DB.AddInParameter(DBCmd, "@PageNo", DbType.Int32, Objtbl_MemberMasterProp.PageNo);
                DB.AddInParameter(DBCmd, "@RecordCount", DbType.Int32, Objtbl_MemberMasterProp.RecordCount);
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
        public DataSet Search_Data(tbl_MemberMasterProp Objtbl_MemberMasterProp)
        {
            try
            {
                Database DB = DatabaseFactory.CreateDatabase("AppConNagar");
                DbCommand DBCmd = DB.GetStoredProcCommand("Search_tbl_MemberMaster");
                DB.AddInParameter(DBCmd, "@SearchBy", DbType.String, Objtbl_MemberMasterProp.SearchBy);
                DB.AddInParameter(DBCmd, "@SearchVal", DbType.String, Objtbl_MemberMasterProp.SearchVal);
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
                DbCommand DBCmd = DB.GetStoredProcCommand("SelectCombo_tbl_MemberMaster");
                return DB.ExecuteDataSet(DBCmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
