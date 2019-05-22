using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class ClienteCollection : List<Cliente>
    {
        
        public void Agregar(Cliente cli)
        {
            this.Add(cli);
        }

        public List<Cliente> Mostrar
        {
            get
            {
                return this;
            }
        }
    }

}
