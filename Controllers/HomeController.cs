using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using DropDownList.Models;

namespace DropDownList.Controllers {
    public class HomeController : Controller
    {
        private fbEntities1 db = new fbEntities1();

        public ActionResult Index(int? selId)
        {
            ViewData["idSel"] = selId;
            ViewBag.list = new List<DropList>
            {
                //Лучше бы конечно чтобы значения в списке формировались по таблице БД. 
                //Однажды может появиться новый жанр а в этом месте добавить забудут
                //Захардкоженный список получился
                new DropList {IDs = 1, Value = "Comedy"},
                new DropList {IDs = 2, Value = "Family"},
                new DropList {IDs = 3, Value = "Romance"},
                new DropList {IDs = 4, Value = "Fantasy"}
            };
            var films = db.Films.Include(f => f.Category).Where(p=> p.cat_film==selId);
            return View(films.ToList());
        }

        [HttpPost]
        public ActionResult index()
        {
            return View();
        }
    }
}
