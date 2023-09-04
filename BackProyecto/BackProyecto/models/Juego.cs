namespace BackProyecto.models
{
    public class Juego
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public DateTime fecha_Lanzamiento { get; set; }
        public int estudio_id { get; set; }
        public int consola_id { get; set; }
        public int director_id { get; set; }
    }
}
