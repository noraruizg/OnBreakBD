using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Valorizador
    {
        //        Concepto         |Criterio	| Recargo (UF)
        //_________________________|____________|______________________________________________________
        //     	                   | 1 a 20 	| 3
        //	      Asistentes       | 21 a 50 	| 5
        //	                       | Más de 50  | 2 por cada 20 personas adicionales(no proporcional)
        //_________________________|____________|______________________________________________________
        //                         | 2 	        | 2
        //	Personal Adicional(*)  | 3 	        | 3
        //	                       | 4	        | 3,5
        //	                       | Más de 4	| 3,5 + 0,5 por cada adicional

        // Valor Total Evento = Valor Base Tipo Evento + Recargo Asistentes + Recargo Personal

        public double ValorTotalEvento(double asis,double pa,double valorbase)
        {
            double total=0;


            
            double cargoasis = 0;
            double cargoperso = 0;

            double aux = 0;
            if (asis >= 1 && asis <= 20)
            {
                cargoasis = 3;
            }
            else if (asis > 20 && asis <= 50)
            {
                cargoasis = 5;
            }
            else if (asis==0)
            {
                cargoasis = 0;
            }
            else
            {
                cargoasis = asis - 50;
                if (cargoasis % 20 == 0)
                {
                    cargoasis = cargoasis / 20;
                    cargoasis = cargoasis * 2;
                }
                else
                {
                    aux = cargoasis % 20;
                    cargoasis = (cargoasis - aux) / 20;
                    cargoasis = (cargoasis + 1) * 2;

                }
            }

            if (pa >= 1 && pa <= 2)
            {
                cargoperso = 2;
            }
            else if (pa == 3)
            {
                cargoperso = 3;
            }
            else if (pa == 4)
            {
               cargoperso = 3.5;
            }
            else if (pa > 4)
            {
                cargoperso = (pa - 4) * 0.5;
                cargoperso = 3.5 + cargoperso;

            }
            else if (pa == 0)
            {
                cargoperso = 0;
            }

            total = valorbase + cargoasis + cargoperso;

            
            return total;
        }








    }
}
