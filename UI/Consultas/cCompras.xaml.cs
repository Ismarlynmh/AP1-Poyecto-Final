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
    /// Lógica de interacción para cCompras.xaml
    /// </summary>
    public partial class cCompras : Window
    {
        public static int usuarioSiempreActivoId;
        Usuarios usuario = new Usuarios();
        public cCompras(int usuarioId)
        {
            InitializeComponent();
            usuarioSiempreActivoId = usuarioId;
            usuario = UsuariosBLL.Buscar(usuarioSiempreActivoId);

        }

        public cCompras()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Compras>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltrarComboBox.SelectedIndex)
                {
                    case 0:
                        listado = ComprasBLL.GetList(o => true);
                        break;
                    case 1:
                        int id;
                        id = int.Parse(CriterioTextBox.Text);
                        listado = ComprasBLL.GetList(o => o.CompraId == id);
                        break;

                    case 2:
                        int idS;
                        idS = int.Parse(CriterioTextBox.Text);
                        listado = ComprasBLL.GetList(o => o.SuplidorId == idS);
                        break;

                    case 3:
                        DateTime fecha = Convert.ToDateTime(CriterioTextBox.Text);
                        listado = ComprasBLL.GetList(x => x.FechaDeCompra.Date >= fecha.Date && x.FechaDeCompra.Date <= fecha.Date);
                        break;
                    case 4:
                        int idU;
                        idU = int.Parse(CriterioTextBox.Text);
                        listado = ComprasBLL.GetList(x => x.UsuariosId == idU);
                        break;

                }
            }
            else if (FiltrarComboBox.SelectedIndex == 3)
            {
                listado = ComprasBLL.GetList(x => x.FechaDeCompra.Date >= DesdeDateTimePicker.SelectedDate && x.FechaDeCompra.Date <= HastaDateTimePicker.SelectedDate);
            }
            else
            {
                listado = ComprasBLL.GetList(p => true);
            }
            ConsultarDataGrid.ItemsSource = null;
            ConsultarDataGrid.ItemsSource = listado;
        }
    
    }
}
