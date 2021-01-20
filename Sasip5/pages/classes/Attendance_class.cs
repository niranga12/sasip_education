using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sasip5.pages.classes
{
    public class Attendance_class
    {
        public int ID { get; set; }
        public string Date { get; set; }

        public void Mark_in(Attendance_class at)
        {
            string sql = "INSERT INTO Attendance(SID, Date) VALUES ('"+at.ID+ "','" + at.Date + "')";
            Shared share = new Shared();
            share.ExecuteQuery(sql);
        }
    }
}