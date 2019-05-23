using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class ActividadEmpresaBLL
    {
        public int IdActividadEmpresa { get; set; }
        public string Descripcion { get; set; }



        public List<ActividadEmpresaBLL> Listar()
        {
            List<ActividadEmpresaBLL> list = new List<ActividadEmpresaBLL>();
            using (OnBreakEntities bd = new OnBreakEntities())
            {
                IEnumerable<ActividadEmpresa> lista =
                    (from item
                     in bd.ActividadEmpresa
                     select item).ToList<ActividadEmpresa>();



                foreach (var item in lista)
                {
                    ActividadEmpresaBLL nuevo = new ActividadEmpresaBLL();
                    nuevo.IdActividadEmpresa = item.IdActividadEmpresa;
                    nuevo.Descripcion = item.Descripcion;

                    list.Add(nuevo);
                }

                return list;

            }


        }
    }
}
