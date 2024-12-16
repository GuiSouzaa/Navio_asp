var builder = WebApplication.CreateBuilder(args);

// Registra a classe Conexao no container de dependência
builder.Services.AddSingleton<Conexao>();

// Adiciona os serviços para Controllers e Views
builder.Services.AddControllersWithViews();

// Adiciona o serviço do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configura o Swagger para o ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  // Gera a documentação da API
    app.UseSwaggerUI();  // Exibe a interface de usuário do Swagger
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // O valor padrão de HSTS é 30 dias. Você pode querer mudar isso para cenários de produção.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
