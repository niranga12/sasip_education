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

namespace Sasip5.pages.classes
{
    public partial class s_payments : System.Web.UI.Page
    {
        //get connection from web config file
        public static string cs = ConfigurationManager.ConnectionStrings["dbconn"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EType"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (IsPostBack == false)
            {

            }
        }

        //Load Details to from
        public void LoadDetails()
        {
            Shared lc = new Shared();
            string sql = "SELECT Name FROM students where S_id='" + txt_id.Text + "'";


            try
            {
                txt_name.Text = lc.getdata(sql).Tables[0].Rows[0]["Name"].ToString();
                loadSubject();
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "erroralert();", true);


            }
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
           txt_fee.Text = txt_month.Text = txt_year.Text = txt_overdue.Text = txt_pay.Text = txt_name.Text = "";

            LoadDetails();

        }

        //Load Details to from
        public void loadSubject()
        {


            try
            {
                
                Shared lc = new Shared();
                string sql = "SELECT a.Sub_ID,b.Name FROM Stu_Sub as a inner join Subject as b on a.Sub_ID=b.ID where a.Stu_ID='" + txt_id.Text + "'";
                drop_subject.DataTextField = "Name";
                drop_subject.DataValueField = "Sub_ID";

                drop_subject.DataSource = lc.getdata(sql).Tables[0];
                drop_subject.DataBind();
                drop_subject.Items.Insert(0, new ListItem("Select a Subject", "NA"));

            }
            catch (Exception)
            {

            }
        }



        //Subject Details Load
        protected void drop_subject_SelectedIndexChanged(object sender, EventArgs e)
        {
            drop_changed();
        }

        public void drop_changed()
        {

            txt_fee.Text = txt_month.Text = txt_year.Text = txt_overdue.Text = txt_pay.Text="";
            Shared lc = new Shared();


            try
            {
                string sql = "SELECT a.ID,a.Name,a.Year,a.Month,a.Fee,b.Name as LName FROM Subject as a left join users as b on a.L_ID=b.E_id where a.ID='" + drop_subject.SelectedValue + "'";
                txt_year.Text = lc.getdata(sql).Tables[0].Rows[0]["Year"].ToString();
                txt_month.Text = lc.getdata(sql).Tables[0].Rows[0]["Month"].ToString();
                txt_overdue.Text = txt_fee.Text = lc.getdata(sql).Tables[0].Rows[0]["Fee"].ToString();

                string sql1 = "SELECT ID,Stu_ID, Sub_ID, Pay, Overdue, Status FROM S_payment where Sub_ID='" + drop_subject.SelectedValue + "' and Stu_ID='"+txt_id.Text+"' order by ID DESC offset 0 rows fetch next 1 rows only;";
                txt_overdue.Text = lc.getdata(sql1).Tables[0].Rows[0]["Overdue"].ToString();
                lbl_status.Text = lc.getdata(sql1).Tables[0].Rows[0]["Status"].ToString();


            }
            catch (Exception)
            {
               
            }
        }

        //Make payment
        protected void btn_Pay_Click(object sender, EventArgs e)
        {
            Pay();
        }

        public void Pay() {
            try
            {
                S_Payment sp = new S_Payment();
                sp.Stu_ID = Int16.Parse(txt_id.Text);
                sp.Sub_ID = Int16.Parse(drop_subject.SelectedValue);
                sp.Pay = Convert.ToDecimal(txt_pay.Text);
                sp.OverDue = Convert.ToDecimal(txt_overdue.Text);
                sp.Status = lbl_status.Text;
                sp.Date = DateTime.Now.ToString();

                sp.pay(sp);

                clear_form();
            }
            catch (Exception)
            {
            }
        
        }

        public void clear_form()
        {
            txt_id.Text = txt_fee.Text = txt_month.Text = txt_year.Text = txt_overdue.Text = txt_pay.Text = txt_name.Text = "";
        }

        protected void btn_PayPrint_Click(object sender, EventArgs e)
        {
            Pay();
            Response.Redirect("print_pay_student.aspx");
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                decimal ODue = Convert.ToDecimal(txt_overdue.Text);
                decimal pay = Convert.ToDecimal(txt_pay.Text);

                decimal pending = ODue - pay;

                if (pending != 0)
                {
                    lbl_status.Text = "Payment Not Complete";
                }
                else
                {
                    lbl_status.Text = "Payment Completed";
                }

                txt_overdue.Text = pending.ToString();
            }
            catch (Exception)
            {

                
            }
        
        }

        protected void btn_clears_Click(object sender, EventArgs e)
        {
            clear_form();
        }
    }
}