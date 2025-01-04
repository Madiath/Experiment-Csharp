namespace LogicaNegocio.Entidades
{
    public class Pais
    {
        public int Id { get; set; }

        public string Nombre { get; set; }
        public int CantHabitantes { get; set; }

        public Pais()
        {
            
        }

        public Pais(string nombre, int cantHabitantes)
        {
            Nombre = nombre; 
            CantHabitantes = cantHabitantes;
        }

        

    }
}