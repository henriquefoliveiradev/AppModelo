// Builder principal � dele de onde tudo deriva
using Microsoft.AspNetCore.Mvc.Razor;

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