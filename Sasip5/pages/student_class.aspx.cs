using Sasip5.pages.classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sasip5.pages
{
    public partial class student_class : System.Web.UI.Page
    {
        //get connection from web config file
        public static string cs = ConfigurationManager.ConnectionStrings["dbconn"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
          //  if (Session["EType"] == null)
         //   {
        //        Response.Redirect("Login.aspx");
         //   }
            if (IsPostBack == false)
          {
                 DataLoad();
                Loadsubject();            
           }

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



        //Clear method
        private void clear_form()
        {
          txt_id.Text = txt_SName.Text = txt_LName.Text = txt_CFee.Text = "";
            txt_year.Text = txt_month.Text = "";
            drop_subject.ClearSelection();
        }

        //when, Grid view selected, data load to form 
        protected void dgvItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                hidden_id.Visible = true;
                hidden_id.Text = dgvItems.SelectedRow.Cells[2].Text.Replace("&nbsp;", " ");
                DGVpanal.Visible = true;
                txt_id.Text = dgvItems.SelectedRow.Cells[3].Text.Replace("&nbsp;", " ");
                txt_SName.Text = dgvItems.SelectedRow.Cells[4].Text.Replace("&nbsp;", " ");

                string t = dgvItems.SelectedRow.Cells[5].Text;
                drop_subject.ClearSelection();
                drop_subject.Items.FindByText(t).Selected = true;
                drop_changed();

                txt_del_name.Text = txt_SName.Text + " remove from " + t +"?";

            }
            catch (Exception ex)
            {
                throw ex;
                //Console.WriteLine(ex.StackTrace);
            }
        }

        //Grid view search function
        public void SearchUser()
        {
            
            string sql = "SELECT a.ID, a.Stu_ID,b.Name as Student, a.Date,c.Name as Subject FROM Stu_Sub as a inner join students as b on a.Stu_ID = b.S_id inner join Subject as c on a.Sub_ID = c.ID where a.Stu_ID like '"+txt_search.Text+ "%' or b.Name like '" + txt_search.Text + "%' or c.Name like '" + txt_search.Text + "%'";

            Shared gd = new Shared();
            dgvItems.DataSource = gd.getdata(sql).Tables[0];

            //Bind the fetched data to gridview
            dgvItems.DataBind();

        }

        //Gridview reset button
        protected void btnReset_Click1(object sender, EventArgs e)
        {
            DataLoad();
            txt_search.Text = string.Empty;
        }

        //data Load to Grid view   
        public void DataLoad()
        {

            using (SqlConnection con = new SqlConnection(cs))
            {
                string sql = "SELECT a.ID, a.Stu_ID,b.Name as Student, a.Date,(c.Name +' - '+ c.Branch) as Subject FROM Stu_Sub as a inner join students as b on a.Stu_ID=b.S_id inner join Subject as c on a.Sub_ID= c.ID";

                Shared gd = new Shared();
                dgvItems.DataSource = gd.getdata(sql).Tables[0];

                //Bind the fetched data to gridview           
                dgvItems.DataBind();

            }
        }


        //Delete user function
        protected void btn_delete_yes_Click1(object sender, EventArgs e)
        {
            S_class sc = new S_class();
            try
            {
                sc.ID = Int32.Parse(hidden_id.Text);
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "User Selection Failed", "alert('Please Select a User First..')", true);
            }

            sc.Delete(sc);
            DataLoad();
        }

        //Load Details to from
        public void LoadDetails()
        {
            Shared lc = new Shared();
            string sql = "SELECT Name FROM students where S_id='"+txt_id.Text+"'";


            try
            {
                txt_SName.Text = lc.getdata(sql).Tables[0].Rows[0]["Name"].ToString();

            }
            catch (Exception)
            {
                string script = "alert(\"Student Not found..!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

            }
        }

        //Subject Details Load
        protected void drop_subject_SelectedIndexChanged(object sender, EventArgs e)
        {
            drop_changed();
        }

        public void drop_changed()
        {
            Shared lc = new Shared();
            string sql = "SELECT a.ID,a.Name,a.Year,a.Month,a.Fee,b.Name as LName FROM Subject as a left join users as b on a.L_ID=b.E_id where a.ID='"+drop_subject.SelectedValue+"'";

            try
            {
                txt_year.Text = lc.getdata(sql).Tables[0].Rows[0]["Year"].ToString();
               txt_month.Text = lc.getdata(sql).Tables[0].Rows[0]["Month"].ToString();
                txt_CFee.Text = lc.getdata(sql).Tables[0].Rows[0]["Fee"].ToString();
                string Lname = lc.getdata(sql).Tables[0].Rows[0]["LName"].ToString();

                if (Lname == "")
                {
                    txt_LName.Text = "Lecturer is not assign yet.";
                }
                else {
                    txt_LName.Text = Lname;
                }
            }
            catch (Exception)
            {


            }
        }

        //Student Search
        protected void btn_search_Click(object sender, EventArgs e)
        {
            LoadDetails();
        }

        //Assign Student to Subjects
        protected void btn_SAddToClass_Click(object sender, EventArgs e)
        {
            S_class sc = new S_class();

            try
            {
                sc.StudentID = Int16.Parse(txt_id.Text);
                sc.SubjectID = Int16.Parse(drop_subject.SelectedValue);
                sc.Date = DateTime.Now.ToString();
            }
            catch (Exception)
            {
                Exception ex;
            }

            sc.Assign(sc);

            DataLoad();

            clear_form();
        }

        protected void btn_clear_Click1(object sender, EventArgs e)
        {
            clear_form();
            Response.Redirect("student_class.aspx");
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            string sql = "SELECT a.ID, a.Stu_ID,b.Name as Student, a.Date,c.Name as Subject FROM Stu_Sub as a inner join students as b on a.Stu_ID = b.S_id inner join Subject as c on a.Sub_ID = c.ID where a.Stu_ID like '" + txt_search.Text + "%'";

            Shared gd = new Shared();
            dgvItems.DataSource = gd.getdata(sql).Tables[0];

            //Bind the fetched data to gridview
            dgvItems.DataBind();
        }
    }
}