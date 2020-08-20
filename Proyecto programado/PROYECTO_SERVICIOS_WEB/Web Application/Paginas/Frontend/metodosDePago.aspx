<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Frontend.Master" AutoEventWireup="true" CodeBehind="metodosDePago.aspx.cs" Inherits="Web_Application.Paginas.Frontend.metodosDePago" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="./index.aspx">Inicio</a></li>
            <li class="breadcrumb-item active" aria-current="page">Metodos de pago</li>
        </ol>
    </nav>
        <link rel="stylesheet" href="../../Public/estilos/tarjetas.css">
<div style="background-image: url('../../Public/imagenes/fondo_general.png'); height: 1100px;" class="text-white">
    <div class="container">
        <div class="row justify-content-center">
            <div class="form-group col-4">
                <div class="p-3 mb-2 bg-dark text-white text-center text-uppercase font-weight-bold">
                    Administración de metodos de pago
                </div>
                <div class="descripcion">
                    <a href="tarjetas.aspx">Administración de tarjetas de credito y debito</a>
                    <br />
                    <br/>
                    <a href="EasyPay.aspx">Administración de cuentas EasyPay</a>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>
