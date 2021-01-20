using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sasip5.pages.classes
{
    public class Student
    {
        public int S_id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Branch { get; set; }
        public string Mobile { get; set; }
        public string User_name { get; set; }
        public string Password { get; set; }
        public string About { get; set; }
        public string Date { get; set; }
        public int Age { get; set; }

        public void SaveUser(Student std)
        {
            string sql = "INSERT INTO students(Name, Address, Branch, Mobile, U_name, Pass, About, Date,Age) VALUES ('"+std.Name+ "','" + std.Address+ "','" + std.Branch+ "','" + std.Mobile+ "','" + std.User_name+ "','" + std.Password+ "','" + std.About+ "','" + std.Date+ "','"+std.Age+"')";
            Shared share = new Shared();
            share.ExecuteQuery(sql);
        }

        public void DeleteUser(Student std)
        {
            string sql = "DELETE FROM students where S_id='" + std.S_id + "'";
            Shared share = new Shared();
            share.ExecuteQuery(sql);
        }

        public void UpdateUser(Student std)
        {
            string sql = "UPDATE students SET Name ='" + std.Name + "', Address ='" + std.Address + "', Branch ='" + std.Branch + "', Age ='" + std.Age + "', Mobile ='" + std.Mobile + "', U_name ='" + std.User_name + "', Pass ='" + std.Password + "', About ='" + std.About + "' where S_id='" + std.S_id + "'";
            Shared share = new Shared();
            share.ExecuteQuery(sql);
        }
    }
}