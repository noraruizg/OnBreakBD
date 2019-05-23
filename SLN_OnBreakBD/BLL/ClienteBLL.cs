using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data.Entity;


namespace BLL
{
    public class ClienteBLL
    {
       

        private string rut;

        public string RutCliente
    {
            get { return rut; }
            set
            {
                if (validar_rut.ValidaRut(value))
                {
                    rut = value;
                }
                else
                {
                    throw new Exception("RUT Invalido");
                }
            }
        }


        private string razonSocial;

        public string RazonSocial
        {
            get { return razonSocial; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    razonSocial = value;
                }
                else
                {
                    throw new Exception("Razon social no puede estar vacio o nulo!");
                }
            }
        }
        

        private string nombreContrato;

        public string NombreContacto
        {
            get { return nombreContrato; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    nombreContrato = value;
                }
                else
                {
                    throw new Exception("nombre de contrato no puede estar vacio o nulo!");
                }
            }
        }

        

        private string mailContacto;

        public string MailContacto
        {
            get { return mailContacto; }
            set
            {
                if (validar_mail.IsValidEmailAddress(value))
                {
                    mailContacto = value;

                }
                else
                {
                    throw new Exception("Mail de contacto incorrecto");
                }
            }
        }


        private string direccion;

        public string Direccion
        {
            get { return direccion; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    direccion = value;
                }
                else
                {
                    throw new Exception("direccion no puede estar vacio o nulo!");
                }
            }
        }

        private string telefono;

        public string Telefono
        {
            get { return telefono; }
            set
            {
                if (value.Length == 9)
                {
                    telefono = value;
                }
                else
                {
                    throw new Exception("Telefono incorrecto");
                }
            }
        }





        public int IdActividadEmpresa { get; set; }
        public int IdTipoEmpresa { get; set; }

        public void Crear()
        {
            OnBreakEntities modelo = new OnBreakEntities();

            Cliente c = modelo.Cliente.Where(item => item.RutCliente == this.RutCliente).FirstOrDefault();

            if (c==null)
            {
                Cliente nuevo = new Cliente();
                nuevo.RutCliente = RutCliente;
                nuevo.RazonSocial = RazonSocial;
                nuevo.NombreContacto = NombreContacto;
                nuevo.MailContacto = MailContacto;
                nuevo.Direccion = Direccion;
                nuevo.Telefono = Telefono;
                nuevo.IdActividadEmpresa = IdActividadEmpresa;
                nuevo.IdTipoEmpresa = IdTipoEmpresa;

                modelo.Cliente.Add(nuevo);
                modelo.SaveChanges();

            }
            else
            {
                throw new Exception("El Cliente ya Existe!!!");
            }
            
        }


        public bool BuscarRut(string rut)
        {
            OnBreakEntities modelo = new OnBreakEntities();

            Cliente c = modelo.Cliente.Where(item => item.RutCliente == rut).FirstOrDefault();

            if (c == null)
            {
                return false;
            }
            else
            {
                Cliente cliedit = new Cliente();
                
                return true;
            }

        }

      


        

        public List<ClienteBLL> Listar()
        {
            List<ClienteBLL> list = new List<ClienteBLL>();
            using (OnBreakEntities bd = new OnBreakEntities())
            {
                IEnumerable<Cliente> lista =
                    (from item
                     in bd.Cliente
                     select item).ToList<Cliente>();

                

                foreach (var item in lista)
                {
                    ClienteBLL nuevo = new ClienteBLL();
                    nuevo.RutCliente = item.RutCliente;
                    nuevo.RazonSocial = item.RazonSocial;
                    nuevo.NombreContacto = item.NombreContacto;
                    nuevo.MailContacto = item.MailContacto;
                    nuevo.Direccion = item.Direccion;
                    nuevo.Telefono = item.Telefono;
                    nuevo.IdActividadEmpresa = item.IdActividadEmpresa;
                    nuevo.IdTipoEmpresa = item.IdTipoEmpresa;


                    list.Add(nuevo);
                }

                return list;

            }
            

        }





           
        
       

    }
}
