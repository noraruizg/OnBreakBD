using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Cliente
    {

        private string rut;

        public string Rut
        {
            get { return rut; }
            set
            {
                if (validar_rut.ValidaRut(value))
                {
                    rut = value;
                }
                else
                {
                    throw new Exception("RUT Invalido");
                }
            }
        }

        private string razonSocial;

        public string RazonSocial
        {
            get { return razonSocial; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    razonSocial = value;
                }
                else
                {
                    throw new Exception("Razon social no puede estar vacio o nulo!");
                }
            }
        }
        private string nombreContrato;

        public string NombreContrato
        {
            get { return nombreContrato; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    nombreContrato = value;
                }
                else
                {
                    throw new Exception("nombre de contrato no puede estar vacio o nulo!");
                }
            }
        }
        private string mailContacto;

        public string MailContacto
        {
            get { return mailContacto; }
            set
            {
                if (validar_mail.IsValidEmailAddress(value))
                {
                    mailContacto = value;

                }
                else
                {
                    throw new Exception("Mail de contacto incorrecto");
                }
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
                    throw new Exception("direccion no puede estar vacio o nulo!");
                }
            }
        }

        private int telefono;

        public int Telefono
        {
            get { return telefono; }
            set
            {
                if ( value <8 || value >10)
                {
                    telefono = value;
                }
                else
                {
                    throw new Exception("Telefono incorrecto");
                }
            }
        }


        public ActividadEmpresa actividad { get; set; }
        public TipoEmpresa tipo { get; set; }

        public  Cliente(string rut, string razonSocial, string nombreContrato, string mailContacto, string direccion, int telefono, TipoEmpresa tipo, ActividadEmpresa actividad)
        {
            Rut = rut;
            RazonSocial = razonSocial;
            NombreContrato = nombreContrato;
            MailContacto = mailContacto;
            Direccion = direccion;
            Telefono = telefono;
            this.tipo = tipo;
            this.actividad = actividad;
            
        }
        
    }
}
