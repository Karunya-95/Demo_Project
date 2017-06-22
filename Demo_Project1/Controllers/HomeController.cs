
//old
using Demo_Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Demo_Project1.Controllers
{
    public class HomeController : Controller
    {
		public ActionResult Index()
        {
            return View();
        }

		//For Login Controller
		public ActionResult ValidateUser(string user_name, string password)
		{
			Int32 validateuser = 0;
			Register Validate = new Register();
			validateuser = Validate.ValidateUser(user_name, password);
			if (validateuser == 1)
            {
                Session["UseerId"] = user_name;
                return Json(new { status = "Success", message = "Success" });
            }	
			else
				return Json(new { status = "Error", message = "Failed" });
		}

		//For Register Controller
		public JsonResult SaveDetailedInfo(string user_name, DateTime dob, string mail_id, string password, string confirm_password, string phone_number, string Address)
		{

			Register Log = new Register();
			Log.Savedata(user_name, dob, mail_id, password, confirm_password, phone_number, Address);
			return Json(new { status = "Success", message = "Success" });
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

		public ActionResult Instruction()
		{
			
			return View();
		}
        //For Questionnaire Page
		public ActionResult Questionnaire()
		{
			Register Reg = new Register();
			List<questions> listids = new List<questions>();
			listids = Reg.Questionniare();
			return View(listids);
		}
        //For Generating the result
        public ActionResult GenerateResult(List<SelectListItem> list)
        {
            int rightcount = 0;
            int wrongans = 0;
            Register Reg = new Register();
            List<questions> listids = new List<questions>();
            listids = Reg.Questionniare();
            for (int i = 0; i <= 19; i++)
            {
                if (listids[i].QuestionId == Convert.ToInt32(list[i].Text) && listids[i].Correct_Answer == list[i].Value)
                {
                    rightcount += 1;
                }
                else
                {
                    wrongans += 1;
                }
            }
            string User_Id = Session["UseerId"].ToString();
            Reg.SaveDataFromUser(list, listids, User_Id);
            return Json(new { rAns = rightcount, wans = wrongans });
        }       
	}
}