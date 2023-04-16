//Tudo inicia a partir do builder
var builder = WebApplication.CreateBuilder(args);

//Adicionando o MVC ao container
builder.Services.AddControllersWithViews();

//Realizando o build das configurações que resultará na App
var app = builder.Build();

//Ativando a página de erros caso seja ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

// Adicionando suporte a rota
app.UseRouting();

// Rota de área genérica
app.MapControllerRoute("areas", "{area:exists}/{controller=Home}/{action=Index}/{id?}");

// Rota padrão
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

//Colocando a app para mamar, ops, rodar
app.Run();
