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
    /// Lógica de interacción para GestionarContrato.xaml
    /// </summary>
    public partial class GestionarContrato : MetroWindow
    {
        public GestionarContrato()
        {
            InitializeComponent();
            dgridListContratos.ItemsSource = new ContratoBLL().Listar();
            dgridListContratos.IsReadOnly = true;


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

                foreach (var item in new ContratoBLL().Listar())
                {
                    if (txt_nro.Text == item.Numero.ToString())
                    {
                        if (MessageBox.Show("Detalles: Contrato Disponible, Desea Editar sus Parametros?", "Información", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.No)
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
                    MessageBox.Show("Contrato no encontrado o no registrado", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    
                }

            }
        }



    private void DgridListContratos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string num = ((ContratoBLL)dgridListContratos.SelectedItem).Numero;
            ContratoBLL c = new ContratoBLL();
            //if (c.BuscarRut(numc))
            //{

            //    if (MessageBox.Show("Desea Editar los Datos del Cliente con RUT " + rut + " o Eliminarlo del sistema?", "Información", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.No)
            //    {

            //    }
            //    else
            //    {
            //        c = new ClienteBLL().DatosClienteporRut(rut);
            //        EditarCliente edcli = new EditarCliente();
            //        edcli.txt_rut.Text = c.RutCliente;
            //        edcli.txt_nombreconta.Text = c.NombreContacto;
            //        edcli.txt_direccion.Text = c.Direccion;
            //        edcli.txt_mail.Text = c.MailContacto;
            //        edcli.txt_razon.Text = c.RazonSocial;
            //        edcli.txt_telefono.Text = c.Telefono.ToString();
            //        foreach (var ac in new ActividadEmpresaBLL().Listar())
            //        {
            //            if (ac.IdActividadEmpresa == c.IdActividadEmpresa)
            //            {
            //                edcli.cbx_actividad.SelectedItem = ac.Descripcion;
            //                break;
            //            }
            //        }
            //        foreach (var te in new TipoEmpresaBLL().Listar())
            //        {
            //            if (te.IdTipoEmpresa == c.IdTipoEmpresa)
            //            {
            //                edcli.cbx_tipo.SelectedItem = te.Descripcion;
            //                break;
            //            }
            //        }
            //        edcli.Show();
            //        this.Close();

            //    }

            //}
        }

        private void Btn_agregarcon_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Se Abrirá la pestaña de agregar contrato, ¿Desea continuar?", "Información", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.No)
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
