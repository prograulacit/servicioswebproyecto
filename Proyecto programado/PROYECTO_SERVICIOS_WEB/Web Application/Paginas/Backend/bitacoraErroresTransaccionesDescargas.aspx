<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Backend.Master" AutoEventWireup="true" CodeBehind="bitacoraErroresTransaccionesDescargas.aspx.cs" Inherits="Web_Application.Paginas.Backend.bitacoraErroresTransaccionesDescargas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="./index.aspx">Inicio</a></li>
            <li class="breadcrumb-item active" aria-current="page">Consultas y monitoreo</li>
        </ol>
    </nav>
    <div class="p-3 mb-2 bg-dark text-white text-center text-uppercase font-weight-bold">
        Consultas y monitorización del sistema.
    </div>

    <div class="container">
        <div class="row justify-content-center">
            <div class="form-group col-4">
                <div class="descripcion">
                    Por favor, utilice el dropdown aquí dado para realizar consultas de monitorización.
                </div>

                <div>
                    <select class="form-control" id="dropdown_consulta">
                        <option value="Bitacora">Bitacora</option>
                        <option value="Errores">Errores</option>
                        <option value="Transacciones">Transacciones</option>
                        <option value="Descargas">Descargas</option>
                    </select>
                    <br>
                    <button class="btn btn-primary justify-content-center" type="button" onclick="boton_consultar()">Consultar</button>
                </div>
            </div>
        </div>
    </div>

    <div id="contenido">

    </div>

    <script src="../../Public/scripts/bitacoraErroresTransaccionesDescargas.js"></script>
</asp:Content>