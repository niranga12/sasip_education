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
    public class S_class
    {
        //get connection from web config file
        public static string cs = ConfigurationManager.ConnectionStrings["dbconn"].ToString();
        public int ID { get; set; }
        public int StudentID { get; set; }
        public int SubjectID { get; set; }
        public string Date { get; set; }

        public void Assign(S_class sc)
        {
            string sql = "INSERT INTO Stu_Sub(Stu_ID, Sub_ID, Date) VALUES ('" + sc.StudentID+"','"+sc.SubjectID+"','"+sc.Date+"')";
            Shared share = new Shared();
            share.ExecuteQuery(sql);
        }

        public void Update(S_class sc)
        {
            string sql = "UPDATE Stu_Sub SET Sub_ID='"+sc.SubjectID+"', Date='"+sc.Date+"' where ID='" + sc.ID+"'";
            Shared share = new Shared();
            share.ExecuteQuery(sql);
        }

        public void Delete(S_class sc)
        {
            string sql = "DELETE FROM Stu_Sub where ID='"+sc.ID+"'";
            Shared share = new Shared();
            share.ExecuteQuery(sql);
        }
    }


}