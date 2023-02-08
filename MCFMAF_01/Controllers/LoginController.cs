#nullable disable
using Azure.Identity;
using MCFMAF_01.Database.TRDB1;
using MCFMAF_01.Database.TRDB2;
using MCFMAF_01.Models;
using MCFMAF_01.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MCFMAF_01.Controllers
{
    [Route("account")]
    public class LoginController : Controller
    {
        private AccountService accountService;
    
        public LoginController(AccountService _accountService) 
        { 
            accountService = _accountService;
        }


        [Route("")]
        [Route("~/")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(string username,string password)
        {
            var account = accountService.Login(username, password);
            if (account != null)
            {
                HttpContext.Session.SetString("username", username);
                return RedirectToAction("welcome", new {username = account.Username,usertype = account.UserType } );
            }
            else
            {
                ViewBag.msg = "Invalid Login";
                return View("Index");
            }

         }

        [Route("welcome")]
        public IActionResult Welcome(string username,string usertype)
        {
            ViewBag.username = HttpContext.Session.GetString("username");

            if(usertype == "001")
            {
                return View("BPKBPage1");
            }
            else if (usertype == "002")
            {
                return View("BPKBPage2");
            }
            else
            {
                ViewBag.msg = "Usertype is not registered";
                HttpContext.Session.Remove("username");
                return View("Index"); 
            }
        }

        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("index");
        }


    }
}

