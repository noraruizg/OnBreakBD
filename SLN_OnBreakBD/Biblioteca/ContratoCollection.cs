using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class ContratoCollection: List<Contrato>
    {

        public void Agregar(Contrato con)
        {
            this.Add(con);
        }

        public List<Contrato> Mostrar
        {
            get
            {
                return this;
            }
        }
    }

}
