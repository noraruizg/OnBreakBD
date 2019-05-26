
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
using MahApps.Metro.Controls;
using MahApps.Metro;

namespace WPF_ONBREAK
{
    /// <summary>
    /// Lógica de interacción para GestionarClientes.xaml
    /// </summary>
    public partial class GestionarClientes : MetroWindow
    {
        public GestionarClientes()
        {
            InitializeComponent();

      

            dgridListClientes.ItemsSource = new ClienteBLL().Listar();
            dgridListClientes.IsReadOnly = true;


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

        private void Btn_buscar_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow modalbuscar = new MainWindow();
            //modalbuscar.Owner = this;
            //modalbuscar.ShowDialog();
            string rut = txt_rut.Text;
            if (rut.Length == 9)
            {
                rut = rut.Replace("-", "").ToUpper();

                if (rut.Length == 8)
                {

                    string dv = rut.Substring(rut.Length - 1, 1);
                    string ru = rut.Substring(0, 7);
                    rut = ru + "-" + dv;
                }
                else
                {
                    string d = rut.Substring(rut.Length - 1, 1);
                    string r = rut.Substring(0, 8);
                    rut = r + "-" + d;
                }
            }
            else if (rut.Length == 8)
            {
                
                string d = rut.Substring(rut.Length - 1, 1);
                string r = rut.Substring(0, 7);
                rut = r + "-" + d;
            }
            if (string.IsNullOrEmpty(rut))
            {
                MessageBox.Show("Detalles: Rut no puede estar vacio ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else if (!validar_rut.ValidaRut(rut))
            {
                MessageBox.Show("Detalles: Rut incorrecto ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                    ClienteBLL c = new ClienteBLL();
                    if (c.BuscarRut(rut))
                    {

                    if (MessageBox.Show("Cliente Encontrado!, Desea Editar sus Datos o Eliminarlo?", "Información", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.No)
                    {

                    }
                    else
                    {
                        c = new ClienteBLL().DatosClienteporRut(rut);
                        EditarCliente edcli = new EditarCliente();
                        edcli.txt_rut.Text = c.RutCliente;
                        edcli.txt_nombreconta.Text = c.NombreContacto;
                        edcli.txt_direccion.Text = c.Direccion;
                        edcli.txt_mail.Text = c.MailContacto;
                        edcli.txt_razon.Text = c.RazonSocial;
                        edcli.txt_telefono.Text = c.Telefono.ToString();
                        foreach (var ac in new ActividadEmpresaBLL().Listar())
                        {
                            if (ac.IdActividadEmpresa == c.IdActividadEmpresa)
                            {
                                edcli.cbx_actividad.SelectedItem = ac.Descripcion;
                                break;
                            }
                        }
                        foreach (var te in new TipoEmpresaBLL().Listar())
                        {
                            if (te.IdTipoEmpresa == c.IdTipoEmpresa)
                            {
                                edcli.cbx_tipo.SelectedItem = te.Descripcion;
                                break;
                            }
                        }
                        edcli.Show();
                        this.Close();

                    }

                }
                    else
                    {
                        //si no existe

                        if (MessageBox.Show("Cliente no registrado, Desea Agregarlo?", "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                        {

                            //do no stuff
                        }
                        else
                        {
                            AgregarCliente agrcli = new AgregarCliente();
                            rut = rut.Replace(".", "").ToUpper();
                            agrcli.txt_rut.Text = rut;
                            agrcli.Show();
                            this.Close();

                        }
                    }

            }


        }

        private void Btn_volver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow inicio = new MainWindow();
            inicio.Show();
            this.Close();
        }

        private void Txt_rut_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DgridListClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string rut = ((ClienteBLL)dgridListClientes.SelectedItem).RutCliente;
            ClienteBLL c = new ClienteBLL();
            if (c.BuscarRut(rut))
            {

                if (MessageBox.Show("Desea Editar los Datos del Cliente con RUT " + rut + " o Eliminarlo del sistema?", "Información", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.No)
                {

                }
                else
                {
                    c = new ClienteBLL().DatosClienteporRut(rut);
                    EditarCliente edcli = new EditarCliente();
                    edcli.txt_rut.Text = c.RutCliente;
                    edcli.txt_nombreconta.Text = c.NombreContacto;
                    edcli.txt_direccion.Text = c.Direccion;
                    edcli.txt_mail.Text = c.MailContacto;
                    edcli.txt_razon.Text = c.RazonSocial;
                    edcli.txt_telefono.Text = c.Telefono.ToString();
                    foreach (var ac in new ActividadEmpresaBLL().Listar())
                    {
                        if (ac.IdActividadEmpresa == c.IdActividadEmpresa)
                        {
                            edcli.cbx_actividad.SelectedItem = ac.Descripcion;
                            break;
                        }
                    }
                    foreach (var te in new TipoEmpresaBLL().Listar())
                    {
                        if (te.IdTipoEmpresa == c.IdTipoEmpresa)
                        {
                            edcli.cbx_tipo.SelectedItem = te.Descripcion;
                            break;
                        }
                    }
                    edcli.Show();
                    this.Close();

                }

            }   
        }

        


    }
}
