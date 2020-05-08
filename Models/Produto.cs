using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace demoMongoDB.Models
{
    public class Produto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Descricao")]
        [JsonProperty("Descricao")]
        public string DescricaoCompleta { get; set; }

        public string DescricaoResumida { get; set; }

        public bool Ativo { get; set; }
    }
}