using System;
namespace SocialCommunityProp
{
public class tbl_PhotoGalleryMasterProp
{
private int _PhotoCode;
public int PhotoCode
{
get { return _PhotoCode; }
set { _PhotoCode = value; }
}
private string _PhotoHead;
public string PhotoHead
{
get { return _PhotoHead; }
set { _PhotoHead = value; }
}
private string _FileName;
public string FileName
{
get { return _FileName; }
set { _FileName = value; }
}
private int _AlbumCode;
public int AlbumCode
{
get { return _AlbumCode; }
set { _AlbumCode = value; }
}
private bool _isVideo;
public bool isVideo
{
get { return _isVideo; }
set { _isVideo = value; }
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
