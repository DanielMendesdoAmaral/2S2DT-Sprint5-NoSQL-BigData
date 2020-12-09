using System;
using System.Collections.Generic;
using MongoDB.Driver;
using Nyous_API_MongoDB.Contexts;
using Nyous_API_MongoDB.Domains;
using Nyous_API_MongoDB.Interfaces.Repositories;

namespace Nyous_API_MongoDB.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly IMongoCollection<Evento> _eventos;

        public EventoRepository(INyousDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            //Injeção de dependência. Guarda o "DbSet".
            _eventos = database.GetCollection<Evento>(settings.EventosCollectionName);
        }

        public List<Evento> Listar()
        {
            try
            {
                //AsQueryable enumera todos os documentos da coleção especificada.
                return _eventos.AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Evento BuscarPorId(string id)
        {
            try
            {
                return _eventos.Find(evento => evento.Id == id).First();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Evento Adicionar(Evento evento)
        {
            try
            {
                _eventos.InsertOne(evento);

                return evento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Evento Atualizar(string id, Evento evento)
        {
            try
            {
                _eventos.ReplaceOne(
                    evento => evento.Id == id, //Id do evento a ser atualizado
                    evento //Novo evento
                );

                return evento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Deletar(string id)
        {
            try
            {
                _eventos.DeleteOne(evento => evento.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}