using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Nyous_API_MongoDB.Domains
{
    public class Categoria
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Nome { get; set; }
        public string UrlImagem { get; set; }
        public ICollection<string> Eventos { get; set; }
    }
}