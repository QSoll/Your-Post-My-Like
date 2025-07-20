using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using siteYourPostMyLike.Models;
using MongoDB.Driver;



namespace siteYourPostMyLike.Pages
{
    public class FormularioModel : PageModel
    {
        private readonly IMongoCollection<Post> colecao;

        public FormularioModel()
        {
            var cliente = new MongoClient("mongodb+srv://QSoll:AUwWmGJio@cluster0.x2fpnor.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0");
            var banco = cliente.GetDatabase("yourpost");
            colecao = banco.GetCollection<Post>("postagens");
        }


        [BindProperty]
        public Post Post { get; set; } = new();

        [BindProperty]
        public List<string> CategoriasSelecionadas { get; set; } = new();

        public List<string> Categorias { get; set; } = new()
        {
            "Contato", "Devs", "TI", "Cibersecurity", "QA",
            "Vagas de trabalho", "Esportes", "Alimentação",
            "Moda", "Recomendo", "Matéria"
        };

        public IActionResult OnPost()
        {
            TimeZoneInfo brasil = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            Post.Data = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, brasil);
            Post.Categorias = CategoriasSelecionadas;

            colecao.InsertOne(Post); // Salva no Atlas

            TempData["Sucesso"] = "Postagem realizada com sucesso!";
            return RedirectToPage("Postagens");
        }

    }
}
