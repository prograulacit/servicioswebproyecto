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
            if (!Memoria.productoAComprar.seHaSeleccionadoProductoParaComprar() &&
                !Memoria.compraMetodoDePago.seHaSeleccionadoMetodoDePago())
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
            var producto = Memoria.productoAComprar;
            string labelMensaje = "";

            switch (tipoDeProducto)
            {
                case "pelicula":
                    labelMensaje += 
                        $"Tipo de producto: Película<br><br>" +
                        $"Nombre: {producto.pelicula.nombre}<br>" +
                        $"Genero: {producto.pelicula.genero}<br>" +
                        $"Año: {producto.pelicula.anio}<br>" +
                        $"Actores: {producto.pelicula.actores}<br>" +
                        $"Costo: ₡{producto.pelicula.monto}";
                    break;
                case "musica":
                    labelMensaje +=
                        $"Tipo de producto: Música<br>" +
                        $"Nombre: {producto.musica.nombre}<br>" +
                        $"Genero: {producto.musica.genero}<br>" +
                        $"Tipo de interpretación: {producto.musica.tipoInterpretacion}<br>" +
                        $"Idioma: {producto.musica.idioma}<br>" +
                        $"País: {producto.musica.pais}<br>" +
                        $"Disquera: {producto.musica.disquera}<br>" +
                        $"Disco: {producto.musica.nombreDisco}<br>" +
                        $"Año: {producto.musica.anio}<br>" +
                        $"Costo: ₡{producto.musica.monto}";
                    break;
                case "libro":
                    labelMensaje +=
                        $"Tipo de producto: Libro<br>" +
                        $"Nombre: {producto.libro.nombre}<br>" +
                        $"Categoría: {producto.libro.categoria}<br>" +
                        $"Autor: {producto.libro.autor}<br>" +
                        $"Idioma: {producto.libro.idioma}<br>" +
                        $"Editorial: {producto.libro.editorial}<br>" +
                        $"Año: {producto.libro.anioPublicacion}<br>" +
                        $"Costo: ₡{producto.libro.monto}";
                    break;
                default:
                    labelMensaje += "Ha habido un error.";
                    break;
            }

            Label_informacionDelProducto.Text = labelMensaje;
        }
    }
}