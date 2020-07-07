using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DBLogica
    {
        public static bool encriptar_datos = true;

        // Strings de conexión de las bases de datos.
        ///////////////////////////////////////////////////
        public static string stringDeConexion_baseDeDatos_principal =
            "Data Source=10.172.61.116;Initial Catalog=SERVICIOSWEB_MAIN;User ID=admin;Password=admin123";
        public static string stringDeConexion_baseDeDatos_pagos = "";

        /// <summary>
        /// Ejecuta una consulta de SQL en donde no es requerido un retorno de datos.
        /// Ejemplos de uso serian el agregar o actualizar registros.
        /// </summary>
        /// <param name="stringDeConexion">String de conexión de la base de datos a usar.</param>
        /// <param name="nombre_storedProcedure">Nombre del Store Procedure a usar.</param>
        /// <param name="parametros">Array de parametros a usar con relación al Store Procedure.</param>
        /// <param name="valores">Array de valores a usar con relación al Store Procedure.</param>
        public static void querySimple(
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
                if (encriptar_datos) { valor_entrante = Encriptacion.encriptar(valores[i]); }else{ valor_entrante = valores[i]; }
                cmd.Parameters.AddWithValue(parametros[i], SqlDbType.NVarChar).Value = valor_entrante;
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
        public static DataSet queryConRetornoDeDatos(
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
                if (encriptar_datos) { valor_entrante = Encriptacion.encriptar(valores[i]); } else { valor_entrante = valores[i]; }
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
        public static DataSet queryConRetornoDeDatos_sinParametros(
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

