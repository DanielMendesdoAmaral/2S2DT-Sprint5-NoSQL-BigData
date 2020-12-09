using System.Collections.Generic;
using Nyous_API_MongoDB.Domains;

namespace Nyous_API_MongoDB.Interfaces.Repositories
{
    public interface ICategoriaRepository
    {
        List<Categoria> Listar();
        Categoria BuscarPorId(string id);
        Categoria Adicionar(Categoria categoria);
        Categoria Atualizar(string id, Categoria categoria);
        void Deletar(string id);
    }
}