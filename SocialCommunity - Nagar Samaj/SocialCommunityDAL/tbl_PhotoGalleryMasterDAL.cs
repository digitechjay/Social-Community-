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
public class tbl_PhotoGalleryMasterDAL
{
public int InsertUpdate_Data(tbl_PhotoGalleryMasterProp Objtbl_PhotoGalleryMasterProp)
{
try {
Database DB = DatabaseFactory.CreateDatabase("AppConNagar");
DbCommand DBCmd = DB.GetStoredProcCommand("InsertUpdate_tbl_PhotoGalleryMaster");
DB.AddInParameter(DBCmd, "@PhotoCode", DbType.Int32, Objtbl_PhotoGalleryMasterProp.PhotoCode);
DB.AddInParameter(DBCmd, "@PhotoHead", DbType.String, Objtbl_PhotoGalleryMasterProp.PhotoHead);
DB.AddInParameter(DBCmd, "@FileName", DbType.String, Objtbl_PhotoGalleryMasterProp.FileName);
DB.AddInParameter(DBCmd, "@AlbumCode", DbType.Int32, Objtbl_PhotoGalleryMasterProp.AlbumCode);
DB.AddInParameter(DBCmd, "@isVideo", DbType.Boolean, Objtbl_PhotoGalleryMasterProp.isVideo);
DB.AddOutParameter(DBCmd, "@RetVal", DbType.Int32, 18);
DB.ExecuteNonQuery(DBCmd);
return Convert.ToInt32(DBCmd.Parameters["@RetVal"].Value);
}
catch (Exception ex) 
{
throw ex;
}
}
public int Delete_Data(tbl_PhotoGalleryMasterProp Objtbl_PhotoGalleryMasterProp)
{
try {
Database DB = DatabaseFactory.CreateDatabase("AppConNagar");
DbCommand DBCmd = DB.GetStoredProcCommand("Delete_tbl_PhotoGalleryMaster");
DB.AddInParameter(DBCmd, "@PhotoCode", DbType.Int32, Objtbl_PhotoGalleryMasterProp.PhotoCode);
return DB.ExecuteNonQuery(DBCmd);
}
catch (Exception ex) 
{
throw ex;
}
}
public DataSet Select_Data(tbl_PhotoGalleryMasterProp Objtbl_PhotoGalleryMasterProp, ref int TotalCount)
{
try {
Database DB = DatabaseFactory.CreateDatabase("AppConNagar");
DbCommand DBCmd = DB.GetStoredProcCommand("Select_tbl_PhotoGalleryMaster");
DB.AddInParameter(DBCmd, "@PhotoCode", DbType.Int32, Objtbl_PhotoGalleryMasterProp.PhotoCode);
DB.AddInParameter(DBCmd, "@PageNo", DbType.Int32, Objtbl_PhotoGalleryMasterProp.PageNo);
DB.AddInParameter(DBCmd, "@RecordCount", DbType.Int32, Objtbl_PhotoGalleryMasterProp.RecordCount);
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
public DataSet Search_Data(tbl_PhotoGalleryMasterProp Objtbl_PhotoGalleryMasterProp)
{
try {
Database DB = DatabaseFactory.CreateDatabase("AppConNagar");
DbCommand DBCmd = DB.GetStoredProcCommand("Search_tbl_PhotoGalleryMaster");
DB.AddInParameter(DBCmd, "@SearchBy", DbType.String, Objtbl_PhotoGalleryMasterProp.SearchBy);
DB.AddInParameter(DBCmd, "@SearchVal", DbType.String, Objtbl_PhotoGalleryMasterProp.SearchVal);
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
DbCommand DBCmd = DB.GetStoredProcCommand("SelectCombo_tbl_PhotoGalleryMaster");
return DB.ExecuteDataSet(DBCmd);
}
catch (Exception ex) 
{
throw ex;
}
}
}
}
