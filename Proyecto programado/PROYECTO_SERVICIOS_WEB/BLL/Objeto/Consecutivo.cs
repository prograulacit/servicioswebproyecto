using System.Collections.Generic;
using System.Data;
using BLL.Logica;

namespace BLL.Objeto
{
    public class Consecutivo
    {
        public string id { get; set; }
        public string tipoConsecutivo { get; set; }
        public string descripcion { get; set; }
        public string prefijo { get; set; }
        public string rangoInicial { get; set; }
        public string rangoFinal { get; set; }

        public List<Consecutivo> traerConsecutivos()
        {
            DataSet datos = Memoria.logica_database
                .queryConRetornoDeDatos_sinParametros(
                Memoria.logica_database.stringDeConexion_baseDeDatos_principal,
                "sp_consecutivo_traer"
                );

            if (datos.Tables[0].Rows.Count > 0)
            {
                List<Consecutivo> lista_consecutivos = new List<Consecutivo>();
                for (int i = 0; i < datos.Tables[0].Rows.Count; i++)
                {
                    lista_consecutivos.Add(
                        new Consecutivo
                            (
                            Encriptacion.desencriptar(datos.Tables[0].Rows[i]["ID"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["tipoConsecutivo"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["descripcion"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["prefijo"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["rangoInicial"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["rangofinal"].ToString())
                            )
                        );
                }
                return lista_consecutivos;
            }
            else
            {
                return null;
            }
        }

        public void guardarConsecutivo_baseDeDatos(Consecutivo consecutivo)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            string nombre_storedProcedure = "sp_consecutivo_crear";

            Memoria.logica_database
                .querySimple(stringDeConexion
                , nombre_storedProcedure
                , this.parametros
                , return_valores(consecutivo));
        }

        public void actualizarConsecutivo_baseDeDatos(Consecutivo consecutivo)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            string nombre_storedProcedure = "sp_consecutivo_actualizar";

            Memoria.logica_database
                .querySimple(stringDeConexion
                , nombre_storedProcedure
                , this.parametros
                , return_valores(consecutivo));
        }

        public void eliminarConsecutivo_baseDeDatos(string id)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_principal;
            string nombre_storedProcedure = "sp_consecutivo_eliminar";

            string[] parametros = { "ID" };
            string[] valores = { id };

            Memoria.logica_database
               .querySimple(stringDeConexion
               , nombre_storedProcedure
               , parametros
               , valores);
        }

        /// <summary>
        /// Retorna un objeto de tipo Consecutivo el cual es el reflejo exacto de un
        /// registro de Consecutivo en la base de datos. Se utilizara para aumentar el valor
        /// descripcion del consecutivo principalmente.
        /// </summary>
        /// <param name="elemento_requerido">String con el ID requerido para trabajar con.
        /// Estos pueden ser, admin, musica, libro, pelicula o transaccion. Dependiendo
        /// de el valor dado, este sera el objeto consecutivo que sera retornado.</param>
        /// <returns>Objeto Consecutivo el cual es el reflejo exacto de un registro
        /// en la base de datos.</returns>
        public Consecutivo traerConsecutivo_registroReflejadoEnDB(string elemento_requerido)
        {
            List<Consecutivo> lista_consecutivos = traerConsecutivos();

            switch (elemento_requerido)
            {
                case "pelicula":
                    for (int i = 0; i < lista_consecutivos.Count; i++)
                    {
                        if (lista_consecutivos[i].id == "pelicula")
                        {
                            return lista_consecutivos[i];
                        }
                    }
                    break;
                case "musica":
                    for (int i = 0; i < lista_consecutivos.Count; i++)
                    {
                        if (lista_consecutivos[i].id == "musica")
                        {
                            return lista_consecutivos[i];
                        }
                    }
                    break;
                case "libro":
                    for (int i = 0; i < lista_consecutivos.Count; i++)
                    {
                        if (lista_consecutivos[i].id == "libro")
                        {
                            return lista_consecutivos[i];
                        }
                    }
                    break;
                case "admin":
                    for (int i = 0; i < lista_consecutivos.Count; i++)
                    {
                        if (lista_consecutivos[i].id == "admin")
                        {
                            return lista_consecutivos[i];
                        }
                    }
                    break;
                case "transaccion":
                    for (int i = 0; i < lista_consecutivos.Count; i++)
                    {
                        if (lista_consecutivos[i].id == "transaccion")
                        {
                            return lista_consecutivos[i];
                        }
                    }
                    break;
                default:
                    return null;
            }
            return null;
        }

        public Consecutivo() { }

        public Consecutivo(string id
            , string tipoConsecutivo
            , string descripcion
            , string prefijo
            , string rangoInicial
            , string rangoFinal)
        {
            this.id = id;
            this.tipoConsecutivo = tipoConsecutivo;
            this.descripcion = descripcion;
            this.prefijo = prefijo;
            this.rangoInicial = rangoInicial;
            this.rangoFinal = rangoFinal;
        }

        string[] parametros = {
                "ID"
                ,"tipoConsecutivo"
                , "descripcion"
                , "prefijo"
                , "rangoInicial"
                , "rangoFinal"};

        private string[] return_valores(Consecutivo consecutivo)
        {
            string[] valores = {
                consecutivo.id,
                consecutivo.tipoConsecutivo,
                consecutivo.descripcion,
                consecutivo.prefijo,
                consecutivo.rangoInicial,
                consecutivo.rangoFinal};
            return valores;
        }
    }
}
