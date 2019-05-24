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
using BLL;
namespace WPF_ONBREAK
{
    /// <summary>
    /// Lógica de interacción para EditarCliente.xaml
    /// </summary>
    public partial class EditarCliente : Window
    {
        
        public EditarCliente()
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
            Cliente c = App.clientes.Mostrar.Where(item => item.Rut == txt_rut.Text).FirstOrDefault();
            
           
        }
        
        private void Btn_editarcli_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Confirma que desea Editar?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
            {
                Cliente c = App.clientes.Mostrar.Where(item => item.Rut == txt_rut.Text).FirstOrDefault();

                c.RazonSocial = txt_razon.Text;
                c.NombreContrato = txt_nombreconta.Text;
                c.MailContacto = txt_mail.Text;
                c.Telefono = int.Parse(txt_telefono.Text);
                c.Direccion = txt_direccion.Text;
                //(EstadoCivil)cboEstadoCivil.SelectedItem;
                c.tipo = (TipoEmpresa)cbx_tipo.SelectedItem;
                c.actividad = (ActividadEmpresa)cbx_actividad.SelectedItem;
                
                GestionarClientes gcli = new GestionarClientes();
                            
                gcli.Show();
                this.Close();
            }
        }

        private void Btn_eliminacli_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Acaba de Seleccionar Eliminar cliente, está seguro que desea Eliminarlo?", "Peligro", MessageBoxButton.YesNo, MessageBoxImage.Stop) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
            {
                Cliente c = App.clientes.Mostrar.Where(item => item.Rut == txt_rut.Text).FirstOrDefault();

                App.clientes.Remove(c);

                GestionarClientes gcli = new GestionarClientes();
                gcli.Show();
                this.Close();
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
