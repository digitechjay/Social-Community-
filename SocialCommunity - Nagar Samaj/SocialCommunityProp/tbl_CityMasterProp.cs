using System;
namespace SocialCommunityProp
{
public class tbl_CityMasterProp
{
private int _CityCode;
public int CityCode
{
get { return _CityCode; }
set { _CityCode = value; }
}
private string _CityName;
public string CityName
{
get { return _CityName; }
set { _CityName = value; }
}
private int _StateCode;
public int StateCode
{
get { return _StateCode; }
set { _StateCode = value; }
}
private string _SearchBy;
public string SearchBy
{
get { return _SearchBy; }
set { _SearchBy = value; }
}
private string _SearchVal;
public string SearchVal
{
get { return _SearchVal; }
set { _SearchVal = value; }
}
private int _PageNo;
public int PageNo
{
get { return _PageNo; }
set { _PageNo = value; }
}
private int _RecordCount;
public int RecordCount
{
get { return _RecordCount; }
set { _RecordCount = value; }
}
}
}
