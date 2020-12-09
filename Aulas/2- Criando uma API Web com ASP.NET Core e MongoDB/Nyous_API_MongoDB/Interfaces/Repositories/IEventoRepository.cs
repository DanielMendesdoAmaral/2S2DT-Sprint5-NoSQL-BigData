using System.Collections.Generic;
using Nyous_API_MongoDB.Domains;

namespace Nyous_API_MongoDB.Interfaces.Repositories
{
    public interface IEventoRepository
    {
        List<Evento> Listar();
        Evento BuscarPorId(string id);
        Evento Adicionar(Evento evento);
        Evento Atualizar(string id, Evento evento);
        void Deletar(string id);
    }
}