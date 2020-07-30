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
                    <a href="./crearNuevoAdmin.aspx">- Crear nuevo administrador</a>
                    <br>
                    <a href="./editarAdministradores.aspx">- Editar administradores</a>
                    <br>
                    <a href="./cambiarContrasenia.aspx">- Cambiar contraseña actual</a>
                </div>
            </div>
            <div class="col-12 col-sm-4 col-md-4 col-lg-2">
                <div  class="fondo-gris-mas categoria">
                    Administración
                </div>
                <div class="fondo-gris">
                    <a href="generosPeliculas.aspx">- Generos peliculas.</a>
                    <br>
                    <a href="generosMusica.aspx">- Generos musica.</a>
                    <br>
                    <a href="categoriasLibro.aspx">- Categorias libro.</a>
                    <br>
                    <a href="consecutivos.aspx">- Consecutivos.</a>
                    <br>
                    <a href="parametros.aspx">- Parámetros</a>
                    <br>
                    <a href="peliculasAdmin.aspx">- Películas</a>
                    <br>
                    <a href="libroAdmin.aspx">- Libros</a>
                    <br>
                    <a href="musicaAdmin.aspx">- Música</a>
                </div>
            </div>
            <div class="col-12 col-sm-4 col-md-4 col-lg-2">
                <div class="fondo-gris-mas categoria">
                    Consultas
                </div>
                <div class="fondo-gris">
                    <a href="consultasBitacora.aspx">- Bitácora.</a>
                    <br>
                    <a href="consultasTransacciones.aspx">- Transacciones.</a>
                    <br>
                    <a href="consultasDescargas.aspx">- Descargas.</a>
                    <br>
                    <a href="consultasErrores.aspx">- Errores.</a>
                </div>
            </div>
        </div>
    </div>
    </asp:Content>
