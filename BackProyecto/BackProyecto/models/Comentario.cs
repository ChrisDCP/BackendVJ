namespace BackProyecto.models
{
    public class Comentario
    {
        public int id { get; set; }
        public int juego_id { get; set; }
        public int jugador_id { get; set; }
        public string comentario { get; set; }
    }
}
