<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Frontend.Master" AutoEventWireup="true" CodeBehind="tarjetas.aspx.cs" Inherits="Web_Application.Paginas.Frontend.tarjetas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../../Public/estilos/tarjetas.css">
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@9"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="./index.aspx">Inicio</a></li>
            <li class="breadcrumb-item"><a href="./metodosDePago.aspx">Metodos de pago</a></li>
            <li class="breadcrumb-item active" aria-current="page">Tarjetas</li>
        </ol>
    </nav>
    <div class="container">
        <div class="p-3 mb-2 bg-dark text-white text-center text-uppercase font-weight-bold">
            Administracion de tarjetas
        </div>
        <hr />
        <div class="row">
            <%--Selector de opciones--%>
            <%--<div class="selectorDeAcciones">
                <div class="selectorDeAcciones_accion">
                    <a href="#" onclick="crearNuevaTarjeta()">Agregar nueva tarjeta</a>
                </div>
                <div class="selectorDeAcciones_accion">
                    <a href="#" onclick="verTarjetasRegistradas()">Ver tarjetas registradas</a>
                </div>
            </div>
            <hr />--%>

            <div class="col-12 col-sm-12 col-md-12 col-lg-3">
                <%--Formulario para crear nueva tarjeta--%>
                <div class="crearNuevaTarjeta" id="crearNuevaTarjeta">
                    <div class="subtitulo">
                        Crear nueva tarjeta
                    </div>
                    <div class="text-font-normal">Numero de tarjeta</div>
                    <asp:TextBox class="form-control" ID="TextBox_numeroTarjeta" runat="server" MaxLength="16"></asp:TextBox>
                    <div class="text-font-normal">Mes de expiración</div>
                    <asp:DropDownList class="form-control" ID="DropDownList_mesExpiracion" runat="server"></asp:DropDownList>
                    <div class="text-font-normal">Año de expiracion</div>
                    <asp:DropDownList class="form-control" ID="DropDownList_anioExpiracion" runat="server"></asp:DropDownList>
                    <div class="text-font-normal">CVV</div>
                    <asp:TextBox class="form-control" ID="TextBox_cvv" runat="server" MaxLength="4"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button class="btn btn-primary justify-content-center" type="button" ID="Button_guardarTarjeta" runat="server" Text="Guardar tarjeta" OnClick="Button_guardarTarjeta_Click" />
                </div>
            </div>



            <div class="col-12 col-sm-12 col-md-12 col-lg-9">
                <%--Formulario para ver tarjetas existentes--%>
                <div class="verTarjetasRegistradas" id="tarjetas_registradas">
                    <div class="spinner-border text-primary" role="status">
                        <span class="sr-only">Loading...</span>
                    </div>
                    *** Cargando tarjetas...
                </div>
            </div>
        </div>

        <br />
        <br />
        <asp:Label ID="Label_status_error" class="alert alert-danger" runat="server" Text=""></asp:Label>
        <asp:Label ID="Label_status_success" class="alert alert-success" runat="server" Text=""></asp:Label>
    </div>
    <script src="../../Public/scripts/tarjetas.js"></script>
    <script>
        cargar_tarjetas();
    </script>
</asp:Content>
