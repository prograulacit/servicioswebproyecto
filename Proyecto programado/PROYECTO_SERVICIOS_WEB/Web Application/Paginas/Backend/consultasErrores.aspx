<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Backend.Master" AutoEventWireup="true" CodeBehind="consultasErrores.aspx.cs" Inherits="Web_Application.Paginas.Backend.consultasErrores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="/Paginas/Backend/Index.aspx">Inicio</a></li>
            <li class="breadcrumb-item">Consultas</li>
            <li class="breadcrumb-item active" aria-current="page">Errores</li>
        </ol>
    </nav>
    <div class="container">
        <div class="row">
            <div class="col-md-4">
                <br />
                <h3 class="text-uppercase text-muted">Consulta de Errores</h3>
                <br />
                <label class="text-font-normal">Fecha Inicio</label>
                <input type="date" id="input_errores_fecha_inicio" class="form-control" aria-label="Search" />
                <br />
                <label class="text-font-normal">Fecha Final</label>
                <input type="date" id="input_errores_fecha_final" class="form-control" aria-label="Search" />
                <br />
                <button class="btn btn-outline-success my-2 my-sm-0" type="button" onclick="button_submit_errores_buscar()">Buscar</button>
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
    <script src="../../Public/scripts/consultasErrores.js"></script>
</asp:Content>
