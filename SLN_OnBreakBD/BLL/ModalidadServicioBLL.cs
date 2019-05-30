using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class ModalidadServicioBLL
    {
        public string IdModalidad { get; set; }
        public int IdTipoEvento { get; set; }
        public string Nombre { get; set; }
        public double ValorBase { get; set; }
        public int PersonalBase { get; set; }



        public List<ModalidadServicioBLL> Listar(int id)
        {
            List<ModalidadServicioBLL> list = new List<ModalidadServicioBLL>();
            using (OnBreakEntities bd = new OnBreakEntities())
            {
                IEnumerable<ModalidadServicio> lista =
                    (from item
                     in bd.ModalidadServicio
                     where item.IdTipoEvento == id
                     select item).ToList<ModalidadServicio>();



                foreach (var item in lista)
                {
                    ModalidadServicioBLL nuevo = new ModalidadServicioBLL();
                    nuevo.IdModalidad = item.IdModalidad;
                    nuevo.IdTipoEvento = item.IdTipoEvento;
                    nuevo.Nombre = item.Nombre;
                    nuevo.ValorBase = item.ValorBase;
                    nuevo.PersonalBase = item.PersonalBase;

                    list.Add(nuevo);
                }

                return list;

            }


        }


    }
}
