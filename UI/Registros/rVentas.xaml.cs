﻿using System;
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
using Prueba_Ismarlin_Proyecto.Entidades;
using Prueba_Ismarlin_Proyecto.UI.Consultas;
using Prueba_Ismarlin_Proyecto.BLL;

namespace Prueba_Ismarlin_Proyecto.UI.Registros
{
    /// <summary>
    /// Lógica de interacción para rVentas.xaml
    /// </summary>
    /// 
    public partial class rVentas : Window
    {
        Ventas venta = new Ventas();
        public List<VentasDetalle> Detalle { get; set; }
        List<Productos> lista = new List<Productos>();
        private decimal SubTotal;
        private decimal Total;
        private int Cantidad;
        private decimal Precio;
        private decimal Itbis;
        private decimal Bandera;
        private decimal AplicaPorcentaje;
        private double Porcentaje;
        private decimal Descuento;
        public rVentas()
        {
            InitializeComponent();
            this.DataContext = venta;
            this.Detalle = new List<VentasDetalle>();
            VentaIdTextBox.Text = "0";
            SubTotalTextBox.Text = "0";
            ITBISTextBox.Text = "18";
            DescuentoTextBox.Text = "0";
            ProductoIdTextBox.Text = "0";
            PrecioTextBox.Text = "0";
            CantidadTextBox.Text = "0";
            TotalTextBox.Text = "0";
            FechaVentaDateTimePicker.SelectedDate = DateTime.Now;

            Cargar();


            Cantidad = 0;
            Precio = 0;
            Itbis = 0;
            Bandera = 0;
            Porcentaje = 0;
            AplicaPorcentaje = 0;
            SubTotal = 0;
            Total = 0;
        }

        private void BuscarBoton_Click(object sender, RoutedEventArgs e)
        {
            var Permisos = VentasBLL.Buscar(Utilidades.ToInt(VentaIdTextBox.Text));

            if (Permisos != null)
            {
                this.venta = Permisos;
            }
            else
            {
                this.venta = new Ventas();
                MessageBox.Show("Esta venta no existe", "No existe", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            this.DataContext = this.venta;
        }

        private void AgregarBoton_Click(object sender, RoutedEventArgs e)
        {
            if (VentasDataGrid.ItemsSource != null)
            {
                this.Detalle = (List<VentasDetalle>)VentasDataGrid.ItemsSource;
            }

            if (!ValidarProductosId(Convert.ToInt32(ProductoIdTextBox.Text)))
            {
                MessageBox.Show("Producto Id no valido", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }


            this.Detalle.Add(new VentasDetalle
            {
                Id = 0,
                ProductoId = Convert.ToInt32(ProductoIdTextBox.Text),
                Precio = Convert.ToInt32(PrecioTextBox.Text),
                Cantidad = Convert.ToInt32(CantidadTextBox.Text)

            });

            Cargar();
            AumentarSubTotal();
            AumentarTotal();
            int valor = Convert.ToInt32(CantidadTextBox.Text);
            int id = Convert.ToInt32(ProductoIdTextBox.Text);
            ProductosBLL.DisminuirInventario(id, valor);

            ProductoIdTextBox.Text = string.Empty;
            CantidadTextBox.Text = string.Empty;
            PrecioTextBox.Text = string.Empty;

        }
        private void AumentarSubTotal() //Metodo para aumentar el subTotal
        {
            Cantidad = Convert.ToInt32(CantidadTextBox.Text);
            Porcentaje = Convert.ToDouble(Convert.ToDouble(ITBISTextBox.Text) / 100);
            Itbis = (decimal)Porcentaje;
            Precio = Convert.ToDecimal(PrecioTextBox.Text);
            Bandera = Convert.ToDecimal(Precio * Cantidad);
            AplicaPorcentaje = (Bandera * Itbis);
            SubTotal += (Bandera);
        }

        private void RemoveFromSubTotal() //Metodo para Remover cantidad del Subtotal si se elimina un producto del Grid
        {
            SubTotal -= (Bandera);
        }

        private void RemoveFromTotal() //Metodo para Remover cantidad del Total si se elimina un producto del Grid
        {
            Total = SubTotal;
        }

        private void AumentarTotal()
        {
            Descuento = Convert.ToDecimal(DescuentoTextBox.Text);
            Total = (SubTotal + AplicaPorcentaje) - Descuento;
        }

        private void RemoverBoton_Click(object sender, RoutedEventArgs e)
        {
            if (VentasDataGrid.Items.Count > 0 && VentasDataGrid.SelectedItem != null)
            {
                Detalle.RemoveAt(VentasDataGrid.SelectedIndex);
                RemoveFromSubTotal();
                RemoveFromTotal();
                Cargar();
            }
        }

        private void NuevoBoton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarBoton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = VentasBLL.Guardar(this.venta);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Informacion almacenada correctamente!");
            }
            else
                MessageBox.Show("La informacion no pudo ser almacenada correctamente.");
        }
        private bool ValidarProductosId(int id)
        {
            lista = ProductosBLL.GetList(p => true);
            bool paso = false;

            foreach (var item in lista)
            {
                if (item.ProductoId == id)
                {
                    return paso = true;
                }
            }
            return paso;
        }
        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrEmpty(TotalTextBox.Text))
            {
                paso = false;
                TotalTextBox.Focus();

            }

