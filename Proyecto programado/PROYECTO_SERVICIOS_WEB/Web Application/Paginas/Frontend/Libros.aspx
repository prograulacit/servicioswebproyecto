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
    <div class="container" id="main_container">
        <div class="row justify-content-center">
            <div class="form-group col-4">
                <br />
                <h3 class="p-3 mb-2 bg-dark text-white text-center text-uppercase font-weight-bold">Búsqueda de Libros</h3>
                <br />
                <label class="text-font-normal">Categoría</label>
                <div class="spinner-border text-primary input_libros_Categorias_spinner" role="status">
                    <span class="sr-only">Loading...</span>
                </div>
                <select id="input_libros_Categorias" class="form-control"></select>
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
                <button class="btn btn-primary justify-content-center" type="button" onclick="button_submit_libro_buscar()">Buscar</button>
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
    <div id="libro_container" class="container" style="display:none">	
        <div class="column">	
            <a href="#" class="btn btn-secondary mb-4" onclick="ir_a_tabla()">Atras</a>	
            <div id="embed_file">	
            </div>	
        </div>	
    </div>
    <script src="../../Public/scripts/libro.js"></script>
    <script src="../../Public/scripts/productoCompra.js"></script>
    <script>
        traer_categorias();
    </script>
</asp:Content>
