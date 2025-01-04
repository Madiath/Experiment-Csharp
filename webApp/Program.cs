using LogicaAccesoDatos;
using LogicaAplicacion.InterfaceCU.ICUUsuario;
using LogicaAplicacion.CasosUso.CUUsuario;
using Microsoft.EntityFrameworkCore;
using LogicaNegocio.InterfacesRepositorios;
using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.InterfaceCU;
using LogicaAplicacion.InterfaceCU.ICUDigitador;
using LogicaAplicacion.CasosUso.CUDigitador;

namespace webApp
{
    public class Program
    {
        public static void Main(string[] args)
        {

                       var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddSession();
            
            //INYECCIONES
            //CASOS DE USO
            builder.Services.AddScoped<ICUUsuarioLogin, CUUsuarioLogin>();
            builder.Services.AddScoped<ICUAltaUsuario, CUAltaUsuario>();
            builder.Services.AddScoped<ICUListarUsuarios, CUListarUsuarios>();
            builder.Services.AddScoped<ICUListarAtletas, CUListarAtletas>();
            builder.Services.AddScoped<ICUAgregarDisciplina, CUAgregarDisciplinaAtleta>();
            builder.Services.AddScoped<ICUAltaDisciplina, CUAltaDisciplina >() ;
            builder.Services.AddScoped<ICUListarDisciplinas, CUListarDisciplinas>() ;
            builder.Services.AddScoped<ICUAltaEvento, CUAltaEvento>() ;
            builder.Services.AddScoped<ICUListarEventos, CUListarEventos>() ;
            builder.Services.AddScoped<ICUListarAtletasEvento, CUListarAtletasEvento>();
            builder.Services.AddScoped<ICUActualizarPuntuacion, CUActualizarPuntuacion>();
            builder.Services.AddScoped<ICUListarEventosSinFiltrar, CUListarEventosSinFiltrar>();

            //REPO
            builder.Services.AddScoped<IRepositorioAtleta, RepositorioAtleta>();
            builder.Services.AddScoped<IRepositorioEvento, RepositorioEvento>();
            builder.Services.AddScoped<IRepositorioDisciplina, RepositorioDisciplina>();
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            builder.Services.AddScoped<IRepositorioAuditoria, RepositorioAuditoria>();
            builder.Services.AddScoped<IRepositorioEventoAtleta, RepositorioEventoAtleta>();





            // Configurar la cadena de conexión (desde appsettings.json)
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");//DefaultConnection debe coincidir con el nombre designado en el JSON.

            // Registrar el DbContext en el contenedor de servicios
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
          
            
            
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

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
