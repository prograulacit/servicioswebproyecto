<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Backend.Master" AutoEventWireup="true" CodeBehind="categoriasLibro.aspx.cs" Inherits="Web_Application.Paginas.Backend.categoriasLibro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Public/scripts/categoriasLibro.js"></script>
    <link rel="stylesheet" href="../../Public/estilos/generosCategoriasProductos.css">
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@9"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="./index.aspx">Inicio</a></li>
            <li class="breadcrumb-item active" aria-current="page">Administracion de generos y categorias.</li>
        </ol>
    </nav>
    <div class="tp-3 mb-2 bg-dark text-white text-center text-uppercase font-weight-bold">
        Administracion de categorias de libro
    </div>

    <div class="text-font-normal">
        Utilice los controles para administrar
    </div>

     <div class="container">
        <div class="row justify-content-center">
            <div class="form-group col-4">
                 <div class="contenedor">
                    <div class="formulario">
                        <br/>
                        <br/>
                        <h3 class="text-font-normal">Ingresar categoria nuevo</h3>
                        <input class="form-control" type="text" name="ingresar_categoria_contenido" id="input_elementoNuevo">
                        <br/>
                        <button class="btn btn-primary justify-content-center" type="button" onclick="ingresar_elemento()">Guardar</button>
                    </div>
                     <br/>
                     <br/>
                    <div class="formulario">
                        <h3>Editar categoria</h3>
                        <label class="text-font-normal" for="">ID</label>
                        
                        <input class="form-control" type="text" name="actualizar_categoria_id" id="inputId_elementoActualizar">
                        
                        <label class="text-font-normal" for="">Nueva categoria</label>
                        
                        <input class="form-control" type="text" name="actualizar_genero_contenido" id="inputContenido_elementoActualizar">
                        <br>
                        <button class="btn btn-primary justify-content-center" type="button" onclick="actualizar_elemento()">Actualizar</button>
                    </div>
                     <br/>
                     <br/>
                    <div class="formulario">
                        <h3>Eliminar categoria</h3>
                        <label class="text-font-normal" for="">ID</label>
                        
                        <input class="form-control" type="text" name="eliminar_datos" id="inputId_elementoEliminar">
                        <br/>
                        <button class="btn btn-primary justify-content-center" type="button" onclick="eliminar_elemento()">Eliminar</button>
                    </div>
                </div>
            </div>
         </div>
      </div>

    <div class="formulario">
        <div id="http_response_contenido">
            <div class="spinner-border text-primary" role="status">
                <span class="sr-only">Loading...</span>
            </div>
            Cargando...
        </div>
    </div>

    <script>
        obtener_elementos();
    </script>
</asp:Content>
