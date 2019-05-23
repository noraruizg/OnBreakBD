using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class TipoEmpresaBLL
    {

        private int idTipoEmpresa;

        public int IdTipoEmpresa
        {
            get { return idTipoEmpresa; }
            set { idTipoEmpresa = value; }
        }

        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }



        public List<TipoEmpresa> Listar()
        {
            using (OnBreakEntities bd = new OnBreakEntities())
            {
                IEnumerable<TipoEmpresa> lista =
                    (from item
                     in bd.TipoEmpresa
                     select item);

                return lista.ToList<TipoEmpresa>();
            }
        }


    }
}
