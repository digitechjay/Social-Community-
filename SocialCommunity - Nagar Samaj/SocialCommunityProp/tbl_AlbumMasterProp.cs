using System;
namespace SocialCommunityProp
{
public class tbl_AlbumMasterProp
{
private int _AlbumCode;
public int AlbumCode
{
get { return _AlbumCode; }
set { _AlbumCode = value; }
}
private string _AlbumName;
public string AlbumName
{
get { return _AlbumName; }
set { _AlbumName = value; }
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
