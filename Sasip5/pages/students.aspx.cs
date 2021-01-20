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
    public partial class students : System.Web.UI.Page
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

        //data Load to Grid view
        public void DataLoad()
        {

            using (SqlConnection con = new SqlConnection(cs))
            {
                string sql = "select * from students";

                Shared gd = new Shared();
                dgvItems.DataSource = gd.getdata(sql).Tables[0];

                //Bind the fetched data to gridview           
                dgvItems.DataBind();

            }
        }

        //register new student
        protected void btn_re_new_Click(object sender, EventArgs e)
        {
           
            Student std = new Student();
            std.Name = txt_name.Text;
            std.Address = txt_address.Text;
            std.Branch = drop_branch.SelectedItem.ToString();
            std.Mobile = txt_mobile.Text;
            std.User_name = txt_uname.Text;
            std.Password = txt_pass.Text;
            std.About = txt_about.Text;
            std.Date = DateTime.Now.ToString();
            std.Age = Convert.ToInt32(txt_age.Text);

            std.SaveUser(std);

            DataLoad();

            clear_form();
        }

        //clear the form
        private void clear_form()
        {
            txt_id.Text =txt_age.Text =txt_name.Text = txt_address.Text = txt_mobile.Text = txt_uname.Text = txt_pass.Text = txt_about.Text = hidden_id.Text ="";
            drop_branch.Text = "Select Branch";
        }

        //update student details
        protected void btn_update_Click(object sender, EventArgs e)
        {
            Student std = new Student();
            try
            {
                std.S_id = Convert.ToInt32(txt_id.Text);
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Student Selection Failed", "alert('Please Select a Student First..')", true);
            }
            std.Name = txt_name.Text;
            std.Address = txt_address.Text;
            std.Branch = drop_branch.SelectedItem.ToString();
            std.Mobile = txt_mobile.Text;
            std.User_name = txt_uname.Text;
            std.Password = txt_pass.Text;
            std.About = txt_about.Text;
            std.Date = DateTime.Now.ToString();
            std.Age = Convert.ToInt32(txt_age.Text);

            std.UpdateUser(std);

            DataLoad();

            clear_form();
        }

        //clear button
        protected void btn_clear_Click(object sender, EventArgs e)
        {
            clear_form();
        }

        //search student button
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            SearchUser();
        }

        public void SearchUser()
        {

            string sql = "select * from students where Name like '" + txt_search.Text + "%'";

            Shared gd = new Shared();
            dgvItems.DataSource = gd.getdata(sql).Tables[0];

            //Bind the fetched data to gridview
            dgvItems.DataBind();

        }

        //Gride view select method
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
                txt_age.Text = dgvItems.SelectedRow.Cells[6].Text;
                drop_branch.Text = dgvItems.SelectedRow.Cells[7].Text;
                txt_mobile.Text = dgvItems.SelectedRow.Cells[8].Text.Replace("&nbsp;", " ");
                txt_uname.Text = dgvItems.SelectedRow.Cells[9].Text;
                txt_pass.Text = dgvItems.SelectedRow.Cells[10].Text;
                txt_about.Text = dgvItems.SelectedRow.Cells[11].Text.Replace("&nbsp;", " ");

                txt_del_name.Text = "Delete User -->" + txt_id.Text + " " + txt_name.Text;
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

        //grid view reset button for search function
        protected void btnReset_Click1(object sender, EventArgs e)
        {
            DataLoad();
            txt_search.Text = string.Empty;
        }

        //delete record
        protected void btn_delete_yes_Click(object sender, EventArgs e)
        {
            Student std = new Student();
            try
            {
                std.S_id = Int32.Parse(hidden_id.Text);
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Student Selection Failed", "alert('Please Select a Student First..')", true);
            }
            
            std.DeleteUser(std);
            DataLoad();
        }
    }
}