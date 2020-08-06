<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Backend.Master" AutoEventWireup="true" CodeBehind="consultasTransacciones.aspx.cs" Inherits="Web_Application.Paginas.Backend.consultasTransacciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="/Paginas/Backend/Index.aspx">Inicio</a></li>
            <li class="breadcrumb-item">Consultas</li>
            <li class="breadcrumb-item active" aria-current="page">Transacciones</li>
        </ol>
    </nav>
    <div class="container">
        <div class="row justify-content-center">
            <div class="form-group col-4">
                <br />
                <h3 class="tp-3 mb-2 bg-dark text-white text-center text-uppercase font-weight-bold">Consulta de Transacciones</h3>
                <br />
                <label class="text-font-normal">Tipo Fecha</label>
                <select id="input_transacciones_tipo_fecha" class="form-control" onChange="tipo_transaccion_cambio()" >
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
                <input type="date" id="input_transacciones_inicio_fecha" class="form-control" aria-label="Search" style="display:none"/>
                <br />
                <label class="text-font-normal" style="display:none">Final Fecha</label>
                <input type="date" id="input_transacciones_final_fecha" class="form-control" aria-label="Search" style="display:none"/>
                <br />
                <label class="text-font-normal">Medio Pago</label>
                <select id="input_transacciones_medio_pago" class="form-control">
                    <option value="">Ninguna</option>
                    <option value="tarjeta">Tarjeta de crédito/débito</option>
                    <option value="easypay">EasyPay</option>
                    <option value="ambas">Ambas</option>
                </select>
                <br />
                <button class="btn btn-primary justify-content-center" type="button" onclick="button_submit_transacciones_buscar()">Buscar</button>
            </div>
            <div class="col-md-8">
                <br />
                <br />
                <br />
                <br />
                <div id="total_transacciones"><strong>Total de transacciones: </strong> 0</div>
                <div id="tabla_transacciones"></div>
            </div>
        </div>
    </div>
    <script src="../../Public/scripts/utils.js"></script>
    <script src="../../Public/scripts/consultasTransacciones.js"></script>
</asp:Content>
