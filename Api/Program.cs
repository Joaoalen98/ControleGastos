using Microsoft.EntityFrameworkCore;
using Repositorio;
using Servico;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(x => 
    x.UseSqlServer(builder.Configuration.GetConnectionString("SQL_SERVER")));

// servico
builder.Services.AddTransient<HashService>();
builder.Services.AddTransient<JwtService>();
builder.Services.AddTransient<UsuarioServico>();
builder.Services.AddTransient<MovimentacaoServico>();

// repositorio
builder.Services.AddTransient<UsuarioRepositorio>();
builder.Services.AddTransient<MovimentacaoRepositorio>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
