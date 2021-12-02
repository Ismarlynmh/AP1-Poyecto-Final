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
using AP1PoyectoFinal.Entidades;
using AP1PoyectoFinal.UI.Consultas;
using AP1PoyectoFinal.BLL;
using System.Text.RegularExpressions;

namespace AP1PoyectoFinal.UI.Registros
{
    /// <summary>
    /// Lógica de interacción para rUsuarios.xaml\
    /// </summary>
    public partial class rUsuarios : Window
    {
        private Roles Rol;
        private Usuarios usuarios;
        public rUsuarios()
        {
            InitializeComponent();
            usuarios = new Usuarios();
            Rol = new Roles();
            this.DataContext = usuarios;
            FechaIngresoDateTimePicker.SelectedDate = DateTime.Now;
            this.RolIdComboBox.ItemsSource = RolesBLL.GetList(x => true);
            this.RolIdComboBox.SelectedValuePath = "RolId";
            this.RolIdComboBox.DisplayMemberPath = "Descripcion";
        }
        
        private void Limpiar()
        {
            usuarios = new Usuarios();
            this.DataContext = usuarios;
        }
        private Boolean EmailValido(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static bool NumeroValido(string telefono)
        {
            return Regex.Match(telefono, @"^([\+]?1[-]?|[0])?[1-9][0-9]{9}$").Success;
        }
        public static bool CedulaValida(string cedula)
        {
            return Regex.Match(cedula, @"^([\+]?1[-]?|[0])?[1-9][0-9]{10}$").Success;
        }
        private bool Validar()
        {
            bool esValido = true;

            if (string.IsNullOrEmpty(NombresTextBox.Text))
            {
                esValido = false;
                MessageBox.Show("El campo Nombres no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                NombresTextBox.Focus();

            }

            if (string.IsNullOrEmpty(ApellidosTextBox.Text))
            {
                esValido = false;
                MessageBox.Show("El campo Apellidos no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                ApellidosTextBox.Focus();

            }

            if (!CedulaValida(CedulaTextBox.Text))
            {
                esValido = false;
                MessageBox.Show("Cédula No Valida, Debe introducir solo números !!!\n Introducca la Cédula sin guiones.", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
                CedulaTextBox.Focus();
            }


            if (SexoComboBox.SelectedItem == null)
            {
                esValido = false;
                MessageBox.Show("El campo Cedula no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                SexoComboBox.Focus();
            }

            if (!NumeroValido(CelularTextBox.Text))
            {
                esValido = false;
                MessageBox.Show("Celular No Valido, Debe introducir solo números !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
                CelularTextBox.Focus();
            }

            if (!NumeroValido(TelefonoTextBox.Text))
            {
                esValido = false;
                MessageBox.Show("Teléfono No Valido, Debe introducir solo números !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
                TelefonoTextBox.Focus();
            }

            if (string.IsNullOrEmpty(DireccionTextBox.Text))
            {
                esValido = false;
                MessageBox.Show("El campo Direccion no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                DireccionTextBox.Focus();
            }

            if (!EmailValido(EmailTextBox.Text))
            {
                esValido = false;
                MessageBox.Show("Email No Valido !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
                EmailTextBox.Focus();
            }

            if (string.IsNullOrEmpty(NombreDeUsuarioTextBox.Text))
            {
                esValido = false;
                MessageBox.Show("El campo Nombre Usuario no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                NombreDeUsuarioTextBox.Focus();
            }

            if (string.IsNullOrEmpty(ContraseñaTextBox.Password))
            {
                esValido = false;
                MessageBox.Show("El campo contraseña Usuario no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                ContraseñaTextBox.Focus();
            }
            if (RolIdComboBox.Items.Count <= 0)
            {
                esValido = false;
                MessageBox.Show("Debe Seleccionar el Rol correcto", "Fallo", MessageBoxButton.OK, MessageBoxImage.Information);
                RolIdComboBox.Focus();
            }
            return esValido;
        }

        


        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsuariosBLL.Eliminar(usuarios.UsuarioId))
            {
                MessageBox.Show("Elimando", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("No se logro eliminar", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
       
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
            {
                return;
            }
            var ok = UsuariosBLL.Guardar(usuarios);
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

        private void NuevoButtton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var registro = UsuariosBLL.Buscar(usuarios.UsuarioId);
            if (registro != null)
            {
                usuarios = registro;
                this.DataContext = usuarios;
            }
            else
            {
                MessageBox.Show("No se encontro el registro", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RolIdComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RolIdComboBox.SelectedIndex != -1)
            {
                Rol = (Roles)RolIdComboBox.SelectedItem;
            }
        }
    }
}
