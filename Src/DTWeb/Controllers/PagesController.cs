using DTWeb.Models;
using System.Web.Mvc;

namespace DTWeb.Controllers
{
    public class PagesController : Controller
    {
        // Regular ID-based routing
        [Route("pages/{id}")]
        public ActionResult Detail(int? id)
        {
            return View();
        }

        // Slug-based routing - reuse View from above controller.
        public ActionResult DetailSlug(string slug)
        {
            //var model = MyDbContext.Pages.SingleOrDefault(x => x.Slug == slug);
            //if (model == null)
            //{
            //    return new HttpNotFoundResult();
            //}
            //ViewBag.Title = model.Title;
            var model = new NewsModel();
            return View("Detail", model);
        }
    }
}