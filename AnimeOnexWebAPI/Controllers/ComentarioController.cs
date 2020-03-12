using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AnimeOnex.ModelData.Logic;
using EntityState = System.Data.Entity.EntityState;

namespace AnimeOnexWebAPI.Controllers
{
    public class ComentarioController : ApiController
    {
        private AnimeOnexDBEntities db = new AnimeOnexDBEntities();

        // GET: api/Comentario
        public IQueryable<Comentario> GetComentario()
        {
            return db.Comentario;
        }

        // GET: api/Comentario/5
        [ResponseType(typeof(Comentario))]
        public IHttpActionResult GetComentario(int id)
        {
            Comentario comentario = db.Comentario.Find(id);
            if (comentario == null)
            {
                return NotFound();
            }

            return Ok(comentario);
        }

        // PUT: api/Comentario/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutComentario(int id, Comentario comentario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comentario.comentarioID)
            {
                return BadRequest();
            }

            db.Entry(comentario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComentarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Comentario
        [ResponseType(typeof(Comentario))]
        public IHttpActionResult PostComentario(Comentario comentario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Comentario.Add(comentario);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ComentarioExists(comentario.comentarioID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = comentario.comentarioID }, comentario);
        }

        // DELETE: api/Comentario/5
        [ResponseType(typeof(Comentario))]
        public IHttpActionResult DeleteComentario(int id)
        {
            Comentario comentario = db.Comentario.Find(id);
            if (comentario == null)
            {
                return NotFound();
            }

            db.Comentario.Remove(comentario);
            db.SaveChanges();

            return Ok(comentario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ComentarioExists(int id)
        {
            return db.Comentario.Count(e => e.comentarioID == id) > 0;
        }
    }
}