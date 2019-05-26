using Biblioteca;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using BLL;

namespace WPF_ONBREAK
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Darkmode dm = new Darkmode(false);
        
        public static List<Darkmode> darkmode = new List<Darkmode>() {dm};





        public static ClienteCollection clientes = new ClienteCollection();
        public static ContratoCollection contratos = new ContratoCollection();
        public static List<Tipo_evento> eventos = new List<Tipo_evento>();

        public static void cargareventos() {
            Tipo_evento e1 = new Tipo_evento();
            e1.ID = 100;
            e1.Nombre = "Cofee";
            e1.ValorBase = 3;
            e1.PersonalBase = 3;
            eventos.Add(e1);

            Tipo_evento e2 = new Tipo_evento();
            e2.ID = 200;
            e2.Nombre = "Cena";
            e2.ValorBase = 5;
            e2.PersonalBase = 10;
            eventos.Add(e2);

            Tipo_evento e3 = new Tipo_evento();
            e3.ID = 300;
            e3.Nombre = "Lanzamiento";
            e3.ValorBase = 36;
            e3.PersonalBase = 11;
            eventos.Add(e3);
        }

        

        public static void borrar()
        {
            eventos.Clear();
        }
    }
}
