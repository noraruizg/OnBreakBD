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
    /// Lógica de interacción para AgregarContrato2.xaml
    /// </summary>
    public partial class AgregarContrato2 : MetroWindow
    {
        public string direcccionc;
        public string ruttt;
        public DateTime fyhinicio;
        public DateTime fyhtermino;
        public string nomcon;
        public AgregarContrato2()
        {
            InitializeComponent();
            dgrid_eventos.IsReadOnly = true;
            dgrid_ModServicio.IsEnabled = false;
            dgrid_ModServicio.IsReadOnly = true;

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

        private void Btn_Cancelar_Click(object sender, RoutedEventArgs e)
        {

            MainWindow inicio = new MainWindow();
            inicio.Show();
            this.Close();
        }

        private void Btn_sguiente_Click(object sender, RoutedEventArgs e)
        {
            //verificar que los campos no esten vacios
            if (string.IsNullOrEmpty(txt_observacion.Text))
            {
                MessageBox.Show("Observacion no puede ser vacia", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (string.IsNullOrEmpty(txt_personal.Text))
            {
                MessageBox.Show("Personal base no puede estar vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (int.Parse(txt_asistentes.Text) <1 || string.IsNullOrEmpty(txt_asistentes.Text))
            {
                MessageBox.Show("Asistentes  debe ser mayor a 0", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (int.Parse(txt_personalAdicional.Text) <1 || string.IsNullOrEmpty(txt_personalAdicional.Text))
            {
                MessageBox.Show("Personal adicional debe ser mayor a 0", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {


                string agnos = DateTime.Now.Year.ToString();
                string mes = DateTime.Now.Month.ToString();
                string dia = DateTime.Now.Day.ToString();
                string hora = DateTime.Now.Hour.ToString();
                string min = DateTime.Now.Minute.ToString();
                if (mes.Length == 1)
                {
                    mes = "0" + mes;
                }
                if (dia.Length == 1)
                {
                    dia = "0" + dia;
                }
                if (hora.Length == 1)
                {
                    hora = "0" + hora;
                }
                if (min.Length == 1)
                {
                    min = "0" + min;
                }

                ContratoBLL con = new ContratoBLL();
                
                con.Numero = agnos + mes + dia + hora + min;

                con.Creacion = DateTime.Now.Date;
                con.Termino = fyhtermino.Date;
                con.RutCliente = txt_rut.Text;
                con.IdModalidad = txt_nombree.Text;
                con.IdTipoEvento = int.Parse(txt_ide.Text);
                con.FechaHoraInicio = fyhinicio;
                con.FechaHoraTermino = fyhtermino;
                con.Asistentes = int.Parse(txt_asistentes.Text);
                con.PersonalAdicional = int.Parse(txt_personalAdicional.Text);
                con.Realizado = false;
                con.Observaciones = txt_observacion.Text;

                con.ValorTotalContrato = double.Parse(txt_vtotal.Text.Trim().Remove(txt_vtotal.Text.Length-2,2));

                con.Crear();
            }
        }

        private void Dgrid_eventos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            
            txt_ide.Text = ((TipoEventoBLL)dgrid_eventos.SelectedItem).IdTipoEvento.ToString();
            txt_nombree.Text = "";
            txt_valorbase.Text = "";
            txt_personal.Text = "";
            dgrid_ModServicio.ItemsSource = new ModalidadServicioBLL().Listar(((TipoEventoBLL)dgrid_eventos.SelectedItem).IdTipoEvento);
            txt_asistentes.IsEnabled = false;
            txt_personalAdicional.IsEnabled = false;
            txt_observacion.IsEnabled = false;
            dgrid_ModServicio.IsEnabled = true;
            dgrid_ModServicio.Items.Refresh();
        }

        private void Dgrid_ModServicio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgrid_ModServicio.IsEnabled == true)
            {
                txt_nombree.Text = ((ModalidadServicioBLL)dgrid_ModServicio.SelectedItem).IdModalidad;
                txt_valorbase.Text = ((ModalidadServicioBLL)dgrid_ModServicio.SelectedItem).ValorBase.ToString();
                txt_personal.Text = ((ModalidadServicioBLL)dgrid_ModServicio.SelectedItem).PersonalBase.ToString();

                txt_asistentes.IsEnabled = true;
                txt_personalAdicional.IsEnabled = true;
                txt_observacion.IsEnabled = true;
                dgrid_ModServicio.IsEnabled = false;
            }
            
        }


        private void Txt_valorbase_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt_vtotal.Text = txt_valorbase.Text + " UF";
        }

        


        private void Txt_personalAdicional_TextChanged(object sender, TextChangedEventArgs e)
        {
            Valorizador v = new Valorizador();
            double a = 0;
            if (string.IsNullOrEmpty(txt_asistentes.Text) || txt_asistentes.Text == "0")
            {
                a = 0;
            }
            else
            {
                double.TryParse(txt_asistentes.Text, out a);
            }

            double p = 0;
            if (string.IsNullOrEmpty(txt_personalAdicional.Text) || txt_personalAdicional.Text == "0")
            {
                p = 0;
            }
            else
            {
                double.TryParse(txt_personalAdicional.Text, out p);
            }
            
            double val = double.Parse(txt_valorbase.Text);
            txt_vtotal.Text = v.ValorTotalEvento(a, p, val).ToString() + " UF";
        }

        private void Txt_asistentes_TextChanged(object sender, TextChangedEventArgs e)
        {
            Valorizador v = new Valorizador();
            double a = 0;
            if (string.IsNullOrEmpty(txt_asistentes.Text))
            {
                a = 0;
            }
            else
            {
                double.TryParse(txt_asistentes.Text, out a);
            }
            double p = 0;
            if (string.IsNullOrEmpty(txt_personalAdicional.Text ))
            {
                p = 0;
            }
            else
            {
                double.TryParse(txt_personalAdicional.Text, out p);
            }
            
            double val = double.Parse(txt_valorbase.Text);
            txt_vtotal.Text = v.ValorTotalEvento(a, p, val).ToString() + " UF";
            btn_sguiente.IsEnabled = true;
        }
    }
}
