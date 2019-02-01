using System.Web.Mvc;
using System.Web.Routing;

namespace RotasMvc5
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Todas as Notícias",
               url: "noticias/",
               defaults: new { controller = "Home", action = "TodasAsNoticias" }
           );

            routes.MapRoute(
               name: "categoria especifica",
               url: "noticias/{categoria}",
               defaults: new { controller = "Home", action = "MostrarCategoria" }
           );

            routes.MapRoute(
              name: "Mostrar Noticia",
              url: "noticias/{categoria}/{titulo}-{noticiaID}",
              defaults: new { controller = "Home", action = "MostrarNoticias" }
          );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

           
        }
    }
}
