using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McSystemOpenBuyProV2
{
    class PROVEEDOR
    {
         int idProveedor;

        public int IdProveedor
        {
          get { return idProveedor; }
          set { idProveedor = value; }
        }
        string nombre;

        public string Nombre
        {
          get { return nombre; }
          set { nombre = value; }
        }
        int estatus;

        public int Estatus
        {
          get { return estatus; }
          set { estatus = value; }
        }

        public PROVEEDOR(int idProveedor, string nombre, int estatus)
        {
            this.idProveedor = idProveedor;
            this.Nombre = nombre;
            this.Estatus = estatus;
        }
    }
}
