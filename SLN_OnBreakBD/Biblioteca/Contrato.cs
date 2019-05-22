using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Contrato
    {

        public Cliente Cliente { get; set; }

        private string numeroContrato;

        public string NumeroContrato
        {

            //Se crea automaticamente
            get { return numeroContrato; }
            set
            { numeroContrato = value; }
        }

        //Hora del momento de creacion , no es necesariodar la opcion al cliente de ponerla 
        private DateTime creacion;

        public DateTime Creacion
        {
            get { return creacion; }
            set { creacion = value; }
        }



        private DateTime termino;

        public DateTime Termino
        {
            get { return termino; }
            set
            {
                if (value >= DateTime.Now)
                {
                    termino = value;
                }
                else
                {
                    throw new Exception("La fecha de termino de contrato  no puede ser menor al dia de hoy");
                }
            }
        }

        private DateTime fechahoraInicio;

        public DateTime FechaHoraInicio
        {
            get { return fechahoraInicio; }
            set { fechahoraInicio = value; }
                           
        }


        private DateTime fechahoratermino;

        public DateTime FechaHoraTermino
        {
            get { return fechahoratermino; }
            set
            {
                fechahoratermino = value;
            }
        }


        private string direccion;

        public string Direccion
        {
            get { return direccion; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {

                    direccion = value;
                }
                else
                {
                    throw new Exception("la direccion  no puede estar vacio o nulo!");
                }
            }
        }


        private bool estaVigente;

        public bool EstaVigente
        {
            get { return estaVigente; }
            set { estaVigente = value; }
        }



        public Tipo_evento Tipo { get; set; }

        private string observacion;

        public string Observacion
        {
            get { return observacion; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    observacion = value;
                }
                else
                {
                    throw new Exception("La observacion de contrato no puede estar vacio o nulo!");
                }            
            }
        }

        private double valortotal;

        public double ValorTotal
        {
            get { return valortotal; }
            set { valortotal = value; }
        }


        public Contrato(string numeroContrato, DateTime creacion, DateTime termino, DateTime fechaHoraInicio, DateTime fechaHoraTermino, string direccion, bool estaVigente, Tipo_evento tipo, string observacion,Cliente cliente,double vt)
        {
            NumeroContrato = numeroContrato;
            Creacion = creacion;
            Termino = termino;
            FechaHoraInicio = fechaHoraInicio;
            FechaHoraTermino = fechaHoraTermino;
            Direccion = direccion;
            EstaVigente = estaVigente;
            Tipo = tipo;
            Observacion = observacion;
            Cliente = cliente;
            ValorTotal = vt;
        }
    }
}
