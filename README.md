# Your-Post-My-Like
Comunidade para engajamento e conexão

# 🌺 Projeto: Mural Interativo "YourPost MyLike"

## 🎨 Visão Geral
Um mural digital criado com ASP.NET Core, MongoDB Atlas e hospedagem na web via Render. Usuários podem postar mensagens, curtir com coração, comentar e explorar links sociais do autor.

---

## 🧰 Tecnologias Utilizadas

| Tecnologia         | Função                                 |
|--------------------|------------------------------------------|
| ASP.NET Core Razor | Backend e interface web                 |
| MongoDB Atlas      | Banco de dados na nuvem                 |
| C#                 | Lógica de aplicação e modelo de dados   |
| HTML / CSS         | Estrutura e estilos visuais             |
| Render             | Hospedagem do site                      |
| GitHub             | Versionamento e deploy automático       |

---

## 🧩 Estrutura do Projeto


---

## 🖼️ Funcionalidades

- ✅ Criar postagens com título, mensagem, resumo, autor e redes sociais
- ✅ Salvar no MongoDB (`yourpost/postagens`)
- ✅ Curtir com botão ❤️ (e ficar vermelho ao clicar)
- ✅ Contador de curtidas por post
- ✅ Comentar com nome e mensagem
- ✅ Listar postagens com data, autor e links sociais
- ✅ Layout responsivo e estilizado com CSS personalizado

---

## 🧠 Lógica de Curtir

- Botão ❤️ altera visual com `toggle("curtido")`
- Curtidas iniciam com valor `1` no modelo (`Post.cs`)
- (Planejado) Curtida única por usuário com possibilidade de descurtir usando `CurtidoPor`

---

## 📄 Estrutura do Documento `Post.cs`

```csharp
public class Post
{
    public ObjectId Id { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? Titulo { get; set; }
    public string? Mensagem { get; set; }
    public string? Resumo { get; set; }
    public DateTime Data { get; set; } = DateTime.Now;
    public int Curtidas { get; set; } = 1;
    public List<string>? Categorias { get; set; }
    public List<Comentario>? Comentarios { get; set; }
    public string? LinkInstagram { get; set; }
    public string? LinkFacebook { get; set; }
    public string? LinkYouTube { get; set; }
    public string? LinkGitHub { get; set; }
    public string? LinkLinkedin { get; set; }
    public string? LinkOutros { get; set; }
}

