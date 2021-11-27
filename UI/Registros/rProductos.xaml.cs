using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using AP1PoyectoFinal.BLL;
using AP1PoyectoFinal.Entidades;
using AP1PoyectoFinal.UI.Consultas;

namespace AP1PoyectoFinal.UI.Registros
{
    /// <summary>
    /// Interaction logic for rProductos.xaml
    /// </summary>
    public partial class rProductos : Window
    {
        Productos producto = new Productos();
        List<Suplidores> lista = new List<Suplidores>();

        /*public static int usuarioSiempreActivoId;
        Usuarios usuario = new Usuarios();
        public rProductos(int usuarioId)
        {
            InitializeComponent();
            FechaIngresoDatePicker.SelectedDate = DateTime.Now;
            ProductoIdTextBox.Text = "0";
            PrecioCompraTextBox.Text = "0";
            PrecioVentaTextBox.Text = "0";
            this.DataContext = producto;
            UsuarioIdTextBox.Text = (/*MainWindow.usuarioSiempreActivoId.ToString());

            usuarioSiempreActivoId = usuarioId;
            usuario = UsuariosBLL.Buscar(usuarioSiempreActivoId); 

        }*/

            private void Limpiar()
        {

            ProductoIdTextBox.Text = "0";
            NombreProductoTextBox.Clear();
            MarcaProductoTextBox.Clear();
            InventarioTextBox.Clear();
            PrecioVentaTextBox.Text = "0";
            PrecioCompraTextBox.Text = "0";
            FechaIngresoDatePicker.SelectedDate = DateTime.Now;
            SuplidorIdTextBox.Text = "0";
            CategoriaIdTextBox.Text = "0";
            /*UsuarioIdTextBox.Text = /*(/*MainWindow.usuarioSiempreActivoId.ToString()); */

             Productos producto = new Productos();
            Actualizar();
        }
        private void LlenaCampo(Productos productos)
        {
            ProductoIdTextBox.Text = Convert.ToString(productos.ProductoId);
            NombreProductoTextBox.Text = productos.NombreProducto;
            MarcaProductoTextBox.Text = productos.MarcaProducto;
            InventarioTextBox.Text = Convert.ToString(productos.Inventario);
            PrecioCompraTextBox.Text = Convert.ToString(productos.PrecioDeCompra);
            PrecioVentaTextBox.Text = Convert.ToString(productos.PrecioDeVenta);
            SuplidorIdTextBox.Text = Convert.ToString(productos.SuplidorId);
            CategoriaIdTextBox.Text = Convert.ToString(productos.CategoriaId);
            /*UsuarioIdTextBox.Text = Convert.ToString(productos.UsuariosId);*/
        }
        private bool ExisteEnDB()
        {
            Productos productos = ProductosBLL.Buscar(Convert.ToInt32(ProductoIdTextBox.Text));
            return (productos != null);
        }

        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = producto;
        }

        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrEmpty(NombreProductoTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Nombre producto no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                NombreProductoTextBox.Focus();

            }

            if (string.IsNullOrEmpty(MarcaProductoTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo marca producto no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                MarcaProductoTextBox.Focus();

            }

            if (string.IsNullOrEmpty(InventarioTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Inventario no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                InventarioTextBox.Focus();
            }

            if (string.IsNullOrEmpty(PrecioCompraTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Precio de Compra no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                InventarioTextBox.Focus();
            }

            if (string.IsNullOrEmpty(PrecioVentaTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Precio de Venta no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                InventarioTextBox.Focus();
            }

            if (string.IsNullOrEmpty(FechaIngresoDatePicker.Text))
            {
                MessageBox.Show("Debe ingresar la fecha de ingreso", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                FechaIngresoDatePicker.Focus();
            }
            if (string.IsNullOrEmpty(SuplidorIdTextBox.Text.Replace("-", "")))
            {
                paso = false;
                MessageBox.Show("El campo Suplidpr Id no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                SuplidorIdTextBox.Focus();
            }

            if (string.IsNullOrEmpty(CategoriaIdTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Categoria Id no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                CategoriaIdTextBox.Focus();
            }

            /*if (string.IsNullOrEmpty(UsuarioIdTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Usuario Id no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                UsuarioIdTextBox.Focus();
            }*/

            return paso;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id;
                Productos products = new Productos();
                int.TryParse(ProductoIdTextBox.Text, out id);
                Limpiar();
                products = ProductosBLL.Buscar(id);

                if (products != null)
                {
                    LlenaCampo(products);
                }
                else
                {
                    MessageBox.Show(" No Encontrado !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error en base de datos intente de nuevo", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool paso = false;

                if (!Validar())
                    return;

                if (String.IsNullOrEmpty(ProductoIdTextBox.Text) || ProductoIdTextBox.Text == "0")
                    paso = ProductosBLL.Guardar(producto);
                else
                {
                    if (!ExisteEnDB())
                    {
                        MessageBox.Show("No existe el cliente en la base de " +
                            "datos", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    paso = ProductosBLL.Modificar(producto);
                }

                if (paso)
                {
                    MessageBox.Show("Guardado!!", "EXITO", MessageBoxButton.OK, MessageBoxImage.Information);
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(" No guardado!!", "Informacion", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                }
            }
            catch
            {
                MessageBox.Show(" Usuario Id no valido!!", "Informacion", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id;
                int.TryParse(ProductoIdTextBox.Text, out id);

                if (ProductosBLL.Eliminar(id))
                {
                    MessageBox.Show("Eliminado con exito!!!", "ELiminado", MessageBoxButton.OK, MessageBoxImage.Information);
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(" No eliminado !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch
            {
                MessageBox.Show(" No encontrado !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void NuevoButtton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
    }
}
