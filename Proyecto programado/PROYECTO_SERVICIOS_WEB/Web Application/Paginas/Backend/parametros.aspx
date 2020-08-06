<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Backend.Master" AutoEventWireup="true" CodeBehind="parametros.aspx.cs" Inherits="Web_Application.Paginas.Backend.parametros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Public/scripts/parametros.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@9"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="./index.aspx">Inicio</a></li>
            <li class="breadcrumb-item active" aria-current="page">Administracion de parametros</li>
        </ol>
    </nav>
    <div class="tp-3 mb-2 bg-dark text-white text-center text-uppercase font-weight-bold">
        Parametros
    </div>

    <div class="text-font-normal">
        Administración de parametros.
    </div>
    <br>
    <div class="container">
        <div class="row justify-content-center">
            <div class="form-group col-4">
                <div>
                    <label class="text-font-normal">Ruta de almacenamiento previsualizacion Libros</label>
                    <br>
                    <input class="form-control" type="text" name="" id="pre_libros">
                    <br>
                    <label class="text-font-normal">Ruta de almacenamiento de Libros</label>
                    <br>
                    <input class="form-control" type="text" name="" id="alm_libros">
                    <br>
                    <label class="text-font-normal">Ruta de almacenamiento previsualizacion Peliculas</label>
                    <br>
                    <input class="form-control" type="text" name="" id="pre_peliculas">
                    <br>
                    <label class="text-font-normal">Ruta de almacenamiento de Peliculas</label>
                    <br>
                    <input class="form-control" type="text" name="" id="alm_peliculas">
                    <br>
                    <label class="text-font-normal">Ruta de almacenamiento previsualizacion musica</label>
                    <br>
                    <input class="form-control" type="text" name="" id="pre_musica">
                    <br>
                    <label class="text-font-normal">Ruta de almacenamiento de musica</label>
                    <br>
                    <input class="form-control" type="text" name="" id="alm_musica">
                    <br>
                    <br>
                    <button class="btn btn-primary justify-content-center" type="button" onclick="actualizar_parametros()">Actualizar datos</button>
                </div>
            </div>
        </div>
    </div>

    <script>
        traer_datos();
    </script>

</asp:Content>
