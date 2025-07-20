using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

public class Postagem
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("titulo")]
    public string Titulo { get; set; } = "";

    [BsonElement("autor")]
    public string Autor { get; set; } = "";

    [BsonElement("mensagem")]
    public string Mensagem { get; set; } = "";

    [BsonElement("categorias")]
    public string[] Categorias { get; set; } = Array.Empty<string>();

    [BsonElement("data")]
    public DateTime Data { get; set; } = DateTime.UtcNow;
}

