using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RotasMvc5.Controllers
{
    public class HomeController : Controller
    {
        //o objeto todasAsNoticias ira receber a lista de noticias que esta na classe noticia
        private readonly IEnumerable<Models.Noticia> todasAsNoticias;

        public HomeController()
        {
            //recebe a mesma lista só que ordenada pela data
            todasAsNoticias = new Models.Noticia().TodasAsNoticias().OrderByDescending(x=> x.Data);
        }

        public ActionResult Index()
        {
            //tras as ultimas 3 notiticias
            var ultimasNoticias = todasAsNoticias.Take(3);
            //tras todas as categorias - Distinct não mostra categorias iguais e ToList apenas lista as categorias
            var todasAsCategorias = todasAsNoticias.Select(x => x.Categoria).Distinct().ToList();
            //viewBag para mostrar as categorias distintas
            ViewBag.Categoria = todasAsCategorias;
            //apresenta as ultimas noticias tipadas
            return View(ultimasNoticias);
        }

        public ActionResult TodasAsNoticias()
        {
            return View(todasAsNoticias);
        }


        public ActionResult MostrarNoticias(int noticiaID, string titulo, string categoria)
        {
            return View(todasAsNoticias.FirstOrDefault(x=> x.NoticiaId == noticiaID));
        }


        public ActionResult MostrarCategoria(string categoria)
        {
            var categoriaEspecifica = todasAsNoticias.Where(x => x.Categoria.ToLower() == categoria.ToLower()).ToList();
            ViewBag.Categoria = categoria;
            return View(categoriaEspecifica);

        }

    }
}