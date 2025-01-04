using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioEvento:IRepositorio<Evento>
    {
        List<Evento> FindAllByDate(DateTime fecha);
      
       

        Evento FindByName(string nombre);


        List<Evento> FindEventoByDisciplina(int id);

        List<Evento> FindEventoEntreFechas(DateTime fecha1, DateTime fecha2);

        List<Evento> FindEventoByNombreEvento(String nombre);


        List<Evento> FiltroEvento(int? disciplinaId,
       DateTime? fechaInicio,
       DateTime? fechaFin,
       string? nombreEvento,
       int? puntajeMin,
       int? puntajeMax);

    }
}
