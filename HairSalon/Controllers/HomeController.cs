using Microsoft.AspNetCore.Mvc;

namespace HairSalon.Controllers
{
  public class HomeController : Controller
  {

    [HttpGet("/")]
    public ActionResult Index()
    {
      ViewBag.PageTitle = "Eau Claire's Salon Administrator Dashboard";
      return View();
    }
  
  }
}