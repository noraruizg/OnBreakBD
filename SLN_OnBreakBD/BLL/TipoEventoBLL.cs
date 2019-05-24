using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class TipoEventoBLL
    {

        private int idTipoEvento;

        public int IdTipoEvento
        {
            get { return idTipoEvento; }
            set { idTipoEvento = value; }
        }

        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public List<TipoEventoBLL> Listar()
        {
            List<TipoEventoBLL> list = new List<TipoEventoBLL>();
            using (OnBreakEntities bd = new OnBreakEntities())
            {
                IEnumerable<TipoEvento> lista =
                    (from item
                     in bd.TipoEvento
                     select item).ToList<TipoEvento>();



                foreach (var item in lista)
                {
                    TipoEventoBLL nuevo = new TipoEventoBLL();
                    nuevo.IdTipoEvento = item.IdTipoEvento;
                    nuevo.Descripcion = item.Descripcion;

                    list.Add(nuevo);
                }

                return list;

            }


        }
    }
}
