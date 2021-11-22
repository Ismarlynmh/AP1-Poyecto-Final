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
