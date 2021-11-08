using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McSystemOpenBuyProV2
{
    class CATEGORIAS
    {
        int idCategoria;

        public int IdCategoria
        {
          get { return idCategoria; }
          set { idCategoria = value; }
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

        public CATEGORIAS(int idCategoria,string nombre,int estatus)
        {
            this.IdCategoria = idCategoria;
            this.Nombre = nombre;
            this.Estatus = estatus;
        }
    }
}
