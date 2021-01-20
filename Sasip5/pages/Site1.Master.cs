using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sasip5.pages
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string etype = Session["EType"].ToString();

                if (etype == "Admin")
                {
                    li_user.Visible = true;
                }

                else if (etype == "Full-Time Lecture" || etype == "Part-Time Lecture")
                {
                    li_student.Visible = false;
                    li_classManagemnet.Visible = false;
                    li_user.Visible = false;
                    li_payment.Visible = false;
                    li_student_reports.Visible = false;
                    li_profit_reports.Visible = false;
                }
                else
                {
                    li_user.Visible = false;
                    li_l_payments.Visible = false;
                    li_profit_reports.Visible = false;
                }
            }
            catch (Exception)
            {

                
            }
          
            //Side Bar active Colour
            String activepage = HttpContext.Current.Request.Url.AbsolutePath;
            if (activepage.Contains("/pages/dashboard.aspx"))
            {
                li_dash.Attributes.Add("class", "active");
            }
            else if (activepage.Contains("/pages/users.aspx"))
            {
                li_user.Attributes.Add("class", "active");
            }
            else if (activepage.Contains("/pages/students.aspx"))
            {
                li_student.Attributes.Add("class", "active");
            }
            else if (activepage.Contains("/pages/student_class.aspx"))
            {
                li_sclass.Attributes.Add("class", "active");
            }
            else if (activepage.Contains("/pages/lecturer_class.aspx"))
            {
                li_lclass.Attributes.Add("class", "active");
            }
            else if (activepage.Contains("/pages/add_subjects.aspx"))
            {
                li_add_subjects.Attributes.Add("class", "active");
            }
            else if (activepage.Contains("/pages/s_payments.aspx"))
            {
                li_s_payments.Attributes.Add("class", "active");
            }
            else if (activepage.Contains("/pages/l_payments.aspx"))
            {
                li_l_payments.Attributes.Add("class", "active");
            }
            else if (activepage.Contains("/pages/subject_reports.aspx"))
            {
                li_subject_reports.Attributes.Add("class", "active");
            }
            else if (activepage.Contains("/pages/student_reports.aspx"))
            {
                li_student_reports.Attributes.Add("class", "active");
            }
            else if (activepage.Contains("/pages/profit_reports.aspx"))
            {
                li_profit_reports.Attributes.Add("class", "active");
            }
            else {

            }
        }
    }
}