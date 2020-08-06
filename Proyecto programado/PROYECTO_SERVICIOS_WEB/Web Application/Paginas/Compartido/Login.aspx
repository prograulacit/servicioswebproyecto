<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/SesionAnonimo.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web_Application.Paginas.Compartido.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="p-3 mb-2 bg-dark text-white text-center text-uppercase font-weight-bold">
            Formulario de inicio de sesión.
        </div>
        <div class="container form-group col-4">
            <br/>
            <br/>
            <asp:Label class="text-font-normal" runat="server" Text="Nombre de usuario"></asp:Label>
            <br />
            <asp:TextBox class="form-control" ID="textbox_nombre_usuario" runat="server"></asp:TextBox>
            <br />
            <asp:Label class="text-font-normal" runat="server" Text="Contraseña"></asp:Label>
            <br />
            <asp:TextBox class="form-control" TextMode="Password" ID="textbox_contrasenia" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button class="btn btn-primary justify-content-center" ID="button_submit_login" runat="server" Text="Submit" OnClick="button_submit_login_Click" />
            <br/>
            <br/>
            <a class="text-font-normal" href="index.aspx">Volver</a>
            <br />
            <asp:Label class="badge badge-danger" ID="Label_status_error" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <script>
        document.getElementById("ContentPlaceHolder1_textbox_nombre_usuario").autofocus;

    </script>

</asp:Content>
