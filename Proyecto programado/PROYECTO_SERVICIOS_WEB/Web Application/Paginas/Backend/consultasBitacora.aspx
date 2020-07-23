<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Backend.Master" AutoEventWireup="true" CodeBehind="consultasBitacora.aspx.cs" Inherits="Web_Application.Paginas.Backend.consultasBitacora" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="/Paginas/Backend/Index.aspx">Inicio</a></li>
            <li class="breadcrumb-item">Consultas</li>
            <li class="breadcrumb-item active" aria-current="page">Bitacora</li>
        </ol>
    </nav>
    <div class="container">
        <div class="row">
            <div class="col-md-4">
                <br />
                <h3 class="text-uppercase text-muted">Consulta de Bitacora</h3>
                <br />
                <label class="text-font-normal">Usuario</label>
                <input type="text" id="input_bitacora_usuario" placeholder="Usuario" class="form-control sm-1" aria-label="Search" />
                <br />
                <label class="text-font-normal">Fecha Inicio</label>
                <input type="date" id="input_bitacora_fecha_inicio" class="form-control" aria-label="Search" />
                <br />
                <label class="text-font-normal">Fecha Final</label>
                <input type="date" id="input_bitacora_fecha_final" class="form-control" aria-label="Search" />
                <br />
                <label class="text-font-normal">Tipo</label>
                <select id="input_bitacora_tipo" class="form-control">
                  <option value="">Ninguno</option>
                  <option value="agregar">Agregar</option>
                  <option value="modificar">Modificar</option>
                  <option value="eliminar">Eliminar</option>
                </select>
                <br />
                <button class="btn btn-outline-success my-2 my-sm-0" type="button" onclick="button_submit_bitacora_buscar()">Buscar</button>
            </div>
            <div class="col-md-8">
                <br />
                <br />
                <br />
                <br />
                <div id="tabla_bitacora"></div>
            </div>
        </div>
    </div>
    <script src="../../Public/scripts/consultasBitacora.js"></script>
</asp:Content>
