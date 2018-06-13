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
    public class tbl_CityMasterDAL
    {
        public int InsertUpdate_Data(tbl_CityMasterProp Objtbl_CityMasterProp)
        {
            try
            {
                Database DB = DatabaseFactory.CreateDatabase("AppConNagar");
                DbCommand DBCmd = DB.GetStoredProcCommand("InsertUpdate_tbl_CityMaster");
                DB.AddInParameter(DBCmd, "@CityCode", DbType.Int32, Objtbl_CityMasterProp.CityCode);
                DB.AddInParameter(DBCmd, "@CityName", DbType.String, Objtbl_CityMasterProp.CityName);
                DB.AddInParameter(DBCmd, "@StateCode", DbType.Int32, Objtbl_CityMasterProp.StateCode);
                DB.AddOutParameter(DBCmd, "@RetVal", DbType.Int32, 18);
                DB.ExecuteNonQuery(DBCmd);
                return Convert.ToInt32(DBCmd.Parameters["@RetVal"].Value);
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
                Database DB = DatabaseFactory.CreateDatabase("AppConNagar");
                DbCommand DBCmd = DB.GetStoredProcCommand("Delete_tbl_CityMaster");
                DB.AddInParameter(DBCmd, "@CityCode", DbType.Int32, Objtbl_CityMasterProp.CityCode);
                return DB.ExecuteNonQuery(DBCmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_Data(tbl_CityMasterProp Objtbl_CityMasterProp, ref int TotalCount)
        {
            try
            {
                Database DB = DatabaseFactory.CreateDatabase("AppConNagar");
                DbCommand DBCmd = DB.GetStoredProcCommand("Select_tbl_CityMaster");
                DB.AddInParameter(DBCmd, "@CityCode", DbType.Int32, Objtbl_CityMasterProp.CityCode);
                DB.AddInParameter(DBCmd, "@PageNo", DbType.Int32, Objtbl_CityMasterProp.PageNo);
                DB.AddInParameter(DBCmd, "@RecordCount", DbType.Int32, Objtbl_CityMasterProp.RecordCount);
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
        public DataSet Search_Data(tbl_CityMasterProp Objtbl_CityMasterProp)
        {
            try
            {
                Database DB = DatabaseFactory.CreateDatabase("AppConNagar");
                DbCommand DBCmd = DB.GetStoredProcCommand("Search_tbl_CityMaster");
                DB.AddInParameter(DBCmd, "@SearchBy", DbType.String, Objtbl_CityMasterProp.SearchBy);
                DB.AddInParameter(DBCmd, "@SearchVal", DbType.String, Objtbl_CityMasterProp.SearchVal);
                return DB.ExecuteDataSet(DBCmd);
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
                Database DB = DatabaseFactory.CreateDatabase("AppConNagar");
                DbCommand DBCmd = DB.GetStoredProcCommand("SelectCombo_tbl_CityMaster");
                DB.AddInParameter(DBCmd, "@StateCode", DbType.String, Objtbl_CityMasterProp.StateCode);
                return DB.ExecuteDataSet(DBCmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
