using SoDelivery.Core.Contracts;
using SoDelivery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoDelivery.WebUI.Controllers
{
    public class AcountAdminController : Controller
    {
        IRepository<Account> context;
        public AcountAdminController(IRepository<Account> accountContex)
        {
            context = accountContex;
        }
        // GET: AcountAdmin
        public ActionResult Index()
        {
            List<Account> accounts = context.Collection().ToList();
            return View(accounts);
        }

        public ActionResult Create()
        {
            Account account = new Account();
            return View(account);
        }
        [HttpPost]
        public ActionResult Create(Account account)
        {
            if (!ModelState.IsValid)
            {
                return View(account);
            }
            else
            {
                context.Insert(account);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit(string Id)
        {
            Account account = context.Find(Id);
            if (account == null)
            {
                return HttpNotFound();
            }
            else
            {
               
                return View(account);
            }
        }
        [HttpPost]
        public ActionResult Edit(Account account, string Id)
        {
            Account accountToEdit = context.Find(Id);
            if (accountToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(account);
                }


                accountToEdit.AccountType = account.AccountType;
                
                context.Update(accountToEdit);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}