using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DBLogica
    {

        public DBLogica() { }

        public DBLogica(bool datos_encriptados)
        {
            this.datos_encriptados = datos_encriptados;
        }

        // Si es true, los datos con los que la aplicación está trabajando están
        // encriptados. Si es false, se está trabajando con datos en texto plano.
        // Los datos serán siempre enviados a la base de datos según el estado de
        // ésta variable. Por defecto la variable sera false si no es establecida.
        private bool datos_encriptados = false;

        ///////////////////////////////////////////////////
        // Strings de conexión de las bases de datos.
        ///////////////////////////////////////////////////
        //////////////////////////////////////////////////////
        public string stringDeConexion_baseDeDatos_principal =
            @"Data Source=LAPTOP-REB68UHC\SQLEXPRESS;Initial Catalog=SERVICIOSWEB_MAIN;Integrated Security=True";
            //"Data Source=.;Initial Catalog=SERVICIOSWEB_MAIN;Integrated Security=True";
        public string stringDeConexion_baseDeDatos_pagos =
            @"Data Source=LAPTOP-REB68UHC\SQLEXPRESS;Initial Catalog=SERVICIOSWEB_PAGOS;Integrated Security=True";
            //"Data Source=.;Initial Catalog=SERVICIOSWEB_MAIN;Integrated Security=True";
        //////////////////////////////////////////////////////
        //////////////////////////////////////////////////////
        //////////////////////////////////////////////////////

        /// <summary>
        /// Ejecuta una consulta de SQL en donde no es requerido un retorno de datos.
        /// Ejemplos de uso serian el agregar o actualizar registros.
        /// </summary>
        /// <param name="stringDeConexion">String de conexión de la base de datos a usar.</param>
        /// <param name="nombre_storedProcedure">Nombre del Store Procedure a usar.</param>
        /// <param name="parametros">Array de parametros a usar con relación al Store Procedure.</param>
        /// <param name="valores">Array de valores a usar con relación al Store Procedure.</param>
        public void querySimple(
            string stringDeConexion,
            string nombre_storedProcedure,
            string[] parametros,
            string[] valores)
        {
            SqlConnection con = new SqlConnection(stringDeConexion);
            SqlCommand cmd = new SqlCommand(nombre_storedProcedure, con);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < parametros.Length; i++)
            {
                string valor_entrante;
                if (datos_encriptados) 
                { 
                    valor_entrante = Encriptacion.encriptar(valores[i]);
                } else 
                { 
                    valor_entrante = valores[i]; 
                }
                cmd.Parameters.AddWithValue(parametros[i]
                    , SqlDbType.NVarChar).Value = valor_entrante;
            }
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Exito en la ejecución querySimple");
            }
            catch (Exception ex)
            {
                Console.WriteLine("FALLO EN LA EJECUCIÓN querySimple!!!");
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Ejecuta una consulta de SQL y espera una respuesta de datos.
        /// </summary>
        /// <param name="stringDeConexion">String de conexión de la base de datos a usar.</param>
        /// <param name="nombre_storedProcedure">Nombre del Store Procedure a usar.</param>
        /// <param name="parametros">Array de parametros a usar con relación al Store Procedure.</param>
        /// <param name="valores">Array de valores a usar con relación al Store Procedure.</param>
        /// <returns>DataSet con los registros encontrados.</returns>
        public DataSet queryConRetornoDeDatos(
            string stringDeConexion,
            string nombre_storedProcedure,
            string[] parametros,
            string[] valores)
        {
            SqlConnection con = new SqlConnection(stringDeConexion);
            con.Open();
            SqlCommand cmd = new SqlCommand(nombre_storedProcedure, con);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < parametros.Length; i++)
            {
                string valor_entrante;
                if (datos_encriptados) { valor_entrante = Encriptacion.encriptar(valores[i]); } else { valor_entrante = valores[i]; }
                cmd.Parameters.AddWithValue(parametros[i], SqlDbType.NVarChar).Value = valor_entrante;
            }
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            con.Close();
            return ds;
        }

        /// <summary>
        /// Ejecuta una consulta de SQL y espera una respuesta de datos. Se utiliza cuando se hace uso
        /// se un Store Procedure que no requiere parametros.
        /// </summary>
        /// <param name="stringDeConexion">String de conexión de la base de datos a usar.</param>
        /// <param name="nombre_storedProcedure">Nombre del Store Procedure a usar.</param>
        /// <returns>DataSet con los registros encontrados.</returns>
        public DataSet queryConRetornoDeDatos_sinParametros(
            string stringDeConexion,
            string nombre_storedProcedure)
        {
            SqlConnection con = new SqlConnection(stringDeConexion);
            con.Open();
            SqlCommand cmd = new SqlCommand(nombre_storedProcedure, con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            con.Close();
            return ds;
        }
    }
}

