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
        }
        
        private void BuscarBoton_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void AgregarBoton_Click(object sender, RoutedEventArgs e)
        {
            

        }

        private void RemoverBoton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NuevoBoton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void GuardarBoton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void EliminarBoton_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void TotalTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void SubTotalTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }
       
    }
}
