using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    
    public enum filtrarClientes
    {
        Tipo_Empresa = 0,
        RUT_Cliente = 1,
        Actividad = 2
    }

    public enum filtrarContratos
    {
        Nro_Contrato = 0,
        RUT_Cliente = 1,
        Tipo_De_Contrato = 2
    }
}
