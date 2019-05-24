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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Biblioteca;
using BLL;
using MahApps.Metro.Controls;
namespace WPF_ONBREAK
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        
        public MainWindow()
        {
            InitializeComponent();
        }



        private void Btn_gestContrato_Click(object sender, RoutedEventArgs e)
        {
            GestionarContrato gcon = new GestionarContrato();
            gcon.Show();
            this.Close();
        }

        private void Btn_listContra_Click(object sender, RoutedEventArgs e)
        {
            ListarContrato listcon = new ListarContrato();
            listcon.Show();
            this.Close();
        }

        private void Btn_listClientes_Click(object sender, RoutedEventArgs e)
        {
            ListarClientes listcli = new ListarClientes();
            listcli.Show();
            this.Close();
        }

        private void Btn_gestClientes_Click(object sender, RoutedEventArgs e)
        {
            GestionarClientes gcli = new GestionarClientes();
            gcli.Show();
            this.Close();
        }
        
    }


}
