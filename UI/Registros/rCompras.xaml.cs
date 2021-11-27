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
using AP1PoyectoFinal.BLL;
using AP1PoyectoFinal.UI.Consultas;
using AP1PoyectoFinal.Entidades;

namespace AP1PoyectoFinal.UI.Registros
{ 
    /// <summary>
    /// Lógica de interacción para rCompras.xaml
    /// </summary>
    public partial class rCompras : Window
    {
        private decimal SubTotal;
        private decimal Total;
        private int Cantidad;
        private decimal Precio;
        private decimal Itbis;
        private decimal Bandera;
        private decimal AplicaPorcentaje;
        private double Porcentaje;
        private decimal Descuento;

        Compras compra = new Compras();
        List<Productos> lista = new List<Productos>();

        List<Suplidores> lista2 = new List<Suplidores>();
        public List<ComprasDetalle> Detalle { get; set; }

        public rCompras()
        {
            InitializeComponent();
            CompraIdTextBox.Text = "0";
            SuplidorIdTextBox.Text = "0";
            SubTotalTextBox.Text = "0";
            ITBISTextBox.Text = "18";
            DescuentoTextBox.Text = "0";
            ProductoIdTextBox.Text = "0";
            PrecioTextBox.Text = "0";
            CantidadTextBox.Text = "0";
            TotalTextBox.Text = "0";

            this.DataContext = compra;
            this.Detalle = new List<ComprasDetalle>();
            CargarGrid();

            Cantidad = (Cantidad < 0) ? Cantidad = 0 : Cantidad;
            Precio = (Precio < 0) ? Precio = 0 : Precio;
            Itbis = (Bandera < 0) ? Itbis = 0 : Itbis;
            Bandera = (Bandera < 0) ? Bandera = 0 : Bandera;
            Porcentaje = (Porcentaje < 0) ? Porcentaje = 0 : Porcentaje;
            AplicaPorcentaje = (Total < 0) ? AplicaPorcentaje = 0 : AplicaPorcentaje;
            SubTotal = (SubTotal < 0) ? SubTotal = 0 : SubTotal;
            Total = (Total < 0) ? Total = 0 : Total;
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
        private bool ValidarSuplidorId(int id)
        {
            lista2 = SuplidoresBLL.GetList(p => true);
            bool paso = false;

            foreach (var item in lista2)
            {
                if (item.SuplidorId == id)
                {
                    return paso = true;
                }
            }

            return paso;
        }
        private void Limpiar()
        {
            CompraIdTextBox.Text = "0";
            SuplidorIdTextBox.Text = "0";
            SubTotalTextBox.Text = "0";
            ITBISTextBox.Text = "18";
            DescuentoTextBox.Text = "0";
            ProductoIdTextBox.Text = "0";
            PrecioTextBox.Text = "0";
            CantidadTextBox.Text = "0";
            TotalTextBox.Text = "0";
            FechaDeCompraTimePicker.SelectedDate = DateTime.Now;

            SubTotal = 0;
            Total = 0;
            Cantidad = 0;
            Precio = 0;
            Itbis = 0;
            Bandera = 0;
            AplicaPorcentaje = 0;
            Porcentaje = 0;

            Compras compra = new Compras();
            this.Detalle = new List<ComprasDetalle>();
            CargarGrid();
            Actualizar();
        }

        private bool ExisteEnDB()
        {
            Compras compra = ComprasBLL.Buscar(Convert.ToInt32(CompraIdTextBox.Text));
            return (compra != null);
        }

        private void CargarGrid()
        {
            CompraDetalleDataGrid.ItemsSource = null;
            CompraDetalleDataGrid.ItemsSource = this.Detalle;
        }

        private Compras LlenaClase()
        {
            Compras compras = new Compras();
            compras.CompraId = int.Parse(CompraIdTextBox.Text);
            compras.SuplidorId = int.Parse(SuplidorIdTextBox.Text);
            compras.FechaDeCompra = (DateTime)FechaDeCompraTimePicker.SelectedDate;
            compras.SubTotal = decimal.Parse(SubTotalTextBox.Text);
            compras.ITBIS = double.Parse(ITBISTextBox.Text);
            compras.Descuento = decimal.Parse(DescuentoTextBox.Text);
            compras.Total = decimal.Parse(TotalTextBox.Text);
            compras.Detalle = this.Detalle;

            return compras;
        }

        private void LlenaCampo(Compras compra)
        {
            CompraIdTextBox.Text = Convert.ToString(compra.CompraId);
            SuplidorIdTextBox.Text = Convert.ToString(compra.SuplidorId);
            FechaDeCompraTimePicker.SelectedDate = compra.FechaDeCompra;
            ITBISTextBox.Text = Convert.ToString(compra.ITBIS);
            DescuentoTextBox.Text = Convert.ToString(compra.Descuento);

            SubTotal = compra.SubTotal;
            Total = compra.Total;
            SubTotalTextBox.Text = Convert.ToString(compra.SubTotal);
            TotalTextBox.Text = Convert.ToString(compra.Total);

            this.Detalle = compra.Detalle;
            CargarGrid();

        }


        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = compra;
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

            if (string.IsNullOrEmpty(SubTotalTextBox.Text))
            {
                paso = false;
                SubTotalTextBox.Focus();

            }

            if (string.IsNullOrEmpty(FechaDeCompraTimePicker.Text))
            {
                paso = false;
                FechaDeCompraTimePicker.Focus();

            }


            if (string.IsNullOrEmpty(SuplidorIdTextBox.Text))
            {
                paso = false;
                SuplidorIdTextBox.Focus();

            }

            if (string.IsNullOrEmpty(CompraIdTextBox.Text))
            {
                paso = false;
                CompraIdTextBox.Focus();

            }

            if (this.Detalle.Count == 0)
            {
                MessageBox.Show("La Compra debe tener un producto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                paso = false;
            }
            return paso;
        }
        private void BuscarBoton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            Compras compra = new Compras();
            int.TryParse(CompraIdTextBox.Text, out id);

            compra = ComprasBLL.Buscar(id);

            if (compra != null)
            {
                LlenaCampo(compra);
            }
            else
            {
                MessageBox.Show(" No encontrado !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void AgregarBoton_Click(object sender, RoutedEventArgs e)
        {

            if (CompraDetalleDataGrid.ItemsSource != null)
            {
                this.Detalle = (List<ComprasDetalle>)CompraDetalleDataGrid.ItemsSource;
            }

            if (!ValidarProductosId(Convert.ToInt32(ProductoIdTextBox.Text)))
            {
                MessageBox.Show("Producto Id no valido", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            this.Detalle.Add(new ComprasDetalle
            {
                Id = 0,
                ProductoId = Convert.ToInt32(ProductoIdTextBox.Text),
                Precio = Convert.ToInt32(PrecioTextBox.Text),
                Cantidad = Convert.ToInt32(CantidadTextBox.Text)

            });

            CargarGrid();
            AumentarSubTotal();
            AumentarTotal();
            int valor = Convert.ToInt32(CantidadTextBox.Text);
            int id = Convert.ToInt32(ProductoIdTextBox.Text);
            ProductosBLL.AumentarInventario(id, valor);

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

        public decimal TotalAlterno;

        private void AumentarTotal()
        {
            Descuento = Convert.ToDecimal(DescuentoTextBox.Text);
            Total = (SubTotal + AplicaPorcentaje) - Descuento;
        }
        private void RemoverBoton_Click(object sender, RoutedEventArgs e)
        {
            if (CompraDetalleDataGrid.Items.Count > 0 && CompraDetalleDataGrid.SelectedItem != null)
            {
                Detalle.RemoveAt(CompraDetalleDataGrid.SelectedIndex);
                RemoveFromSubTotal();
                RemoveFromTotal();
                CargarGrid();
            }
        }

        private void NuevoBoton_Click(object sender, RoutedEventArgs e)
        {

            Limpiar();
        }

        private void GuardarBoton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool paso = false;
                Compras compra;

                if (!Validar())
                    return;
                if (!ValidarSuplidorId(Convert.ToInt32(SuplidorIdTextBox.Text)))
                {
                    MessageBox.Show("Suplidor Id no valido", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                compra = LlenaClase();

                if (string.IsNullOrEmpty(CompraIdTextBox.Text) || CompraIdTextBox.Text == "0")
                    paso = ComprasBLL.Guardar(compra);
                else
                {
                    if (!ExisteEnDB())
                    {
                        MessageBox.Show("Persona No Encontrada", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    paso = ComprasBLL.Modificar(compra);
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
                MessageBox.Show(" Id no valido!!", "Informacion", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            }
        }

        private void EliminarBoton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(CompraIdTextBox.Text, out id);

            try
            {
                if (ComprasBLL.Eliminar(id))
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

        private void TotalTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                TotalTextBox.Text = Convert.ToString(Total);
                compra.Total = Total;
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
                compra.SubTotal = SubTotal;
            }
            catch (Exception)
            {
                return;
            }
        }
       
    }
}
