using System;
namespace SocialCommunityProp
{
public class tbl_NewsMasterProp
{
private int _NewsCode;
public int NewsCode
{
get { return _NewsCode; }
set { _NewsCode = value; }
}
private string _NewsHead;
public string NewsHead
{
get { return _NewsHead; }
set { _NewsHead = value; }
}
private string _NewsDescription;
public string NewsDescription
{
get { return _NewsDescription; }
set { _NewsDescription = value; }
}
private string _PhotoPath;
public string PhotoPath
{
get { return _PhotoPath; }
set { _PhotoPath = value; }
}
private DateTime _CreatedDate;
public DateTime CreatedDate
{
get { return _CreatedDate; }
set { _CreatedDate = value; }
}
private bool _isActive;
public bool isActive
{
get { return _isActive; }
set { _isActive = value; }
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
