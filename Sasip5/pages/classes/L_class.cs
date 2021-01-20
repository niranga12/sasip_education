using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Sasip5.pages.classes
{
    public class L_class
    {
        //get connection from web config file
        public static string cs = ConfigurationManager.ConnectionStrings["dbconn"].ToString();
        public int ID { get; set; }
        public int LID { get; set; }
        public int SubjectID { get; set; }


        public void Assign(L_class lc)
        {
            string sql = "UPDATE Subject SET L_ID='"+lc.LID+"' where ID='" + lc.SubjectID + "'";
            Shared share = new Shared();
            share.ExecuteQuery(sql);
        }

        public void UnAssign(L_class lc)
        {
            string sql = "UPDATE Subject SET L_ID=null where ID='"+lc.SubjectID + "'";
            Shared share = new Shared();
            share.ExecuteQuery(sql);
        }
    }


}