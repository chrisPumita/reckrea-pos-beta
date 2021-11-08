using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McSystemOpenBuyProV2
{
    public class EMPLEADO : PERSONA
    {
        int sexo;

        public int Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }
        string nick;

        public string Nick
        {
            get { return nick; }
            set { nick = value; }
        }
        string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        string depto;

        public string Depto
        {
            get { return depto; }
            set { depto = value; }
        }
        DateTime fechaRegistro;

        public DateTime FechaRegistro
        {
            get { return fechaRegistro; }
            set { fechaRegistro = value; }
        }
        int tipoCuenta;

        public int TipoCuenta
        {
            get { return tipoCuenta; }
            set { tipoCuenta = value; }
        }
    }
}
