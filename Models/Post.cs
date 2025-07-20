using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace siteYourPostMyLike.Models
{
    public class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        public List<string> Categorias { get; set; } = new();
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string? WhatsApp { get; set; }
        public string? Resumo { get; set; }
        public DateTime Data { get; set; }
        public List<Comentario> Comentarios { get; set; } = new();
        public int Curtidas { get; set; } = 1;


        // Links de redes sociais

        public string? LinkLinkedin { get; set; }
        public string? LinkGitHub { get; set; }
        public string? LinkInstagram { get; set; }
        public string? LinkFacebook { get; set; }
        public string? LinkYouTube { get; set; }
        public string? LinkOutros { get; set; }

        public string? Mensagem { get; set; }

    }

    public class Comentario
    {
        public string Nome { get; set; } = string.Empty;
        public string Texto { get; set; } = string.Empty;
        public DateTime Data { get; set; } = DateTime.Now;
    }


}
