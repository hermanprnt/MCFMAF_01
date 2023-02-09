#nullable disable
using Azure.Identity;
using MCFMAF_01.Database.MasterDB;
using MCFMAF_01.Database.TRDB1;
using MCFMAF_01.Database.TRDB2;
using MCFMAF_01.Models;
using MCFMAF_01.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Services.Profile;

namespace MCFMAF_01.Controllers
{
    [Route("account")]
    public class LoginController : Controller
    {
        private readonly MasterDbContext dbmaster;
        private readonly TransactionDb1Context _transactionDb1Context;
        private readonly TransactionDb2Context _transactionDb2Context;

        public LoginController(MasterDbContext mastercontext, TransactionDb1Context transactionDb1Context, TransactionDb2Context transactionDb2Context)
        {
            dbmaster = mastercontext;
            _transactionDb1Context = transactionDb1Context;
            _transactionDb2Context = transactionDb2Context;
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
            var account = LoginAttempt(username, password);
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

        public MsUser LoginAttempt(string username, string password)
        {
            var user = dbmaster.MsUsers.Where(d => d.Username == username && d.Password == password).FirstOrDefault();
            return user;
        }


        [Route("welcome")]
        public IActionResult Welcome(string username,string usertype)
        {
            ViewBag.username = HttpContext.Session.GetString("username");

            if(usertype == "001")
            {
                return RedirectToAction("BPKBPage1");
                            }
            else if (usertype == "002")
            {
                return RedirectToAction("BPKBPage2");
                
            }
            else
            {
                ViewBag.msg = "Usertype is not registered";
                HttpContext.Session.Remove("username");
                return View("Index"); 
            }
        }

        [Route("BPKBPage1")]
        public IActionResult BPKBPage1()
        {
            var locationData = (from location in _transactionDb1Context.MsStorageLocations
                                select new SelectListItem()
                                {
                                    Value = Convert.ToString(location.LocationId),
                                    Text = location.LocationName
                                }).ToList();
            ViewBag.Locations = locationData;

            return View();
        }

        [Route("BPKBPage2")]
        public IActionResult BPKBPage2()
        {
            var locationData = (from location in _transactionDb2Context.MsStorageLocations
                                select new SelectListItem()
                                {
                                    Value = Convert.ToString(location.LocationId),
                                    Text = location.LocationName
                                }).ToList();
            ViewBag.Locations = locationData;

            return View();
        }

        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("createtr1")]
        public async Task<IActionResult> CreateTR1(Database.TRDB1.TrBpkb transactionViewModel)
        {
            if (ModelState.IsValid)
            {
                _transactionDb1Context.Add(transactionViewModel);
                await _transactionDb1Context.SaveChangesAsync();
                return RedirectToAction("BPKBPage1");
            }
            return RedirectToAction("BPKBPage1");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("createtr2")]
        public async Task<IActionResult> CreateTR2(Database.TRDB2.TrBpkb transactionViewModel)
        {
            if (ModelState.IsValid)
            {
                _transactionDb2Context.Add(transactionViewModel);
                await _transactionDb2Context.SaveChangesAsync();
                return RedirectToAction("BPKBPage2");
            }
            return RedirectToAction("BPKBPage2");
        }
    }
}

