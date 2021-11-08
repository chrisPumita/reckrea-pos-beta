using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McSystemOpenBuyProV2
{
    public class DETAILS_Servicio
    {
        SERVICIO servicio;

        internal SERVICIO Servicio
        {
            get { return servicio; }
            set { servicio = value; }
        }
        double cantidad;


        int idDetalle_serv;

        public int IdDetalle_serv
        {
            get { return idDetalle_serv; }
            set { idDetalle_serv = value; }
        }

        public double Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        double costoU;

        public double CostoU
        {
            get { return costoU; }
            set { costoU = value; }
        }

        double desc;

        public double Desc
        {
            get { return desc; }
            set { desc = value; }
        }

        double subtotal;

        public double Subtotal
        {
            get { return subtotal; }
            set { subtotal = value; }
        }


        int precioVariable;

        public int PrecioVariable
        {
            get { return precioVariable; }
            set { precioVariable = value; }
        }

        string detalles;

        public string Detalles
        {
            get { return detalles; }
            set { detalles = value; }
        }
    }
}
