﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Frontend.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Web_Application.Paginas.Frontend.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item active" aria-current="page">Inicio</li>
        </ol>
    </nav>
        <link rel="stylesheet" href="../../Public/estilos/tarjetas.css">
<div style="background-image: url('../../Public/imagenes/fondo_general.png'); height: 1100px;" class="text-white">
    <div class="container">
        <br />
        <br />
        <br />
        <div class="justify-content-center ">
            <h1 class="text-uppercase text-muted">Bienvenido a la aplicacion</h1>
        </div>
    </div>
</div>
</asp:Content>
