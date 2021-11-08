using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McSystemOpenBuyProV2
{
    public class PERSONA
    {
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        string app;

        public string App
        {
            get { return app; }
            set { app = value; }
        }
        string apm;

        public string Apm
        {
            get { return apm; }
            set { apm = value; }
        }
        string telefono;

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        string correo;

        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }

        int estatus;

        public int Estatus
        {
            get { return estatus; }
            set { estatus = value; }
        }
    }
}
