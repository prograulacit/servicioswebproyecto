<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Backend.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Web_Application.Paginas.Backend.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item active" aria-current="page">Inicio</li>
        </ol>
    </nav>
    <div class="titulo">
        Bienvenido/a a E-Descargas Backend
    </div>
    <div class="descripcion">
        Esta es una aplicación web para la gestión de compras y descargas de vídeos, música y libros electrónicos (PDF).
    </div>

    <div class="container">
        <div class="row">
            <div class="col-12 col-sm-4 col-md-4 col-lg-3">
                <div class="fondo-gris-mas categoria">
                    Seguridad
                </div>
                <div class="fondo-gris">
                    <a href="#">- Crear nuevo usuario</a>
                    <br>
                    <a href="#">- Asignar roles de usuarios</a>
                    <br>
                    <a href="#">- Cambiar contraseña actual</a>
                </div>
            </div>
            <div class="col-12 col-sm-4 col-md-4 col-lg-2">
                <div  class="fondo-gris-mas categoria">
                    Administración
                </div>
                <div class="fondo-gris">
                    <a href="#">- Consecutivos</a>
                    <br>
                    <a href="#">- Parámetros</a>
                    <br>
                    <a href="#">- Películas</a>
                    <br>
                    <a href="#">- Libros</a>
                    <br>
                    <a href="#">- Música</a>
                </div>
            </div>
            <div class="col-12 col-sm-4 col-md-4 col-lg-2">
                <div class="fondo-gris-mas categoria">
                    Consultas
                </div>
                <div class="fondo-gris">
                    <a href="#">- Bitácora</a>
                    <br>
                    <a href="#">- Transacciones</a>
                    <br>
                    <a href="#">- Descargas</a>
                    <br>
                    <a href="#">- Errores</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
