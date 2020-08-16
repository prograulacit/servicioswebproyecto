<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Frontend.Master" AutoEventWireup="true" CodeBehind="misArticulos.aspx.cs" Inherits="Web_Application.Paginas.Frontend.misArticulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row justify-content-center">
            <div class="col-md-12">
                <br />
                <br />
                <div id="tabla_articulos"></div>
            </div>
        </div>
    </div>

    <script src="../../Public/scripts/misArticulos.js"></script>
    <script>
        cargar_articulos('asociada');
    </script>
</asp:Content>
