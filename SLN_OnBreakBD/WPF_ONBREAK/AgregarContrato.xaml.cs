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
    /// Lógica de interacción para AgregarContrato.xaml
    /// </summary>
    //AAAAMMDDHHmm,  Donde;
    // AAAA: Años de creación  MM: Mes de Creación, debe considerar que meses menores a 10, deben anteponer un CERO “0”.
    // DD: Día de Creación, debe considerar que días menores a 10, deben anteponer un CERO “0”. 
    // HH: Hora de creación en formato 24 horas, debe considerar que horas menores a 10, deben anteponer un CERO “0”. 
    // mm: Minuto de creación, debe considerar que minutos menores a 10, deben anteponer un CERO “0”. 
    public partial class AgregarContrato : MetroWindow
    {
        string brut;
        public AgregarContrato()
        {
            InitializeComponent();
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

        private void Btn_ventana_click(object sender, RoutedEventArgs e)
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

        private void Btn_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow inicio = new MainWindow();
            inicio.Show();
            this.Close();
        }

        private void Btn_busrut_Click(object sender, RoutedEventArgs e)
        {

            ClienteBLL c = new ClienteBLL();
            string rut = txt_busrut.Text;
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
                MessageBox.Show("Detalles: Rut no puede estar vacio ", "Error", MessageBoxButton.OKCancel, MessageBoxImage.Error);

            }
            else if (!validar_rut.ValidaRut(rut))
            {
                MessageBox.Show("Detalles: Rut incorrecto ", "Error", MessageBoxButton.OKCancel, MessageBoxImage.Error);

            }
            else if (c.BuscarRut(rut))
            {


                c = new ClienteBLL().DatosClienteporRut(rut);
                MessageBox.Show("Cliente Encontrado!", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

                txt_nombre.Text = c.NombreContacto;
                txt_rsocial.Text = c.RazonSocial;
                brut = c.RutCliente;
                btn_sguiente.IsEnabled = true;


            }
            else
            {
                //agregar opcion de poder abrir la lista de clientes para seleccionarlos desde ahi
                MessageBox.Show("El Cliente no Existe!", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                txt_nombre.Text = "";
                txt_rsocial.Text = "";
                btn_sguiente.IsEnabled = false;
            }
        }
        

        private void Btn_sguiente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(dpinicio.SelectedDate.ToString()))
                {
                    MessageBox.Show("Detalles: La fecha y hora de inicio no pueden estar vacias", "Error", MessageBoxButton.OKCancel, MessageBoxImage.Error);

                }
                else if (string.IsNullOrEmpty(dptermino.SelectedDate.ToString()))
                {
                    MessageBox.Show("Detalles: La fecha y hora de Termino no pueden estar vacias", "Error", MessageBoxButton.OKCancel, MessageBoxImage.Error);

                }
                else if (dptermino.SelectedDate.Value < dpinicio.SelectedDate.Value)
                {
                    MessageBox.Show("Detalles: La fecha y hora de termino no puede ser menor a la fecha y hora de inicio", "Error", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                }
                else
                {
                    string rut2 = txt_busrut.Text;
                    if (rut2 != brut)
                    {
                        MessageBox.Show("El rut del cliente no corresponde con los datos ingresados de forma automatica, por favor vuelva a buscar el rut del cliente", "Error", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                    }
                    else
                    {
                        AgregarContrato2 agrc2 = new AgregarContrato2();
                        agrc2.txt_rut.Text = rut2;
                        agrc2.fyhinicio = dpinicio.SelectedDate.Value;
                        agrc2.fyhtermino = dptermino.SelectedDate.Value;
                        agrc2.txt_nombrecontacto.Text = txt_nombre.Text;
                        agrc2.dgrid_eventos.ItemsSource = new TipoEventoBLL().Listar();
                        agrc2.dgrid_eventos.Items.Refresh();
                        agrc2.Show();
                        this.Close();
                    }
                    
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Detalles: " + ex, "Error", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
            
        }

        
    }
}
