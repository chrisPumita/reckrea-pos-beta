using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McSystemOpenBuyProV2
{
    public class EQUIPO
    {
        int idEquipo;

        public int IdEquipo
        {
            get { return idEquipo; }
            set { idEquipo = value; }
        }
        int idClienteFk;

        public int IdClienteFk
        {
            get { return idClienteFk; }
            set { idClienteFk = value; }
        }

        int idCategoriaFk;

        public int IdCategoriaFk
        {
            get { return idCategoriaFk; }
            set { idCategoriaFk = value; }
        }

        string categoriaName;

        public string CategoriaName
        {
            get { return categoriaName; }
            set { categoriaName = value; }
        }

        int idMarcaFk;

        public int IdMarcaFk
        {
            get { return idMarcaFk; }
            set { idMarcaFk = value; }
        }


        string marcaName;

        public string MarcaName
        {
            get { return marcaName; }
            set { marcaName = value; }
        }

        string modelo;

        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }

        string no_serie;

        public string No_serie
        {
            get { return no_serie; }
            set { no_serie = value; }
        }
        DateTime fechaRegistro;

        public DateTime FechaRegistro
        {
            get { return fechaRegistro; }
            set { fechaRegistro = value; }
        }
        string detalles;

        public string Detalles
        {
            get { return detalles; }
            set { detalles = value; }
        }
        int estado;

        public int Estado
        {
            get { return estado; }
            set { estado = value; }
        }


    }
}
