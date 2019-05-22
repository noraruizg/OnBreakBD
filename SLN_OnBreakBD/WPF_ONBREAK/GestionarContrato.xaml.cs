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
using Biblioteca;

namespace WPF_ONBREAK
{
    /// <summary>
    /// Lógica de interacción para GestionarContrato.xaml
    /// </summary>
    public partial class GestionarContrato : Window
    {
        public GestionarContrato()
        {
            InitializeComponent();
            dgridListContratos.ItemsSource = App.contratos.Mostrar;
            dgridListContratos.IsReadOnly = true;
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

        private void Btn_buscar_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(txt_nro.Text))
            {
                MessageBox.Show("Detalles: El Campo 'Nro Contrato' no debe estar vacio!", "Error", MessageBoxButton.OKCancel, MessageBoxImage.Error);

            }
            else
            {
                bool search = false;

                foreach (var item in App.contratos.Mostrar)
                {
                    if (txt_nro.Text == item.NumeroContrato.ToString())
                    {
                        if (MessageBox.Show("Detalles: Contrato Encontrado!, Desea Editar sus Parametros?", "Información", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.No)
                        {
                            //do no stuff
                        }
                        else
                        {
                            //setear parametros de la ventana editar
                            search = true;
                        }

                    }
                }
                if (search == false)
                {
                    //si no existe

                    if (MessageBox.Show("Contrato no registrado, Desea Agregarlo?", "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                    {

                        //do no stuff
                    }
                    else
                    {
                        AgregarContrato agrcon = new AgregarContrato();
                        agrcon.Show();
                        this.Close();
                    }
                }

            }
        }
    }
}
