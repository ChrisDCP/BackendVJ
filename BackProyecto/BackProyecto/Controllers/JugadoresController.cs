using BackProyecto.models;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace BackProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JugadoresController : ControllerBase
    {
        private IConfiguration _Config;

        public JugadoresController(IConfiguration config)
        {
            _Config = config;
        }

        [HttpGet]
        public async Task<ActionResult<List<Jugador>>> GetJugador()
        {
            using var conexion = new SqlConnection(_Config.GetConnectionString("MyDB"));
            conexion.Open();
            var oJugador = conexion.Query<Jugador>("MosJugador", commandType: System.Data.CommandType.StoredProcedure);
            return Ok(oJugador);
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<List<Jugador>>> GetJugadorId (int JugadorId)
        {
            using var conexion = new SqlConnection(_Config.GetConnectionString("MyDB"));
            conexion.Open();
            var param = new DynamicParameters();
            param.Add("@id", JugadorId);
            var oJugador = conexion.Query<Jugador>("MosJugador", param, commandType: System.Data.CommandType.StoredProcedure)
            .SingleOrDefault();
            return Ok(oJugador);
        }

        [HttpPost]
        public async Task<ActionResult<List<Jugador>>> InsertJugador(Jugador jug)
        {
            using var conexion = new SqlConnection(_Config.GetConnectionString("MyDB"));
            conexion.Open();
            var param = new DynamicParameters();
            param.Add("@id", jug.id);
            param.Add("@nombre", jug.nombre);
            param.Add("@FechaNac", jug.FechaNac);
            param.Add("@Correo", jug.correo);
            param.Add("@juego_favorito_id", jug.juego_favorito_id);
            var oJugador = conexion.Query<Jugador>("InJugador", param, commandType: System.Data.CommandType.StoredProcedure)
            .SingleOrDefault();
            return Ok(oJugador);
        }

        [HttpPut]
        public async Task<ActionResult<List<Jugador>>> ActJugador(Jugador jug)
        {
            using var conexion = new SqlConnection(_Config.GetConnectionString("MyDB"));
            conexion.Open();
            var param = new DynamicParameters();
            param.Add("@id", jug.id);
            param.Add("@nombre", jug.nombre);
            param.Add("@FechaNac", jug.FechaNac);
            param.Add("@Correo", jug.correo);
            param.Add("@juego_favorito_id", jug.juego_favorito_id);
            var oJugador = conexion.Query<Jugador>("UpdJugador", param, commandType: System.Data.CommandType.StoredProcedure)
            .SingleOrDefault();
            return Ok(oJugador);
        }

        [HttpDelete("{ID}")]
        public async Task<ActionResult<List<Jugador>>> DelJugador(int JugadorId)
        {
            using var conexion = new SqlConnection(_Config.GetConnectionString("MyDB"));
            conexion.Open();
            var param = new DynamicParameters();
            param.Add("@id", JugadorId);
            var oJugador = conexion.Query<Jugador>("DeJugador", param, commandType: System.Data.CommandType.StoredProcedure)
            .SingleOrDefault();
            return Ok(oJugador);
        }

    }
}
