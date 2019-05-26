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
using BLL;
using MahApps.Metro;
using MahApps.Metro.Controls;

namespace WPF_ONBREAK
{
    /// <summary>
    /// Lógica de interacción para ListarClientes.xaml
    /// </summary>
    public partial class ListarClientes : MetroWindow
    {
        MainWindow inicio = new MainWindow();
        public ListarClientes()
        {
            InitializeComponent();
            

            cbx_filtrarclientes.ItemsSource = Enum.GetValues(typeof(filtrarClientes));
            cbx_filtrarclientes.SelectedIndex = 0;
            dgridListarClientes.ItemsSource = new ClienteBLL().Listar();
            dgridListarClientes.IsReadOnly = true;


            foreach (var item in App.darkmode)
            {

                if (item.State == true)
                {
                    ThemeManager.ChangeAppStyle(this,
                                            ThemeManager.GetAccent("Violet"),
                                            ThemeManager.GetAppTheme("BaseDark"));
                    //fondo.Visibility = Visibility.Visible;
                    break;
                }
                else
                {
                    ThemeManager.ChangeAppStyle(this,
                                            ThemeManager.GetAccent("Teal"),
                                            ThemeManager.GetAppTheme("BaseLight"));
                    //fondo.Visibility = Visibility.Hidden;
                    break;
                }
            }
        }


        private void btn_ventana_click(object sender, RoutedEventArgs e)
        {
            foreach (var item in App.darkmode)
            {

                if (item.State == false)
                {
                    ThemeManager.ChangeAppStyle(this,
                                            ThemeManager.GetAccent("Violet"),
                                            ThemeManager.GetAppTheme("BaseDark"));
                    //fondo.Visibility = Visibility.Visible;
                    item.State = true;
                    break;
                }
                else
                {
                    ThemeManager.ChangeAppStyle(this,
                                            ThemeManager.GetAccent("Teal"),
                                            ThemeManager.GetAppTheme("BaseLight"));
                    //fondo.Visibility = Visibility.Hidden;
                    item.State = false;
                    break;
                }
            }
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

            List<ClienteBLL> clientesfiltrados = new List<ClienteBLL>();

            switch (cbx_filtrarclientes.SelectedIndex)
            {
                case 0:
                    foreach (var item in new ClienteBLL().Listar())
                    {
                        if (item.IdTipoEmpresa.ToString().ToUpper().Contains(filtro.ToUpper()))
                        {
                            clientesfiltrados.Add(item);
                        }
                    }
                    dgridListarClientes.ItemsSource = clientesfiltrados;
                    dgridListarClientes.Items.Refresh();


                    break;
                case 1:
                    foreach (var item in new ClienteBLL().Listar())
                    {
                        if (item.RutCliente.Contains(filtro))
                        {
                            clientesfiltrados.Add(item);
                        }
                    }
                    dgridListarClientes.ItemsSource = clientesfiltrados;
                    dgridListarClientes.Items.Refresh();



                    break;
                case 2:
                    foreach (var item in new ClienteBLL().Listar())
                    {
                        if (item.IdActividadEmpresa.ToString().ToUpper().Contains(filtro.ToUpper()))
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
