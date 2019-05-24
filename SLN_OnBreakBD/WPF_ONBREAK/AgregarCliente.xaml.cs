using BLL;
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
    /// Lógica de interacción para AgregarCliente.xaml
    /// </summary>
    public partial class AgregarCliente : Window
    {
        public AgregarCliente()
        {
            InitializeComponent();


            TipoEmpresaBLL te = new TipoEmpresaBLL();
            ActividadEmpresaBLL ae = new ActividadEmpresaBLL();
            foreach (var item in te.Listar())
            {
                cbx_tipo.Items.Add(item.Descripcion);
            }

            foreach (var item in ae.Listar())
            {
                cbx_actividad.Items.Add(item.Descripcion);
            }
            cbx_actividad.SelectedIndex = 0;
            cbx_tipo.SelectedIndex = 0;
        }

      

        private void Btn_agregarcli_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Boolean entero = int.TryParse(txt_telefono.Text, out int Telefono);
                int enterito = int.Parse(txt_telefono.Text);
                if (string.IsNullOrEmpty(txt_rut.Text))
                {
                    MessageBox.Show("Detalles: rut no valido", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                else if (string.IsNullOrEmpty(txt_nombreconta.Text))
                {
                    MessageBox.Show("Detalles: El nombre de contacto no debe estar Vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                else if (string.IsNullOrEmpty(txt_razon.Text))
                {
                    MessageBox.Show("Detalles: Razon Social No debe estar vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (string.IsNullOrEmpty(txt_direccion.Text))
                {
                    MessageBox.Show("Detalles: La direccion no debe estar Vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (string.IsNullOrEmpty(txt_mail.Text))
                {
                    MessageBox.Show("Detalles: El mail de contacto no debe estar vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (!validar_mail.IsValidEmailAddress(txt_mail.Text))
                {
                    MessageBox.Show("Detalles: El mail de contacto debe ser correcto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (string.IsNullOrEmpty(txt_telefono.Text))
                {
                    MessageBox.Show("Detalles: el numero de telefono no debe estar vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (!entero)
                {
                    MessageBox.Show("Detalles: Telefono incorrecto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (txt_telefono.Text.Trim().Length != 9)
                {
                     MessageBox.Show("Detalles: el numero de telefono debe contener 9", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (enterito<0)
                {
                     MessageBox.Show("Detalles: El Numero de Telefono no debe Ser negativo", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                else
                {

                    ClienteBLL c = new ClienteBLL();

                    c.RutCliente = txt_rut.Text;
                    c.RazonSocial = txt_razon.Text;
                    c.NombreContacto = txt_nombreconta.Text;
                    c.MailContacto = txt_mail.Text;
                    c.Telefono = txt_telefono.Text;
                    c.Direccion = txt_direccion.Text;
                    foreach (var item in new ActividadEmpresaBLL().Listar())
                    {
                        if (item.Descripcion == cbx_actividad.SelectedItem.ToString())
                        {
                            c.IdActividadEmpresa = item.IdActividadEmpresa;
                            break;
                        }

                    }
                    foreach (var item in new TipoEmpresaBLL().Listar())
                    {
                        if (item.Descripcion == cbx_tipo.SelectedItem.ToString())
                        {
                           c.IdTipoEmpresa = item.IdTipoEmpresa;
                           break;
                        }
                    }

                    c.Crear();
                    //redireccionar a ventana gestionarclientes
                    GestionarClientes gcli = new GestionarClientes();
                    gcli.dgridListClientes.Items.Refresh();
                    gcli.Show();
                    this.Close();
                }

                
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Detalles: Correo incorrecto" + ex, "Error", MessageBoxButton.OKCancel);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Detalles: Mail de contacto incorrecto" + ex, "Error", MessageBoxButton.OKCancel);
            }

            
        }

        private void Btn_inicio_Click(object sender, RoutedEventArgs e)
        {
            MainWindow inicio = new MainWindow();
            inicio.Show();
            this.Close();
        }

        private void Txt_telefono_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
