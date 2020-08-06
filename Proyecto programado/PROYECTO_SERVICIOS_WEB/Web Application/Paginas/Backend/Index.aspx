<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Backend.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Web_Application.Paginas.Backend.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item active" aria-current="page">Inicio</li>
        </ol>
    </nav>
    <div class="tp-3 mb-2 bg-dark text-white text-center text-uppercase font-weight-bold">
        Bienvenido/a a E-Descargas Backend
    </div>
    <br />
    <div class="text-font-normal">
        Esta es una aplicación web para la gestión de compras y descargas de vídeos, música y libros electrónicos (PDF).
    </div>
    <br />
    <div class="container">
        <div class="row justify-content-center">
            <div class="form-group col-4">
                <div class="fondo-gris-mas categoria">
                    Seguridad
                </div>
                <div class="fondo-gris">
                    <a class="text-font-normal" href="./crearNuevoAdmin.aspx">- Crear nuevo administrador</a>
                    <br>
                    <a class="text-font-normal"href="./editarAdministradores.aspx">- Editar administradores</a>
                    <br>
                    <a class="text-font-normal"href="./cambiarContrasenia.aspx">- Cambiar contraseña actual</a>
                </div>
            </div>
            <div class="form-group col-4">
                <div  class="fondo-gris-mas categoria">
                    Administración
                </div>
                <div class="fondo-gris">
                    <a class="text-font-normal"href="generosPeliculas.aspx">- Generos peliculas.</a>
                    <br>
                    <a class="text-font-normal"href="generosMusica.aspx">- Generos musica.</a>
                    <br>
                    <a class="text-font-normal"href="categoriasLibro.aspx">- Categorias libro.</a>
                    <br>
                    <a class="text-font-normal"href="consecutivos.aspx">- Consecutivos.</a>
                    <br>
                    <a class="text-font-normal"href="parametros.aspx">- Parámetros</a>
                    <br>
                    <a class="text-font-normal"href="peliculasAdmin.aspx">- Películas</a>
                    <br>
                    <a class="text-font-normal"href="libroAdmin.aspx">- Libros</a>
                    <br>
                    <a class="text-font-normal"href="musicaAdmin.aspx">- Música</a>
                </div>
            </div>
            <div class="form-group col-4">
                <div class="fondo-gris-mas categoria">
                    Consultas
                </div>
                <div class="fondo-gris">
                    <a class="text-font-normal"href="consultasBitacora.aspx">- Bitácora.</a>
                    <br>
                    <a class="text-font-normal"href="consultasTransacciones.aspx">- Transacciones.</a>
                    <br>
                    <a class="text-font-normal"href="consultasDescargas.aspx">- Descargas.</a>
                    <br>
                    <a class="text-font-normal"href="consultasErrores.aspx">- Errores.</a>
                </div>
            </div>
        </div>
    </div>
    </asp:Content>
