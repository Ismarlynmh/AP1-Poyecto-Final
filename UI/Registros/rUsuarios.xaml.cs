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
using Prueba_Ismarlin_Proyecto.Entidades;
using Prueba_Ismarlin_Proyecto.UI.Consultas;
using Prueba_Ismarlin_Proyecto.BLL;
using System.Text.RegularExpressions;

namespace Prueba_Ismarlin_Proyecto.UI.Registros
{
    /// <summary>
    /// Lógica de interacción para rUsuarios.xaml
    /// </summary>
    public partial class rUsuarios : Window
    {
        Usuarios usuario = new Usuarios();
        public rUsuarios()
        {
            InitializeComponent();
            this.DataContext = usuario;

            UsuarioIdTextBox.Text = "0";
            FechaIngresoDateTimePicker.SelectedDate = DateTime.Now;

            SexoComboBox.Items.Add("Masculino");
            SexoComboBox.Items.Add("Femenino");
            SexoComboBox.Items.Add("Otro");

            TipoUsuarioComboBox.Items.Add("Empleado");
            TipoUsuarioComboBox.Items.Add("Administrador");
        }
        
        private void Limpiar()
        {
            UsuarioIdTextBox.Text = "0";
            NombresTextBox.Clear();
            ApellidosTextBox.Clear();
            CedulaTextBox.Clear();
            SexoComboBox.SelectedItem = "";
            TelefonoTextBox.Clear();
            CelularTextBox.Clear(); ;
            DireccionTextBox.Clear(); ;
            EmailTextBox.Clear(); ;
            TipoUsuarioComboBox.SelectedItem = "";
            FechaIngresoDateTimePicker.SelectedDate = DateTime.Now;
            NombreDeUsuarioTextBox.Clear();
            ContraseñaTextBox.Clear();

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
            bool paso = true;

            if (string.IsNullOrEmpty(NombresTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Nombres no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                NombresTextBox.Focus();

            }

            if (string.IsNullOrEmpty(ApellidosTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Apellidos no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                NombresTextBox.Focus();

            }

            if (!CedulaValida(CedulaTextBox.Text))
            {
                paso = false;
                MessageBox.Show("Cédula No Valida, Debe introducir solo números !!!\n Introducca la Cédula sin guiones.", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
                CedulaTextBox.Focus();
            }


            if (SexoComboBox.SelectedItem == null)
            {
                paso = false;
                MessageBox.Show("El campo Cedula no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                SexoComboBox.Focus();
            }

            if (!NumeroValido(CelularTextBox.Text))
            {
                paso = false;
                MessageBox.Show("Celular No Valido, Debe introducir solo números !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
                CelularTextBox.Focus();
            }

            if (!NumeroValido(TelefonoTextBox.Text))
            {
                paso = false;
                MessageBox.Show("Teléfono No Valido, Debe introducir solo números !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
                TelefonoTextBox.Focus();
            }

            if (string.IsNullOrEmpty(DireccionTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Direccion no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                DireccionTextBox.Focus();
            }

            if (!EmailValido(EmailTextBox.Text))
            {
                paso = false;
                MessageBox.Show("Email No Valido !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
                EmailTextBox.Focus();
            }

            if (string.IsNullOrEmpty(NombreDeUsuarioTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Nombre Usuario no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                NombreDeUsuarioTextBox.Focus();
            }

            if (string.IsNullOrEmpty(ContraseñaTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo contraseña Usuario no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                NombreDeUsuarioTextBox.Focus();
            }
            return paso;
        }

        private void LlenaCampo(Usuarios usuario)
        {
            UsuarioIdTextBox.Text = Convert.ToString(usuario.UsuarioId);
            NombresTextBox.Text = usuario.Nombres;
            ApellidosTextBox.Text = usuario.Apellidos;
            CedulaTextBox.Text = usuario.Cedula;
            SexoComboBox.SelectedItem = usuario.Sexo;
            TelefonoTextBox.Text = usuario.Telefono;
            CelularTextBox.Text = usuario.Celular;
            DireccionTextBox.Text = usuario.Direccion;
            EmailTextBox.Text = usuario.Email;
            TipoUsuarioComboBox.SelectedItem = usuario.TipoUsuario;
            FechaIngresoDateTimePicker.SelectedDate = usuario.FechaIngreso;
            NombreDeUsuarioTextBox.Text = usuario.NombreUsuario;
            ContraseñaTextBox.Text = usuario.Contrasena;
        }


        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsuariosBLL.Eliminar(usuario.UsuarioId))
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
            if (UsuariosBLL.Guardar(usuario))
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
            var registro = UsuariosBLL.Buscar(usuario.UsuarioId);
            if (registro != null)
            {
                usuario = registro;
                this.DataContext = usuario;
            }
            else
            {
                MessageBox.Show("No se encontro el registro", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
