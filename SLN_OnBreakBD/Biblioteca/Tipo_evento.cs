using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Tipo_evento
    {

        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private double valorBase;

        public double ValorBase
        {
            get { return valorBase; }
            set { valorBase = value; }
        }

        private int personalbase;

        public int PersonalBase
        {
            get { return personalbase; }
            set { personalbase = value; }
        }


    }
}
