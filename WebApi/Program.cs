using LogicaAccesoDatos;
using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.CasosUso.CUUsuario;
using LogicaAplicacion.InterfaceCU.ICUUsuario;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;

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
builder.Services.AddScoped<ICUListarEventosSegunAtleta, CUListarEventosSegunAtleta>();

//REPOS
builder.Services.AddScoped<IRepositorioEvento, RepositorioEvento>();
builder.Services.AddScoped<IRepositorioAtleta, RepositorioAtleta>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
