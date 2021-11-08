using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McSystemOpenBuyProV2
{
    public class CLIENTE : PERSONA
    {
        DIRECCION_FISCAL datosDiscales;

        internal DIRECCION_FISCAL DatosDiscales
        {
            get { return datosDiscales; }
            set { datosDiscales = value; }
        }
    }
}