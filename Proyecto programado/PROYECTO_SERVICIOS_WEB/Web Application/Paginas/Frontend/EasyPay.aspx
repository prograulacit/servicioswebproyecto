<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Frontend.Master" AutoEventWireup="true" CodeBehind="EasyPay.aspx.cs" Inherits="Web_Application.Paginas.Frontend.EasyPay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../../Public/estilos/easypay.css">
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@9"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="./index.aspx">Inicio</a></li>
            <li class="breadcrumb-item"><a href="./metodosDePago.aspx">Metodos de pago</a></li>
            <li class="breadcrumb-item active" aria-current="page">EasyPay</li>
        </ol>
    </nav>
    <link rel="stylesheet" href="../../Public/estilos/tarjetas.css">
<div style="background-image: url('../../Public/imagenes/fondo_general.png'); height: 1100px;" >
    <div class="titulo">
        Administración de cuentas EasyPay
    </div>

    <div class="container">
        <div class="row">
            <div class="col-12 col-sm-12 col-md-12 col-lg-4">
                <div class="creacion_de_cuentas">
                    <div class="subtitulo">
                        Crear nueva cuenta
                    </div>
                    <div class="formulario_easypay">
                        <%--Bootstrap Collapse comienza aqui--%>
                        <div class="accordion" id="accordionExample">
                            <div class="card">
                                <div class="card-header" id="headingTwo">
                                    <h2 class="mb-0">
                                        <button class="btn btn-link btn-block text-left collapsed" type="button" data-toggle="collapse" data-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                                            Ver formulario
                                        </button>
                                    </h2>
                                </div>
                                <div id="collapseTwo" class="collapse" aria-labelledby="headingTwo" data-parent="#accordionExample">
                                    <div class="card-body">
                                        <%--Formulario comienza aqui--%>
                                        Elija una de sus tarjetas para realizar el pago con EasyPay.
                                        <div id="tablaTarjetas_easypay">
                                            <div class="spinner-border text-primary" role="status">
                                                <span class="sr-only">Loading...</span>
                                            </div>
                                            Cargando, por favor espere...
                                        </div>
                                        Tarjeta a utilizar:
                                        <br />
                                        <div class="alert alert-secondary">
                                            <asp:Label ID="Label_tarjetaFormateada" runat="server" Text="Sin especificar."></asp:Label>
                                            <br />
                                            <asp:TextBox ID="Textbox_idTarjeta" class="form-control" runat="server" ClientIDMode="Static"></asp:TextBox>
                                        </div>
                                        Contraseña para su cuenta de EasyPay
                                        <br />
                                        <div class="form-group">
                                            <asp:TextBox class="form-control" TextMode="Password" ID="TextBox_contraseniaNueva" runat="server"></asp:TextBox>
                                        </div>
                                        <br />
                                        Confirmar la contraseña:
                                        <br />
                                        <div class="form-group">
                                            <asp:TextBox class="form-control" TextMode="Password" ID="TextBox_contraseniaConfirmar" runat="server"></asp:TextBox>
                                        </div>
                                        <asp:Button class="btn btn-primary btn-block" ID="Button_crearCuentaEasyPay" runat="server" Text="Crear cuenta" OnClick="Button_crearCuentaEasyPay_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12 col-sm-12 col-md-12 col-lg-8 text-white">
                <div class="subtitulo">
                    Cuentas EasyPay registradas
                </div>
                <div id="tabla_easypays">
                    <div class="spinner-border text-primary" role="status">
                        <span class="sr-only">Loading...</span>
                    </div>
                    Cargando, por favor espere...
                </div>
            </div>
        </div>
        <br />
        <br />
        <asp:Label ID="Label_status_error" class="alert alert-danger" runat="server" Text=""></asp:Label>
        <asp:Label ID="Label_status_success" class="alert alert-success" runat="server" Text=""></asp:Label>
    </div>
</div>
    <script src="../../Public/scripts/EasyPay.js"></script>
    <script src="../../Public/scripts/tarjetas.js"></script>
    <script>
        cargarTarjetas_easypay();
        cargar_easypays();
    </script>
</asp:Content>
