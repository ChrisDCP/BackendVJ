using BackProyecto.models;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace BackProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectoresController : ControllerBase
    {
        private IConfiguration _Config;

        public DirectoresController(IConfiguration config)
        {
            _Config = config;
        }

        [HttpGet]
        public async Task<ActionResult<List<Director>>> GetDirector()
        {
            using var conexion = new SqlConnection(_Config.GetConnectionString("MyDB"));
            conexion.Open();
            var oDirector = conexion.Query<Director>("MosDirector", commandType: System.Data.CommandType.StoredProcedure);
            return Ok(oDirector);
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<List<Director>>> GetDirectorId(int DirectorId)
        {
            using var conexion = new SqlConnection(_Config.GetConnectionString("MyDB"));
            conexion.Open();
            var param = new DynamicParameters();
            param.Add("@id", DirectorId);
            var oDirector = conexion.Query<Director>("MosDirector", param, commandType: System.Data.CommandType.StoredProcedure)
            .SingleOrDefault();
            return Ok(oDirector);
        }

        [HttpPost]
        public async Task<ActionResult<List<Director>>> InsertDirector(Director dir)
        {
            using var conexion = new SqlConnection(_Config.GetConnectionString("MyDB"));
            conexion.Open();
            var param = new DynamicParameters();
            param.Add("@id", dir.id);
            param.Add("@id_Estudio", dir.id_Estudio);
            param.Add("@nombre", dir.nombre);
            param.Add("@apellido", dir.apellido);
            param.Add("@pais", dir.pais);
            var oDirector = conexion.Query<Director>("InDirector", param, commandType: System.Data.CommandType.StoredProcedure)
            .SingleOrDefault();
            return Ok(oDirector);
        }

        [HttpPut]
        public async Task<ActionResult<List<Director>>> ActDirector(Director dir)
        {
            using var conexion = new SqlConnection(_Config.GetConnectionString("MyDB"));
            conexion.Open();
            var param = new DynamicParameters();
            param.Add("@id", dir.id);
            param.Add("@nombre", dir.nombre);
            param.Add("@apellido", dir.apellido);
            param.Add("@pais", dir.pais);
            var oDirector = conexion.Query<Director>("UpdDirector", param, commandType: System.Data.CommandType.StoredProcedure)
            .SingleOrDefault();
            return Ok(oDirector);
        }

        [HttpDelete("{ID}")]
        public async Task<ActionResult<List<Director>>> DelDirector(int DirectorId)
        {
            using var conexion = new SqlConnection(_Config.GetConnectionString("MyDB"));
            conexion.Open();
            var param = new DynamicParameters();
            param.Add("@id", DirectorId);
            var oDirector = conexion.Query<Director>("DEDirector", param, commandType: System.Data.CommandType.StoredProcedure)
            .SingleOrDefault();
            return Ok(oDirector);
        }



    }
}
