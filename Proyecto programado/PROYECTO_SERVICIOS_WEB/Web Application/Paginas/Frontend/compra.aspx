<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Frontend.Master" AutoEventWireup="true" CodeBehind="compra.aspx.cs" Inherits="Web_Application.Paginas.Frontend.checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@9"></script>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.14.0/css/all.css" integrity="sha384-HzLeBuhoNPvSl5KYnjx0BT+WB0QEEqLprO+NBkkk5gbc67FTaL7XIGa2w1L0Xbgc" crossorigin="anonymous">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="./index.aspx">Inicio</a></li>
            <li class="breadcrumb-item active" aria-current="page">Compra</li>
        </ol>
    </nav>
    <link rel="stylesheet" href="../../Public/estilos/tarjetas.css">
<div style="background-image: url('../../Public/imagenes/fondo_general.png'); height: 1100px;" class="text-white">
    <div class="container">
        <div class="titulo">
            Compra
        </div>
        <div class="row">
            <div class="col-12 col-sm-12 col-md-12 col-lg-3">
                <div class="subtitulo">
                    Información del producto
                </div>
                <div id="informacionDelProducto">
                    <asp:Label ID="Label_informacionDelProducto" runat="server" Text="INFORMACION DEL PRODUCTO AQUÍ"></asp:Label>
                </div>
                <br />
                <br />
                <a href="Index.aspx">Cancelar compra</a>
            </div>
            <div class="col-12 col-sm-12 col-md-12 col-lg-9">
                <div class="subtitulo">
                    Método de pago
                </div>

                <div id="selector_metodoDePago">
                    <ul class="nav nav-pills">
                        <li class="nav-item">
                            <a onclick="seleccion_tarjeta()" class="nav-link active" href="#">Tarjeta</a>
                        </li>
                        <li class="nav-item">
                            <a onclick="seleccion_easypay()" class="nav-link" href="#">EasyPay</a>
                        </li>
                    </ul>
                </div>

                <div id="tabla_metodosDePago">
                    <div class="spinner-border text-primary" role="status">
                        <span class="sr-only">Loading...</span>
                    </div>
                </div>
                <div id="botonCompra_contenedor" style="display: none;">
                    <button type="button" class="btn btn-primary btn-lg btn-block" onclick="realizarCompra()">Realizar compra</button>
                </div>
            </div>
        </div>
    </div>
</div>
    <script src="../../Public/scripts/compra.js"></script>
    <script src="../../Public/scripts/tarjetas.js"></script>
    <script src="../../Public/scripts/EasyPay.js"></script>
    <script>
        cargar_tarjetasCompras();
    </script>
</asp:Content>
