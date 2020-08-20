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
        <link rel="stylesheet" href="../../Public/estilos/tarjetas.css">
<div style="background-image: url('../../Public/imagenes/fondo_general.png'); height: 1100px;" class="text-white">
    <div class="container" id="buscador_bitacora">
        <div class="row justify-content-center">
            <div class="form-group col-4">
                <br />
                <h3 class="tp-3 mb-2 bg-dark text-white text-center text-uppercase font-weight-bold">Consulta de Bitacora</h3>
                <br />
                <label class="text-font-normal">Usuario</label>
                <input type="text" id="input_bitacora_usuario" placeholder="Usuario" class="form-control" aria-label="Search" />
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
                  <option value="Agregar">Agregar</option>
                  <option value="Modificar">Modificar</option>
                  <option value="Eliminar">Eliminar</option>
                </select>
                <br />
                <button class="btn btn-primary justify-content-center" type="button" onclick="button_submit_bitacora_buscar()">Buscar</button>
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

    <div class="container" id="detalle_bitacora_contenedor" style="display:none">
        <a href="#" onclick="ir_atras_detalle()">Atras</a>
        <div class="container" id="detalle_bitacora"></div>
    </div>
</div>
    <script src="../../Public/scripts/utils.js"></script>
    <script src="../../Public/scripts/consultasBitacora.js"></script>
</asp:Content>
