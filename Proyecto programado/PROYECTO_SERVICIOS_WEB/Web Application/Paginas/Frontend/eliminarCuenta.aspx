<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Frontend.Master" AutoEventWireup="true" CodeBehind="eliminarCuenta.aspx.cs" Inherits="Web_Application.Paginas.Frontend.eliminarCuenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <link rel="stylesheet" href="../../Public/estilos/tarjetas.css">
<div style="background-image: url('../../Public/imagenes/fondo_general.png'); height: 1100px;" class="text-white">
    <div class="p-3 mb-2 bg-dark text-white text-center text-uppercase font-weight-bold">
        Eliminar cuenta
    </div>
        <div class="container">
            <div class="row justify-content-center">
                <div class="form-group col-4">
                    <div class="text-font-normal">
                    Para eliminar su cuenta, vuelva a escribir su contraseña y nombre de usuario.
                    </div>
                    <br/>
                    <div class="text-font-normal">
                        Nombre de usuario
                    </div>
                    <asp:TextBox class="form-control" ID="TextBox_nombreUsuario" runat="server"></asp:TextBox>
                    <div class="text-font-normal">
                        Contraseña
                    </div>
                    <asp:TextBox class="form-control" TextMode="Password" ID="TextBox_contrasenia" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label_status_error" runat="server" Text="" class="badge badge-danger"></asp:Label>
                    <br />
                    <asp:Button class="btn btn-primary justify-content-center" ID="Button_eliminarCuenta" runat="server" Text="Eliminar cuenta" OnClick="Button_eliminarCuenta_Click" />
                </div>
            </div>
        </div>
</div>
</asp:Content>
