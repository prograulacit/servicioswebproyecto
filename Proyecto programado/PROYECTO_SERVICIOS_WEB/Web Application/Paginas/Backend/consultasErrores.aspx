<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Backend.Master" AutoEventWireup="true" CodeBehind="consultasErrores.aspx.cs" Inherits="Web_Application.Paginas.Backend.consultasErrores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../../Public/estilos/estilo_global.css">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="/Paginas/Backend/Index.aspx">Inicio</a></li>
            <li class="breadcrumb-item">Consultas</li>
            <li class="breadcrumb-item active" aria-current="page">Errores</li>
        </ol>
    </nav>
<div style="background-image: url('../../Public/imagenes/fondo_general.png'); height: 811px;" class="text-white">
    <div class="container">
        <div class="row justify-content-center">
            <div class="form-group col-4">
                <br />
                <h3 class="tp-3 mb-2 bg-dark text-white text-center text-uppercase font-weight-bold">Consulta de Errores</h3>
                <br />
                <label class="text-font-normal">Fecha Inicio</label>
                <input type="date" id="input_errores_fecha_inicio" class="form-control" aria-label="Search" />
                <br />
                <label class="text-font-normal">Fecha Final</label>
                <input type="date" id="input_errores_fecha_final" class="form-control" aria-label="Search" />
                <br />
                <button class="btn btn-primary justify-content-center" type="button" onclick="button_submit_errores_buscar()">Buscar</button>
            </div>
            <div class="col-md-8">
                <br />
                <br />
                <br />
                <br />
                <div id="tabla_errores"></div>
            </div>
        </div>
    </div>
</div>
    <script src="../../Public/scripts/utils.js"></script>
    <script src="../../Public/scripts/consultasErrores.js"></script>
</asp:Content>
