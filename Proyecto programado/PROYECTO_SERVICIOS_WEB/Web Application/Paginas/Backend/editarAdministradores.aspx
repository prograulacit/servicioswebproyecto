<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Compartido/MasterPage_Backend.Master" AutoEventWireup="true" CodeBehind="editarAdministradores.aspx.cs" Inherits="Web_Application.Paginas.Backend.editarAdministradores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@9"></script>
    <script src="https://kit.fontawesome.com/651255ba72.js" crossorigin="anonymous"></script>
    <script src="../../Public/scripts/tareas.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../../Public/estilos/estilo_global.css">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="./index.aspx">Inicio</a></li>
            <li class="breadcrumb-item active" aria-current="page">Editar administradores</li>
        </ol>
    </nav>
<div style="background-image: url('../../Public/imagenes/fondo_general.png'); height: 1009px;" class="text-white">
    <div class="tp-3 mb-2 bg-dark text-white text-center text-uppercase font-weight-bold">Editar administradores</div>
    <div class="container">
        <div class="titulo">Por favor, elija el administrador que desea editar o eliminar</div>

        <div id="lista_admins">
            Cargando datos... por favor, espere
            <div class="spinner-border text-primary" role="status">
                <span class="sr-only">Loading...</span>
            </div>
        </div>

        <div class="row justify-content-center">
            <div class="form-group col-4">
                <div id="editar_admin">
                    <form action="">
                        <br />
                        <label class="text-font-normal">ID:</label>
                        <br>
                        <input class="form-control" type="text" name="" id="editar_id">
                        <br>
                        <label class="text-font-normal">Nombre de usuario:</label>
                        <br>
                        <input class="form-control" type="text" name="" id="editar_nombreUsuario" required>
                        <br>
                        <label class="text-font-normal">Contraseña:</label>
                        <br>
                        <input class="form-control" type="password" name="" id="editar_contrasenia" required>
                        <br>
                        <label class="text-font-normal">Correo Electrónico:</label>
                        <br>
                        <input class="form-control" type="text" name="" id="editar_correoElectronico" required>
                        <br>
                        <label class="text-font-normal">Pregunta de seguridad:</label>
                        <br>
                        <input class="form-control" type="text" name="" id="editar_preguntaSeguridad" required>
                        <br>
                        <label class="text-font-normal">Respuesta de seguridad:</label>
                        <br>
                        <input class="form-control" type="text" name="" id="editar_respuestaSeguridad" required>
                        <br>
                        <label class="text-font-normal">Admin maestro</label>
                        <input class="form-check-input" type="checkbox" name="" id="editar_adminMaestro">
                        <br>
                        <label class="text-font-normal">Admin de seguridad</label>
                        <input class="form-check-input" type="checkbox" name="" id="editar_adminSeguridad">
                        <br>
                        <label class="text-font-normal">Admin de mantenimiento</label>
                        <input class="form-check-input" type="checkbox" name="" id="editar_adminMantenimiento">
                        <br>
                        <label class="text-font-normal">Admin de consultas</label>
                        <input class="form-check-input" type="checkbox" name="" id="editar_adminConsultas">
                        <br>
                        <br>

                        <input class="btn btn-primary justify-content-center" onclick="editarAdmin_guardarCambios()" type="submit" value="Guardar cambios">
                        <button class="btn btn-primary justify-content-center" onclick="editarAdmin_cancelarCambios()">Cancelar edicion</button>
                    </form>
                </div>
            </div>
        </div>
    </div>
