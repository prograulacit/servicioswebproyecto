<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Backend.Master" AutoEventWireup="true" CodeBehind="peliculasAdmin.aspx.cs" Inherits="Web_Application.Paginas.Backend.peliculasAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Public/scripts/peliculasAdmin.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@9"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="titulo">
        Administracion de peliculas
    </div>

    <div class="descripcion">
        Aquí puede administrar los recursos de peliculas
    </div>

    <div id="boton_crear">
        <button type="button" onclick="contenedorCrear_visible('inline'); 
        contenedorTabla_visible('none'); 
        contenedorEditar_visible('none')">Crear nuevo registro</button>
    </div>

    <div id="contenedor_tabla">
        Cargando...
        <div class="spinner-border text-primary" role="status">
            <span class="sr-only">Loading...</span>
        </div>
    </div>

    <div id="contenedor_editar">
        <div class="titulo">
            Editando pelicula
        </div>
        ID:
        <br>
        <input type="text" name="" id="editar_id">
        <br>
        Nombre:
        <br>
        <input type="text" name="" id="editar_nombre">
        <br>
        Genero:
        <br>
        <input type="text" name="" id="editar_genero">
        <br>
        Año:
        <br>
        <input type="text" name="" id="editar_anio">
        <br>
        Idioma:
        <br>
        <input type="text" name="" id="editar_idioma">
        <br>
        Actores:
        <br>
        <input type="text" name="" id="editar_actores">
        <br>
        Archivo descarga:
        <br>
        <input type="text" name="" id="editar_descarga">
        <br>
        Archivo previsualizacion:
        <br>
        <input type="text" name="" id="editar_previsualizacion">
        <br>
        Monto:
        <br>
        <input type="text" name="" id="editar_monto">
        <br>
        <button type="button" onclick="guardar_cambios()">Guardar cambios</button>
        <button>Cancelar</button>
    </div>

    <div id="contenedor_crear">
        Nombre:
        <br>
        <input type="text" name="" id="crear_nombre">
        <br>
        Genero:
        <br>
        <input type="text" name="" id="crear_genero">
        <br>
        Año:
        <br>
        <input type="text" name="" id="crear_anio">
        <br>
        Idioma:
        <br>
        <input type="text" name="" id="crear_idioma">
        <br>
        Actores:
        <br>
        <input type="text" name="" id="crear_actores">
        <br>
        Archivo descarga:
        <br>
        <input type="text" name="" id="crear_descarga">
        <br>
        Archivo previsualizacion:
        <br>
        <input type="text" name="" id="crear_previsualizacion">
        <br>
        Monto:
        <br>
        <input type="text" name="" id="crear_monto">
        <br>
        <button type="button" onclick="crear_elemento()">Crear nueva pelicula</button>
        <button>Cancelar</button>
    </div>

    <script>
        cargar_elementos();
        contenedorTabla_visible("inline");
        contenedorEditar_visible("none");
        contenedorCrear_visible("none");
    </script>
</asp:Content>