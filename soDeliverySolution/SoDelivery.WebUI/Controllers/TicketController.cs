using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using SoDelivery.Core.Contracts;
using SoDelivery.Core.Models;
using SoDelivery.DataAccess.InMemory;
using SoDelivery.WebUI.Models;

namespace SoDelivery.WebUI.Controllers
{
    [Authorize(Roles ="Employeur")]
    public class TicketController : Controller
    {
        // GET: Ticket
        IRepository<Ticket> context;
        public TicketController(IRepository<Ticket> InMemoryRepository)
        {
            context = InMemoryRepository;
        }
        public ActionResult Index()
        {
            List<Ticket> tickets = context.Collection().ToList();
            var ID = User.Identity.GetUserId();
            //IEnumerable<Ticket> t = from r in tickets
            //          where r.UserId.Equals(ID)
            //          select r;
            List<Ticket> t = new List<Ticket>();
            foreach(var r in tickets)
            {
                if (r.UserId.IsNullOrWhiteSpace())
                {
                    continue;
                }
                try {
                    if (r.UserId.Equals(ID))
                    {
                        t.Add(r);
                    }
                    else if (r.Id.Equals(ID))
                    {
                        t.Add(r);
                    }
                }catch(Exception e)
                {

                }
            }
            return View(t.ToList());
        }
        public ActionResult Create()
        {
            Ticket ticket = new Ticket();
            return View(ticket);
        }
        [HttpPost]
        public ActionResult Create(Ticket ticket)
        {
            if (!ModelState.IsValid)
            {
                return View(ticket);
            }
            ticket.UserId = User.Identity.GetUserId();
            context.Insert(ticket);
            context.Commit();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string Id)
        {
            Ticket ticket = context.Find(Id);
            if(ticket == null)
            {
                return HttpNotFound();
            }
            else
            {
                
                return View(ticket);
            }
        }
        [HttpPost]
        public ActionResult Edit(Ticket ticket, string Id)
        {
            Ticket productToEdit = context.Find(Id);
            if (productToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(ticket);
                }

               
                productToEdit.CreatedAt = ticket.CreatedAt;
                productToEdit.Day = ticket.Day;
                productToEdit.Description = ticket.Description;
                productToEdit.EndTime = ticket.EndTime;
                productToEdit.StartTime = ticket.StartTime;
                productToEdit.Vehicle = ticket.Vehicle;
                 context.Update(productToEdit);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(string Id)
        {
            Ticket ticketToDelete = context.Find(Id);
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
            Ticket ticketToDelete = context.Find(Id);
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