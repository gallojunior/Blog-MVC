var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

// // Adicionar serviço de sessão
// builder.Services.AddSession(options =>
// {
//     options.IdleTimeout = TimeSpan.FromMinutes(30); // Tempo de expiração da sessão
//     options.Cookie.HttpOnly = true;
//     options.Cookie.IsEssential = true;
//     options.Cookie.SameSite = SameSiteMode.Strict;
// });

// Adicionar serviço de cookies de autenticação
builder.Services.AddAuthentication("BlogCookieAuth")
    .AddCookie("BlogCookieAuth", options =>
    {
        options.Cookie.Name = "BlogAuthCookie";
        options.LoginPath = "/Home/Login"; // Rota para login
        options.AccessDeniedPath = "/Home/AccessDenied"; // Rota para acesso negado
        options.ExpireTimeSpan = TimeSpan.FromDays(7); // Cookie válido por 7 dias
    });

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// app.UseSession();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
