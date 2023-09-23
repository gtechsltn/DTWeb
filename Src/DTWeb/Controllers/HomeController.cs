using DTWeb.Business;
using DTWeb.Models;
using System.Web.Mvc;

namespace DTWeb.Controllers
{
    public class HomeController : Controller
    {
        //private readonly INewsBusiness _newsBusiness;

        //public HomeController(INewsBusiness newsBusiness)
        //{
        //    _newsBusiness = newsBusiness;
        //}

        public HomeController()
        {
            //_newsBusiness = new NewsBusiness();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AnotherLink()
        {
            return View("Index");
        }

        [HttpGet]
        public ActionResult Open(string slug)
        {
            //NewsModel model = _newsBusiness.GetBySlug(slug);
            //return View(model);

            return View("Index");
        }
    }
}