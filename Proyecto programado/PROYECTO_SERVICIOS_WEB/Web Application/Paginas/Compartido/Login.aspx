<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/SesionAnonimo.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web_Application.Paginas.Compartido.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Public/scripts/externo/oauth.js"></script>
    <script src="../../Public/scripts/login.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="background-image: url('../../Public/imagenes/fondo_general.png'); height: 900px;" class="text-white">
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
            <div class="fb-login-button" data-size="large" data-button-type="login_with" data-layout="default" data-auto-logout-link="false" data-use-continue-as="false" data-width=""></div>
            <br />
            <a class="bnt-twitter-login" href="#" onclick="twitter_login()">Iniciar sesión con Twitter</a>
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
</div>
    <%--Hidden elements--%>
    <asp:Button ID="btn_submit_social_login" class="submit_social_login" runat="server" Text="Submit" OnClick="btn_submit_social_login_Click" style="display:none"/>
    <input class="social_name" id="socialName" type="text" runat="server" value="No definido" style="display:none"/>
    <input class="social_email" id="socialEmail" type="text" runat="server" value="No definido" style="display:none"/>
    <input class="social_username" id="socialUsername" type="text" runat="server" value="No definido" style="display:none"/>
    <input class="social_id" id="socialId" type="text" runat="server" style="display:none"/>

    <script async defer crossorigin="anonymous" src="https://connect.facebook.net/es_ES/sdk.js#xfbml=1&version=v8.0&appId=3299543530092459&autoLogAppEvents=1" nonce="TvtcEOb4"></script>
    <script>
        document.getElementById("ContentPlaceHolder1_textbox_nombre_usuario").autofocus;

    </script>

</asp:Content>
