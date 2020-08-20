<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Frontend.Master" AutoEventWireup="true" CodeBehind="checkout.aspx.cs" Inherits="Web_Application.Paginas.Frontend.checkout1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../../Public/estilos/estilo_global.css">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="./index.aspx">Inicio</a></li>
            <li class="breadcrumb-item active" aria-current="page">Compra</li>
            <li class="breadcrumb-item active" aria-current="page">Checkout</li>
        </ol>
    </nav>
    <div style="background-image: url('../../Public/imagenes/fondo_general.png'); height: 806px;" class="text-white">

    <asp:Label ID="Label_status" runat="server" Text=""></asp:Label>
</div>
</asp:Content>
