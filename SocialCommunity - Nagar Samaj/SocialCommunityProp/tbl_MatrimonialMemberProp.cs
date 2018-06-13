using System;
namespace SocialCommunityProp
{
    public class tbl_MatrimonialMemberProp
    {
        private int _MemberCode;
        public int MemberCode
        {
            get { return _MemberCode; }
            set { _MemberCode = value; }
        }
        private string _MemberName;
        public string MemberName
        {
            get { return _MemberName; }
            set { _MemberName = value; }
        }
        private DateTime _DOB;
        public DateTime DOB
        {
            get { return _DOB; }
            set { _DOB = value; }
        }
        private int _Gender;
        public int Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }
        private string _Gotra;
        public string Gotra
        {
            get { return _Gotra; }
            set { _Gotra = value; }
        }
        private int _LivingIn;
        public int LivingIn
        {
            get { return _LivingIn; }
            set { _LivingIn = value; }
        }
        private string _EmailID;
        public string EmailID
        {
            get { return _EmailID; }
            set { _EmailID = value; }
        }
        private string _ContactNo;
        public string ContactNo
        {
            get { return _ContactNo; }
            set { _ContactNo = value; }
        }
        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        private string _MemberPhoto;
        public string MemberPhoto
        {
            get { return _MemberPhoto; }
            set { _MemberPhoto = value; }
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
