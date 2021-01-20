using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Sasip5.pages.classes;


namespace Sasip5.pages
{
    public partial class users : System.Web.UI.Page
    {
        //get connection from web config file
        public static string cs = ConfigurationManager.ConnectionStrings["dbconn"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EType"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                DataLoad();
            }

            //Check if have hidden ID's
            if (hidden_id.Text == "")
            {
                btn_re_new.Visible = true;
                btn_update.Visible = false;
                header_add.Visible = true;
                header_update.Visible = false;
            }
            else
            {
                btn_re_new.Visible = false;
                btn_update.Visible = true;
                header_add.Visible = false;
                header_update.Visible = true;
            }
            hidden_id.Visible = false;
        }

        //register new Users
        protected void btn_re_click(object sender, EventArgs e)
        {
            User usr = new User();
            usr.Name = txt_name.Text;
            usr.Address = txt_address.Text;
            usr.Branch = drop_branch.SelectedItem.ToString();
            usr.E_type = drop_etype.SelectedItem.ToString();
            usr.Mobile = txt_mobile.Text;
            usr.User_name = txt_uname.Text;
            usr.Password = txt_pass.Text;
            usr.About = txt_about.Text;
            usr.Date = DateTime.Now.ToString();

            usr.SaveUser(usr);

            DataLoad();

            clear_form();

            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);

        }

        protected void btn_edit_click(object sender, EventArgs e)
        {
            txt_id.Text = "1";
        }

        //Clear button method
        protected void btn_clear_click(object sender, EventArgs e)
        {
            clear_form();
            Response.Redirect("users.aspx");
        }

        //Clear method
        private void clear_form()
        {
            txt_id.Text = txt_name.Text = txt_address.Text = txt_mobile.Text = txt_uname.Text = txt_pass.Text = txt_about.Text =hidden_id.Text ="";

            drop_branch.ClearSelection();
            drop_etype.ClearSelection();
        }

        //when, Grid view selected, data load to form 
        protected void dgvItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                hidden_id.Visible = true;
                hidden_id.Text = dgvItems.SelectedRow.Cells[3].Text;
                DGVpanal.Visible = true;
               txt_id.Text = dgvItems.SelectedRow.Cells[3].Text;
               txt_name.Text = dgvItems.SelectedRow.Cells[4].Text;
                txt_address.Text = dgvItems.SelectedRow.Cells[5].Text;
                drop_branch.Text = dgvItems.SelectedRow.Cells[6].Text;
                drop_etype.Text = dgvItems.SelectedRow.Cells[7].Text;
                txt_mobile.Text = dgvItems.SelectedRow.Cells[8].Text.Replace("&nbsp;", " ");
                txt_uname.Text = dgvItems.SelectedRow.Cells[9].Text;
                txt_pass.Text = dgvItems.SelectedRow.Cells[10].Text;
                txt_about.Text = dgvItems.SelectedRow.Cells[11].Text.Replace("&nbsp;", " ");

                txt_del_name.Text = "Delete User -->"+txt_id.Text +" "+ txt_name.Text;
                if (hidden_id.Text == "")
                {
                    btn_re_new.Visible = true;
                    btn_update.Visible = false;
                    header_add.Visible = true;
                    header_update.Visible = false;
                }
                else
                {
                    btn_re_new.Visible = false;
                    btn_update.Visible = true;
                    header_add.Visible = false;
                    header_update.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        //Grid view search function
        public void SearchUser()
        {
            
            string sql = "select * from users where Name like '" + txt_search.Text + "%'";

            Shared gd = new Shared();
            dgvItems.DataSource = gd.getdata(sql).Tables[0];

            //Bind the fetched data to gridview
            dgvItems.DataBind();
                   
        }

        //Gridview search button's click
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            SearchUser();
        }

        //Gridview search text box auto search
        protected void Search_TextChanged(object sender, EventArgs e)
        {
            SearchUser();
        }

        //Gridview reset button
        protected void btnReset_Click1(object sender, EventArgs e)
        {
            DataLoad();
            txt_search.Text = string.Empty;
        }

        //Data load to grid view
        public void DataLoad()
        {

            using (SqlConnection con = new SqlConnection(cs))
            {            
                string sql = "select * from users";

                Shared gd = new Shared();
                dgvItems.DataSource = gd.getdata(sql).Tables[0];

                //Bind the fetched data to gridview           
                    dgvItems.DataBind();
            
            }
        }

      
        //Update user details
        protected void btn_update_Click(object sender, EventArgs e)
        {
            User usr = new User();     

            try
            {
              usr.U_id = Int32.Parse(hidden_id.Text);
            }
           catch (Exception)
             {
               ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "User Selection Failed", "alert('Please Select a User First..')", true);
            }
            usr.Name = txt_name.Text;
            usr.Address = txt_address.Text;
            usr.Branch = drop_branch.SelectedItem.ToString();
            usr.E_type = drop_etype.SelectedItem.ToString();
            usr.Mobile = txt_mobile.Text;
            usr.User_name = txt_uname.Text;
            usr.Password = txt_pass.Text;
            usr.About = txt_about.Text;
            usr.UpdateUser(usr);
            DataLoad();
            clear_form();
        }

        //Delete user function
        protected void btn_delete_yes_Click1(object sender, EventArgs e)
        {
            User usr = new User();
            try
            {
                usr.U_id = Int32.Parse(hidden_id.Text);
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "User Selection Failed", "alert('Please Select a User First..')", true);
            }
         
            usr.DeleteUser(usr);
            DataLoad();
            clear_form();
        }
    }
}