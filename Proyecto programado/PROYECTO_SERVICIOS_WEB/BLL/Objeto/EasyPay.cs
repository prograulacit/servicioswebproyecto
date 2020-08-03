using BLL.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Objeto
{
    public class EasyPay
    {
        public string id { get; set; }
        public string IDusuario { get; set; }
        public string numeroCuenta { get; set; }
        public string codigoSeguridad { get; set; }
        public string contrasenia { get; set; }
        public string monto { get; set; }

        public List<EasyPay> traer_easyPays()
        {
            DataSet datos = Memoria.logica_database
             .queryConRetornoDeDatos_sinParametros(
             Memoria.logica_database.stringDeConexion_baseDeDatos_pagos,
             "sp_easypay_leer"
             );

            if (datos.Tables[0].Rows.Count > 0)
            {
                List<EasyPay> lista_easyPays = new List<EasyPay>();
                for (int i = 0; i < datos.Tables[0].Rows.Count; i++)
                {
                    lista_easyPays.Add(
                        new EasyPay
                            (
                            Encriptacion.desencriptar(datos.Tables[0].Rows[i]["ID"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["IDusuario"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["numeroCuenta"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["codigoSeguridad"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["contrasenia"].ToString())
                            , Encriptacion.desencriptar(datos.Tables[0].Rows[i]["monto"].ToString())
                            )
                        );
                }
                return lista_easyPays;
            }
            else
            {
                return null;
            }
        }

        public void guardar_easyPay(EasyPay easypay)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_pagos;
            string nombre_storedProcedure = "sp_easypay_crear";

            Memoria.logica_database
                .querySimple(stringDeConexion
                , nombre_storedProcedure
                , this.parametros
                , return_valores(easypay));
        }

        public void actualizar_easypay(EasyPay easypay)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_pagos;
            string nombre_storedProcedure = "sp_easypay_actualizar";

            Memoria.logica_database
                .querySimple(stringDeConexion
                , nombre_storedProcedure
                , this.parametros
                , return_valores(easypay));
        }

        public void eliminar_easypay(string id)
        {
            string stringDeConexion = Memoria.logica_database.stringDeConexion_baseDeDatos_pagos;
            string nombre_storedProcedure = "sp_easypay_eliminar";

            string[] parametros = { "ID" };
            string[] valores = { id };

            Memoria.logica_database
               .querySimple(stringDeConexion
               , nombre_storedProcedure
               , parametros
               , valores);
        }

        public EasyPay() { }

        public EasyPay(string id
            , string iDusuario
            , string numeroCuenta
            , string codigoSeguridad
            , string contrasenia
            , string monto)
        {
            this.id = id;
            IDusuario = iDusuario;
            this.numeroCuenta = numeroCuenta;
            this.codigoSeguridad = codigoSeguridad;
            this.contrasenia = contrasenia;
            this.monto = monto;
        }

        string[] parametros = {
                "ID"
                ,"IDusuario"
                ,"numeroCuenta"
                ,"codigoSeguridad"
                ,"contrasenia"
                ,"monto"};

        private string[] return_valores(EasyPay easypay)
        {
            string[] valores = {
                easypay.id
                ,easypay.IDusuario
                ,easypay.numeroCuenta
                ,easypay.codigoSeguridad
                ,easypay.contrasenia
                ,easypay.monto
            };
            return valores;
        }
    }
}
