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
public class tbl_NewsMasterDAL
{
public int InsertUpdate_Data(tbl_NewsMasterProp Objtbl_NewsMasterProp)
{
try {
Database DB = DatabaseFactory.CreateDatabase("AppConNagar");
DbCommand DBCmd = DB.GetStoredProcCommand("InsertUpdate_tbl_NewsMaster");
DB.AddInParameter(DBCmd, "@NewsCode", DbType.Int32, Objtbl_NewsMasterProp.NewsCode);
DB.AddInParameter(DBCmd, "@NewsHead", DbType.String, Objtbl_NewsMasterProp.NewsHead);
DB.AddInParameter(DBCmd, "@NewsDescription", DbType.String, Objtbl_NewsMasterProp.NewsDescription);
DB.AddInParameter(DBCmd, "@PhotoPath", DbType.String, Objtbl_NewsMasterProp.PhotoPath);
DB.AddInParameter(DBCmd, "@CreatedDate", DbType.DateTime, Objtbl_NewsMasterProp.CreatedDate);
DB.AddInParameter(DBCmd, "@isActive", DbType.Boolean, Objtbl_NewsMasterProp.isActive);
DB.AddOutParameter(DBCmd, "@RetVal", DbType.Int32, 18);
DB.ExecuteNonQuery(DBCmd);
return Convert.ToInt32(DBCmd.Parameters["@RetVal"].Value);
}
catch (Exception ex) 
{
throw ex;
}
}
public int Delete_Data(tbl_NewsMasterProp Objtbl_NewsMasterProp)
{
try {
Database DB = DatabaseFactory.CreateDatabase("AppConNagar");
DbCommand DBCmd = DB.GetStoredProcCommand("Delete_tbl_NewsMaster");
DB.AddInParameter(DBCmd, "@NewsCode", DbType.Int32, Objtbl_NewsMasterProp.NewsCode);
return DB.ExecuteNonQuery(DBCmd);
}
catch (Exception ex) 
{
throw ex;
}
}
public DataSet Select_Data(tbl_NewsMasterProp Objtbl_NewsMasterProp, ref int TotalCount)
{
try {
Database DB = DatabaseFactory.CreateDatabase("AppConNagar");
DbCommand DBCmd = DB.GetStoredProcCommand("Select_tbl_NewsMaster");
DB.AddInParameter(DBCmd, "@NewsCode", DbType.Int32, Objtbl_NewsMasterProp.NewsCode);
DB.AddInParameter(DBCmd, "@PageNo", DbType.Int32, Objtbl_NewsMasterProp.PageNo);
DB.AddInParameter(DBCmd, "@RecordCount", DbType.Int32, Objtbl_NewsMasterProp.RecordCount);
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
public DataSet Search_Data(tbl_NewsMasterProp Objtbl_NewsMasterProp)
{
try {
Database DB = DatabaseFactory.CreateDatabase("AppConNagar");
DbCommand DBCmd = DB.GetStoredProcCommand("Search_tbl_NewsMaster");
DB.AddInParameter(DBCmd, "@SearchBy", DbType.String, Objtbl_NewsMasterProp.SearchBy);
DB.AddInParameter(DBCmd, "@SearchVal", DbType.String, Objtbl_NewsMasterProp.SearchVal);
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
DbCommand DBCmd = DB.GetStoredProcCommand("SelectCombo_tbl_NewsMaster");
return DB.ExecuteDataSet(DBCmd);
}
catch (Exception ex) 
{
throw ex;
}
}
}
}
