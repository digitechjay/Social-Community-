using System;
namespace SocialCommunityProp
{
public class tbl_EventMasterProp
{
private int _EventCode;
public int EventCode
{
get { return _EventCode; }
set { _EventCode = value; }
}
private string _EventName;
public string EventName
{
get { return _EventName; }
set { _EventName = value; }
}
private DateTime _EventStartDate;
public DateTime EventStartDate
{
get { return _EventStartDate; }
set { _EventStartDate = value; }
}
private DateTime _EventEndDate;
public DateTime EventEndDate
{
get { return _EventEndDate; }
set { _EventEndDate = value; }
}
private string _EventDescription;
public string EventDescription
{
get { return _EventDescription; }
set { _EventDescription = value; }
}
private double _Charges;
public double Charges
{
get { return _Charges; }
set { _Charges = value; }
}
private string _FilePath;
public string FilePath
{
get { return _FilePath; }
set { _FilePath = value; }
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
