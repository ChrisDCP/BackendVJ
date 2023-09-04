namespace BackProyecto.models
{
    public class Jugador
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public DateTime FechaNac { get; set;}
        public string correo { get; set; }
        public int juego_favorito_id { get; set; }
    }
}
