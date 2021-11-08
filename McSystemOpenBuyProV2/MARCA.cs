using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McSystemOpenBuyProV2
{
    class MARCA
    {
        int idMarca;

        public int IdMarca
        {
          get { return idMarca; }
          set { idMarca = value; }
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

        public MARCA(int idMarca,string nombre,int estatus)
        {
            this.IdMarca = idMarca;
            this.Nombre = nombre;
            this.Estatus = estatus;
        }
    }
}
