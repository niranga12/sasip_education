using Sasip5.pages.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sasip5.pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                Login_check();
            }
            catch (Exception)
            {

                throw;
            }
                
        }


        public void Login_check()
        {

            string sql = "SELECT E_id, Name, E_type, User_name, Password, About, Date FROM users where User_name='"+txt_ID.Text+"' and Password='"+txt_pass.Text+"'";

            Shared gd = new Shared();

            if (gd.getdata(sql).Tables[0].Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "LoginFail();", true);
            }
            else
            {
                Session["EType"] = gd.getdata(sql).Tables[0].Rows[0]["E_type"].ToString();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);
            }

        }
    }
}