<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Backend.Master" AutoEventWireup="true" CodeBehind="consecutivos.aspx.cs" Inherits="Web_Application.Paginas.Backend.consecutivos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
    <div class="tp-3 mb-2 bg-dark text-white text-center text-uppercase font-weight-bold">
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


    <div class="container">
        <div class="row justify-content-center">
            <div class="form-group col-4">
                <div id="contenedor_editar">
                    <div class="text-font-normal">
                        Editando consecutivo
                    </div>
                    <label class="text-font-normal">ID:</label>
                    <br>
                    <input disabled type="text" name="" class="editar_id form-control">
                    <br>
                    <label class="text-font-normal">Tipo:</label>
                    <br>
                    <input type="text" name="" class="editar_tipo form-control">
                    <br>
                    <label class="text-font-normal">Consecutivo:</label>
                    <br>
                    <input disabled type="text" name="" class="editar_descripcion form-control">
                    <br>
                    <label class="text-font-normal">Prefijo:</label>
                    <br>
                    <input type="text" name="" class="editar_prefijo form-control">
                    <br>
                    <label class="text-font-normal">Rango Inicial:</label>
                    <br>
                    <input type="text" name="" class="editar_rangoInicial form-control">
                    <br>
                    <label class="text-font-normal">Rango Final:</label>
                    <br>
                    <input type="text" name="" class="editar_rangoFinal form-control">
                    <br>
                    <button class="btn btn-primary justify-content-center" type="button" onclick="guardar_cambios()">Guardar cambios</button>
                    <button class="btn btn-primary justify-content-center">Cancelar</button>
                </div>
            </div>
        </div>
    </div>

    

    <script>
        cargar_elementos();
        contenedorTabla_visible("inline");
        contenedorEditar_visible("none");
    </script>
</asp:Content>