            if (string.IsNullOrEmpty(SubTotalTextBox.Text))
            {
                paso = false;
                SubTotalTextBox.Focus();

            }


            if (string.IsNullOrEmpty(DescuentoTextBox.Text))
            {
                paso = false;
                DescuentoTextBox.Focus();

            }

            if (string.IsNullOrEmpty(ITBISTextBox.Text))
            {
                paso = false;
                ITBISTextBox.Focus();

            }

            if (string.IsNullOrEmpty(FechaVentaDateTimePicker.Text))
            {
                paso = false;
                FechaVentaDateTimePicker.Focus();

            }
            if (string.IsNullOrEmpty(VentaIdTextBox.Text))
            {
                paso = false;
                VentaIdTextBox.Focus();
            }

            if (this.Detalle.Count == 0)
            {
                MessageBox.Show("La venta debe tener un producto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                paso = false;
            }
            return paso;
        }

        private void EliminarBoton_Click(object sender, RoutedEventArgs e)
        {
            Ventas existe = VentasBLL.Buscar(this.venta.VentaId);

            if (VentasBLL.Eliminar(this.venta.VentaId))
            {
                Limpiar();
                MessageBox.Show("La venta ha sido eliminado con exito");
            }
            else
            {
                MessageBox.Show("No fue posible eliminarlo");
            }
        }

        private void TotalTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                TotalTextBox.Text = Convert.ToString(Total);
                venta.Total = Total;
            }
            catch (Exception)
            {
                return;
            }
        }

        private void SubTotalTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                SubTotalTextBox.Text = Convert.ToString(SubTotal);
                venta.SubTotal = SubTotal;
            }
            catch (Exception)
            {
                return;
            }
        }
        private void Limpiar()
        {
            VentaIdTextBox.Text = "0";
            SubTotalTextBox.Text = "0";
            ITBISTextBox.Text = "18";
            DescuentoTextBox.Text = "0";
            ProductoIdTextBox.Text = "0";
            PrecioTextBox.Text = "0";
            CantidadTextBox.Text = "0";
            TotalTextBox.Text = "0";
            FechaVentaDateTimePicker.SelectedDate = DateTime.Now;

            SubTotal = 0;
            Total = 0;
            Cantidad = 0;
            Precio = 0;
            Itbis = 0;
            Bandera = 0;
            AplicaPorcentaje = 0;
            Porcentaje = 0;

            Ventas venta = new Ventas();
            this.Detalle = new List<VentasDetalle>();
            Cargar();
        }

        private void Cargar()
        {
            this.VentasDataGrid.ItemsSource = null;
            this.VentasDataGrid.ItemsSource = this.venta.Detalle;
            this.DataContext = null;
            this.DataContext = this.venta;
        }

        private Ventas LlenaClase()
        {
            Ventas ventas = new Ventas();
            ventas.VentaId = int.Parse(VentaIdTextBox.Text);
            ventas.FechaVenta = (DateTime)FechaVentaDateTimePicker.SelectedDate;
            ventas.SubTotal = decimal.Parse(SubTotalTextBox.Text);
            ventas.ITBIS = double.Parse(ITBISTextBox.Text);
            ventas.Descuento = decimal.Parse(DescuentoTextBox.Text);
            ventas.Total = decimal.Parse(TotalTextBox.Text);
            ventas.Detalle = this.Detalle;

            return ventas;
        }

        private void LlenaCampo(Ventas venta)
        {
            VentaIdTextBox.Text = Convert.ToString(venta.VentaId);
            FechaVentaDateTimePicker.SelectedDate = venta.FechaVenta;
            ITBISTextBox.Text = Convert.ToString(venta.ITBIS);
            DescuentoTextBox.Text = Convert.ToString(venta.Descuento);


            SubTotal = venta.SubTotal;
            Total = venta.Total;
            SubTotalTextBox.Text = Convert.ToString(venta.SubTotal);
            TotalTextBox.Text = Convert.ToString(venta.Total);

            this.Detalle = venta.Detalle;
            Cargar();

        }


        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = venta;
        }
    }
}
