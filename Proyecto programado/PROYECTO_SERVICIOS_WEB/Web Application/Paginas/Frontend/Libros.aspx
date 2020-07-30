<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Frontend.Master" AutoEventWireup="true" CodeBehind="Libros.aspx.cs" Inherits="Web_Application.Paginas.Frontend.Libros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="/Paginas/Frontend/Index.aspx">Inicio</a></li>
            <li class="breadcrumb-item">Búsqueda</li>
            <li class="breadcrumb-item active" aria-current="page">Libros</li>
        </ol>
    </nav>
    <div class="container">
        <div class="row">
            <div class="col-md-4">
                <br />
                <h3 class="text-uppercase text-muted">Búsqueda de Libros</h3>
                <br />
                <label class="text-font-normal">Categoría</label>
                <div class="spinner-border text-primary input_libros_Categorias_spinner" role="status">
                    <span class="sr-only">Loading...</span>
                </div>
                <select id="input_libros_Categorias" class="form-control sm-1"></select>
                <br />
                <label class="text-font-normal">Nombre</label>
                <input type="text" id="input_libros_Nombre" placeholder="Nombre" class="form-control" aria-label="Search" />
                <br />
                <label class="text-font-normal">Autor</label>
                <input type="text" id="input_libros_Autor" placeholder="Autor" class="form-control" aria-label="Search" />
                <br />
                <label class="text-font-normal">Idioma</label>
                <input type="text" id="input_libros_Idioma" placeholder="Idioma" class="form-control" aria-label="Search" />
                <br />
                <label class="text-font-normal">Editorial</label>
                <input type="text" id="input_libros_Editorial" placeholder="Editorial" class="form-control" aria-label="Search" />
                <br />
                <label class="text-font-normal">Año</label>
                <input type="text" id="input_libros_Anio" placeholder="Año" class="form-control" aria-label="Search" />
                <br />
                <button class="btn btn-outline-success my-2 my-sm-0" type="button" onclick="button_submit_libro_buscar()">Buscar</button>
            </div>
            <div class="col-md-8">
                <br />
                <br />
                <br />
                <br />
                <div id="tabla_Libros"></div>
            </div>
        </div>
    </div>
    <script src="../../Public/scripts/libro.js"></script>
    <script>
        traer_categorias();
    </script>
</asp:Content>
