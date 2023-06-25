using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repositorio;
using Servico;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
        var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("Jwt")["Key"]);

        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

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

var cors = new CorsPolicyBuilder();
cors.WithOrigins("https://localhost:7056")
    .AllowAnyHeader()
    .AllowAnyMethod();

builder.Services.AddCors(x =>
{
    x.AddDefaultPolicy(cors.Build());
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
