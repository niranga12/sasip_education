using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sasip5.pages.classes
{
    public class User
    {
        public int U_id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Branch { get; set; }

        public string E_type { get; set; }
        public string Mobile { get; set; }
        public string User_name { get; set; }
        public string Password { get; set; }
        public string About { get; set; }
        public string Date { get; set; }
        
        //Save User
        public void SaveUser(User user)
        {
            string sql = "insert into users (Name,Address,Branch,E_type,Mobile,User_name,Password,About,Date) values ('" + user.Name + "' ,'" + user.Address + "' ,'" + user.Branch + "','" + user.E_type + "','" + user.Mobile + "','" + user.User_name + "','" + user.Password + "','" + user.About + "','" + user.Date + "')";
            Shared share = new Shared();
            share.ExecuteQuery(sql);
        }
        //DeleteUser
        public void DeleteUser(User user)
        {
            string sql = "DELETE FROM users where E_id='"+user.U_id+"'";
            Shared share = new Shared();
            share.ExecuteQuery(sql);
        }
        //Update user
        public void UpdateUser(User user)
        {
            string sql = "UPDATE users SET Name ='"+user.Name+ "', Address ='" + user.Address+ "', Branch ='" + user.Branch+ "', E_type ='" + user.E_type+ "', Mobile ='" + user.Mobile+ "', User_name ='" + user.User_name+ "', Password ='" + user.Password+ "', About ='" + user.About+ "' where E_id='" + user.U_id + "'";
            Shared share = new Shared();
            share.ExecuteQuery(sql);
        }
    }
}