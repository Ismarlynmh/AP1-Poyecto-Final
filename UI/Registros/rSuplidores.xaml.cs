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

namespace AP1PoyectoFinal.UI.Registros
{
    /// <summary>
    /// Interaction logic for rSuplidores.xaml
    /// </summary>
    public partial class rSuplidores : Window
    {
        Suplidores suplidor = new Suplidores();
        public rSuplidores()
        {
            InitializeComponent();
            this.DataContext = suplidor;
            /*SuplidorIdTextBox.Text = (MainWindow.usuarioSiempreActivoId.ToString()); */
            SuplidorIdTextBox.Text = "0";

        }
        private bool ExisteEnDB()
        {
            Suplidores suplidores = SuplidoresBLL.Buscar(Convert.ToInt32(SuplidorIdTextBox.Text));
            return (suplidores != null);
        }

        private void LlenaCampo(Suplidores suplidores)
        {
            SuplidorIdTextBox.Text = Convert.ToString(suplidores.SuplidorId);
            NombreTextBox.Text = suplidores.NombreSuplidor;
            ApellidoTextBox.Text = suplidores.Apellidos;
            NombreCompaniaTextBox.Text = suplidores.NombreCompania;
            DireccionTextBox.Text = suplidores.Direccion;
            TelefonoTextBox.Text = suplidores.Telefono;
            CelularTextBox.Text = suplidores.Celular;
            EmailTextBox.Text = suplidores.Email;
            CiudadTextBox.Text = suplidores.Ciudad;

            UsuariosIdTextBox.Text = Convert.ToString(suplidores.UsuariosId);
        }
        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = suplidor;
        }
        private void Limpiar()
        {
            SuplidorIdTextBox.Text = "0";
            NombreTextBox.Clear();
            ApellidoTextBox.Clear();
            NombreCompaniaTextBox.Clear();
            DireccionTextBox.Clear();
            TelefonoTextBox.Clear();
            CelularTextBox.Clear();
            EmailTextBox.Clear();
            CiudadTextBox.Clear();

            /*UsuariosIdTextBox.Text = (MainWindow.usuarioSiempreActivoId.ToString()); */

            Suplidores suplidor = new Suplidores();
            Actualizar();
        }
        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrEmpty(DireccionTextBox.Text))
            {
                paso = false;
                DireccionTextBox.Focus();
            }

            if (string.IsNullOrEmpty(NombreCompaniaTextBox.Text.Replace("-", "")))
            {
                paso = false;
                NombreCompaniaTextBox.Focus();
            }
            return paso;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id;
                Suplidores supplier = new Suplidores();
                int.TryParse(SuplidorIdTextBox.Text, out id);
                Limpiar();
                supplier = SuplidoresBLL.Buscar(id);

                if (supplier != null)
                {
                    LlenaCampo(supplier);
                }
                else
                {
                    MessageBox.Show(" No Encontrado !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error en base de datos intente de nuevo", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void NuevoButtton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                bool paso = false;

                if (!Validar())
                    return;

                if (String.IsNullOrEmpty(SuplidorIdTextBox.Text) || SuplidorIdTextBox.Text == "0")
                    paso = SuplidoresBLL.Guardar(suplidor);
                else
                {
                    if (!ExisteEnDB())
                    {
                        MessageBox.Show("No existe el Empleado en la base de datos", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    paso = SuplidoresBLL.Modificar(suplidor);
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

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id;
                int.TryParse(SuplidorIdTextBox.Text, out id);

                if (SuplidoresBLL.Eliminar(id))
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
    }
}