</div>

    <script>

        cargarDatos();
        document.getElementById('editar_admin').style.display = "none";

        function editarAdmin_guardarCambios() {

            const id = document.getElementById("editar_id").value;
            const nombreUsuario = document.getElementById("editar_nombreUsuario").value;
            const contrasenia = document.getElementById("editar_contrasenia").value;
            const correoElectronico = document.getElementById("editar_correoElectronico").value;
            const preguntaSeguridad = document.getElementById("editar_preguntaSeguridad").value;
            const respuestaSeguridad = document.getElementById("editar_respuestaSeguridad").value;
            const adminMaestro = document.getElementById("editar_adminMaestro").checked;
            const adminSeguridad = document.getElementById("editar_adminSeguridad").checked;
            const adminMantenimiento = document.getElementById("editar_adminMantenimiento").checked;
            const adminConsultas = document.getElementById("editar_adminConsultas").checked;

            if (id && nombreUsuario && contrasenia && correoElectronico && preguntaSeguridad
                && respuestaSeguridad) {
                var json_request =
                {
                    "id": id,
                    "nombreUsuario": nombreUsuario,
                    "contrasenia": contrasenia,
                    "correoElectronico": correoElectronico,
                    "preguntaSeguridad": preguntaSeguridad,
                    "respuestaSeguridad": respuestaSeguridad,
                    "adminMaestro": "" + adminMaestro,
                    "adminSeguridad": "" + adminSeguridad,
                    "adminMantenimiento": "" + adminMantenimiento,
                    "adminConsultas": "" + adminConsultas
                }

                const url = "https://localhost:44371/api/admin";

                fetch(url, {
                    method: 'PUT',
                    body: JSON.stringify(json_request),
                    headers: {
                        'Content-Type': 'application/json'
                    }
                }).then(res => res.json())
                    .catch(error => console.error('Error:', error))
                    .then((response) => {
                        Swal.fire(
                            'Hecho',
                            'Los datos del administrador han sido actualizados con exito',
                            'success'
                        )
                        document.getElementById("editar_id").readOnly = false;
                        document.getElementById('editar_admin').style.display = "none";
                        cargarDatos();
                    });
            } else {
                Swal.fire({
                    icon: 'error',
                    title: 'Error',
                    text: 'Por favor, rellene todos los espacios.',
                })
            }
        }

        function editarAdmin_cancelarCambios() {
            document.getElementById("editar_id").readOnly = false;
            document.getElementById('editar_admin').style.display = "none";
            document.getElementById("lista_admins").style.display = "inline";
            cargarDatos();
        }

        function cargarDatos() {
            const contenedor_id = "lista_admins";
            const url = "https://localhost:44371/api/admin";

            fetch(url)
                .then(function (response) {
                    return response.text();
                })
                .then(function (response) {
                    let json = JSON.parse(response);
                    renderizar(json, contenedor_id);
                })
                .catch(function (err) {
                    console.error(err);
                    document.getElementById(contenedor_id).innerHTML = "*** Ha ocurrido un error";
                });
        }

        function renderizar(json, contenedor_id) {
            if (json != null) {

                let html = "";

                html +=
                    `<p>Total de administradores: ${json.length}</p>
                     <table class="table table-bordered">
                        <thead class="thead-light">
                            <tr scope="col">
                                <th>ID</th>
                                <th>Nombre de usuario</th>
                                <th>Admin maestro</th>
                                <th>Admin Seguridad</th>
                                <th>Admin mantenimiento</th>
                                <th>Admin consultas</th>
                                <th colspan="2">Acción</th>
                            </tr>
                        </thead>
                    `;

                for (let index = 0; index < json.length; index++) {
                    let adminMaestro = json[index].adminMaestro
                    let adminSeguridad = json[index].adminSeguridad
                    let adminMantenimiento = json[index].adminMantenimiento
                    let adminConsultas = json[index].adminConsultas

                    if (adminMaestro) {
                        var valor_adminMaestro = '<i class="fas fa-check"></i>'
                    } else {
                        valor_adminMaestro = '<i class="fas fa-times"></i>';
                    }

                    if (adminSeguridad) {
                        var valor_adminSeguridad = '<i class="fas fa-check"></i>'
                    } else {
                        valor_adminSeguridad = '<i class="fas fa-times"></i>';
                    }

                    if (adminMantenimiento) {
                        var valor_adminMantenimiento = '<i class="fas fa-check"></i>'
                    } else {
                        valor_adminMantenimiento = '<i class="fas fa-times"></i>';
                    }

                    if (adminConsultas) {
                        var valor_adminConsultas = '<i class="fas fa-check"></i>'
                    } else {
                        valor_adminConsultas = '<i class="fas fa-times"></i>';
                    }

                    html += "<tr><th scope='row'>" + json[index].id + "</th><th scope='row'>" + json[index].nombreUsuario + "</th>" +
                        `<th>` +
                        valor_adminMaestro +
                        `</th>` +
                        `<th>` +
                        valor_adminSeguridad
                        +
                        `</th>` +
                        `<th>` +
                        valor_adminMantenimiento +
                        `</th>` +
                        `<th>` +
                        valor_adminConsultas +
                        `</th>` +
                        `<th><a onclick="editarAdmin('` + json[index].id + `')"" href='#'>Editar</a></th>` +
                        `<th><a onclick="eliminarDatos('` + json[index].id + `')"" href='#'>Eliminar</a></th></tr>`;
                }
                html += "</table>";

                document.getElementById(contenedor_id).innerHTML = "** Cargando datos...";
                document.getElementById(contenedor_id).innerHTML = html;
            } else {
                document.getElementById(contenedor_id).innerHTML = "No hay datos registrados.";
            }
        }

        function editarAdmin(id) {
            document.getElementById('editar_admin').style.display = "inline";
            document.getElementById("lista_admins").style.display = "none";

            const contenedor_id = "lista_admins";
            const url = "https://localhost:44371/api/admin";

            fetch(url)
                .then(function (response) {
                    return response.text();
                })
                .then(function (response) {
                    let json = JSON.parse(response);
                    for (let index = 0; index < json.length; index++) {
                        if (json[index].id == id) {
                            document.getElementById("editar_id").value = json[index].id;
                            document.getElementById("editar_nombreUsuario").value = json[index].nombreUsuario;
                            document.getElementById("editar_contrasenia").value = json[index].contrasenia;
                            document.getElementById("editar_correoElectronico").value = json[index].correoElectronico;
                            document.getElementById("editar_preguntaSeguridad").value = json[index].preguntaSeguridad;
                            document.getElementById("editar_respuestaSeguridad").value = json[index].respuestaSeguridad;
                            if (json[index].adminMaestro) {
                                document.getElementById("editar_adminMaestro").checked = true;
                            } else {
                                document.getElementById("editar_adminMaestro").checked = false;
                            }
                            if (json[index].adminSeguridad) {
                                document.getElementById("editar_adminSeguridad").checked = true;
                            } else {
                                document.getElementById("editar_adminSeguridad").checked = false;
                            }
                            if (json[index].adminMantenimiento) {
                                document.getElementById("editar_adminMantenimiento").checked = true;
                            } else {
                                document.getElementById("editar_adminMantenimiento").checked = false;
                            }
                            if (json[index].adminConsultas) {
                                document.getElementById("editar_adminConsultas").checked = true;
                            } else {
                                document.getElementById("editar_adminConsultas").checked = false;
                            }
                            document.getElementById("editar_id").readOnly = true;
                            break;
                        }
                    }
                })
                .catch(function (err) {
                    console.error(err);
                    document.getElementById(contenedor_id).innerHTML = "*** Ha ocurrido un error";
                });
        }

        function eliminarDatos(id) {

            if (id != "adm1") {
                Swal.fire({
                    title: 'Esta seguro que desea eliminar este admin?',
                    text: "Esta accion no se puede deshacer",
                    icon: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Eliminar',
                    cancelButtonText: "Cancelar"
                }).then((result) => {
                    if (result.value) {
                        const url = "https://localhost:44371/api/admin";

                        if (id != "") {
                            var json_request = {
                                ID: id
                            };

                            fetch(url + '/?ID=' + id, {
                                method: 'delete'
                            }).then(response =>
                                response.json().then((json) => {
                                    console.log(json);
                                    guardarBitacora("asjd", "asjd", "asjd", "asjd");
                                    cargarDatos();
                                })
                            );
                        }
                        Swal.fire(
                            'Hecho',
                            'El administrador ha sido eliminado con exito.',
                            'success'
                        ).then((result) => {
                            if (result.value) {
                                location.reload();
                            }
                        })
                    }
                })
            } else {
                Swal.fire({
                    icon: 'error',
                    title: 'Admin Maestro',
                    text: 'El Administrador Maestro no puede ser eliminado.',

                })
            }
        }

    </script>
</asp:Content>
