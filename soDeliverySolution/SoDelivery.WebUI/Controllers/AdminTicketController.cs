using Microsoft.Owin.Security.Notifications;
using SoDelivery.Core.Contracts;
using SoDelivery.Core.Models;
using SoDelivery.Core.ViewModel;
using SoDelivery.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
namespace SoDelivery.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminTicketController : Controller
    {
        //IRepository<TicketViewModel> context;
        IRepository<Customer> customer;
        IRepository<Ticket> ticket;
        
        public AdminTicketController( IRepository<Customer> customer, IRepository<Ticket> ticket)
        {
            //this.context = context;
            this.customer = customer;
            this.ticket = ticket;
           
        }
        public ActionResult Index()
        {
            var context = new ApplicationDbContext();
            var t = context.Users.ToList();
            List<Ticket> ticketCollection = ticket.Collection().ToList();
            
            List<Customer> customerCollection = customer.Collection().ToList();
            List<TicketUserViewModel> listTVM = new List<TicketUserViewModel>();
            
                foreach(var c in t)
            {
                var d = from ticket in ticketCollection
                        where ticket.UserId == c.Id
                        select ticket;


                //   TicketViewModel tvm = ;
                if (d.Count() > 0) { 
                listTVM.Add(new TicketUserViewModel
                {
                    User = c,
                    Tickets = d.ToList()
                });
                }
            }
            


            return View(listTVM);
        }
        [HttpGet]
        public ActionResult Edit(string Id)
        {
            var TICKET = ticket.Find(Id);
            return View(TICKET);
        }
        [HttpPost]
        public ActionResult Edit(Ticket t, string Id)
        {
            Ticket ticketToEdit = ticket.Find(Id);
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
                ticketToEdit = t;
                ticketToEdit.Day = t.Day;
                ticketToEdit.Description = t.Description;
                ticketToEdit.EndTime = t.EndTime;
                ticketToEdit.StartTime = t.StartTime;
                ticketToEdit.Vehicle = t.Vehicle;
                ticket.Update(ticketToEdit);
                ticket.Commit();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(string Id)
        {
            Ticket ticketToDelete = ticket.Find(Id);
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
            Ticket ticketToDelete = ticket.Find(Id);
            if (ticketToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                ticket.Delete(Id);
                ticket.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Asign (string Id)
        {
            Ticket ticketToAsign = ticket.Find(Id);
            var context = new ApplicationDbContext();
            var t = context.Users.ToList();
            dynamic mymodel = new ExpandoObject();
            mymodel.Ticket = ticketToAsign;
            mymodel.users = t;
            if (ticketToAsign == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(mymodel);
            }
            
        }
        
        public ActionResult AsignIT(string TicketId,string userId)
        {
            Ticket ticketToAsign = ticket.Find(TicketId);
            var context = new ApplicationDbContext();
            var t = context.Users.Find(userId);
            string msg = "We noticed that you are available. \n We would like you to confirm that you can work for this\n";
            msg += ticketToAsign.Day.ToString("yyyy/MM/dd")+"\n From: "+ticketToAsign.StartTime+" To: "+ticketToAsign.EndTime+"\n Salary: "+ticketToAsign.Price+"$h";
            string to=t.Email, from="jjjkahn@gmail.com";

            sendEmail( msg,  to,  from);
            return RedirectToAction("Index");
        }

        private void sendEmail( string msg,  string to,  string from)
        {
            //Comment this line
             to = "jjjkahn@gmail.com"; //To address
             from = "jjjkahn@gmail.com"; //From address    
            MailMessage message = new MailMessage(from, to);
            string mailbody = msg;
            message.Subject = "Work Available - Need confirmation";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("jjjkahn@gmail.com", "marshallmathers");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}