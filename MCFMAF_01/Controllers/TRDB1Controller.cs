using MCFMAF_01.Database.TRDB1;
using MCFMAF_01.Models;
using Microsoft.AspNetCore.Mvc;

namespace MCFMAF_01.Controllers
{
    public class TRDB1Controller : Controller
    {

        private TransactionDb1Context _context;

        public TRDB1Controller(TransactionDb1Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("createtr1")]
        public async Task<IActionResult> CreateTR1(TransactionViewModel transactionViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transactionViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transactionViewModel);
        }
    }
}
