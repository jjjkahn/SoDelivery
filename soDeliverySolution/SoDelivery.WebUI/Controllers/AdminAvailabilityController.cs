using SoDelivery.Core.Contracts;
using SoDelivery.Core.Models;
using SoDelivery.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoDelivery.WebUI.Controllers
{
    public class AdminAvailabilityController : Controller
    {
        //IRepository<TicketViewModel> context;
        IRepository<Customer> customer;
        IRepository<Availability> availbilities;

        public AdminAvailabilityController(IRepository<Customer> customer, IRepository<Availability> ticket)
        {
            //this.context = context;
            this.customer = customer;
            this.availbilities = ticket;

        }
        // GET: AdminAvailability
        public ActionResult Index()
        {
            var context = new ApplicationDbContext();
            var t = context.Users.ToList();
            List<Availability> AVaCol = availbilities.Collection().ToList();

            List<Customer> customerCollection = customer.Collection().ToList();
            List<AvailabilityUserViewModel> listTVM = new List<AvailabilityUserViewModel>();

            foreach (var c in t)
            {
                var d = from ticket in AVaCol
                        where ticket.UserId == c.Id
                        select ticket;


                //   TicketViewModel tvm = ;
                if (d.Count() > 0)
                {
                    listTVM.Add(new AvailabilityUserViewModel
                    {
                        User = c,
                        Availabilities = d.ToList()
                    });
                }
            }



            return View(listTVM);
        }
        [HttpGet]
        public ActionResult Edit(string Id)
        {
            var TICKET = availbilities.Find(Id);
            return View(TICKET);
        }
        [HttpPost]
        public ActionResult Edit(Availability t, string Id)
        {
            Availability ticketToEdit = availbilities.Find(Id);
            if (ticketToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(t);
                }

                ticketToEdit.Day = t.Day;
                ticketToEdit.EndTime = t.EndTime;
                ticketToEdit.StartTime = t.StartTime;
                availbilities.Update(ticketToEdit);
                availbilities.Commit();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(string Id)
        {
            Availability ticketToDelete = availbilities.Find(Id);
            if (ticketToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(ticketToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Availability ticketToDelete = availbilities.Find(Id);
            if (ticketToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                availbilities.Delete(Id);
                availbilities.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}