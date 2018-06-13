using System;
namespace SocialCommunityProp
{
    public class tbl_MemberMasterProp
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

        private string _CurrentAddress;
        public string CurrentAddress
        {
            get { return _CurrentAddress; }
            set { _CurrentAddress = value; }
        }

        private int _CountryCode;
        public int CountryCode
        {
            get { return _CountryCode; }
            set { _CountryCode = value; }
        }

        private int _StateCode;
        public int StateCode
        {
            get { return _StateCode; }
            set { _StateCode = value; }
        }

        private int _CityCode;
        public int CityCode
        {
            get { return _CityCode; }
            set { _CityCode = value; }
        }

        private string _PermanentAddress;
        public string PermanentAddress
        {
            get { return _PermanentAddress; }
            set { _PermanentAddress = value; }
        }

        private string _ContactNo;
        public string ContactNo
        {
            get { return _ContactNo; }
            set { _ContactNo = value; }
        }

        private string _EmailID;
        public string EmailID
        {
            get { return _EmailID; }
            set { _EmailID = value; }
        }

        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        private DateTime _DOB;
        public DateTime DOB
        {
            get { return _DOB; }
            set { _DOB = value; }
        }

        private int _QualificationCode;
        public int QualificationCode
        {
            get { return _QualificationCode; }
            set { _QualificationCode = value; }
        }

        private int _OccupationCode;
        public int OccupationCode
        {
            get { return _OccupationCode; }
            set { _OccupationCode = value; }
        }

        private int _MaritalStatusCode;
        public int MaritalStatusCode
        {
            get { return _MaritalStatusCode; }
            set { _MaritalStatusCode = value; }
        }

        private bool _Gender;
        public bool Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }

        private int _NativePlaceCode;
        public int NativePlaceCode
        {
            get { return _NativePlaceCode; }
            set { _NativePlaceCode = value; }
        }

        private int _NationalityCode;
        public int NationalityCode
        {
            get { return _NationalityCode; }
            set { _NationalityCode = value; }
        }

        private int _PhysicalChallangedCode;
        public int PhysicalChallangedCode
        {
            get { return _PhysicalChallangedCode; }
            set { _PhysicalChallangedCode = value; }
        }

        private int _RelationshipCode;
        public int RelationshipCode
        {
            get { return _RelationshipCode; }
            set { _RelationshipCode = value; }
        }

        private int _ParentCode;
        public int ParentCode
        {
            get { return _ParentCode; }
            set { _ParentCode = value; }
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

        private string _PhotoPath;
        public string PhotoPath
        {
            get { return _PhotoPath; }
            set { _PhotoPath = value; }
        }
    }
}
