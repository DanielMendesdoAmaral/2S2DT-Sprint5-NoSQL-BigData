using System;
using System.Collections.Generic;
using MongoDB.Driver;
using Nyous_API_MongoDB.Contexts;
using Nyous_API_MongoDB.Domains;
using Nyous_API_MongoDB.Interfaces.Repositories;

namespace Nyous_API_MongoDB.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly IMongoCollection<Categoria> _categorias;

        public CategoriaRepository(INyousDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _categorias = database.GetCollection<Categoria>(settings.CategoriasCollectionName);
        }

        public List<Categoria> Listar()
        {
            try
            {
                return _categorias.AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Categoria BuscarPorId(string id)
        {
            try
            {
                return _categorias.Find(categoria => categoria.Id == id).First();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Categoria Adicionar(Categoria categoria)
        {
            try
            {
                _categorias.InsertOne(categoria);

                return categoria;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Categoria Atualizar(string id, Categoria categoria)
        {
            try
            {
                _categorias.ReplaceOne(
                    categoria => categoria.Id == id,
                    categoria
                );

                return categoria;
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
                _categorias.DeleteOne(categoria => categoria.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}