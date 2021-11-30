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
using AP1PoyectoFinal.UI.Consultas;
using System.Linq.Expressions;

namespace AP1PoyectoFinal.UI.Consultas
{
    /// <summary>
    /// Lógica de interacción para cEmpleados.xaml
    /// </summary>
    public partial class cEmpleados : Window
    {
        public cEmpleados()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Empleados>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltrarComboBox.SelectedIndex)
                {
                    case 0:
                        listado = EmpleadosBLL.GetList(x => true);
                        break;
                    case 1:
                        int id;
                        id = int.Parse(CriterioTextBox.Text);
                        listado = EmpleadosBLL.GetList(x => x.EmpleadoId == id);
                        break;

                    case 2:
                        listado = EmpleadosBLL.GetList(x => x.Nombres == CriterioTextBox.Text);
                        break;

                    case 3:
                        listado = EmpleadosBLL.GetList(x => x.Apellidos == CriterioTextBox.Text);
                        break;

                    case 4:
                        listado = EmpleadosBLL.GetList(x => x.Cedula == CriterioTextBox.Text);
                        break;

                    case 5:
                        listado = EmpleadosBLL.GetList(x => x.Direccion == CriterioTextBox.Text);
                        break;

                    case 6:
                        listado = EmpleadosBLL.GetList(x => x.Telefono == CriterioTextBox.Text);
                        break;

                    case 7:
                        listado = EmpleadosBLL.GetList(x => x.Celular == CriterioTextBox.Text);
                        break;

                    case 8:
                        listado = EmpleadosBLL.GetList(x => x.Email == CriterioTextBox.Text);
                        break;

                    case 9:
                        listado = EmpleadosBLL.GetList(x => x.Cargo == CriterioTextBox.Text);
                        break;

                    case 10:
                        decimal s;
                        s = int.Parse(CriterioTextBox.Text);
                        listado = EmpleadosBLL.GetList(x => x.Sueldo == s);
                        break;

                    case 11:
                        DateTime fechaN = Convert.ToDateTime(CriterioTextBox.Text);
                        listado = EmpleadosBLL.GetList(x => x.FechaNacimiento.Date >= fechaN.Date && x.FechaIngreso.Date <= fechaN.Date);
                        break;

                    case 12:
                        DateTime fechaI = Convert.ToDateTime(CriterioTextBox.Text);
                        listado = EmpleadosBLL.GetList(x => x.FechaIngreso.Date >= fechaI.Date && x.FechaIngreso.Date <= fechaI.Date);
                        break;

                }
            }
            else if (FiltrarComboBox.SelectedIndex == 11)
            {
                listado = EmpleadosBLL.GetList(x => x.FechaNacimiento.Date >= DesdeDateTimePicker.SelectedDate && x.FechaNacimiento.Date <= HastaDateTimePicker.SelectedDate);
            }
            else if (FiltrarComboBox.SelectedIndex == 12)
            {
                listado = EmpleadosBLL.GetList(x => x.FechaIngreso.Date >= DesdeDateTimePicker.SelectedDate && x.FechaIngreso.Date <= HastaDateTimePicker.SelectedDate);
            }
            else
            {
                listado = EmpleadosBLL.GetList(p => true);
            }
            ConsultarDataGrid.ItemsSource = null;
            ConsultarDataGrid.ItemsSource = listado;
        }
    }
}
