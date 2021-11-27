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
using AP1PoyectoFinal.BLL;

namespace AP1PoyectoFinal.UI.Registros
{
    /// <summary>
    /// Lógica de interacción para rRoles.xaml
    /// </summary>
    public partial class rRoles : Window
    {
        private Roles Rol;
        public rRoles()
        {
            InitializeComponent();
            this.DataContext = this.Rol = new Roles();
        }
        private bool Validar()
        {
            bool esValido = true;

            if (string.IsNullOrEmpty(DescripciónTextBox.Text))
            {
                esValido = false;
                MessageBox.Show("El campo Descripcion no puede estar vacio", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                DescripciónTextBox.Focus();
            }

            return esValido;
        }
        private void Limpiar()
        {
            DescripciónTextBox.Text = string.Empty;
            Rol = new Roles();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(RolIdTextBox.Text, out int RolId);
            var Rol = RolesBLL.Buscar(RolId);

            if (Rol != null)
                this.Rol = Rol;
            else
            {
                this.Rol = new Roles();
                MessageBox.Show("No existe este Rol!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            this.DataContext = this.Rol;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = RolesBLL.Guardar(this.Rol);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Se encontro!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No se escontro!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (RolesBLL.Eliminar(this.Rol.RolId))
            {
                Limpiar();
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
                MessageBox.Show("No se pudo eliminar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
