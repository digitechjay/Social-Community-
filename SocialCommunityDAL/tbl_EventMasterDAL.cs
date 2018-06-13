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
    public class tbl_EventMasterDAL
    {
        public int InsertUpdate_Data(tbl_EventMasterProp Objtbl_EventMasterProp)
        {
            try
            {
                Database DB = DatabaseFactory.CreateDatabase("AppConNagar");
                DbCommand DBCmd = DB.GetStoredProcCommand("InsertUpdate_tbl_EventMaster");
                DB.AddInParameter(DBCmd, "@EventCode", DbType.Int32, Objtbl_EventMasterProp.EventCode);
                DB.AddInParameter(DBCmd, "@EventName", DbType.String, Objtbl_EventMasterProp.EventName);
                DB.AddInParameter(DBCmd, "@EventStartDate", DbType.DateTime, Objtbl_EventMasterProp.EventStartDate);
                DB.AddInParameter(DBCmd, "@EventEndDate", DbType.DateTime, Objtbl_EventMasterProp.EventEndDate);
                DB.AddInParameter(DBCmd, "@EventDescription", DbType.String, Objtbl_EventMasterProp.EventDescription);
                DB.AddInParameter(DBCmd, "@Charges", DbType.Int32, Objtbl_EventMasterProp.Charges);
                DB.AddInParameter(DBCmd, "@FilePath", DbType.String, Objtbl_EventMasterProp.FilePath);
                DB.AddOutParameter(DBCmd, "@RetVal", DbType.Int32, 18);
                DB.ExecuteNonQuery(DBCmd);
                return Convert.ToInt32(DBCmd.Parameters["@RetVal"].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete_Data(tbl_EventMasterProp Objtbl_EventMasterProp)
        {
            try
            {
                Database DB = DatabaseFactory.CreateDatabase("AppConNagar");
                DbCommand DBCmd = DB.GetStoredProcCommand("Delete_tbl_EventMaster");
                DB.AddInParameter(DBCmd, "@EventCode", DbType.Int32, Objtbl_EventMasterProp.EventCode);
                return DB.ExecuteNonQuery(DBCmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_Data(tbl_EventMasterProp Objtbl_EventMasterProp, ref int TotalCount)
        {
            try
            {
                Database DB = DatabaseFactory.CreateDatabase("AppConNagar");
                DbCommand DBCmd = DB.GetStoredProcCommand("Select_tbl_EventMaster");
                DB.AddInParameter(DBCmd, "@EventCode", DbType.Int32, Objtbl_EventMasterProp.EventCode);
                DB.AddInParameter(DBCmd, "@PageNo", DbType.Int32, Objtbl_EventMasterProp.PageNo);
                DB.AddInParameter(DBCmd, "@RecordCount", DbType.Int32, Objtbl_EventMasterProp.RecordCount);
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

        public DataSet Search_Data(tbl_EventMasterProp Objtbl_EventMasterProp)
        {
            try
            {
                Database DB = DatabaseFactory.CreateDatabase("AppConNagar");
                DbCommand DBCmd = DB.GetStoredProcCommand("Search_tbl_EventMaster");
                DB.AddInParameter(DBCmd, "@SearchBy", DbType.String, Objtbl_EventMasterProp.SearchBy);
                DB.AddInParameter(DBCmd, "@SearchVal", DbType.String, Objtbl_EventMasterProp.SearchVal);
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
                DbCommand DBCmd = DB.GetStoredProcCommand("SelectCombo_tbl_EventMaster");
                return DB.ExecuteDataSet(DBCmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
