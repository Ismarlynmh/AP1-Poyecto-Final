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
        private Usuarios usuario;
        public rUsuarios()
        {
            InitializeComponent();
            this.DataContext = usuario;
            FechaIngresoDateTimePicker.SelectedDate = DateTime.Now;
            this.RolIdComboBox.ItemsSource = RolesBLL.GetList(x => true);
            this.RolIdComboBox.SelectedValuePath = "RolId";
            this.RolIdComboBox.DisplayMemberPath = "Descripcion";
        }
        
        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = usuario;
        }
        private void Limpiar()
        {
            usuario = new Usuarios();
            this.DataContext = usuario;
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
                ApellidosTextBox.Focus();

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

            if (string.IsNullOrEmpty(ContraseñaTextBox.Password))
            {
                paso = false;
                MessageBox.Show("El campo contraseña Usuario no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                ContraseñaTextBox.Focus();
            }
            if (RolIdComboBox.Items.Count <= 0)
            {
                paso = false;
                MessageBox.Show("Debe Seleccionar el Rol correcto", "Fallo", MessageBoxButton.OK, MessageBoxImage.Information);
                RolIdComboBox.Focus();
            }
            return paso;
        }

        


        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id;
                int.TryParse(UsuarioIdTextBox.Text, out id);
                if (UsuariosBLL.Eliminar(id))
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
            ContraseñaTextBox.Password = usuario.Contrasena;
            RolIdComboBox.SelectedItem = usuario.RolId;
        }

        private bool ExisteEnDB()
        {
            Usuarios usuario = UsuariosBLL.Buscar(Convert.ToInt32(UsuarioIdTextBox.Text));
            return (usuario != null);
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool paso = false;

                if (!Validar())
                    return;

                if (String.IsNullOrEmpty(UsuarioIdTextBox.Text) || UsuarioIdTextBox.Text == "0")
                    paso = UsuariosBLL.Guardar(usuario);
                else
                {
                    if (!ExisteEnDB())
                    {
                        MessageBox.Show("No existe en la base de " +
                            "datos", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    paso = UsuariosBLL.Modificar(usuario);
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

        private void NuevoButtton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id;
                Usuarios usuarios = new Usuarios();
                int.TryParse(UsuarioIdTextBox.Text, out id);

                Limpiar();

                usuarios = UsuariosBLL.Buscar(id);

                if (usuarios != null)
                {
                    LlenaCampo(usuarios);
                }
                else
                {
                    MessageBox.Show("No encontrado!!!", "Informacion", MessageBoxButton.YesNo, MessageBoxImage.Information);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error en base de datos, intente de nuevo.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
