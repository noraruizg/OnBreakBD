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
    /// Lógica de interacción para GestionarClientes.xaml
    /// </summary>
    public partial class GestionarClientes : Window
    {
        public GestionarClientes()
        {
            InitializeComponent();

            ClienteBLL c = new ClienteBLL();

            dgridListClientes.ItemsSource = c.Listar();
            dgridListClientes.IsReadOnly = true;
            
            
            //dgridListClientes.Columns[1].Header = "RUT"; //Index 1 - NombreProducto
            //dgridListClientes.Columns[2].Header = "Razon Social"; //Index 2 - PrecioVenta}
            //dgridListClientes.Columns[3].Header = "Nombre de Contacto"; //Index 2 - PrecioVenta
            //dgridListClientes.Columns[4].Header = "Mail de Contacto"; //Index 2 - PrecioVenta


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
                        foreach (var item in c.Listar())
                        {
                            if (item.RutCliente == rut)
                            {
                                EditarCliente edcli = new EditarCliente();
                                edcli.txt_rut.Text = item.RutCliente;
                                edcli.txt_nombreconta.Text = item.NombreContacto;
                                edcli.txt_direccion.Text = item.Direccion;
                                edcli.txt_mail.Text = item.MailContacto;
                                edcli.txt_razon.Text = item.RazonSocial;
                                edcli.txt_telefono.Text = item.Telefono.ToString();
                                //edcli.cbx_actividad.SelectedItem = item.ActividadEmpresa;
                                //edcli.cbx_tipo.SelectedItem = item.TipoEmpresa;
                                edcli.Show();
                                this.Close();
                            }
                        }
                            
                            
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

        }
    }
}
