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

//Adicionando a rota padrão
app.MapControllerRoute(
    "default", "{controller=Home}/{action=Index}/{id?}");

//Colocando a app para mamar, ops, rodar
app.Run();
