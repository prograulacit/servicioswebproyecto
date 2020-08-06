<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/SesionAnonimo.Master" AutoEventWireup="true" CodeBehind="login_preguntaSeguridad.aspx.cs" Inherits="Web_Application.Paginas.Backend.login_preguntaSeguridad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p class="text-font-normal">
        Comprobación de pregunta de seguridad para administradores.</p>
    <p class="text-font-normal">
        Por favor, ingrese su respuesta de seguridad.</p>
    <p class="text-font-normal">
        Pista de respuesta de seguridad:</p>
    <p class="text-font-normal">
        <asp:Label ID="Label_pistaPreguntaSeguridad" runat="server" Text="PISTA PREGUNTA DE SEGURIDAD AQUÍ"></asp:Label>
    </p>
    <div class="container">
        <div class="row justify-content-center">
            <div class="form-group col-4">
                <p class="text-font-normal">
                    Respuesta de seguridad:</p>
                <p>
                    &nbsp;<asp:TextBox class="form-control" TextMode="Password" ID="TextBox_respuestaSeguridad" runat="server"></asp:TextBox>
                </p>
                <p>
                    <asp:Button class="btn btn-primary justify-content-center" ID="Button_aceptar" runat="server" Text="Aceptar" OnClick="Button_aceptar_Click" />
                </p>
                <p>
                    <asp:Button class="btn btn-primary justify-content-center" ID="Button_cancelar" runat="server" Text="Cancelar" OnClick="Button_cancelar_Click" />
                </p>
            </div>
        </div>
    </div>
    <p>
        <asp:Label class="badge badge-danger" ID="Label_status_error" runat="server" Text=""></asp:Label>
    </p>
</asp:Content>
