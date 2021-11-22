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
using System.Windows.Navigation;
using System.Windows.Shapes;
using AP1PoyectoFinal.Entidades;
using AP1PoyectoFinal.UI.Consultas;
using AP1PoyectoFinal.UI.Registros;
using AP1PoyectoFinal.BLL;



namespace AP1PoyectoFinal
{ 
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int usuarioSiempreActivoId;
        Usuarios usuario = new Usuarios();
        public MainWindow(int UsuarioId)
        {
            InitializeComponent();
            usuarioSiempreActivoId = UsuarioId;
            usuario = UsuariosBLL.Buscar(usuarioSiempreActivoId);
            UsuarioActivoTextBox.Text = ("Usuario activo: " + usuario.NombreUsuario.ToString() + "\nID Usuario activo: " + usuario.UsuarioId.ToString());

        }

        private void UsuarioButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EmpleadosButton_Click(object sender, RoutedEventArgs e)
        {
            rEmpleados rEmpleados = new rEmpleados();
            rEmpleados.Show();
        }

        private void SuplidoresrButton_Click(object sender, RoutedEventArgs e)
        {
            rSuplidores rSuplidores = new rSuplidores();
            rSuplidores.Show();
        }

        private void ProductosButton_Click(object sender, RoutedEventArgs e)
        {
            rProductos rProductos = new rProductos(usuarioSiempreActivoId);
            rProductos.Show();
        }

        private void ComprasButton_Click(object sender, RoutedEventArgs e)
        {
            rCompras rCompras = new rCompras();
            rCompras.Show();
        }

        private void VentasButton_Click(object sender, RoutedEventArgs e)
        {
            rVentas rVentas = new rVentas();
            rVentas.Show();
        }

        private void ConsultarUsuarioButton_Click(object sender, RoutedEventArgs e)
        {
            cUsuarios cUsuarios = new cUsuarios(usuarioSiempreActivoId);
            cUsuarios.Show();

        }

        private void ConsultarEmpleadosButton_Click(object sender, RoutedEventArgs e)
        {
            cEmpleados cEmpleados = new cEmpleados();
            cEmpleados.Show();
        }

        private void ConsultarSuplidoresrButton_Click(object sender, RoutedEventArgs e)
        {
            cSuplidores cSuplidores = new cSuplidores(usuarioSiempreActivoId);
            cSuplidores.Show();
        }

        private void ConsultarProductosButton_Click(object sender, RoutedEventArgs e)
        {
            cProductos cProductos = new cProductos(usuarioSiempreActivoId);
            cProductos.Show();
        }

        private void ConsultarComprasButton_Click(object sender, RoutedEventArgs e)
        {
            cCompras cCompras = new cCompras();
            cCompras.Show();

        }

      
        private void ConsultarVentasButton_Click(object sender, RoutedEventArgs e)
        {
            cVentas cVentas = new cVentas();
            cVentas.Show();
        }

        private void RolesButton_Click(object sender, RoutedEventArgs e)
        {
            rRoles rRoles = new rRoles();
            rRoles.Show();
        }

        private void CerrarSecion_Click(object sender, RoutedEventArgs e)
        {
            /*
            LogIn logIn = new LogIn();
            this.Close();
            logIn.Show();*/

        }
    }
}
