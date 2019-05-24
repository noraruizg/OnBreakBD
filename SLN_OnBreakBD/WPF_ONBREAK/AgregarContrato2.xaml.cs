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
            App.cargareventos();
            InitializeComponent();
            dgrid_eventos.ItemsSource = App.eventos ;
            dgrid_eventos.IsReadOnly = true;
            txt_personalAdicional.Text = "0";
            txt_asistentes.Text = "0";
            txt_valorbase.Text = "0";
            

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
            App.borrar();
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
            else if (string.IsNullOrEmpty(txt_nombree.Text))
            {
                MessageBox.Show("Nombre de evento no puede estar vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (string.IsNullOrEmpty(txt_personal.Text))
            {
                MessageBox.Show("Personal base no puede estar vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (string.IsNullOrEmpty(txt_valorbase.Text))
            {
                MessageBox.Show("Valor base  no puede estar vacio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (int.Parse(txt_asistentes.Text) <1 || string.IsNullOrEmpty(txt_asistentes.Text))
            {
                MessageBox.Show("Asistentes  debe ser mayor a 0", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (int.Parse(txt_personalAdicional.Text) <1 || string.IsNullOrEmpty(txt_personalAdicional.Text))
            {
                MessageBox.Show("Personal adicional debe ser mayor a 0", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (string.IsNullOrEmpty(txt_ide.Text))
            {
                MessageBox.Show("Completa los campos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
                string numcon = agnos + mes + dia + hora + min;

                DateTime creacion = DateTime.Now.Date;
                DateTime termino = fyhtermino.Date;
                bool vige = true;

                Tipo_evento te = new Tipo_evento();
                te.ID = int.Parse(txt_ide.Text);
                te.Nombre = txt_nombree.Text;
                te.PersonalBase = int.Parse(txt_personal.Text);
                te.ValorBase = int.Parse(txt_valorbase.Text);

                string Observacion = txt_observacion.Text;

                string vtotal = txt_vtotal.Text;
                vtotal = vtotal.Replace("UF", "").ToUpper();
                double valor = 0;
                double.TryParse(vtotal, out valor);
                double valotal = valor;

                string rut;
                string RazonSocial;
                string NombreContrato;
                string MailContacto;
                int Telefono;
                string Direccion;
                //TipoEmpresa Tipo;
                //ActividadEmpresa Actividad;

                foreach (var item in App.clientes.Mostrar)
                {
                    if (item.Rut == txt_rut.Text)
                    {
                        rut = item.Rut;
                        RazonSocial = item.RazonSocial;
                        NombreContrato = item.NombreContrato;
                        MailContacto = item.MailContacto;
                        Telefono = item.Telefono;
                        Direccion = item.Direccion;
                        //Tipo = item.tipo;
                        //Actividad = item.actividad;
                        //Cliente cli = new Cliente(rut, RazonSocial, NombreContrato, MailContacto, Direccion, Telefono, Tipo, Actividad);

                        //Contrato con = new Contrato(numcon, creacion, termino, fyhinicio, fyhtermino, direcccionc, vige, te, Observacion, cli, valotal);

                        //App.contratos.Add(con);
                        //redireccionar a ventana gestionarContratos
                        GestionarContrato gcon = new GestionarContrato();
                        gcon.dgridListContratos.Items.Refresh();
                        gcon.Show();
                        this.Close();


                    }
                }







            }
        }

        private void Dgrid_eventos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txt_nombree.Text = ((Tipo_evento)dgrid_eventos.SelectedItem).Nombre;
            txt_valorbase.Text = ((Tipo_evento)dgrid_eventos.SelectedItem).ValorBase.ToString();
            txt_personal.Text = ((Tipo_evento)dgrid_eventos.SelectedItem).PersonalBase.ToString();
            txt_ide.Text = ((Tipo_evento)dgrid_eventos.SelectedItem).ID.ToString();
            txt_personalAdicional.Text = "0";
            txt_asistentes.Text = "0";
        }

        

        private void Txt_valorbase_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt_vtotal.Text =  " UF";
        }

      

        private void Txt_asistentes_TextChanged(object sender, TextChangedEventArgs e)
        {
            //            Asistentes
            //1 a 20  3 21 a 50  5 Más de 50 2 por cada 20 personas adicionales(no proporcional)

           
            double valor = 0;
            double.TryParse(txt_asistentes.Text, out valor);
            double cargoasis = valor;
            valor = 0;
            double.TryParse(txt_personalAdicional.Text, out valor);
            double Cargoperso = valor;
            valor = 0;
            double.TryParse(txt_valorbase.Text, out valor);
            double valBase = valor;
            double aux = 0;
            if (cargoasis >= 1 && cargoasis <= 20)
            {
                cargoasis = 3;
            }
            else if (cargoasis > 20 && cargoasis <= 50)
            {
                cargoasis = 5;
            }
            else
            {
                cargoasis = cargoasis - 50;
                if (cargoasis % 20 == 0)
                {
                    cargoasis = cargoasis / 20;
                    cargoasis = cargoasis * 2;
                }
                else
                {
                    aux = cargoasis % 20;
                    cargoasis = (cargoasis - aux) / 20;
                    cargoasis = (cargoasis + 1) * 2;

                }
            }
            //            Personal Adicional(*) 
            //2  2 3  3 4 3,5 Más de 4 3,5 + 0,5 por cada adicional
            if (Cargoperso >= 1 && Cargoperso <= 2)
            {
                Cargoperso = 2;
            }
            else if (Cargoperso == 3)
            {
                Cargoperso = 3;
            }
            else if (Cargoperso == 4)
            {
                Cargoperso = 3.5;
            }
            else if (Cargoperso > 4)
            {
                Cargoperso = (Cargoperso - 4) * 0.5;
                Cargoperso = 3.5 + Cargoperso;

            }

            double valtotal = valBase + cargoasis + Cargoperso;
            txt_vtotal.Text = valtotal.ToString() + " UF";
            btn_sguiente.IsEnabled = true;
        }

        private void Txt_personalAdicional_TextChanged(object sender, TextChangedEventArgs e)
        {
            double valor = 0;
            double.TryParse(txt_asistentes.Text, out valor);
            double cargoasis = valor;
            valor = 0;
            double.TryParse(txt_personalAdicional.Text, out valor);
            double Cargoperso = valor;
            valor = 0;
            double.TryParse(txt_valorbase.Text, out valor);
            double ValBase = valor;
            double aux = 0;
            if (cargoasis >= 1 && cargoasis <= 20)
            {
                cargoasis = 3;
            }
            else if (cargoasis > 20 && cargoasis <= 50)
            {
                cargoasis = 5;
            }
            else
            {
                cargoasis = cargoasis - 50;
                if (cargoasis % 20 == 0)
                {
                    cargoasis = cargoasis / 20;
                    cargoasis = cargoasis * 2;
                }
                else
                {
                    aux = cargoasis % 20;
                    cargoasis = (cargoasis - aux) / 20;
                    cargoasis = (cargoasis + 1) * 2;

                }
            }
            if (Cargoperso >= 1 && Cargoperso <= 2)
            {
                Cargoperso = 2;
            }
            else if (Cargoperso == 3)
            {
                Cargoperso = 3;
            }
            else if (Cargoperso == 4)
            {
                Cargoperso = 3.5;
            }
            else if (Cargoperso > 4)
            {
                Cargoperso = (Cargoperso - 4) * 0.5;
                Cargoperso = 3.5 + Cargoperso;

            }

            double valtotal = ValBase + cargoasis + Cargoperso;
            txt_vtotal.Text = valtotal.ToString() + "UF";

            btn_sguiente.IsEnabled = true;
        }
    }
}
