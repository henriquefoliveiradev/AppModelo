// Builder principal � dele de onde tudo deriva
using DevIO.UI.Site.Data;
using DevIO.UI.Site.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Build.Evaluation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// *** Configurando servi�os no container ***

// Adicionando suporte a mudan�a de conven��o da rota das areas.
//builder.Services.Configure<RazorViewEngineOptions>(options =>
//{
//    options.AreaViewLocationFormats.Clear();
//    options.AreaViewLocationFormats.Add("/Modulos/{2}/Views/{1}/{0}.cshtml");
//    options.AreaViewLocationFormats.Add("/Modulos/{2}/Views/Shared/{0}.cshtml");
//    options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
//});

builder.Services.AddDbContext<MeuDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MeuDbContext")));

builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddTransient<IOperationTransient, DevIO.UI.Site.Data.Operation>();
builder.Services.AddScoped<IOperationScoped,  DevIO.UI.Site.Data.Operation>();
builder.Services.AddSingleton<IOperationSingleton, DevIO.UI.Site.Data.Operation>();

// Adicionando suporte ao MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// *** Configurando o resquest dos servi�os no pipeline ***
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseMyMiddleware();
// Adicionando suporte a rota
app.UseRouting();

// Rota de �reas especializadas
app.MapAreaControllerRoute("AreaProdutos", "Produtos", "Produtos/{controller=Cadastro}/{action=Index}/{id?}");
app.MapAreaControllerRoute("AreaVendas", "Vendas", "Vendas/{controller=Pedidos}/{action=Index}/{id?}");

// Rota de �rea gen�rica
//app.MapControllerRoute("areas", "{area:exists}/{controller=Home}/{action=Index}/{id?}");

// Rota padr�o
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

app.Run();