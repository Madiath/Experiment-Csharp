using LogicaAccesoDatos;
using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.CasosUso.CUDigitador;
using LogicaAplicacion.CasosUso.CUUsuario;
using LogicaAplicacion.InterfaceCU.ICUDigitador;
using LogicaAplicacion.InterfaceCU.ICUUsuario;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);




// Configurar la cadena de conexión (desde appsettings.json)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");//DefaultConnection debe coincidir con el nombre designado en el JSON.

// Registrar el DbContext en el contenedor de servicios
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//Inyecciones

//CASOS DE USO
builder.Services.AddScoped<ICUObtenerEventosAtleta,CUObtenerEventosAtleta>();
builder.Services.AddScoped<ICUUsuarioLogin, CUUsuarioLogin>();
builder.Services.AddScoped<ICUListarAtletasDisciplina, CUListarAtletasDisciplina>();
builder.Services.AddScoped<ICUEliminarDisciplina, CUEliminarDisciplina>();
builder.Services.AddScoped<ICUAltaDisciplina, CUAltaDisciplina>();
builder.Services.AddScoped<ICUModificarDisciplina, CUModificarDisciplina>();
builder.Services.AddScoped<ICUListarDisciplinas, CUListarDisciplinas>();
builder.Services.AddScoped<ICUListarEventosDisciplina, CUListarEventosDisciplina>();
builder.Services.AddScoped<ICUListarEventosEntreFechas, CUListarEventosEntreFechas>();
builder.Services.AddScoped<ICUListarEventosNombre, CUListarEventosNombre>();
builder.Services.AddScoped<ICUListarEventosPuntaje, CUListarEventosPuntaje>();
builder.Services.AddScoped<ICUFiltrarEventos, CUFiltrarEventos>();
builder.Services.AddScoped<ICUObtenerDisciplinaId, CUObtenerDisciplinaId>();
builder.Services.AddScoped<ICUObtenerDisciplinaNombre,CUObtenerDisciplinaNombre>();
//REPOS
builder.Services.AddScoped<IRepositorioEvento, RepositorioEvento>();
builder.Services.AddScoped<IRepositorioAtleta, RepositorioAtleta>();
builder.Services.AddScoped<IRepositorioEventoAtleta, RepositorioEventoAtleta>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddScoped<IRepositorioDisciplina, RepositorioDisciplina>();
builder.Services.AddScoped<IRepositorioAuditoria, RepositorioAuditoria>();


//Confifuracion jsonWebToken

var clave = "UTzl^7yPl$5xrT6&{7RZCSG&O42MEK-89$CW1XXRrN(>XqIp{W4s2S5$>KT$6CG!2M]'ZlrqH-t%eI4.X9W~u#qO+oX£+[?7QDAa";
var claveEncriptada = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(clave));


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        //Definir las verificaciones a realizar
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true,

        IssuerSigningKey = claveEncriptada
    };

});



var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();


app.UseAuthorization();
app.MapControllers();

app.Run();


