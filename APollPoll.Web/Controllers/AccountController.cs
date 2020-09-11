using APollPoll.Services.Accounts.Models;
using APollPoll.Web.Authorization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace APollPoll.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login(string returnUrl = "")
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginRequest model, string returnUrl = "")
        {
            if (ModelState.IsValid && Membership.ValidateUser(model.Email, model.Password))
            {
                var user = (AuthMembershipUser)Membership.GetUser(model.Email, false);
                if (user != null)
                {
                    var userModel = new AuthSerializeModel()
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Role = user.Role
                    };

                    var userData = JsonConvert.SerializeObject(userModel);
                    var authTicket = new FormsAuthenticationTicket(1, model.Email, DateTime.Now, DateTime.Now.AddMinutes(15), false, userData);
                    var encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var cookie = new HttpCookie("AuthCookie", encryptedTicket);
                    Response.Cookies.Add(cookie);
                }

                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "User or Password is invalid.");
            return View(model);
        }

        public ActionResult LogOut()
        {
            Response.Cookies.Add(new HttpCookie("AuthCookie", "")
            {
                Expires = DateTime.Now.AddYears(-1)
            });

            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}