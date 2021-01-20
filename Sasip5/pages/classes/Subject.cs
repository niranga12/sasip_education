using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sasip5.pages.classes
{
    public class Subject
    {
        public int Id { get; set; }
        public int L_Id { get; set; }
        public string Name { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public decimal Fee { get; set; }
        public string Grade { get; set; }
        public string About { get; set; }
        public string Branch { get; set; }

        public void SaveSub(Subject sbd)
        {
            string sql = "INSERT INTO Subject(Name, Year, Month, Fee, Grade,About,Branch) VALUES ('" + sbd.Name + "','" + sbd.Year + "','" + sbd.Month + "','" + sbd.Fee + "','" + sbd.Grade + "','" + sbd.About + "','"+sbd.Branch+"')";
            Shared share = new Shared();
            share.ExecuteQuery(sql);
        }

        public void DeleteSub(Subject sbd)
        {
            string sql = "DELETE FROM Subject where ID='" + sbd.Id + "'";
            Shared share = new Shared();
            share.ExecuteQuery(sql);
        }

        public void UpdateSub(Subject sbd)
        {
              string sql = "UPDATE Subject SET Name ='" + sbd.Name + "', Year ='" + sbd.Year + "', Month ='" + sbd.Month + "', Fee ='" + sbd.Fee + "', Grade ='" + sbd.Grade + "', About ='" + sbd.About + "',Branch='"+sbd.Branch+"' where ID='" + sbd.Id + "'";
             Shared share = new Shared();
              share.ExecuteQuery(sql);
        }

        public void AssignLectures(Subject sbd)
        {
            string sql = "UPDATE Subject SET L_ID ='" + sbd.L_Id + "' where ID='" + sbd.Id + "'";
            Shared share = new Shared();
            share.ExecuteQuery(sql);
        }
    }
}