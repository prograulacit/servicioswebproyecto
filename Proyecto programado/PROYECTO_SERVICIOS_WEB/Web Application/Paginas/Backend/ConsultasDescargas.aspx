<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Backend.Master" AutoEventWireup="true" CodeBehind="consultasDescargas.aspx.cs" Inherits="Web_Application.Paginas.Backend.ConsultasDescargas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="/Paginas/Backend/Index.aspx">Inicio</a></li>
            <li class="breadcrumb-item">Consultas</li>
            <li class="breadcrumb-item active" aria-current="page">Descargas</li>
        </ol>
    </nav>
        <link rel="stylesheet" href="../../Public/estilos/tarjetas.css">
<div style="background-image: url('../../Public/imagenes/fondo_general.png'); height: 1100px;" class="text-white">
    <div class="container">
        <div class="row justify-content-center">
            <div class="form-group col-4">
                <br />
                <h3 class="ttp-3 mb-2 bg-dark text-white text-center text-uppercase font-weight-bold">Consulta de Descargas</h3>
                <br />
                <label class="text-font-normal">Nombre producto</label>
                <br />
                <input type="text" id="input_descargas_nombre" placeholder="Nombre producto" class="form-control sm-1" aria-label="Search" />
                <br />
                <label class="text-font-normal">Tipo</label>
                <select id="input_descargas_tipo" class="form-control">
                    <option value="">Ninguno</option>
                    <option value="pelicula">Peliculas</option>
                    <option value="musica">Musica</option>
                    <option value="libro">Libros</option>
                </select>
                <br />
                <label class="text-font-normal">Tipo Fecha</label>
                <select id="input_descargas_tipo_fecha" class="form-control" onChange="tipo_descarga_cambio()" >
                    <option value="">Ninguna</option>
                    <option value="diaria">Diaria</option>
                    <option value="semanal">Semanal</option>
                    <option value="mensualActual">Mensual (Actual)</option>
                    <option value="mensualAnterior">Mensual (Anterior)</option>
                    <option value="trimestral">Trimestral</option>
                    <option value="semestral">Semestral</option>
                    <option value="anual">Anual</option>
                    <option value="rango">Rango</option>
                </select>
                <br />
                <label class="text-font-normal" style="display:none">Inicio Fecha</label>
                <input type="date" id="input_descargas_inicio_fecha" class="form-control" aria-label="Search" style="display:none"/>
                <br />
                <label class="text-font-normal" style="display:none">Final Fecha</label>
                <input type="date" id="input_descargas_final_fecha" class="form-control" aria-label="Search" style="display:none"/>
                <br />
                <button class="btn btn-primary justify-content-center" type="button" onclick="button_submit_descargas_buscar()">Buscar</button>
            </div>
            <div class="col-md-8">
                <br />
                <br />
                <br />
                <br />
                <div id="tabla_descargas"></div>
            </div>
        </div>
    </div>
</div>
    <script src="../../Public/scripts/utils.js"></script>
    <script src="../../Public/scripts/consultasDescargas.js"></script>
</asp:Content>
