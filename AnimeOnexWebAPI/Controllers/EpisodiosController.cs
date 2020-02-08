using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AnimeOnex.ModelData.Logic;
using EntityState = System.Data.Entity.EntityState;

namespace AnimeOnexWebAPI.Controllers
{
    public class EpisodiosController : Controller
    {
        private AnimeOnexDBEntities db = new AnimeOnexDBEntities();

        // GET: Episodios
        public ActionResult Index()
        {
            var episodio = db.Episodio.Include(e => e.Anime);
            return View(episodio.ToList());
        }

        // GET: Episodios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Episodio episodio = db.Episodio.Find(id);
            if (episodio == null)
            {
                return HttpNotFound();
            }
            return View(episodio);
        }

        // GET: Episodios/Create
        public ActionResult Create()
        {
            ViewBag.animeID = new SelectList(db.Anime, "animeID", "titulo");
            return View();
        }

        // POST: Episodios/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "episodioID,animeID,titulo,vizualizacoes,duracaoMin,numeroDoEpisodio,caminhoDoArquivo")] Episodio episodio)
        {
            if (ModelState.IsValid)
            {
                db.Episodio.Add(episodio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.animeID = new SelectList(db.Anime, "animeID", "titulo", episodio.animeID);
            return View(episodio);
        }

        // GET: Episodios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Episodio episodio = db.Episodio.Find(id);
            if (episodio == null)
            {
                return HttpNotFound();
            }
            ViewBag.animeID = new SelectList(db.Anime, "animeID", "titulo", episodio.animeID);
            return View(episodio);
        }

        // POST: Episodios/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "episodioID,animeID,titulo,vizualizacoes,duracaoMin,numeroDoEpisodio,caminhoDoArquivo")] Episodio episodio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(episodio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.animeID = new SelectList(db.Anime, "animeID", "titulo", episodio.animeID);
            return View(episodio);
        }

        // GET: Episodios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Episodio episodio = db.Episodio.Find(id);
            if (episodio == null)
            {
                return HttpNotFound();
            }
            return View(episodio);
        }

        // POST: Episodios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Episodio episodio = db.Episodio.Find(id);
            db.Episodio.Remove(episodio);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
