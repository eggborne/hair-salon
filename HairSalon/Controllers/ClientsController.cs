using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {
    private readonly HairSalonContext _db;

    public ClientsController(HairSalonContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Client> model = _db.Clients
                            .Include(client => client.Stylist)
                            .ToList();
      ViewBag.PageTitle = "All Clients";
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "FirstName");
      ViewBag.PageTitle = "Add A New Client";
      return View();
    }

    [HttpGet]
    public ActionResult Search(string ClientQuery)
    {
      if (ClientQuery == null || ClientQuery.Trim().Length == 0) {
        List<Client> model = _db.Clients.ToList();
        ViewBag.PageTitle = $"Clients matching query '{ClientQuery}'";
        return View(model);
      } else {
        List<Client> model = _db.Clients.ToList().Where(x => 
          x.FirstName.ToLower().Contains(ClientQuery.Trim().ToLower()) ||
          x.LastName.ToLower().Contains(ClientQuery.Trim().ToLower())
        ).ToList();
        ViewBag.PageTitle = $"Clients matching query '{ClientQuery.Trim()}'";
        return View(model);
      }
    }

    [HttpPost]
    public ActionResult Create(Client client)
    {
      if (client.StylistId == 0)
      {
        return RedirectToAction("Create");
      }
      _db.Clients.Add(client);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Client thisClient = _db.Clients
                          .Include(client => client.Stylist)
                          .FirstOrDefault(client => client.ClientId == id);
      ViewBag.PageTitle = $"Details for client {thisClient.FirstName} {thisClient.LastName}";
      return View(thisClient);
    }

    public ActionResult Edit(int id)
    {
      Client thisClient = _db.Clients.FirstOrDefault(client => client.ClientId == id);
      ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "FirstName");
      ViewBag.PageTitle = $"Editing client {thisClient.FirstName} {thisClient.LastName}";
      return View(thisClient);
    }

    [HttpPost]
    public ActionResult Edit(Client client)
    {
      _db.Clients.Update(client);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Client thisClient = _db.Clients.FirstOrDefault(client => client.ClientId == id);
      ViewBag.PageTitle = $"Confirming deletion of {thisClient.FirstName} {thisClient.LastName}";
      return View(thisClient);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Client thisClient = _db.Clients.FirstOrDefault(client => client.ClientId == id);
      _db.Clients.Remove(thisClient);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}