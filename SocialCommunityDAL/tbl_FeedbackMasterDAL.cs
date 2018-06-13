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
public class tbl_FeedbackMasterDAL
{
public int InsertUpdate_Data(tbl_FeedbackMasterProp Objtbl_FeedbackMasterProp)
{
try {
Database DB = DatabaseFactory.CreateDatabase("AppConNagar");
DbCommand DBCmd = DB.GetStoredProcCommand("InsertUpdate_tbl_FeedbackMaster");
DB.AddInParameter(DBCmd, "@MessageCode", DbType.Int32, Objtbl_FeedbackMasterProp.MessageCode);
DB.AddInParameter(DBCmd, "@MessageDescription", DbType.String, Objtbl_FeedbackMasterProp.MessageDescription);
DB.AddInParameter(DBCmd, "@MessageCreatedDate", DbType.DateTime, Objtbl_FeedbackMasterProp.MessageCreatedDate);
DB.AddInParameter(DBCmd, "@MemberCode", DbType.Int32, Objtbl_FeedbackMasterProp.MemberCode);
DB.AddOutParameter(DBCmd, "@RetVal", DbType.Int32, 18);
DB.ExecuteNonQuery(DBCmd);
return Convert.ToInt32(DBCmd.Parameters["@RetVal"].Value);
}
catch (Exception ex) 
{
throw ex;
}
}
public int Delete_Data(tbl_FeedbackMasterProp Objtbl_FeedbackMasterProp)
{
try {
Database DB = DatabaseFactory.CreateDatabase("AppConNagar");
DbCommand DBCmd = DB.GetStoredProcCommand("Delete_tbl_FeedbackMaster");
DB.AddInParameter(DBCmd, "@MessageCode", DbType.Int32, Objtbl_FeedbackMasterProp.MessageCode);
return DB.ExecuteNonQuery(DBCmd);
}
catch (Exception ex) 
{
throw ex;
}
}
public DataSet Select_Data(tbl_FeedbackMasterProp Objtbl_FeedbackMasterProp, ref int TotalCount)
{
try {
Database DB = DatabaseFactory.CreateDatabase("AppConNagar");
DbCommand DBCmd = DB.GetStoredProcCommand("Select_tbl_FeedbackMaster");
DB.AddInParameter(DBCmd, "@MessageCode", DbType.Int32, Objtbl_FeedbackMasterProp.MessageCode);
DB.AddInParameter(DBCmd, "@PageNo", DbType.Int32, Objtbl_FeedbackMasterProp.PageNo);
DB.AddInParameter(DBCmd, "@RecordCount", DbType.Int32, Objtbl_FeedbackMasterProp.RecordCount);
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
public DataSet Search_Data(tbl_FeedbackMasterProp Objtbl_FeedbackMasterProp)
{
try {
Database DB = DatabaseFactory.CreateDatabase("AppConNagar");
DbCommand DBCmd = DB.GetStoredProcCommand("Search_tbl_FeedbackMaster");
DB.AddInParameter(DBCmd, "@SearchBy", DbType.String, Objtbl_FeedbackMasterProp.SearchBy);
DB.AddInParameter(DBCmd, "@SearchVal", DbType.String, Objtbl_FeedbackMasterProp.SearchVal);
return DB.ExecuteDataSet(DBCmd);
}
catch (Exception ex) 
{
throw ex;
}
}
public DataSet SelectCombo_Data()
{
try {
Database DB = DatabaseFactory.CreateDatabase("AppConNagar");
DbCommand DBCmd = DB.GetStoredProcCommand("SelectCombo_tbl_FeedbackMaster");
return DB.ExecuteDataSet(DBCmd);
}
catch (Exception ex) 
{
throw ex;
}
}
}
}
