using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;

namespace HairSalon.Controllers
{
  public class StylistsController : Controller
  {
    private readonly HairSalonContext _db;

    public StylistsController(HairSalonContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Stylist> model = _db.Stylists.ToList();
      ViewBag.PageTitle = "All Stylists";
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.PageTitle = "Add A New Stylist";
      return View();
    }

    [HttpGet]
    public ActionResult Search(string StylistQuery)
    {
      if (StylistQuery == null || StylistQuery.Trim().Length == 0) {
        List<Stylist> model = _db.Stylists.ToList();
        ViewBag.PageTitle = $"Stylists matching query '{StylistQuery}'";
        return View(model);
      } else {
        List<Stylist> model = _db.Stylists.ToList().Where(x => 
          x.FirstName.ToLower().Contains(StylistQuery.Trim().ToLower()) ||
          x.LastName.ToLower().Contains(StylistQuery.Trim().ToLower())
        ).ToList();
        ViewBag.PageTitle = $"Stylists matching query '{StylistQuery.Trim()}'";
        return View(model);
      }
    }

    [HttpPost]
    public ActionResult Create(Stylist stylist)
    {
      _db.Stylists.Add(stylist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Stylist thisStylist = _db.Stylists
                            .Include(stylist => stylist.Clients)
                            .FirstOrDefault(stylist => stylist.StylistId == id);
      ViewBag.PageTitle = $"Details for stylist {thisStylist.LastName} {thisStylist.LastName}";
      return View(thisStylist);
    }

    public ActionResult Edit(int id)
    {
      Stylist thisStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
      ViewBag.PageTitle = $"Editing stylist {thisStylist.FirstName} {thisStylist.LastName}";
      return View(thisStylist);
    }

    [HttpPost]
    public ActionResult Edit(Stylist stylist)
    {
      _db.Stylists.Update(stylist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Stylist thisStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
      ViewBag.PageTitle = $"Confirming deletion of {thisStylist.FirstName} {thisStylist.LastName}";
      return View(thisStylist);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Stylist thisStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
      _db.Stylists.Remove(thisStylist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}