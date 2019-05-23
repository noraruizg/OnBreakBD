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

        public List<ActividadEmpresa> Listar()
        {
            using (OnBreakEntities bd = new OnBreakEntities())
            {
                IEnumerable<ActividadEmpresa> lista =
                    (from item
                     in bd.ActividadEmpresa
                     select item);

                return lista.ToList<ActividadEmpresa>();
            }
        }
    }
}
