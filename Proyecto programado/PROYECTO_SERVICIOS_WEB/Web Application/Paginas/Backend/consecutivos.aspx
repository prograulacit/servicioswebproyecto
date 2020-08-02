<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Backend.Master" AutoEventWireup="true" CodeBehind="consecutivos.aspx.cs" Inherits="Web_Application.Paginas.Backend.consecutivos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="../../Public/scripts/consecutivos.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@9"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="./index.aspx">Inicio</a></li>
            <li class="breadcrumb-item active" aria-current="page">Administracion de consecutivos</li>
        </ol>
    </nav>
    <div class="titulo">
        Administracion de consecutivos
    </div>

    <div class="descripcion">
        Aquí puede administrar los consecutivos
    </div>

    <div id="contenedor_tabla">
        Cargando...
        <div class="spinner-border text-primary" role="status">
            <span class="sr-only">Loading...</span>
        </div>
    </div>

    <div id="contenedor_editar">
        <div class="titulo">
            Editando consecutivo
        </div>
        ID:
        <br>
        <input disabled type="text" name="" class="editar_id">
        <br>
        Tipo:
        <br>
        <input type="text" name="" class="editar_tipo">
        <br>
        Consecutivo:
        <br>
        <input disabled type="text" name="" class="editar_descripcion">
        <br>
        Prefijo:
        <br>
        <input type="text" name="" class="editar_prefijo">
        <br>
        Rango Inicial:
        <br>
        <input type="text" name="" class="editar_rangoInicial">
        <br>
        Rango Final:
        <br>
        <input type="text" name="" class="editar_rangoFinal">
        <br>
        <button type="button" onclick="guardar_cambios()">Guardar cambios</button>
        <button>Cancelar</button>
    </div>

    <script>
        cargar_elementos();
        contenedorTabla_visible("inline");
        contenedorEditar_visible("none");
    </script>
</asp:Content>
