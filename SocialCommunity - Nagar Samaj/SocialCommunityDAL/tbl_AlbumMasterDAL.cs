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
public class tbl_AlbumMasterDAL
{
public int InsertUpdate_Data(tbl_AlbumMasterProp Objtbl_AlbumMasterProp)
{
try {
Database DB = DatabaseFactory.CreateDatabase("AppConNagar");
DbCommand DBCmd = DB.GetStoredProcCommand("InsertUpdate_tbl_AlbumMaster");
DB.AddInParameter(DBCmd, "@AlbumCode", DbType.Int32, Objtbl_AlbumMasterProp.AlbumCode);
DB.AddInParameter(DBCmd, "@AlbumName", DbType.String, Objtbl_AlbumMasterProp.AlbumName);
DB.AddOutParameter(DBCmd, "@RetVal", DbType.Int32, 18);
DB.ExecuteNonQuery(DBCmd);
return Convert.ToInt32(DBCmd.Parameters["@RetVal"].Value);
}
catch (Exception ex) 
{
throw ex;
}
}
public int Delete_Data(tbl_AlbumMasterProp Objtbl_AlbumMasterProp)
{
try {
Database DB = DatabaseFactory.CreateDatabase("AppConNagar");
DbCommand DBCmd = DB.GetStoredProcCommand("Delete_tbl_AlbumMaster");
DB.AddInParameter(DBCmd, "@AlbumCode", DbType.Int32, Objtbl_AlbumMasterProp.AlbumCode);
return DB.ExecuteNonQuery(DBCmd);
}
catch (Exception ex) 
{
throw ex;
}
}
public DataSet Select_Data(tbl_AlbumMasterProp Objtbl_AlbumMasterProp, ref int TotalCount)
{
try {
Database DB = DatabaseFactory.CreateDatabase("AppConNagar");
DbCommand DBCmd = DB.GetStoredProcCommand("Select_tbl_AlbumMaster");
DB.AddInParameter(DBCmd, "@AlbumCode", DbType.Int32, Objtbl_AlbumMasterProp.AlbumCode);
DB.AddInParameter(DBCmd, "@PageNo", DbType.Int32, Objtbl_AlbumMasterProp.PageNo);
DB.AddInParameter(DBCmd, "@RecordCount", DbType.Int32, Objtbl_AlbumMasterProp.RecordCount);
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
public DataSet Search_Data(tbl_AlbumMasterProp Objtbl_AlbumMasterProp)
{
try {
Database DB = DatabaseFactory.CreateDatabase("AppConNagar");
DbCommand DBCmd = DB.GetStoredProcCommand("Search_tbl_AlbumMaster");
DB.AddInParameter(DBCmd, "@SearchBy", DbType.String, Objtbl_AlbumMasterProp.SearchBy);
DB.AddInParameter(DBCmd, "@SearchVal", DbType.String, Objtbl_AlbumMasterProp.SearchVal);
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
DbCommand DBCmd = DB.GetStoredProcCommand("SelectCombo_tbl_AlbumMaster");
return DB.ExecuteDataSet(DBCmd);
}
catch (Exception ex) 
{
throw ex;
}
}
}
}
