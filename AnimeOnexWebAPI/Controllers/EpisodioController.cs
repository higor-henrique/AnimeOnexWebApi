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
using AnimeOnex.Business.Logic;


namespace AnimeOnexWebAPI.Controllers
{
    public class EpisodioController : ApiController
    {
        private AnimeOnexDBEntities db = new AnimeOnexDBEntities();
        private EpisodioBusiness episodioBusiness;

        public EpisodioController ()
        {
            episodioBusiness = new EpisodioBusiness();
        }

        // GET: api/Episodio
        [ResponseType(typeof(Episodio))]
        public List<Episodio> GetEpisodio()
        {
            List < Episodio > episodios= new List<Episodio>();
            episodios = episodioBusiness.Browsable().ToList();
            return episodios;


        }

        // GET: api/Episodio/5
        [ResponseType(typeof(Episodio))]
        public IHttpActionResult GetEpisodio(int id)
        {
            Episodio episodio = db.Episodio.Find(id);
            if (episodio == null)
            {
                return NotFound();
            }

            return Ok(episodio);
        }

        // PUT: api/Episodio/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEpisodio(int id, Episodio episodio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != episodio.episodioID)
            {
                return BadRequest();
            }

            db.Entry(episodio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EpisodioExists(id))
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

        // POST: api/Episodio
        [ResponseType(typeof(Episodio))]
        public IHttpActionResult PostEpisodio(Episodio episodio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Episodio.Add(episodio);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EpisodioExists(episodio.episodioID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = episodio.episodioID }, episodio);
        }

        // DELETE: api/Episodio/5
        [ResponseType(typeof(Episodio))]
        public IHttpActionResult DeleteEpisodio(int id)
        {
            Episodio episodio = db.Episodio.Find(id);
            if (episodio == null)
            {
                return NotFound();
            }

            db.Episodio.Remove(episodio);
            db.SaveChanges();

            return Ok(episodio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EpisodioExists(int id)
        {
            return db.Episodio.Count(e => e.episodioID == id) > 0;
        }
    }
}