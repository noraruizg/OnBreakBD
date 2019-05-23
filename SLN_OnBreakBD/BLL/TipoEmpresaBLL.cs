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



        
        
        public List<TipoEmpresaBLL> Listar()
        {
            List<TipoEmpresaBLL> list = new List<TipoEmpresaBLL>();
            using (OnBreakEntities bd = new OnBreakEntities())
            {
                IEnumerable<TipoEmpresa> lista =
                    (from item
                     in bd.TipoEmpresa
                     select item).ToList<TipoEmpresa>();



                foreach (var item in lista)
                {
                    TipoEmpresaBLL nuevo = new TipoEmpresaBLL();
                    nuevo.IdTipoEmpresa = item.IdTipoEmpresa;
                    nuevo.Descripcion = item.Descripcion;

                    list.Add(nuevo);
                }

                return list;

            }


        }

    }
}
