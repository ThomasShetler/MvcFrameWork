using NewsLetterAppMvc.Models;
using NewsLetterAppMvc.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsLetterAppMvc.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {

            using (NewsletterEntities db = new NewsletterEntities())
            {
                //var signups = db.SignUps_.Where(x => x.Removed == null).ToList();

                var signups = (from c in db.SignUps_
                               where c.Removed == null
                               select c);
                var signupVms = new List<SignupVm>();

                
                foreach (var signup in signups)
                {
                   
                    var signupVm = new SignupVm();
                    
                    signupVm.Id = signup.id;
                    signupVm.FirstName = signup.FirstName;
                    signupVm.LastName = signup.LastName;
                    signupVm.EmailAddress = signup.EmailAddress;
                    signupVms.Add(signupVm);
                }
                return View(signupVms);
            }
        }
        public ActionResult Unsubscribe(int id)
        {
            using (NewsletterEntities db = new NewsletterEntities())
            {
                var signup = db.SignUps_.Find(id);
                signup.Removed = DateTime.Now;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}