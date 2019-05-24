using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class ContratoBLL
    {
        public string Numero { get; set; }
        public System.DateTime Creacion { get; set; }
        public System.DateTime Termino { get; set; }
        public string RutCliente { get; set; }
        public string IdModalidad { get; set; }
        public int IdTipoEvento { get; set; }
        public System.DateTime FechaHoraInicio { get; set; }
        public System.DateTime FechaHoraTermino { get; set; }
        public int Asistentes { get; set; }
        public int PersonalAdicional { get; set; }
        public bool Realizado { get; set; }
        public double ValorTotalContrato { get; set; }
        public string Observaciones { get; set; }


        public void Crear()
        {
            OnBreakEntities modelo = new OnBreakEntities();

            Contrato c = modelo.Contrato.Where(item => item.Numero == this.Numero).FirstOrDefault();

            if (c == null)
            {
                Contrato nuevo = new Contrato();
                nuevo.Numero = Numero;
                nuevo.Creacion = Creacion;
                nuevo.Termino = Termino;
                nuevo.RutCliente = RutCliente;
                nuevo.IdModalidad = IdModalidad;
                nuevo.IdTipoEvento = IdTipoEvento;
                nuevo.FechaHoraInicio = FechaHoraInicio;
                nuevo.Asistentes = Asistentes;
                nuevo.PersonalAdicional = PersonalAdicional;
                nuevo.Realizado = Realizado;
                nuevo.ValorTotalContrato = ValorTotalContrato;
                nuevo.Observaciones = Observaciones;

                modelo.Contrato.Add(nuevo);
                modelo.SaveChanges();

            }
            else
            {
                throw new Exception("El Contrato ya Existe!!!");
            }
        }

        public List<ContratoBLL> Listar()
        {
            List<ContratoBLL> list = new List<ContratoBLL>();
            using (OnBreakEntities bd = new OnBreakEntities())
            {
                IEnumerable<Contrato> lista =
                    (from item
                     in bd.Contrato
                     select item).ToList<Contrato>();

                foreach (var item in lista)
                {
                    ContratoBLL nuevo = new ContratoBLL();
                    nuevo.Numero = item.Numero;
                    nuevo.Creacion = item.Creacion;
                    nuevo.Termino = item.Termino;
                    nuevo.RutCliente = item.RutCliente;
                    nuevo.IdModalidad = item.IdModalidad;
                    nuevo.IdTipoEvento = item.IdTipoEvento;
                    nuevo.FechaHoraInicio = item.FechaHoraInicio;
                    nuevo.Asistentes = item.Asistentes;
                    nuevo.PersonalAdicional = item.PersonalAdicional;
                    nuevo.Realizado = item.Realizado;
                    nuevo.ValorTotalContrato = item.ValorTotalContrato;
                    nuevo.Observaciones = item.Observaciones;

                    list.Add(nuevo);
                }
                return list;
            }
        }

        public void Update(ContratoBLL con)
        {

            OnBreakEntities modelo = new OnBreakEntities();
            Contrato c = (from item in modelo.Contrato
                         where item.Numero == con.Numero
                         select item).FirstOrDefault();
            
            c.Creacion = con.Creacion;
            c.Termino = con.Termino;
            c.RutCliente = con.RutCliente;
            c.IdModalidad = con.IdModalidad;
            c.IdTipoEvento = con.IdTipoEvento;
            c.FechaHoraInicio = con.FechaHoraInicio;
            c.Asistentes = con.Asistentes;
            c.PersonalAdicional = con.PersonalAdicional;
            c.Realizado = con.Realizado;
            c.ValorTotalContrato = con.ValorTotalContrato;
            c.Observaciones = con.Observaciones;

            modelo.SaveChanges();

        }

        public void Delete(string num)
        {

            OnBreakEntities modelo = new OnBreakEntities();
            Contrato c = (from item in modelo.Contrato
                          where item.Numero == num
                          select item).FirstOrDefault();

            if (c.Realizado == true)
            {
                c.Realizado = false;
            }
            else
            {
                c.Realizado = true;
            }
            

            modelo.SaveChanges();

        }


    }
}
