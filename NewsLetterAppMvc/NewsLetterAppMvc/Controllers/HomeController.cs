using NewsLetterAppMvc.Models;
using NewsLetterAppMvc.View_Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsLetterAppMvc.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(string firstName,string lastName, string emailAddress)
        {
            if (string.IsNullOrEmpty(firstName)|| string.IsNullOrEmpty(lastName)||string.IsNullOrEmpty(emailAddress))
                {
                return View("~/Views/Shared/Error.cshtml");
                }
            else
            {
                using (NewsletterEntities db = new NewsletterEntities())
                {
                    var signup = new SignUps_();
                    signup.FirstName = firstName;
                    signup.LastName = lastName;
                    signup.EmailAddress = emailAddress;

                    db.SignUps_.Add(signup);
                    db.SaveChanges();
                }

               
                return View("Success");
            }   
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

       
            
           
        
    }

}