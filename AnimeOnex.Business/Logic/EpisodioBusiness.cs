using System; // qualquer coisa 
using AutoMapper;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using AnimeOnex.Service.Logic;
using AnimeOnex.EnvelopeJson.Logic;
using AnimeOnex.ModelData.Logic;
using AnimeOnex.Util.Pass;
using AnimeOnex.Util.Mail;
using System.Net;
using System.Net.Mail;

namespace AnimeOnex.Business.Logic
{
    public class EpisodioBusiness
    {
        private EpisodioService EpisodioService;



        public EpisodioBusiness()
        {
            EpisodioService = new EpisodioService();
  
        }

        public int Count
        {
            get
            {
                return this.EpisodioService.Count;
            }
        }

        public int CountUsingParams(Expression<Func<Episodio, bool>> predicate)
        {
            return this.EpisodioService.CountUsingParams(predicate);
        }

        //public EpisodioEnvelopeJson Add(EpisodioEnvelopeJson instance)
        //{
        //    Episodio Episodio = Mapper.Map<EpisodioEnvelopeJson, Episodio>(instance);
        //    Episodio.nickname = Episodio.nickname.ToUpper();
        //    Episodio = this.EpisodioService.Add(Episodio);
        //    return Mapper.Map<Episodio, EpisodioEnvelopeJson>(Episodio);
        //}

        public void Edit(EpisodioEnvelopeJson instance, bool comSenha = false)
        {
            Episodio academico = Mapper.Map<EpisodioEnvelopeJson, Episodio>(instance);
            if (comSenha)
            {
                // this.EpisodioService.EditWithPassword(Episodio);
            }
            else
            {
                this.EpisodioService.Edit(academico);


            }
        }

        public IQueryable<Episodio> Browsable(Expression<Func<Episodio, bool>> predicate = null)
        {
            return this.EpisodioService.Browsable(predicate);
        }

        public EpisodioEnvelopeJson Read(Expression<Func<Episodio, bool>> filter)
        {
            Episodio Episodio = this.EpisodioService.Read(filter);
            return Mapper.Map<Episodio, EpisodioEnvelopeJson>(Episodio);
        }





        public string gerarSenha()
        {
            string novaSenha = "asdaseSd";//Password.Generate(0,8);
            return novaSenha;
        }

    }
}