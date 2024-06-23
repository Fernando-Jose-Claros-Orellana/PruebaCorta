using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PruebaCorta.Models;
using System.Data;

namespace PruebaCorta.LogicaAccesoDatos
{
    public class AccesoDatos
    {
        private readonly AppDBContext _context;

        public AccesoDatos(AppDBContext context)
        {
            _context = context;
        }

        //------------------Pregunta------------------------------------

        public async Task<List<PreguntaM>> ObtenerPregunta()
        {
            return await _context.PreguntaM.FromSqlRaw("EXEC ObtenerPreguntas").ToListAsync();
        }

        public async Task Estado(PreguntaM pregunta,int id)
        {
            var parameters = new[]
            {
            new SqlParameter("@Id", id),
            new SqlParameter("@Estado", pregunta.Estado ),
        };
            await _context.Database.ExecuteSqlRawAsync("EXEC Estado @Id, @Estado", parameters);
        }

        public async Task CrearPregunta(PreguntaM pregunta)
        {
            var parameters = new[]
            {
            new SqlParameter("@Nombre", pregunta.Nombre),
            new SqlParameter("@Pregunta", pregunta.Pregunta),
            new SqlParameter("@Estado", pregunta.Estado),

        };
            await _context.Database.ExecuteSqlRawAsync("EXEC CrearPregunta @Nombre, @Pregunta, @Estado", parameters);
        }

        //----------------------------------------------------------

        //-------------------Repuesta--------------------------------- 

        public async Task<List<RespuestaM>> ObtenerRespuesta(int id)
        {
            var parameter = new SqlParameter("@IdPregunta", id);
            var respuesta = await _context.RespuestaM
                .FromSqlRaw("EXEC ObtenerRespuestas @IdPregunta", parameter)
                .ToListAsync();

            return respuesta;
        }
        public async Task CrearRespuesta(RespuestaM respuesta)
        {
            var parameters = new[]
            {

            new SqlParameter("@IdPregunta", respuesta.IdPregunta),
            new SqlParameter("@Nombre", respuesta.Nombre),
            new SqlParameter("@Respuesta", respuesta.Respuesta),
        };
            await _context.Database.ExecuteSqlRawAsync("EXEC CrearRespuesta @IdPregunta, @Nombre, @Respuesta", parameters);
        }

        //----------------------------------------------------------    

        //------------------------------Crear Registro Usuario--------------------

        public async Task<bool> Crear(Usuario usuario)
        {
            var nombreParameter = new SqlParameter("@Nombre", usuario.Nombre);
            var contrasenaParameter = new SqlParameter("@Contrasena", usuario.Contrasena);

            var resultParameter = new SqlParameter
            {
                ParameterName = "@i",
                SqlDbType = SqlDbType.Bit,
                Direction = ParameterDirection.Output
            };

            var parameters = new[] { nombreParameter, contrasenaParameter, resultParameter };

            await _context.Database.ExecuteSqlRawAsync("EXEC CrearUsuario @Nombre, @Contrasena, @i OUTPUT", parameters);

            bool creacionExitosa = (bool)resultParameter.Value;

            return creacionExitosa;
        }

        //--------------------------------------------------------------------------------------------

        //----------------------------------Login Usuario ----------------------------------------------

        public async Task<bool> Login(Usuario usuario)
        {
            var NombreParameter = new SqlParameter("@Nombre", usuario.Nombre);
            var contrasenaParameter = new SqlParameter("@Contrasena", usuario.Contrasena);

            var resultParameter = new SqlParameter
            {
                ParameterName = "@i",
                SqlDbType = SqlDbType.Bit,
                Direction = ParameterDirection.Output
            };

            var parameters = new[] { NombreParameter, contrasenaParameter, resultParameter };

            await _context.Database.ExecuteSqlRawAsync("EXEC Login @Nombre, @Contrasena, @i OUTPUT", parameters);

            bool loginCorrecto = (bool)resultParameter.Value;

            return loginCorrecto;
        }

        //-----------------------------------------------------------------------

    }
}
