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
    public class ComentariosController : Controller
    {
        private AnimeOnexDBEntities db = new AnimeOnexDBEntities();

        // GET: Comentarios
        public ActionResult Index()
        {
            var comentario = db.Comentario.Include(c => c.Episodio).Include(c => c.Usuario);
            return View(comentario.ToList());
        }

        // GET: Comentarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = db.Comentario.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            return View(comentario);
        }

        // GET: Comentarios/Create
        public ActionResult Create()
        {
            ViewBag.episodioID = new SelectList(db.Episodio, "episodioID", "titulo");
            ViewBag.usuarioID = new SelectList(db.Usuario, "usuarioID", "nickname");
            return View();
        }

        // POST: Comentarios/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "comentarioID,usuarioID,episodioID,texto,dataComentario")] Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                db.Comentario.Add(comentario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.episodioID = new SelectList(db.Episodio, "episodioID", "titulo", comentario.episodioID);
            ViewBag.usuarioID = new SelectList(db.Usuario, "usuarioID", "nickname", comentario.usuarioID);
            return View(comentario);
        }

        // GET: Comentarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = db.Comentario.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            ViewBag.episodioID = new SelectList(db.Episodio, "episodioID", "titulo", comentario.episodioID);
            ViewBag.usuarioID = new SelectList(db.Usuario, "usuarioID", "nickname", comentario.usuarioID);
            return View(comentario);
        }

        // POST: Comentarios/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "comentarioID,usuarioID,episodioID,texto,dataComentario")] Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comentario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.episodioID = new SelectList(db.Episodio, "episodioID", "titulo", comentario.episodioID);
            ViewBag.usuarioID = new SelectList(db.Usuario, "usuarioID", "nickname", comentario.usuarioID);
            return View(comentario);
        }

        // GET: Comentarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = db.Comentario.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            return View(comentario);
        }

        // POST: Comentarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comentario comentario = db.Comentario.Find(id);
            db.Comentario.Remove(comentario);
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
