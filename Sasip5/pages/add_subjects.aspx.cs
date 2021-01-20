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

    public partial class add_subjects : System.Web.UI.Page
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

        protected void btn_re_click(object sender, EventArgs e)
        {
            Subject sbd = new Subject();
            sbd.Name = txt_name.Text;
            sbd.Year = drop_year.SelectedItem.ToString();
            sbd.Month = drop_month.SelectedItem.ToString();
            sbd.Fee = Convert.ToDecimal(txt_fee.Text);
            sbd.Grade = drop_grade.SelectedItem.ToString();
            sbd.About = txt_about.Text;
            sbd.Branch = drop_branch.SelectedItem.Text;

            sbd.SaveSub(sbd);

            DataLoad();

            clear_form();
        }

        protected void btn_clear_click(object sender, EventArgs e)
        {
            clear_form();
        }

        private void clear_form()
        {
            txt_id.Text = txt_name.Text = txt_about.Text =hidden_id.Text= "";
            drop_year.Text = "Select Years";
            drop_month.Text = "Select Months";
            drop_grade.Text = "Select Grade";
            drop_branch.ClearSelection();
            txt_fee.Text = "";
            Response.Redirect("add_subjects.aspx");
        }

        protected void dgvItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                hidden_id.Visible = true;
                hidden_id.Text = dgvItems.SelectedRow.Cells[3].Text;
                DGVpanal.Visible = true;
                txt_id.Text = dgvItems.SelectedRow.Cells[3].Text;
                txt_name.Text = dgvItems.SelectedRow.Cells[4].Text;
                drop_branch.Text = dgvItems.SelectedRow.Cells[5].Text;
                drop_year.Text = dgvItems.SelectedRow.Cells[6].Text;
                drop_month.Text = dgvItems.SelectedRow.Cells[7].Text;
                drop_grade.Text = dgvItems.SelectedRow.Cells[8].Text;
                txt_fee.Text = dgvItems.SelectedRow.Cells[9].Text;
                txt_about.Text = dgvItems.SelectedRow.Cells[10].Text;

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

        public void SearchUser()
        {
            string sql = "select * from Subject where Name like '" + txt_search.Text + "%'";

            Shared gd = new Shared();
            dgvItems.DataSource = gd.getdata(sql).Tables[0];

            //Bind the fetched data to gridview
            dgvItems.DataBind();
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            SearchUser();
        }

        protected void btnReset_Click1(object sender, EventArgs e)
        {
            DataLoad();
            txt_search.Text = string.Empty;
        }


        public void DataLoad()
        {

            using (SqlConnection con = new SqlConnection(cs))
            {
                string sql = "select * from Subject";

                Shared gd = new Shared();
                dgvItems.DataSource = gd.getdata(sql).Tables[0];

                //Bind the fetched data to gridview           
                dgvItems.DataBind();

            }
        }


        protected void btn_clears_Click(object sender, EventArgs e)
        {
            clear_form();
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            Subject sbd = new Subject();
            try
            {
                sbd.Id = Int32.Parse(hidden_id.Text);
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Subject Selection Failed", "alert('Please Select a Subject First..')", true);
            }
            sbd.Name = txt_name.Text;
            sbd.Year = drop_year.SelectedItem.ToString();
            sbd.Month = drop_month.SelectedItem.ToString();
            sbd.Fee = Convert.ToDecimal(txt_fee.Text);
            sbd.Grade = drop_grade.SelectedItem.ToString();
            sbd.About = txt_about.Text;
            sbd.Branch = drop_branch.SelectedItem.Text;

            sbd.UpdateSub(sbd);

            DataLoad();
        }

        protected void btn_delete_yes_Click1(object sender, EventArgs e)
        {
            Subject sbd = new Subject();
            try
            {
                sbd.Id = Int32.Parse(hidden_id.Text);
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Subject Selection Failed", "alert('Please Select a Subject First..')", true);
            }

            sbd.DeleteSub(sbd);
            DataLoad();
        }
    }
}