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
    /// Lógica de interacción para EditarCliente.xaml
    /// </summary>
    public partial class EditarCliente : MetroWindow
    {
        
        public EditarCliente()
        {
            
            InitializeComponent();
            foreach (var item in new TipoEmpresaBLL().Listar())
            {
                cbx_tipo.Items.Add(item.Descripcion);
            }

            foreach (var item in new ActividadEmpresaBLL().Listar())
            {
                cbx_actividad.Items.Add(item.Descripcion);
            }

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



        private void Btn_editarcli_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Confirma que desea Editar?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
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
                    else if (enterito < 0)
                    {
                        MessageBox.Show("Detalles: El Numero de Telefono no debe Ser negativo", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                    else
                    {

                        ClienteBLL c = new ClienteBLL().DatosClienteporRut(txt_rut.Text);

                        c.RazonSocial = txt_razon.Text;
                        c.NombreContacto = txt_nombreconta.Text;
                        c.MailContacto = txt_mail.Text;
                        c.Telefono = txt_telefono.Text;
                        c.Direccion = txt_direccion.Text;
                        ActividadEmpresaBLL ae = new ActividadEmpresaBLL();
                        foreach (var item in ae.Listar())
                        {

                            if (item.Descripcion == cbx_actividad.SelectedItem.ToString())
                            {
                                c.IdActividadEmpresa = item.IdActividadEmpresa;
                                break;
                            }

                        }
                        TipoEmpresaBLL te = new TipoEmpresaBLL();
                        foreach (var item in te.Listar())
                        {
                            if (item.Descripcion == cbx_tipo.SelectedItem.ToString())
                            {
                                c.IdTipoEmpresa = item.IdTipoEmpresa;
                                break;
                            }
                        }

                        c.Update(c);


                        
                        GestionarClientes gcli = new GestionarClientes();
                        gcli.Show();
                        this.Close();
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Detalles:" + ex, "Error", MessageBoxButton.OKCancel);
                }
                
            }
        }

        private void Btn_eliminacli_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Acaba de Seleccionar Eliminar cliente, está seguro que desea Eliminarlo?", "Peligro", MessageBoxButton.YesNo, MessageBoxImage.Stop) == MessageBoxResult.No)
                {
                    //do no stuff
                }
                else
                {
                    new ClienteBLL().Delete(txt_rut.Text);

                    GestionarClientes gcli = new GestionarClientes();
                    gcli.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Detalles: " + ex, "Error", MessageBoxButton.OKCancel);
            }
            
        }

        private void Btn_inicio_Click(object sender, RoutedEventArgs e)
        {
            MainWindow inicio = new MainWindow();
            inicio.Show();
            this.Close();
        }
    }
}
