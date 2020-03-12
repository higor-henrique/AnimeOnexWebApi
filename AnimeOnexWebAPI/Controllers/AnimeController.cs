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
    public class AnimeController : ApiController
    {
        private AnimeOnexDBEntities db = new AnimeOnexDBEntities();

        // GET: api/Anime
        public IQueryable<Anime> GetAnime()
        {
            return db.Anime;
        }

        // GET: api/Anime/5
        [ResponseType(typeof(Anime))]
        public IHttpActionResult GetAnime(int id)
        {
            Anime anime = db.Anime.Find(id);
            if (anime == null)
            {
                return NotFound();
            }

            return Ok(anime);
        }

        // PUT: api/Anime/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAnime(int id, Anime anime)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != anime.animeID)
            {
                return BadRequest();
            }

            db.Entry(anime).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimeExists(id))
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

        // POST: api/Anime
        [ResponseType(typeof(Anime))]
        public IHttpActionResult PostAnime(Anime anime)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Anime.Add(anime);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AnimeExists(anime.animeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = anime.animeID }, anime);
        }

        // DELETE: api/Anime/5
        [ResponseType(typeof(Anime))]
        public IHttpActionResult DeleteAnime(int id)
        {
            Anime anime = db.Anime.Find(id);
            if (anime == null)
            {
                return NotFound();
            }

            db.Anime.Remove(anime);
            db.SaveChanges();

            return Ok(anime);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnimeExists(int id)
        {
            return db.Anime.Count(e => e.animeID == id) > 0;
        }
    }
}