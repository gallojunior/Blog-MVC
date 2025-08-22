using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BlogGallo.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace BlogGallo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private List<Categoria> categorias;
    private List<Postagem> postagens;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        categorias = [
            new() { Id = 1, Nome = "Mundo", Cor = "#1E90FF" }, // Azul globo/oceano
            new() { Id = 2, Nome = "Brasil", Cor = "#009C3B" }, // Verde bandeira Brasil
            new() { Id = 3, Nome = "Tecnologia", Cor = "#00BFFF" }, // Azul digital/futurista
            new() { Id = 4, Nome = "Design", Cor = "#FF1493" }, // Rosa vibrante/criatividade
            new() { Id = 5, Nome = "Cultura", Cor = "#8B4513" }, // Marrom terroso/tradição
            new() { Id = 6, Nome = "Negócios", Cor = "#2F4F4F" }, // Cinza executivo
            new() { Id = 7, Nome = "Política", Cor = "#B22222" }, // Vermelho intenso/debates
            new() { Id = 8, Nome = "Opinião", Cor = "#FFD700" }, // Amarelo destaque/foco
            new() { Id = 9, Nome = "Ciências", Cor = "#4682B4" }, // Azul científico/precisão
            new() { Id = 10, Nome = "Saúde", Cor = "#32CD32" }, // Verde saúde/vida
            new() { Id = 11, Nome = "Estilo", Cor = "#FF69B4" }, // Rosa moda/estilo
            new() { Id = 12, Nome = "Viagens", Cor = "#FFA500" } // Laranja aventura/energia
        ];
        postagens = [
            new() {
                Id = 1,
                Nome = "Crise humanitária cresce em zonas de conflito no Oriente Médio",
                CategoriaId = 1,
                Categoria = categorias.Find(c => c.Id == 1),
                DataPostagem = DateTime.Parse("06/08/2025"),
                Descricao = "Agências alertam para a escassez de alimentos e medicamentos nas regiões afetadas",
                Texto = "Os conflitos armados no <b>Oriente Médio</b> atingiram níveis críticos, com relatos de violações generalizadas dos direitos humanos.<br><br><b>Principais pontos da crise:</b><ul><li>Mais de 5 milhões de deslocados internos somente no Iêmen</li><li>Taxa de desnutrição infantil acima de 30% em Gaza</li><li>Hospitais operando com menos de 20% de seus medicamentos essenciais</li></ul><br>A ONU lançou um apelo por <b>US$ 4.9 bilhões</b> em ajuda humanitária urgente, mas apenas 18% desse valor foi captado até o momento.",
                Thumbnail = "/img/posts/1.jpeg",
                Foto = "/img/posts/1.jpeg"
            },
            new() {
                Id = 2,
                Nome = "Novo marco fiscal é aprovado no Congresso",
                CategoriaId = 2,
                Categoria = categorias.Find(c => c.Id == 2),
                DataPostagem = DateTime.Parse("05/08/2025"),
                Descricao = "A medida visa controlar os gastos públicos e estimular o crescimento econômico no país.",
                Texto = "Após meses de debates acalorados, o Congresso Nacional aprovou o <b>Novo Marco Fiscal</b> com 72% dos votos favoráveis.<br><br><b>Principais mudanças:</b><ul><li>Limite de crescimento de gastos públicos vinculado ao PIB</li><li>Criação de mecanismos anticíclicos para períodos de recessão</li><li>Novas regras para investimentos em infraestrutura</li></ul><br>Economistas projetam que a medida pode <b>reduzir o déficit primário</b> em até 1,5% do PIB nos próximos dois anos.",
                Thumbnail = "/img/posts/2.png",
                Foto = "/img/posts/2.png"
            },
            new() {
                Id = 3,
                Nome = "Internet discada ainda existia – e só agora ela vai acabar",
                CategoriaId = 3,
                Categoria = categorias.Find(c => c.Id == 3),
                DataPostagem = DateTime.Parse("07/08/2025"),
                Descricao = "Serviço que já gerou milhões em receita agora se torna peça de museu.",
                Texto = "Você provavelmente nunca mais tinha ouvido falar em internet discada e assumiu que ela ficou totalmente no passado, mas, na realidade, a tecnologia ainda existia. Até agora.<br>A empresa <b>AOL</b> anunciou em um comunicado que encerrará seu serviço de internet discada em 30 de setembro, junto com o software associado.<br><br><strong>Sim, ainda existiam pessoas que usavam internet discada</strong><ul><li>Embora muitos considerem a conexão discada uma relíquia do passado, estima-se que ainda existam cerca de 163 mil domicílios nos EUA usando exclusivamente essa tecnologia.</li></ul>",
                Thumbnail = "/img/posts/3.jpg",
                Foto = "/img/posts/3.jpg"
            },
            new() {
                Id = 4,
                Nome = "Tendências do design minimalista em 2025",
                CategoriaId = 4,
                Categoria = categorias.Find(c => c.Id == 4),
                DataPostagem = DateTime.Parse("04/08/2025"),
                Descricao = "Linhas limpas e cores neutras continuam em alta nos projetos de design gráfico e interiores.",
                Texto = "O <b>minimalismo</b> evoluiu em 2025 para incorporar novas tecnologias e preocupações ambientais.<br><br><b>Principais tendências:</b><ul><li><b>Biofilia digital:</b> combinação de elementos naturais com interfaces limpas</li><li><b>Neo-brutalismo sustentável:</b> uso de materiais crus com baixo impacto ambiental</li><li><b>Micro-interações:</b> animações sutis que melhoram a experiência sem poluição visual</li></ul><br>Segundo o relatório da <b>Design Forward 2025</b>, 78% dos consumidores preferem interfaces que priorizam a funcionalidade sobre o excesso de elementos.",
                Thumbnail = "/img/posts/4.png",
                Foto = "/img/posts/4.png"
            },
            new() {
                Id = 5,
                Nome = "Festival internacional de cinema celebra diversidade",
                CategoriaId = 5,
                Categoria = categorias.Find(c => c.Id == 5),
                DataPostagem = DateTime.Parse("03/08/2025"),
                Descricao = "Mostra reúne produções de mais de 40 países com foco em representatividade.",
                Texto = "A 78ª edição do <b>Festival Internacional de Cinema</b> quebrou recordes de participação este ano.<br><br><b>Destaques da programação:</b><ul><li>45% dos filmes foram dirigidos por mulheres</li><li>Representação de 12 comunidades indígenas em produções competitivas</li><li>Sessão especial com filmes realizados por refugiados</li></ul><br>O festival também introduziu o <b>Prêmio de Impacto Social</b>, que reconhece produções que promovem mudanças concretas em suas comunidades.",
                Thumbnail = "/img/posts/5.jpg",
                Foto = "/img/posts/5.jpg"
            },
            new() {
                Id = 6,
                Nome = "Startups brasileiras atraem investimento estrangeiro recorde",
                CategoriaId = 6,
                Categoria = categorias.Find(c => c.Id == 6),
                DataPostagem = DateTime.Parse("02/08/2025"),
                Descricao = "Setores como fintechs e agritechs lideram captação de recursos.",
                Texto = "O ecossistema de startups brasileiro atingiu o <b>maior volume de investimentos</b> de sua história no primeiro semestre de 2025.<br><br><b>Números impressionantes:</b><ul><li><b>US$ 3.2 bilhões</b> captados apenas em julho</li><li>Crescimento de 140% em relação ao mesmo período de 2024</li><li>Fintechs representam 38% do total investido</li></ul><br>Especialistas atribuem esse boom ao <b>Programa Startup Brasil 3.0</b> e à estabilidade macroeconômica recente.",
                Thumbnail = "/img/posts/6.jpg",
                Foto = "/img/posts/6.jpg"
            },
            new() {
                Id = 7,
                Nome = "Nova legislação eleitoral é sancionada",
                CategoriaId = 7,
                Categoria = categorias.Find(c => c.Id == 7),
                DataPostagem = DateTime.Parse("01/08/2025"),
                Descricao = "Mudanças impactam campanhas e regras para financiamento partidário.",
                Texto = "O presidente sancionou a <b>Reforma Eleitoral 2025</b>, que traz mudanças profundas no sistema político.<br><br><b>Mudanças chave:</b><ul><li>Redução do tempo de campanha de 90 para 45 dias</li><li>Obrigatoriedade de verificação de fatos em todas as propagandas</li><li>Limite de 30% do fundo eleitoral para candidaturas femininas</li></ul><br>A nova lei também <b>proíbe totalmente</b> o uso de robôs e deepfakes em campanhas eleitorais, com multas que podem chegar a R$ 5 milhões por infração.",
                Thumbnail = "/img/posts/7.jpg",
                Foto = "/img/posts/7.jpg"
            },
            new() {
                Id = 8,
                Nome = "A urgência de repensar nosso consumo digital",
                CategoriaId = 8,
                Categoria = categorias.Find(c => c.Id == 8),
                DataPostagem = DateTime.Parse("31/07/2025"),
                Descricao = "A quantidade de conteúdo que consumimos está afetando nossa atenção e bem-estar.",
                Texto = "Estudos revelam que o <b>consumo digital excessivo</b> está reescrevendo nossos cérebros.<br><br><b>Dados alarmantes:</b><ul><li>Média de 6,7 horas diárias de consumo digital não profissional</li><li>Queda de 40% na capacidade de atenção sustentada desde 2010</li><li>58% dos jovens relatam sintomas de ansiedade ligados ao uso digital</li></ul><br>Especialistas recomendam a <b>dieta digital</b>: períodos de detox tecnológico e consumo consciente de informação.",
                Thumbnail = "/img/posts/8.jpg",
                Foto = "/img/posts/8.jpg"
            },
            new() {
                Id = 9,
                Nome = "Descoberta de planeta com atmosfera semelhante à Terra intriga cientistas",
                CategoriaId = 9,
                Categoria = categorias.Find(c => c.Id == 9),
                DataPostagem = DateTime.Parse("30/07/2025"),
                Descricao = "Observatório europeu identifica exoplaneta com potencial para abrigar vida.",
                Texto = "O <b>exoplaneta K2-18b</b>, localizado na zona habitável de sua estrela, apresenta características nunca antes vistas.<br><br><b>Descobertas revolucionárias:</b><ul><li>Presença confirmada de água líquida em sua superfície</li><li>Composição atmosférica com 21% de oxigênio - similar à Terra</li><li>Temperaturas médias entre 0°C e 40°C em regiões equatoriais</li></ul><br>Os cientistas do <b>ESO</b> estimam que dentro de 5 anos poderemos detectar possíveis bioassinaturas com os novos telescópios em construção.",
                Thumbnail = "/img/posts/9.jpeg",
                Foto = "/img/posts/9.jpeg"
            },
            new() {
                Id = 10,
                Nome = "Estudo mostra impacto do sono na saúde cardiovascular",
                CategoriaId = 10,
                Categoria = categorias.Find(c => c.Id == 10),
                DataPostagem = DateTime.Parse("29/07/2025"),
                Descricao = "Dormir mal pode aumentar riscos de doenças cardíacas em até 35%, alerta pesquisa.",
                Texto = "A pesquisa <b>Global Sleep Health</b>, que acompanhou 150 mil pessoas por 8 anos, revelou conexões alarmantes.<br><br><b>Principais achados:</b><ul><li>Dormir menos de 6 horas aumenta em 35% o risco de AVC</li><li>Qualidade do sono impacta mais que genética em casos de hipertensão</li><li>Cada hora adicional de sono reduz 17% o risco de calcificação arterial</li></ul><br>Os médicos agora recomendam a <b>Higiene do Sono</b> como parte essencial da prevenção cardiovascular.",
                Thumbnail = "/img/posts/10.png",
                Foto = "/img/posts/10.png"
            },
            new() {
                Id = 11,
                Nome = "Moda sustentável domina passarelas europeias",
                CategoriaId = 11,
                Categoria = categorias.Find(c => c.Id == 11),
                DataPostagem = DateTime.Parse("28/07/2025"),
                Descricao = "Coleções usam tecidos reciclados e processos ecológicos como tendência principal.",
                Texto = "A <b>Semana de Moda de Paris</b> 2025 marcou o ponto de virada para a indústria fashion.<br><br><b>Revolução sustentável:</b><ul><li>73% das grifes usaram pelo menos 50% de materiais reciclados</li><li>Tecidos biodegradáveis representaram 40% das novas coleções</li><li>Blockchain para rastrear toda a cadeia produtiva</li></ul><br>Analistas projetam que até 2027, <b>moda circular</b> deixará de ser nicho para se tornar padrão na indústria.",
                Thumbnail = "/img/posts/11.jpeg",
                Foto = "/img/posts/11.jpeg"
            },
            new() {
                Id = 12,
                Nome = "Os destinos mais procurados para o final de 2025",
                CategoriaId = 12,
                Categoria = categorias.Find(c => c.Id == 12),
                DataPostagem = DateTime.Parse("27/07/2025"),
                Descricao = "Europa e Ásia lideram as buscas entre os viajantes, com destaque para roteiros culturais.",
                Texto = "O relatório <b>Global Travel Trends 2025</b> revela mudanças significativas no perfil dos viajantes.<br><br><b>Top destinos:</b><ul><li><b>Portugal:</b> combinação de segurança, custo-benefício e patrimônio histórico</li><li><b>Japão:</b> explosão de interesse pós-Olimpíadas de Tóquio</li><li><b>Turquia:</b> roteiros que misturam antiguidade e modernidade</li></ul><br>Dados mostram que <b>viagens com propósito</b> (voluntariado, aprendizagem) cresceram 65% em relação a 2024.",
                Thumbnail = "/img/posts/12.jpg",
                Foto = "/img/posts/12.jpg"
            }
        ];
    }

    public IActionResult Index()
    {
        return View(postagens);
    }

    public IActionResult Postagem(int id)
    {
        var postagem = postagens.Where(p => p.Id == id).FirstOrDefault();
        ViewData["Categorias"] = categorias;
        return View(postagem);
    }

    [Authorize]
    public IActionResult Postagens()
    {
        return View(postagens);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddPostagem(Postagem postagem)
    {

        return RedirectToAction("Index");
    }

    public IActionResult Login(string returnUrl)
    {
        LoginVM login = new()
        {
            ReturnUrl = returnUrl ?? "/"
        };
        return View(login);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> LoginAsync(LoginVM model)
    {
        if (ModelState.IsValid)
        {
            // Verifique as credenciais do usuário aqui
            var isUserValid = VerifyUserCredentials(model.Email, model.Password);

            if (isUserValid)
            {
                // Criar claims (informações do usuário)
                var claims = new List<Claim>
                {
                    new(ClaimTypes.Name, model.Email),
                    new(ClaimTypes.Email, model.Email),
                    new(ClaimTypes.Uri, "/img/users/gallo.png")
                };

                // Criar identidade do usuário
                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // Propriedades de autenticação
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = model.RememberMe, // Cookie persistente se "Lembrar-me" estiver marcado
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7) // Expira em 7 dias
                };

                // Criar o cookie
                await HttpContext.SignInAsync(
                    "BlogCookieAuth",
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return Redirect(model.ReturnUrl);
            }

            ModelState.AddModelError(string.Empty, "E-mail e/ou Senha Inválidos");
        }

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        // Remover o cookie
        await HttpContext.SignOutAsync("BlogCookieAuth");
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    private bool VerifyUserCredentials(string email, string password)
    {
        return email == "gallojunior@gmail.com" && password == "123456";
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
