using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McSystemOpenBuyProV2
{
    class DIRECCION_FISCAL
    {
        int idDireccion;

        public int IdDireccion
        {
            get { return idDireccion; }
            set { idDireccion = value; }
        }
        string razon;

        public string Razon
        {
            get { return razon; }
            set { razon = value; }
        }
        string calle;

        public string Calle
        {
            get { return calle; }
            set { calle = value; }
        }
        string noInt;

        public string NoInt
        {
            get { return noInt; }
            set { noInt = value; }
        }
        string noExt;

        public string NoExt
        {
            get { return noExt; }
            set { noExt = value; }
        }
        string colonia;

        public string Colonia
        {
            get { return colonia; }
            set { colonia = value; }
        }
        string del_mun;

        public string Del_mun
        {
            get { return del_mun; }
            set { del_mun = value; }
        }
        string entidad;

        public string Entidad
        {
            get { return entidad; }
            set { entidad = value; }
        }
        string rfc;

        public string Rfc
        {
            get { return rfc; }
            set { rfc = value; }
        }
    }
}
