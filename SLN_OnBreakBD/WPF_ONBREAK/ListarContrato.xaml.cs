using Biblioteca;
using BLL;
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

namespace WPF_ONBREAK
{
    /// <summary>
    /// Lógica de interacción para ListarContrato.xaml
    /// </summary>
    public partial class ListarContrato : Window
    {
        public ListarContrato()
        {
            InitializeComponent();
            cbx_filtrarcontratos.ItemsSource = Enum.GetValues(typeof(filtrarContratos));
            cbx_filtrarcontratos.SelectedIndex = 0;
            dgridListarContratos.ItemsSource = App.contratos.Mostrar;
            dgridListarContratos.IsReadOnly = true;
        }

        private void Btn_inicio_Click(object sender, RoutedEventArgs e)
        {
            MainWindow inicio = new MainWindow();
            inicio.Show();
            this.Close();
        }

        

       

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow inicio = new MainWindow();
            inicio.Show();
            this.Close();
        }

        private void Txt_filtrarcontratos_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Contrato> contratosfiltrados = new List<Contrato>();

            string filtro = txt_filtrarcontratos.Text;

            switch (cbx_filtrarcontratos.SelectedIndex)
            {
                case 0:
                    //filtrar por nro de contrato
                    foreach (var item in App.contratos.Mostrar)
                    {
                        if (item.NumeroContrato.ToString().Contains(filtro))
                        {
                            contratosfiltrados.Add(item);
                        }
                    }
                    dgridListarContratos.ItemsSource = contratosfiltrados;
                    dgridListarContratos.Items.Refresh();


                    break;
                case 1:
                    // por rut de cliente
                    foreach (var item in App.contratos.Mostrar)
                    {
                        if (item.NumeroContrato.ToString().Contains(filtro))
                        {
                            contratosfiltrados.Add(item);
                        }
                    }
                    dgridListarContratos.ItemsSource = contratosfiltrados;
                    dgridListarContratos.Items.Refresh();



                    break;
                case 2:
                    //filtrar por tipo de contrato...
                    foreach (var item in App.contratos.Mostrar)
                    {
                        if (item.Tipo.ToString().ToUpper().Contains(filtro.ToUpper()))
                        {
                            contratosfiltrados.Add(item);
                        }
                    }
                    dgridListarContratos.ItemsSource = contratosfiltrados;
                    dgridListarContratos.Items.Refresh();


                    break;
                default:
                    break;
            }
        }
    }

}
