using Microsoft.AspNet.Identity;
using SoDelivery.Core.Contracts;
using SoDelivery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoDelivery.WebUI.Controllers
{
    [Authorize(Roles = "Driver")]
    public class AvailabilityController : Controller
    {
        IRepository<Availability> context;
        public AvailabilityController(IRepository<Availability> InMemoryRepository)
        {
            context = InMemoryRepository;
        }
        // GET: Availability
        public ActionResult Index()
        {
            List<Availability> availabilities = context.Collection().ToList();
            // List<Ticket> tickets = context.Collection().ToList();
            var ID = User.Identity.GetUserId();
            //IEnumerable<Ticket> t = from r in tickets
            //          where r.UserId.Equals(ID)
            //          select r;
            List<Availability> t = new List<Availability>();
            foreach (var r in availabilities)
            {
                if (r.UserId == null)
                {
                    continue;
                }
                try
                {
                    if (r.UserId.Equals(ID))
                    {
                        t.Add(r);
                    }
                    else if (r.Id.Equals(ID))
                    {
                        t.Add(r);
                    }
                }
                catch (Exception e) { }

            }
            return View(t);
        }
        public ActionResult Create()
        {
            Availability available = new Availability();
            return View(available);
        }
        [HttpPost]
        public ActionResult Create(Availability available)
        {
            if (!ModelState.IsValid)
            {
                return View(available);
            }
            available.UserId = User.Identity.GetUserId();
            context.Insert(available);
            context.Commit();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string Id)
        {
            Availability available = context.Find(Id);
            if (available == null)
            {
                return HttpNotFound();
            }
            else
            {

                return View(available);
            }
        }
        [HttpPost]
        public ActionResult Edit(Availability available, string Id)
        {
            Availability productToEdit = context.Find(Id);
            if (productToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(available);
                }


                productToEdit.CreatedAt = available.CreatedAt;
                productToEdit.Day = available.Day;

                productToEdit.EndTime = available.EndTime;
                productToEdit.StartTime = available.StartTime;

                context.Update(productToEdit);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(string Id)
        {
            Availability ticketToDelete = context.Find(Id);
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
            Availability ticketToDelete = context.Find(Id);
            if (ticketToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}