<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Backend.Master" AutoEventWireup="true" CodeBehind="musicaAdmin.aspx.cs" Inherits="Web_Application.Paginas.Backend.musicaAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Public/scripts/musicaAdmin.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@9"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="titulo">
        Administracion de musica
    </div>

    <div class="descripcion">
        Aquí puede administrar los recursos de musica
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
            Editando musica
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
        Tipo interpretacion:
        <br>
        <input type="text" name="" id="editar_tipoInterpretacion">
        <br>
        Idioma:
        <br>
        <input type="text" name="" id="editar_idioma">
        <br>
        Pais:
        <br>
        <input type="text" name="" id="editar_pais">
        <br>
        Disquera:
        <br>
        <input type="text" name="" id="editar_disquera">
        <br>
        Nombre del disco:
        <br>
        <input type="text" name="" id="editar_nombreDisco">
        <br>
        Año:
        <br>
        <input type="text" name="" id="editar_anio">
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
        Tipo interpretacion:
        <br>
        <input type="text" name="" id="crear_tipoInterpretacion">
        <br>
        Idioma:
        <br>
        <input type="text" name="" id="crear_idioma">
        <br>
        Pais:
        <br>
        <input type="text" name="" id="crear_pais">
        <br>
        Disquera:
        <br>
        <input type="text" name="" id="crear_disquera">
        <br>
        Nombre del disco:
        <br>
        <input type="text" name="" id="crear_nombreDisco">
        <br>
        Año:
        <br>
        <input type="text" name="" id="crear_anio">
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
        <button type="button" onclick="crear_elemento()">Crear nueva musica</button>
        <button>Cancelar</button>
    </div>

    <script>
        cargar_elementos();
        contenedorTabla_visible("inline");
        contenedorEditar_visible("none");
        contenedorCrear_visible("none");
    </script>
</asp:Content>
