using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using BackProyecto.models;
using Dapper;

namespace BackProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        private IConfiguration _Config;

        public EstudiosController(IConfiguration config)
        {
            _Config = config;
        }

        [HttpGet]
         public async Task<ActionResult<List<Estudio>>> GetEstudio()
         {
             using var conexion = new SqlConnection(_Config.GetConnectionString("MyDB"));
             conexion.Open();
             var oEstudio = conexion.Query<Estudio>("MosEstudio", commandType: System.Data.CommandType.StoredProcedure);
             return Ok(oEstudio);
         }

        [HttpGet ( "{ID}")]
        public async Task<ActionResult<List<Estudio>>> GetEstudioId(int EstudioId)
        {
            using var conexion = new SqlConnection(_Config.GetConnectionString("MyDB"));
            conexion.Open();
            var param = new DynamicParameters();
            param.Add("@id", EstudioId);
            var oEstudio = conexion.Query<Estudio>("MosEstudio", param, commandType: System.Data.CommandType.StoredProcedure)
            .SingleOrDefault();
            return Ok(oEstudio);
        }

        [HttpPost]
        public async Task<ActionResult<List<Estudio>>> InsertEstudio(Estudio Es)
        {
            using var conexion = new SqlConnection(_Config.GetConnectionString("MyDB"));
            conexion.Open();
            var param = new DynamicParameters();
            param.Add("@id", Es.id);
            param.Add("@nombre", Es.nombre);
            param.Add("@pais", Es.pais);
            var oEstudio = conexion.Query<Estudio>("InEstudio", param, commandType: System.Data.CommandType.StoredProcedure)
            .SingleOrDefault();
            return Ok(oEstudio);
        }

        [HttpPut]
        public async Task<ActionResult<List<Estudio>>> ActEstudio(Estudio Es)
        {
            using var conexion = new SqlConnection(_Config.GetConnectionString("MyDB"));
            conexion.Open();
            var param = new DynamicParameters();
            param.Add("@id", Es.id);
            param.Add("@nombre", Es.nombre);
            param.Add("@pais", Es.pais);
            var oEstudio = conexion.Query<Estudio>("UpdEstudio", param, commandType: System.Data.CommandType.StoredProcedure)
            .SingleOrDefault();
            return Ok(oEstudio);
        }

        [HttpDelete ("{ID}")]
        public async Task<ActionResult<List<Estudio>>> DelEstudio(int EstudioId)
        {
            using var conexion = new SqlConnection(_Config.GetConnectionString("MyDB"));
            conexion.Open();
            var param = new DynamicParameters();
            param.Add("@id", EstudioId);
            var oEstudio = conexion.Query<Estudio>("DEEstudio", param, commandType: System.Data.CommandType.StoredProcedure)
            .SingleOrDefault();
            return Ok(oEstudio);
        }
    }
}
