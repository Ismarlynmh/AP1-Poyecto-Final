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


namespace AP1PoyectoFinal
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        List<Usuarios> lista = new List<Usuarios>();
        public int UsuarioId;
        public Login()
        {
            
            InitializeComponent();
        }

        private void IngresarButton_Click(object sender, RoutedEventArgs e)
        {
            lista = UsuariosBLL.GetList(p => true);
            bool paso = false;

            //Si existe usuario en base de datos
            foreach (var item in lista)
            {
                if ((item.NombreUsuario == NombreUsuarioTextBox.Text) && (item.Contrasena == contrasenaBox.Password))
                {
                    UsuarioId = Convert.ToInt32(item.UsuarioId);
                    MainWindow main = new MainWindow(UsuarioId);
                    main.Show();
                    paso = true;
                    this.Close();
                    break;
                }
            }
            if (paso == false)
            {
                MessageBox.Show("Nombre de usuario o Contraseña incorrecto", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                NombreUsuarioTextBox.Text = string.Empty;
                contrasenaBox.Password = string.Empty;
                NombreUsuarioTextBox.Focus();
            }
        }

    }
}