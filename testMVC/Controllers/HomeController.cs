using System;
using System.Data;
using System.Globalization;
using System.Web.Mvc;

namespace testMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //[Route("CalDate")]
        //public ActionResult CalDate()
        //{
        //    return View();
        //}

        [Route("CalDate")]
        public ActionResult CalDate(string txtCalDate3, string txtCalDate2, string txtCalDate)
        {
            if (!string.IsNullOrEmpty(txtCalDate) || !string.IsNullOrEmpty(txtCalDate2) || !string.IsNullOrEmpty(txtCalDate3))
            {
                DataTable dt = new DataTable("MyTable");
                dt.Columns.Add(new DataColumn("serno", typeof(string)));
                dt.Columns.Add(new DataColumn("calDate", typeof(string)));

                int outresult = 0;
                string strDate = (int.Parse(txtCalDate2) + 19110000).ToString();

                TaiwanCalendar twCal = new TaiwanCalendar();

                for (int i = 0; i < 20; i++)
                {
                    DataRow row = dt.NewRow();
                    row["serno"] = i + 1;
                    DateTime dtNow = twCal.AddDays(DateTime.ParseExact(strDate, "yyyyMMdd", CultureInfo.InvariantCulture), 28 * i);
                    row["calDate"] = twCal.GetYear(dtNow).ToString().PadLeft(3, '0') + twCal.GetMonth(dtNow).ToString().PadLeft(2, '0') + twCal.GetDayOfMonth(dtNow).ToString().PadLeft(2, '0');
                    dt.Rows.Add(row);
                }

                return View(dt); //passing the DataTable as my Model     
            }
            else
                return View();

        }
    }
}