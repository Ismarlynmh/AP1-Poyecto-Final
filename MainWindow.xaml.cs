using AP1PoyectoFinal.Entidades;
using AP1PoyectoFinal.UI.Consultas;
using AP1PoyectoFinal.UI.Registros;
using AP1PoyectoFinal.BLL;
using System.Windows;



namespace AP1PoyectoFinal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Usuarios usuario = new Usuarios();
        public static int usuarioSiempreActivoId;
        public MainWindow(int UsuarioId)
        {
            InitializeComponent();
            usuarioSiempreActivoId = UsuarioId;
            usuario = UsuariosBLL.Buscar(usuarioSiempreActivoId);
            UsuarioActivoTextBox.Text = ("Usuario activo: " + usuario.NombreUsuario.ToString() + "\nID Usuario activo: " + usuario.UsuarioId.ToString());

    }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void UsuarioButton_Click(object sender, RoutedEventArgs e)
        {
            rUsuarios rUsuarios = new rUsuarios();
            rUsuarios.Show();
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
            rProductos rProductos = new rProductos();
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
            cUsuarios cUsuarios = new cUsuarios();
            cUsuarios.Show();

        }

        private void ConsultarEmpleadosButton_Click(object sender, RoutedEventArgs e)
        {
            cEmpleados cEmpleados = new cEmpleados();
            cEmpleados.Show();
        }

        private void ConsultarSuplidoresrButton_Click(object sender, RoutedEventArgs e)
        {
            cSuplidores cSuplidores = new cSuplidores();
            cSuplidores.Show();
        }

        private void ConsultarProductosButton_Click(object sender, RoutedEventArgs e)
        {
            cProductos cProductos = new cProductos();
            cProductos.Show();
        }

        private void ConsultarComprasButton_Click(object sender, RoutedEventArgs e)
        {
            cCompras cCompras = new cCompras();
            cCompras.Show();

        }


        private void ConsultarVentasButton_Click(object sender, RoutedEventArgs e)
        {
            cVentas cVentas = new cVentas(usuarioSiempreActivoId);
            cVentas.Show();
        }

        private void RolesButton_Click(object sender, RoutedEventArgs e)
        {
            rRoles rRoles = new rRoles();
            rRoles.Show();
        }

        private void CerrarSecion_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            this.Close();
            login.Show();

        }
    }
}
