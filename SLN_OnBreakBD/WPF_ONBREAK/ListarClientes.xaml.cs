using Biblioteca;
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
    /// Lógica de interacción para ListarClientes.xaml
    /// </summary>
    public partial class ListarClientes : Window
    {
        MainWindow inicio = new MainWindow();
        public ListarClientes()
        {
            InitializeComponent();
            cbx_filtrarclientes.ItemsSource = Enum.GetValues(typeof(filtrarClientes));
            cbx_filtrarclientes.SelectedIndex = 0;
            dgridListarClientes.ItemsSource = App.clientes.Mostrar;
            dgridListarClientes.IsReadOnly = true;
        }

        private void Btn_inicio_Click(object sender, RoutedEventArgs e)
        {
            inicio.Show();
            this.Close();
        }

        

       

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow inicio = new MainWindow();
            inicio.Show();
            this.Close();
        }

        private void Txt_filtrarclientes_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filtro = txt_filtrarclientes.Text;

            List<Cliente> clientesfiltrados = new List<Cliente>();

            switch (cbx_filtrarclientes.SelectedIndex)
            {
                case 0:
                    foreach (var item in App.clientes.Mostrar)
                    {
                        if (item.tipo.ToString().ToUpper().Contains(filtro.ToUpper()))
                        {
                            clientesfiltrados.Add(item);
                        }
                    }
                    dgridListarClientes.ItemsSource = clientesfiltrados;
                    dgridListarClientes.Items.Refresh();


                    break;
                case 1:
                    foreach (var item in App.clientes.Mostrar)
                    {
                        if (item.Rut.Contains(filtro))
                        {
                            clientesfiltrados.Add(item);
                        }
                    }
                    dgridListarClientes.ItemsSource = clientesfiltrados;
                    dgridListarClientes.Items.Refresh();



                    break;
                case 2:
                    foreach (var item in App.clientes.Mostrar)
                    {
                        if (item.actividad.ToString().ToUpper().Contains(filtro.ToUpper()))
                        {
                            clientesfiltrados.Add(item);
                        }
                    }
                    dgridListarClientes.ItemsSource = clientesfiltrados;
                    dgridListarClientes.Items.Refresh();

           
                    break;
                default:
                    break;
            }
        }
    }
}
