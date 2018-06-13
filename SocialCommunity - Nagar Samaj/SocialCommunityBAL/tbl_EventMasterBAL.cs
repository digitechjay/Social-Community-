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
public class tbl_EventMasterBAL
{
public int InsertUpdate_Data(tbl_EventMasterProp Objtbl_EventMasterProp)
{
try {
tbl_EventMasterDAL Objtbl_EventMasterDAL = new tbl_EventMasterDAL();
return Objtbl_EventMasterDAL.InsertUpdate_Data(Objtbl_EventMasterProp);
}
catch (Exception ex) 
{
throw ex;
}
}
public int Delete_Data(tbl_EventMasterProp Objtbl_EventMasterProp)
{
try {
tbl_EventMasterDAL Objtbl_EventMasterDAL = new tbl_EventMasterDAL();
return Objtbl_EventMasterDAL.Delete_Data(Objtbl_EventMasterProp);
}
catch (Exception ex) 
{
throw ex;
}
}
public DataSet Select_Data(tbl_EventMasterProp Objtbl_EventMasterProp, ref int PageCount)
{
try {
if (Objtbl_EventMasterProp.EventCode!= 0)
{
Objtbl_EventMasterProp.PageNo = 1;
Objtbl_EventMasterProp.RecordCount = 1;
}
int RecordCount = 0;
tbl_EventMasterDAL Objtbl_EventMasterDAL = new tbl_EventMasterDAL();
DataSet dsData =  Objtbl_EventMasterDAL.Select_Data(Objtbl_EventMasterProp, ref RecordCount);
double Page = Convert.ToDouble(RecordCount) / Convert.ToDouble(Objtbl_EventMasterProp.RecordCount);
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
public DataSet Search_Data(tbl_EventMasterProp Objtbl_EventMasterProp)
{
try {
tbl_EventMasterDAL Objtbl_EventMasterDAL = new tbl_EventMasterDAL();
return Objtbl_EventMasterDAL.Search_Data(Objtbl_EventMasterProp);
}
catch (Exception ex) 
{
throw ex;
}
}
public DataSet SelectCombo_Data()
{
try {
tbl_EventMasterDAL Objtbl_EventMasterDAL = new tbl_EventMasterDAL();
return Objtbl_EventMasterDAL.SelectCombo_Data();
}
catch (Exception ex) 
{
throw ex;
}
}
}
}
