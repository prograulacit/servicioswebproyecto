<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Backend.Master" AutoEventWireup="true" CodeBehind="ConsultasDescargas.aspx.cs" Inherits="Web_Application.Paginas.Backend.ConsultasDescargas" %>
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
    <div class="container">
        <div class="row">
            <div class="col-md-4">
                <br />
                <h3 class="text-uppercase text-muted">Consulta de Descargas</h3>
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
                <label class="text-font-normal">Tipo</label>
                <select id="input_descargas_tipo" class="form-control">
                    <option value="">Ninguno</option>
                    <option value="peliculas">Peliculas</option>
                    <option value="musica">Musica</option>
                    <option value="libros">Libros</option>
                </select>
                <br />
                <label class="text-font-normal">Género o Categoría</label>
                <input type="text" id="input_descargas_categoria" placeholder="Género o Categoría" class="form-control sm-1" aria-label="Search" />
                <br />
                <button class="btn btn-outline-success my-2 my-sm-0" type="button" onclick="button_submit_descargas_buscar()">Buscar</button>
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
    <script src="../../Public/scripts/consultasDercargas.js"></script>
</asp:Content>
