﻿using BLL.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Application.Paginas.Backend
{
    public partial class consecutivos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Memoria.sesionAdminDatos != null)
            {
                bool adminMaestro = Memoria.sesionAdminDatos.adminMaestro;
                bool mantenimiento = Memoria.sesionAdminDatos.adminMantenimiento;

                if (!adminMaestro && !mantenimiento)
                {
                    Response.Redirect("~/Paginas/Backend/Index.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Paginas/Backend/Index.aspx");
            }
        }
    }
}