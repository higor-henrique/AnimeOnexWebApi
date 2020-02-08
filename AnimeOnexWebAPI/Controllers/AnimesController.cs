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
    public class AnimesController : Controller
    {
        private AnimeOnexDBEntities db = new AnimeOnexDBEntities();

        // GET: Animes
        public ActionResult Index()
        {
            return View(db.Anime.ToList());
        }

        // GET: Animes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anime anime = db.Anime.Find(id);
            if (anime == null)
            {
                return HttpNotFound();
            }
            return View(anime);
        }

        // GET: Animes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Animes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "animeID,titulo,dataEstreia,numeroDeTemporadas,quantidadeDeEpisodios,studio,sinopse,caminhoDaImagem")] Anime anime)
        {
            if (ModelState.IsValid)
            {
                db.Anime.Add(anime);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(anime);
        }

        // GET: Animes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anime anime = db.Anime.Find(id);
            if (anime == null)
            {
                return HttpNotFound();
            }
            return View(anime);
        }

        // POST: Animes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "animeID,titulo,dataEstreia,numeroDeTemporadas,quantidadeDeEpisodios,studio,sinopse,caminhoDaImagem")] Anime anime)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anime).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(anime);
        }

        // GET: Animes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anime anime = db.Anime.Find(id);
            if (anime == null)
            {
                return HttpNotFound();
            }
            return View(anime);
        }

        // POST: Animes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Anime anime = db.Anime.Find(id);
            db.Anime.Remove(anime);
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
