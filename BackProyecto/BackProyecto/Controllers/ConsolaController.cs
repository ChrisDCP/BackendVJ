using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using BackProyecto.models;
using System.Data.SqlClient;

namespace BackProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsolaController : ControllerBase
    {
        private IConfiguration _Config;

        public ConsolaController(IConfiguration config)
        {
            _Config = config;
        }

        [HttpGet]
        public async Task<ActionResult<List<Consola>>> GetConsola()
        {
            using var conexion = new SqlConnection(_Config.GetConnectionString("MyDB"));
            conexion.Open();
            var oConsola = conexion.Query<Consola>("MosConsola", commandType: System.Data.CommandType.StoredProcedure);
            return Ok(oConsola);
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<List<Consola>>> GetConsolaId(int ConsolaId)
        {
            using var conexion = new SqlConnection(_Config.GetConnectionString("MyDB"));
            conexion.Open();
            var param = new DynamicParameters();
            param.Add("@id", ConsolaId);
            var oConsola = conexion.Query<Consola>("MosConsola", param, commandType: System.Data.CommandType.StoredProcedure)
            .SingleOrDefault();
            return Ok(oConsola);
        }

        [HttpPost]
        public async Task<ActionResult<List<Consola>>> InsertConsola(Consola con)
        {
            using var conexion = new SqlConnection(_Config.GetConnectionString("MyDB"));
            conexion.Open();
            var param = new DynamicParameters();
            param.Add("@id", con.id);
            param.Add("@nombre", con.nombre);
            var oConsola = conexion.Query<Consola>("InConsola", param, commandType: System.Data.CommandType.StoredProcedure)
            .SingleOrDefault();
            return Ok(oConsola);
        }

        [HttpPut]
        public async Task<ActionResult<List<Consola>>> ActConsola(Consola con)
        {
            using var conexion = new SqlConnection(_Config.GetConnectionString("MyDB"));
            conexion.Open();
            var param = new DynamicParameters();
            param.Add("@id", con.id);
            param.Add("@nombre", con.nombre);
            var oConsola = conexion.Query<Consola>("UpdConsola", param, commandType: System.Data.CommandType.StoredProcedure)
            .SingleOrDefault();
            return Ok(oConsola);
        }

        [HttpDelete("{ID}")]
        public async Task<ActionResult<List<Consola>>> DelConsola(int ConsolaId)
        {
            using var conexion = new SqlConnection(_Config.GetConnectionString("MyDB"));
            conexion.Open();
            var param = new DynamicParameters();
            param.Add("@id", ConsolaId);
            var oConsola = conexion.Query<Consola>("DeConsola", param, commandType: System.Data.CommandType.StoredProcedure)
            .SingleOrDefault();
            return Ok(oConsola);
        }
    }
}
