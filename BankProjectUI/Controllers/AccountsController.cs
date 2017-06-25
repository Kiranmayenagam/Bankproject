using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using bankproject;

namespace BankProjectUI.Controllers
{
    public class AccountsController : Controller
    {
        private BankModel db = new BankModel();

        // GET: Accounts
        [Authorize]
        public ActionResult Index()
        {
            return View(Bank.GetAllAccountsByEmailAddress(HttpContext.User.Identity.Name));
        }

        public  ActionResult Deposit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = Bank.GetAccountByAccountNumber(id.Value);

            return View(account);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deposit(FormCollection controls)
        {
            var accountNumber = Convert.ToInt32(controls["AccountNumber"]);
            var amount = Convert.ToDecimal(controls["Amount"]);
            Bank.Deposit(accountNumber, amount);
            return RedirectToAction("Index");
        }
        public ActionResult Withdraw(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = Bank.GetAccountByAccountNumber(id.Value);

            return View(account);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Withdraw(FormCollection controls)
        {
            try
            {
                var accountNumber = Convert.ToInt32(controls["AccountNumber"]);
                var amount = Convert.ToDecimal(controls["Amount"]);
                Bank.Withdraw(accountNumber, amount);
                return RedirectToAction("Index");
            }
            catch(ArgumentOutOfRangeException aox)
            {
                ViewBag.ErrorMessage = aox.Message;
            }
            catch(ArgumentException ax)
            {
                ViewBag.ErrorMessage = ax.Message;
            }
            return View();
        }
        public ActionResult Transactions(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           var transactions = Bank.GetAllTransactionsByAccount(id.Value);
            return View(transactions);

        }

        // GET: Accounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = Bank.GetAccountByAccountNumber(id.Value);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: Accounts/Create
        public ActionResult Create()
        {
            var account = new Account { EmailAddress = HttpContext.User.Identity.Name };
            return View(account);
        }

;        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccountNumber,EmailAddress,Balance,TypeOfAccount")] Account account)
        {
            account.EmailAddress = HttpContext.User.Identity.Name;
            if (ModelState.IsValid)
            {
                Bank.CreateAccount(account.EmailAddress, 0.0M, account.TypeOfAccount);
                return RedirectToAction("Index");
            }

            return View(account);
        }

        // GET: Accounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = Bank.GetAccountByAccountNumber(id.Value);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccountNumber,EmailAddress,Balance,TypeOfAccount")] Account account)
        {
            if (ModelState.IsValid)
            {
                Bank.EditAccount(account);
                return RedirectToAction("Index");
            }
            return View(account);
        }

        // GET: Accounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = Bank.GetAccountByAccountNumber(id.Value);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bank.DeleteAccount(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
