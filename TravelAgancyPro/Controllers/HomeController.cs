using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelAgancyPro.Classes;

namespace TravelAgancyPro.Controllers
{
    public class HomeController : Controller
    {

        
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";          
            return View();
        }

        public ActionResult Run(string UserName, string Password, string list)
        {

            if (UserName == "Admin" && Password == "7nJ4oq7@f*Dg")
            {
                switch (list)
                {
                    case  "API":
                        return RedirectToAction("Index", "Help");
                       
                    case "ExportToExcel":
                        ExportDataToFile.ExportToExcel();
                        return Redirect("~/Content/Excel/Users.xlsx");

                    case "DatabaseBakup":
                        DatabaseBackup.GenerateBackup("SQL5104.site4now.net", "db_a8cef5_dbtravelagency01_admin", "8frDKawK9nXakz3", "db_a8cef5_dbtravelagency01");
                        return Redirect("~/Content/DatabaseBackup/TravelAgencyDB.bak");

                    
                    case "GetLogFile":
                        return Redirect("~/Content/Logging/Log.txt");

                    default:
                        return View("~/Views/Shared/Error.cshtml");
                       
                }

               
            }

            return View("~/Views/Shared/Error.cshtml");

        }

     

    }
}
