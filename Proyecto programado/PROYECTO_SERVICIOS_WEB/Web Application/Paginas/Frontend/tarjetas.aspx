<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Frontend.Master" AutoEventWireup="true" CodeBehind="tarjetas.aspx.cs" Inherits="Web_Application.Paginas.Frontend.tarjetas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../../Public/estilos/tarjetas.css">
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
        <div class="titulo">
            Administracion de tarjetas
        </div>

        <%--Selector de opciones--%>
        <div class="selectorDeAcciones">
            <div class="selectorDeAcciones_accion">
                <a href="#" onclick="crearNuevaTarjeta()">Agregar nueva tarjeta</a>
            </div>
            <div class="selectorDeAcciones_accion">
                <a href="#" onclick="verTarjetasRegistradas()">Ver tarjetas registradas</a>
            </div>
        </div>

        <hr />

        <%--Formulario para crear nueva tarjeta--%>
        <div class="crearNuevaTarjeta" id="crearNuevaTarjeta">
            <div>Numero de tarjeta</div>
            <asp:TextBox ID="TextBox_numeroTarjeta" runat="server"></asp:TextBox>
            <div>Mes de expiración</div>
            <asp:TextBox ID="TextBox_mesExpiracion" runat="server"></asp:TextBox>
            <div>Año de expiracion</div>
            <asp:TextBox ID="TextBox_anioDeExpiracion" runat="server"></asp:TextBox>
            <div>CVV</div>
            <asp:TextBox ID="TextBox_cvv" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button_guardarTarjeta" runat="server" Text="Crear tarjeta" />
        </div>

        <%--Formulario para ver tarjetas existentes--%>
        <div class="verTarjetasRegistradas" id="verTarjetasRegistradas">
            <div class="spinner-border text-primary" role="status">
                <span class="sr-only">Loading...</span>
            </div>
            *** Aqui va la tabla con tarjetas registradas...
        </div>
    </div>
    <script src="../../Public/scripts/tarjetas.js"></script>
</asp:Content>
