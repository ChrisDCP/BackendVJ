using BackProyecto.models;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace BackProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentariosController : ControllerBase
    {
        private IConfiguration _Config;

        public ComentariosController(IConfiguration config)
        {
            _Config = config;
        }

        [HttpGet]
        public async Task<ActionResult<List<Jugador>>> GetComentario()
        {
            using var conexion = new SqlConnection(_Config.GetConnectionString("MyDB"));
            conexion.Open();
            var oComentario = conexion.Query<Comentario>("MosJugador", commandType: System.Data.CommandType.StoredProcedure);
            return Ok(oComentario);
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<List<Jugador>>> GetComentarioId(int ComentarioId)
        {
            using var conexion = new SqlConnection(_Config.GetConnectionString("MyDB"));
            conexion.Open();
            var param = new DynamicParameters();
            param.Add("@id", ComentarioId);
            var oComentario = conexion.Query<Comentario>("MosComentario", param, commandType: System.Data.CommandType.StoredProcedure)
            .SingleOrDefault();
            return Ok(oComentario);
        }
        [HttpPost]
        public async Task<ActionResult<List<Comentario>>> InsertComentario(Comentario com)
        {
            using var conexion = new SqlConnection(_Config.GetConnectionString("MyDB"));
            conexion.Open();
            var param = new DynamicParameters();
            param.Add("@id", com.id);
            param.Add("@juego_id", com.juego_id);
            param.Add("@jugador_id", com.jugador_id);
            param.Add("@Comentario",com.comentario);
            var oComentario = conexion.Query<Comentario>("InComentario", param, commandType: System.Data.CommandType.StoredProcedure)
            .SingleOrDefault();
            return Ok(oComentario);
        }

        [HttpPut]
        public async Task<ActionResult<List<Comentario>>> ActComentario(Comentario com)
        {
            using var conexion = new SqlConnection(_Config.GetConnectionString("MyDB"));
            conexion.Open();
            var param = new DynamicParameters();
            param.Add("@id", com.id);
            param.Add("@juego_id", com.juego_id);
            param.Add("@jugador_id", com.jugador_id);
            param.Add("@Comentario", com.comentario);
            var oComentario = conexion.Query<Comentario>("UpdComentario", param, commandType: System.Data.CommandType.StoredProcedure)
            .SingleOrDefault();
            return Ok(oComentario);
        }

        [HttpDelete("{ID}")]
        public async Task<ActionResult<List<Jugador>>> DelComentario(int ComentarioId)
        {
            using var conexion = new SqlConnection(_Config.GetConnectionString("MyDB"));
            conexion.Open();
            var param = new DynamicParameters();
            param.Add("@id", ComentarioId);
            var oComentario = conexion.Query<Comentario>("DeComentario", param, commandType: System.Data.CommandType.StoredProcedure)
            .SingleOrDefault();
            return Ok(oComentario);
        }
    }
}
