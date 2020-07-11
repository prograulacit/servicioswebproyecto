using System.Web.Http;

namespace Web_Application.API
{
    public class TestController : ApiController
    {
        // GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

            //api/test
        public string Get()
        {
            return "funciona";
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            
            return "value";
        }

        // POST api/<controller>
        public string Post([FromBody]string value)
        {
            string[] parametrosAdmin =
                {"ID"
                ,"nombreUsuario"
                , "contrasenia"
                , "correoElectronico"
                , "preguntaSeguridad"
                , "respuestaSeguridad"
                , "adminMaestro"
                , "adminSeguridad"
                , "adminMantenimiento"
                , "adminConsultas" };
            string[] valoresAdmin = {
               "0",
                "0",
                "0",
                "0",
                "0",
                "0",
                "0",
                "0",
                "0",
                "0"};

            //BLL.Logica.Memoria.logica_database.querySimple(
            //    BLL.Logica.Memoria.logica_database.stringDeConexion_baseDeDatos_principal,
            //    "sp_admin_crear",
            //    parametrosAdmin, valoresAdmin);
            System.Environment.Exit(1);
            return value;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}