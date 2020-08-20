<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/SesionAnonimo.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="Web_Application.Paginas.Compartido.Registrarse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="background-image: url('../../Public/imagenes/fondo_general.png'); height: 900px;" class="text-white">
    <div class="p-3 mb-2 bg-dark text-white text-center text-uppercase font-weight-bold">
        Formulario de registro.
    </div>
    <div class="container">

        <asp:Label ID="Label_error" class="badge badge-danger" runat="server" Text=""></asp:Label>
        <asp:Label ID="Label4_success" class="badge badge-success" runat="server" Text=""></asp:Label>

        <div class="row justify-content-center">
            <div class="form-group col-4">
                <br />
                <asp:Label class="text-font-normal" runat="server" Text="Su nombre"></asp:Label>
                <br />
                <asp:TextBox class="form-control" ID="textbox_nombre" runat="server"></asp:TextBox>
                <br />
                <asp:Label class="text-font-normal" runat="server" Text="Apellido paterno"></asp:Label>
                <br />
                <asp:TextBox class="form-control" ID="textbox_ap_paterno" runat="server"></asp:TextBox>
                <br />
                <asp:Label class="text-font-normal" runat="server" Text="Apellido materno"></asp:Label>
                <br />
                <asp:TextBox class="form-control" ID="textbox_ap_materno" runat="server"></asp:TextBox>
                <br />
                <asp:Label class="text-font-normal" runat="server" Text="Correo electrónico" ID="Label1"></asp:Label>
                <br />
                <asp:TextBox class="form-control" ID="textbox_correo_electronico" runat="server"></asp:TextBox>
                <br />
                <asp:Label class="text-font-normal" runat="server" Text="Nombre de usuario" ID="Label2"></asp:Label>
                <br />
                <asp:TextBox class="form-control" ID="textbox_nombre_de_usuario" runat="server"></asp:TextBox>
                <br />
                <asp:Label class="text-font-normal" runat="server" Text="Contraseña"></asp:Label>
                <br />
                <asp:TextBox class="form-control" TextMode="Password" ID="textbox_contrasenia" runat="server"></asp:TextBox>
                <br />
                <asp:Label class="text-font-normal" runat="server" Text="Confirmar contraseña"></asp:Label>
                <br />
                <asp:TextBox class="form-control" TextMode="Password" ID="textbox_confirmar_contrasenia" runat="server"></asp:TextBox>
                <br/>
                <br/>
                <asp:Button class="btn btn-primary justify-content-center" ID="button_submit_login" runat="server" Text="Submit" OnClick="button_submit_login_Click" />
                <br/>
                <br/>
                <a class="text-font-normal"  href="index.aspx">Volver</a>
            </div>
                </div>
        </div>
</div>
</asp:Content>
