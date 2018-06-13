using System;
namespace SocialCommunityProp
{
public class tbl_CountryMasterProp
{
private int _CountryCode;
public int CountryCode
{
get { return _CountryCode; }
set { _CountryCode = value; }
}
private string _CountryName;
public string CountryName
{
get { return _CountryName; }
set { _CountryName = value; }
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
