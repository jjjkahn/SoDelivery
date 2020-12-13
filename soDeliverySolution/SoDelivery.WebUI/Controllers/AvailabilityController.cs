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
    [Authorize(Roles ="Driver")]
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
            return View(availabilities);
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
    }
}