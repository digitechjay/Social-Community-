using System;
namespace SocialCommunityProp
{
public class tbl_FeedbackMasterProp
{
private int _MessageCode;
public int MessageCode
{
get { return _MessageCode; }
set { _MessageCode = value; }
}
private string _MessageDescription;
public string MessageDescription
{
get { return _MessageDescription; }
set { _MessageDescription = value; }
}
private DateTime _MessageCreatedDate;
public DateTime MessageCreatedDate
{
get { return _MessageCreatedDate; }
set { _MessageCreatedDate = value; }
}
private int _MemberCode;
public int MemberCode
{
get { return _MemberCode; }
set { _MemberCode = value; }
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
