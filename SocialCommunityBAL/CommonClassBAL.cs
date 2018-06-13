using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

using SocialCommunityProp;
using SocialCommunityDAL;

namespace SocialCommunityBAL
{
    public class CommonClassBAL
    {
        public DataSet Select_MenuList()
        {
            try
            {
                CommonClassDAL ObjCommonClassDAL = new CommonClassDAL();
                return ObjCommonClassDAL.Select_MenuList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
