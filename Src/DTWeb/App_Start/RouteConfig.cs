using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DTWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Custom route - top priority
            routes.MapRoute(
                    name: "PageSlug",
                    url: "{slug}",
                    defaults: new { controller = "Pages", action = "DetailSlug" },
                    constraints: new
                    {
                        slug = ".+", // Passthru for no slug (goes to home page)
                        slugMatch = new PageSlugMatch() // Custom constraint
                    }
                );

            //routes.MapRoute(
            //    name: "Page",
            //    url: "{slug}",
            //    defaults: new { controller = "Page", action = "Details" },
            //    constraints: new { slug = new SlugConstraint() }
            //);

            routes.MapRoute(
                    name: "Default",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                );
        }
    }

    public class PageSlugMatch : IRouteConstraint
    {
        //private readonly MyDbContext MyDbContext = new MyDbContext();

        public bool Match(
            HttpContextBase httpContext,
            Route route,
            string parameterName,
            RouteValueDictionary values,
            RouteDirection routeDirection
        )
        {
            var routeSlug = values.ContainsKey("slug") ? (string)values["slug"] : "";
            bool slugMatch = false;
            if (!string.IsNullOrEmpty(routeSlug))
            {
                //slugMatch = MyDbContext.Pages.Where(x => x.Slug == routeSlug).Any();
            }
            return slugMatch;
        }
    }

    /// <summary>
    /// https://stackoverflow.com/questions/37193072/c-sharp-mvc-generic-route-using-slug
    /// https://stackoverflow.com/questions/47901394/asp-net-mvc-4-5-refresh-routing-at-runtime
    /// https://stackoverflow.com/questions/11494184/asp-net-mvc-routing-custom-slugs-without-affecting-performance
    /// </summary>
    public class SlugConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (!values.TryGetValue(parameterName, out object slug))
            {
                return false;
            }

            // Your code to get the slugs
            IEnumerable<string> slugs = new string[] {
                "/san-pham/iphone-14-pro-max/"
            };

            // Get the slug from the url
            var mySlug = values["slug"].ToString().ToLower();

            // Check for a match (assumes case insensitive)
            return slugs.Any(x => x.ToLower() == mySlug);
        }
    }
}