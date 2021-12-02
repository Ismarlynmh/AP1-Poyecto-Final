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
using System.Text.RegularExpressions;

namespace AP1PoyectoFinal.UI.Registros
{
    /// <summary>
    /// Interaction logic for rProductos.xaml
    /// </summary>
    public partial class rProductos : Window
    {
        private Productos producto;
        List<Suplidores> lista = new List<Suplidores>();
        public rProductos()
        {
            InitializeComponent();
            producto = new Productos();
            FechaIngresoDatePicker.SelectedDate = DateTime.Now;
            ProductoIdTextBox.Text = "0";
            PrecioCompraTextBox.Text = "0";
            PrecioVentaTextBox.Text = "0";
            this.DataContext = producto;

        }

            private void Limpiar()
        {
            producto = new Productos();
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


            return paso;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var registro = ProductosBLL.Buscar(producto.ProductoId);
            if (registro != null)
            {
                producto = registro;
                this.DataContext = producto;
            }
            else
            {
                MessageBox.Show("No se encontro el registro", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
            {
                return;
            }
            var ok = ProductosBLL.Guardar(producto); ;
            if (ok)
            {
                MessageBox.Show("Guardado", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("No se logro guardar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductosBLL.Eliminar(producto.ProductoId))
            {
                MessageBox.Show("Elimando", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("No se logro eliminar", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void NuevoButtton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
    }
}
