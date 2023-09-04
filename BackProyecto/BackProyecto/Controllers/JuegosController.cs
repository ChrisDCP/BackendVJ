using BackProyecto.models;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace BackProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JuegosController : ControllerBase
    {
        private IConfiguration _Config;

        public JuegosController(IConfiguration config)
        {
            _Config = config;
        }

        [HttpGet]
        public async Task<ActionResult<List<Juego>>> GetJuego()
        {
            using var conexion = new SqlConnection(_Config.GetConnectionString("MyDB"));
            conexion.Open();
            var oJuego = conexion.Query<Juego>("MosJuego", commandType: System.Data.CommandType.StoredProcedure);
            return Ok(oJuego);
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<List<Juego>>> GetJuegoId(int JuegoId)
        {
            using var conexion = new SqlConnection(_Config.GetConnectionString("MyDB"));
            conexion.Open();
            var param = new DynamicParameters();
            param.Add("@id", JuegoId);
            var oJuego = conexion.Query<Juego>("MosJuego", param, commandType: System.Data.CommandType.StoredProcedure)
            .SingleOrDefault();
            return Ok(oJuego);
        }

        [HttpPost]
        public async Task<ActionResult<List<Juego>>> InsertJuego(Juego gam)
        {
            using var conexion = new SqlConnection(_Config.GetConnectionString("MyDB"));
            conexion.Open();
            var param = new DynamicParameters();
            param.Add("@id", gam.id);
            param.Add("@nombre", gam.nombre);
            param.Add("@fecha_Lanzamiento", gam.fecha_Lanzamiento);
            param.Add("@estudio_id", gam.estudio_id);
            param.Add("@consola_id", gam.consola_id);
            param.Add("@director_id", gam.director_id);
            var oJuego = conexion.Query<Juego>("InJuego", param, commandType: System.Data.CommandType.StoredProcedure)
            .SingleOrDefault();
            return Ok(oJuego);
        }

        [HttpPut]
        public async Task<ActionResult<List<Juego>>> ActJuego(Juego gam)
        {
            using var conexion = new SqlConnection(_Config.GetConnectionString("MyDB"));
            conexion.Open();
            var param = new DynamicParameters();
            param.Add("@id", gam.id);
            param.Add("@nombre", gam.nombre);
            param.Add("@fecha_Lanzamiento", gam.fecha_Lanzamiento);
            param.Add("@estudio_id", gam.estudio_id);
            param.Add("@consola_id", gam.consola_id);
            param.Add("@director_id", gam.director_id);
            var oJuego = conexion.Query<Juego>("UpdJuego", param, commandType: System.Data.CommandType.StoredProcedure)
            .SingleOrDefault();
            return Ok(oJuego);
        }

        [HttpDelete("{ID}")]
        public async Task<ActionResult<List<Juego>>> DelJuego(int JuegoId)
        {
            using var conexion = new SqlConnection(_Config.GetConnectionString("MyDB"));
            conexion.Open();
            var param = new DynamicParameters();
            param.Add("@id", JuegoId);
            var oJuego = conexion.Query<Juego>("DeJuego", param, commandType: System.Data.CommandType.StoredProcedure)
            .SingleOrDefault();
            return Ok(oJuego);
        }
    }
}
