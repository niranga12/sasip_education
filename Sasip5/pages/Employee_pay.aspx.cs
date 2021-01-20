using Sasip5.pages.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sasip5.pages
{
    public partial class Employee_pay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EType"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            LoadYear();
        }

        //Load Details to from
        public void LoadDetails()
        {
            Shared lc = new Shared();
            string sql = "SELECT Name,Branch, E_type FROM users where E_id='" + txt_id.Text + "'";

            try
            {
                txt_name.Text = lc.getdata(sql).Tables[0].Rows[0]["Name"].ToString();
                txt_branch.Text = lc.getdata(sql).Tables[0].Rows[0]["Branch"].ToString();
                txt_EType.Text = lc.getdata(sql).Tables[0].Rows[0]["E_type"].ToString();
             
            }
            catch (Exception)
            {
                string script = "alert(\"Employer Not found..!\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

            }
        }

        //Make payment
        protected void btn_Pay_Click(object sender, EventArgs e)
        {
            Pay();
        }

        public void Pay()
        {
            E_payment em = new E_payment();
            em.Em_ID = Int16.Parse(txt_id.Text);
            em.Branch = txt_branch.Text;
            em.Year = drop_year.SelectedItem.Text;
            em.Month = drop_month.SelectedItem.Text;
            em.Date = DateTime.Now.ToString();
            em.Pay = Convert.ToDecimal(txt_pay.Text);

            em.pay(em);

            clear_form();
        }
     


        //Load years to drop Down
        public void LoadYear() {
            int year = DateTime.Now.Year;
            for (int i = year - 5; i <= year + 5; i++)
            {
                ListItem li = new ListItem(i.ToString());
                drop_year.Items.Add(li);
            }
            drop_year.Items.FindByText(year.ToString()).Selected = true;
        }
        public void clear_form()
        {
            txt_id.Text = txt_branch.Text=txt_EType.Text = txt_name.Text = txt_pay.Text ="";
        }

        protected void btn_PayPrint_Click(object sender, EventArgs e)
        {
            Pay();
            Response.Redirect("print_pay_employee.aspx");
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            LoadDetails();

        }

        protected void btn_clears_Click(object sender, EventArgs e)
        {
            clear_form();
        }
    }
}