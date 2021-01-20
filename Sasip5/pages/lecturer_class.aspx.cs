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
    public partial class lecturer_class : System.Web.UI.Page
    {
        //get connection from web config file
        public static string cs = ConfigurationManager.ConnectionStrings["dbconn"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
          //  if (Session["EType"] == null)
          //  {
          //      Response.Redirect("Login.aspx");
          //  }

            if (IsPostBack == false)
            {
                DataLoad();
                Loadsubject();
             
            }
        }

        //data Load to Grid view   
        public void DataLoad()
        {

            using (SqlConnection con = new SqlConnection(cs))
            {
                string sql = "SELECT a.ID,a.L_ID,b.Name,a.Name +' - '+a.Branch  as Sub,a.Year,a.Month,a.Fee FROM Subject a left OUTER JOIN users b on a.L_ID=b.E_id";

                Shared gd = new Shared();
                dgvItems.DataSource = gd.getdata(sql).Tables[0];

                //Bind the fetched data to gridview           
                dgvItems.DataBind();

            }
        }


        //clear the form
        private void clear_form()
        {
            txt_c_fee.Text = txt_id.Text = txt_lname.Text = txt_month.Text = txt_year.Text = "";
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

            string sql = "SELECT a.ID,a.L_ID,b.Name,a.Branch,a.Name as Sub,a.Year,a.Month,a.Fee FROM Subject a left OUTER JOIN users b on a.L_ID=b.E_id where b.Name like '" + txt_search.Text+ "%' or a.Name like '" + txt_search.Text + "%'";

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
                hidden_id.Text = dgvItems.SelectedRow.Cells[3].Text.Replace("&nbsp;", " ");
                DGVpanal.Visible = true;
                txt_id.Text = dgvItems.SelectedRow.Cells[4].Text.Replace("&nbsp;", " ");
                txt_lname.Text = dgvItems.SelectedRow.Cells[5].Text.Replace("&nbsp;", " ");

                string t = dgvItems.SelectedRow.Cells[6].Text;
                drop_subject.ClearSelection();
                drop_subject.Items.FindByText(t).Selected = true;
                drop_changed();

                txt_year.Text = dgvItems.SelectedRow.Cells[7].Text.Replace("&nbsp;", " ");
                txt_month.Text = dgvItems.SelectedRow.Cells[8].Text.Replace("&nbsp;", " ");
                txt_c_fee.Text = dgvItems.SelectedRow.Cells[9].Text.Replace("&nbsp;", " ");

                txt_del_name.Text = "Unassign Lecturer Detail -->" + txt_id.Text + " " + txt_lname.Text;
       

            }
            catch (Exception ex)
            {
                //throw ex;
                //Console.WriteLine(ex.StackTrace);
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
            
            L_class lc = new L_class();

            try
            {
                lc.ID = Int16.Parse(dgvItems.SelectedRow.Cells[3].Text);
            }
            catch (Exception)
            {
                Exception ex;
            }

            lc.UnAssign(lc);

            DataLoad();

            clear_form();
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            LoadDetails();
        }

        //Load subject to dropdown
        public void Loadsubject()
        {
            drop_subject.DataTextField = "onlyOneColumn";
            drop_subject.DataValueField = "ID";
            Shared lc = new Shared();
            string sql = "select ID,(Name +' - '+ Branch) as onlyOneColumn from Subject";
            drop_subject.DataSource = lc.getdata(sql).Tables[0];
            drop_subject.DataBind();
            drop_subject.Items.Insert(0, new ListItem("Select a Subject", "0"));

        }

        //Load Details to from
        public void LoadDetails()
        {
            Shared lc = new Shared();
            string sql = "SELECT E_id, Name FROM users where E_id='"+txt_id.Text+"'";


            try
            {
                txt_lname.Text = lc.getdata(sql).Tables[0].Rows[0]["Name"].ToString();
            }
            catch (Exception)
            {
                string script = "alert(\"Lecturer Not found..!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

            }

         
        }
        //Subect Details load to drop down
        protected void drop_subject_SelectedIndexChanged(object sender, EventArgs e)
        {
            drop_changed();
        }

        public void drop_changed() {
            Shared lc = new Shared();
            string sql = "SELECT a.ID,a.Name,a.Year,a.Month,a.Fee,b.Name as LName FROM Subject as a left join users as b on a.L_ID=b.E_id where a.ID='" + drop_subject.SelectedValue + "'";

            try
            {
                txt_year.Text = lc.getdata(sql).Tables[0].Rows[0]["Year"].ToString();
                txt_month.Text = lc.getdata(sql).Tables[0].Rows[0]["Month"].ToString();
                txt_c_fee.Text = lc.getdata(sql).Tables[0].Rows[0]["Fee"].ToString();

            }
            catch (Exception)
            {


            }
        }

        //Assign lectures to subjects
        protected void btn_LAddToClass_Click(object sender, EventArgs e)
        {
            L_class lc = new L_class();

            try
            {
                lc.LID = Int16.Parse(txt_id.Text);

                lc.SubjectID = Int16.Parse(drop_subject.SelectedValue);
            }
            catch (Exception)
            {
                Exception ex;
            }

            lc.Assign(lc);

            DataLoad();

            clear_form();
        }

        protected void btn_AddNewSub_Click(object sender, EventArgs e)
        {
            Response.Redirect("add_subjects.aspx");
        }

        protected void btn_clear_Click1(object sender, EventArgs e)
        {
            clear_form();
        }
    }
    
}