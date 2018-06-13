using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data.Common;

using SocialCommunityProp;

namespace SocialCommunityDAL
{
    public class CommonClassDAL
    {
        public DataSet Select_MenuList()
        {
            try
            {
                Database DB = DatabaseFactory.CreateDatabase("AppConNagar");
                DbCommand DBCmd = DB.GetStoredProcCommand("Select_MenuList");
                DataSet dsData = DB.ExecuteDataSet(DBCmd);
                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
