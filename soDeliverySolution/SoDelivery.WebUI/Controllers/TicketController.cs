using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SoDelivery.Core.Contracts;
using SoDelivery.Core.Models;
using SoDelivery.DataAccess.InMemory;

namespace SoDelivery.WebUI.Controllers
{
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
            return View(tickets);
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

    }
}