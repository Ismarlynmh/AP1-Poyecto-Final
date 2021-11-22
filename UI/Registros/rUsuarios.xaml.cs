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
using Prueba_Ismarlin_Proyecto.BLL;
using Prueba_Ismarlin_Proyecto.Entidades;
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
            FechaIngresoDatePicker.SelectedDate = DateTime.Now;

            SexoComboBox.Items.Add("Masculino");
            SexoComboBox.Items.Add("Femenino");
            SexoComboBox.Items.Add("Otro");

            TipoUsuarioComboBox.Items.Add("Empleado");
            TipoUsuarioComboBox.Items.Add("Administrador");
        }
        private void Limpiar()
        {
            UsuarioIdTextBox.Text = "0";
            NombreTextBox.Clear();
            ApellidoTextBox.Clear();
            CedulaTextBox.Clear();
            SexoComboBox.SelectedItem = "";
            TelefonoTextBox.Clear();
            CelularTextBox.Clear(); ;
            DireccionTextBox.Clear(); ;
            EmailTextBox.Clear(); ;
            TipoUsuarioComboBox.SelectedItem = "";
            FechaIngresoDatePicker.SelectedDate = DateTime.Now;
            NombreDeUsuarioTextBox.Clear();
            ContrasenaTextBox.Clear();

            Usuarios usuario = new Usuarios();
            Actualizar();
        }

        private void LlenaCampo(Usuarios usuario)
        {
            UsuarioIdTextBox.Text = Convert.ToString(usuario.UsuarioId);
            NombreTextBox.Text = usuario.Nombres;
            ApellidoTextBox.Text = usuario.Apellidos;
            CedulaTextBox.Text = usuario.Cedula;
            SexoComboBox.SelectedItem = usuario.Sexo;
            TelefonoTextBox.Text = usuario.Telefono;
            CelularTextBox.Text = usuario.Celular;
            DireccionTextBox.Text = usuario.Direccion;
            EmailTextBox.Text = usuario.Email;
            TipoUsuarioComboBox.SelectedItem = usuario.TipoUsuario;
            FechaIngresoDatePicker.SelectedDate = usuario.FechaIngreso;
            NombreDeUsuarioTextBox.Text = usuario.NombreUsuario;
            ContrasenaTextBox.Text = usuario.Contrasena;
        }
        private bool ExisteEnDB()
        {
            Usuarios usuario = UsuariosBLL.Buscar(Convert.ToInt32(UsuarioIdTextBox.Text));
            return (usuario != null);
        }

        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = usuario;
        }

        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrEmpty(NombreTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Nombres no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                NombreTextBox.Focus();

            }

            if (string.IsNullOrEmpty(ApellidoTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Apellidos no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                NombreTextBox.Focus();

            }

            

            if (SexoComboBox.SelectedItem == null)
            {
                paso = false;
                MessageBox.Show("El campo Cedula no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                SexoComboBox.Focus();
            }

           


            if (string.IsNullOrEmpty(DireccionTextBox.Text))
            {
                paso = false;
                MessageBox.Show("El campo Direccion no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                DireccionTextBox.Focus();
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
                        MessageBox.Show("No existe el cliente en la base de " +
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

        private void EmpleadoIdButton_Click(object sender, RoutedEventArgs e)
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

    }
}
