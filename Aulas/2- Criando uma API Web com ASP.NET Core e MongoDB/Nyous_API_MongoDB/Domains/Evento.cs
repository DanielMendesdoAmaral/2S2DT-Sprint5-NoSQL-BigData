using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Nyous_API_MongoDB.Domains
{
    public class Evento
    {
        //Semelhante à Data Annotation [Key], que define uma chave primária. Como não existe chaves primária em NoSQL, não podemos chamar assim. Encare como um identificador que garante que cada documento seja único.
        [BsonId]
        //Faz com que o MongoDB converta a propriedade de string para ObjectId, um tipo para id's 32 bits menor que o Guid.
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Nome { get; set; }
        public string UrlImagem { get; set; }
        public string Link { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public string Descricao { get; set; }
        //Como não tem relacionamentos, deixe uma string.
        public string Categoria { get; set; }
    }
}