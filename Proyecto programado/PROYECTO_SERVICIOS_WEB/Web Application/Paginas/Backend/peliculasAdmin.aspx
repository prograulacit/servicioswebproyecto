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
        <button class="btn btn-primary justify-content-center" type="button" onclick="contenedorCrear_visible('inline'); 
        contenedorTabla_visible('none'); 
        contenedorEditar_visible('none')">Crear nuevo registro</button>
    </div>

    <div id="contenedor_tabla">
        Cargando...
        <div class="spinner-border text-primary" role="status">
            <span class="sr-only">Loading...</span>
        </div>
    </div>

    <div class="container">
        <div class="row justify-content-center">
            <div class="form-group col-4">
                <div id="contenedor_editar">
                    <div class="titulo">
                        Editando pelicula
                    </div>
                    <label class="text-font-normal">ID:</label>
                    <br>
                    <input disabled type="text" name="" class="editar_id form-control">
                    <br>
                    <label class="text-font-normal">Nombre:</label>
                    <br>
                    <input type="text" name="" class="editar_nombre form-control">
                    <br>
                    <label class="text-font-normal">Genero:</label>
                    <br>
                    <select id="editarGenero" class="form-control editar_genero"></select>
                    <br>
                    <label class="text-font-normal">Año:</label>
                    <br>
                    <input type="text" name="" class="editar_anio form-control">
                    <br>
                    <label class="text-font-normal">Idioma:</label>
                    <br>
                    <input type="text" name="" class="editar_idioma form-control">
                    <br>
                    <label class="text-font-normal">Actores:</label>
                    <br>
                    <input type="text" name="" class="editar_actores form-control">
                    <br>
                    <label class="text-font-normal">Monto:</label>
                    <br>
                    <input type="number" name="" class="editar_monto form-control">
                    <br>
                    <label class="text-font-normal">Nombre archivo descarga:</label>
                    <br>
                    <input type="text" name="" id="editarNombreDescargaPelicula" class="editar_nombre_descarga_pelicula form-control" runat="server">
                    <br>
                    <label class="text-font-normal">Archivo Pelicula:</label>
                    <br>
                    <input id="editarArchivoPelicula" class="editar_archivo_pelicula form-control" type="file" accept=".mp4,video/*" runat="server"/>
                    <br>
                    <label class="text-font-normal">Nombre archivo previsualizacion:</label>
                    <br>
                    <input type="text" name="" id="editarNombrePrevisualizacionPelicula" class="editar_nombre_previsualizacion_pelicula form-control" runat="server">
                    <br>
                    <label class="text-font-normal">Archivo Pelicula previsualizacion:</label>
                    <br>
                    <input id="editarArchivoPeliculaPrev" class="editar_archivo_pelicula_prev form-control" type="file" accept=".mp4,video/*" runat="server"/>
                    <br>
                    <button class="btn btn-primary justify-content-center" type="button" onclick="guardar_cambios()">Guardar cambios</button>
                    <button class="btn btn-primary justify-content-center" >Cancelar</button>
                </div>

                <div id="contenedor_crear">
                    <label class="text-font-normal">Nombre:</label>
                    <br>
                    <input type="text" name="" class="crear_nombre form-control">
                    <br>
                    <label class="text-font-normal">Genero:</label>
                    <br>
                    <select id="crearGenero" class="form-control crear_genero form-control"></select>
                    <br>
                    <label class="text-font-normal">Año:</label>
                    <br>
                    <input type="text" name="" class="crear_anio form-control">
                    <br>
                    <label class="text-font-normal">Idioma:</label>
                    <br>
                    <input type="text" name="" class="crear_idioma form-control">
                    <br>
                    <label class="text-font-normal">Actores:</label>
                    <br>
                    <input type="text" name="" class="crear_actores form-control">
                    <br>
                    <label class="text-font-normal">Monto:</label>
                    <br>
                    <input type="number" name="" class="crear_monto form-control">
                    <br>
                    <label class="text-font-normal">Nombre archivo descarga:</label>
                    <br>
                    <input type="text" name="" id="nombreArchivoPelicula" class="nombre_archivo_pelicula form-control" runat="server">
                    <br>
                    <label class="text-font-normal">Archivo Pelicula:</label>
                    <br>
                    <input id="archivoPelicula" class="archivo_pelicula form-control" type="file" accept=".mp4,video/*" runat="server"/>
                    <br>
                    <label class="text-font-normal">Nombre archivo previsualizacion:</label>
                    <br>
                    <input type="text" id="nombrePrevisualizacionPelicula" class="nombre_previsualizacion_pelicula form-control" runat="server">
                    <br>
                    <label class="text-font-normal">Archivo Pelicula previsualizacion:</label>
                    <br>
                    <input id="archivoPeliculaPrev" class="archivo_pelicula_prev form-control" type="file" accept=".mp4,video/*" runat="server"/>
                    <br>
                    <button class="btn btn-primary justify-content-center" type="button" onclick="crear_elemento()">Crear nueva pelicula</button>
                    <button class="btn btn-primary justify-content-center" >Cancelar</button>
                </div>
            </div>
        </div>
    </div>


    <%--hidden elements--%>
    <asp:Button class="descargar_archivo_pelicula" id="descargarArchivoPelicula" runat="server" Text="" OnClick="subirArchivosPelicula_Click" style="display:none"/>
    <asp:Button class="eliminar_archivo_pelicula" id="eliminarArchivoPelicula" runat="server" Text="" OnClick="eliminarArchivoPelicula_Click" style="display:none"/>
    <asp:Button class="editar_archivos_pelicula" id="editarArchivosPelicula" runat="server" Text="" OnClick="editarArchivosPelicula_Click" style="display:none"/>
    <input type="text" name="" id="viejoNombreDescargaPelicula" class="viejo_nombre_descarga_pelicula" runat="server" style="display:none">
    <input type="text" name="" id="viejoNombrePrevisualizacionPelicula" class="viejo_nombre_previsualizacion_pelicula" runat="server" style="display:none">

    <script>
        cargar_elementos();
        traer_generos();
        contenedorTabla_visible("inline");
        contenedorEditar_visible("none");
        contenedorCrear_visible("none");
    </script>
</asp:Content>