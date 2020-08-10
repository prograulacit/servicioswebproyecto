using BLL.Logica;
using System;

namespace Web_Application.Paginas.Frontend
{
    public partial class checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Memoria.sesionDeUsuario)
            {
                Response.Redirect("~/Paginas/Compartido/index.aspx");
            }

            // Valida si se ha seleccionado un producto para comprar
            if (!Memoria.productoAComprar.seHaSeleccionadoProductoParaComprar())
            {
                // Retorna el cliente al lobby si no ha seleccionado producto
                // para comprar.
                Response.Redirect("~/Paginas/Frontend/Index.aspx");
            }
            mostrarInformacionDelProducto();
        }

        private void mostrarInformacionDelProducto()
        {
            string tipoDeProducto = Memoria.productoAComprar.obtenerTipoProducto();
            var p = Memoria.productoAComprar;
            string labelMensaje = "";

            switch (tipoDeProducto)
            {
                case "pelicula":
                    labelMensaje += 
                        $"Tipo de producto: Película<br><br>" +
                        $"Nombre: {p.pelicula.nombre}<br>" +
                        $"Genero: {p.pelicula.genero}<br>" +
                        $"Año: {p.pelicula.anio}<br>" +
                        $"Actores: {p.pelicula.actores}<br>" +
                        $"Costo: ₡{p.pelicula.monto}";
                    break;
                case "musica":
                    labelMensaje +=
                        $"Tipo de producto: Música<br>" +
                        $"Nombre: {p.musica.nombre}<br>" +
                        $"Genero: {p.musica.genero}<br>" +
                        $"Tipo de interpretación: {p.musica.tipoInterpretacion}<br>" +
                        $"Idioma: {p.musica.idioma}<br>" +
                        $"País: {p.musica.pais}<br>" +
                        $"Disquera: {p.musica.disquera}<br>" +
                        $"Disco: {p.musica.nombreDisco}<br>" +
                        $"Año: {p.musica.anio}<br>" +
                        $"Costo: ₡{p.musica.monto}";
                    break;
                case "libro":
                    labelMensaje +=
                        $"Tipo de producto: Libro<br>" +
                        $"Nombre: {p.libro.nombre}<br>" +
                        $"Categoría: {p.libro.categoria}<br>" +
                        $"Autor: {p.libro.autor}<br>" +
                        $"Idioma: {p.libro.idioma}<br>" +
                        $"Editorial: {p.libro.editorial}<br>" +
                        $"Año: {p.libro.anioPublicacion}<br>" +
                        $"Costo: ₡{p.libro.monto}";
                    break;
                default:
                    labelMensaje += "Ha habido un error.";
                    break;
            }

            Label_informacionDelProducto.Text = labelMensaje;
        }
    }
}