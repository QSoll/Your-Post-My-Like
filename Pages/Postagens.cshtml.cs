using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using siteYourPostMyLike.Models;
using MongoDB.Driver;
using MongoDB.Bson; // opcional se você quiser usar o ping manual depois



namespace siteYourPostMyLike.Pages
{
    public class PostagensModel : PageModel
    {
        private readonly IMongoCollection<Post> colecao;

        [BindProperty]
        public Post NovaPostagem { get; set; } = new();

        public List<Post> Posts { get; set; } = new();

        public IActionResult OnPostCurtir(string idPost)
        {
            var filtro = Builders<Post>.Filter.Eq("_id", ObjectId.Parse(idPost));
            var update = Builders<Post>.Update.Inc("Curtidas", 1);
            colecao.UpdateOne(filtro, update);

            return RedirectToPage("/Postagens");
        }

        public PostagensModel()
        {
            const string connectionUri = "mongodb+srv://QSoll:AUwWmGJio@cluster0.x2fpnor.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";

            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);

            var cliente = new MongoClient(settings);
            var banco = cliente.GetDatabase("yourpost");
            colecao = banco.GetCollection<Post>("postagens");
        }

        public void OnGet()
        {
            var busca = HttpContext.Request.Query["busca"].ToString();

            Posts = colecao.Find(post => true)
                           .SortByDescending(p => p.Data)
                           .ToList();

            if (!string.IsNullOrWhiteSpace(busca))
            {
                busca = busca.ToLower().Trim();
                Posts = Posts.Where(p =>
                    (p.Titulo?.ToLower().Contains(busca) ?? false) ||
                    (p.Nome?.ToLower().Contains(busca) ?? false) ||
                    (p.Mensagem?.ToLower().Contains(busca) ?? false)
                ).ToList();
            }
        }

        public IActionResult OnPost()
        {
            if (NovaPostagem != null)
            {
                NovaPostagem.Data = DateTime.UtcNow;
                colecao.InsertOne(NovaPostagem);
            }

            return RedirectToPage("/Postagens");
        }
    }


}
