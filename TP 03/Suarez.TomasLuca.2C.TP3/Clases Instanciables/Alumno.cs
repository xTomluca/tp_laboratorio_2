using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;
using static Clases_Instanciables.Universidad;


namespace Clases_Instanciables
{
    sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        EEstadoCuenta estadoCuenta;
        EClases claseQueToma;
        public Alumno()
        {

        }
        public Alumno(int id, string nombre,string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma) : base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma,EEstadoCuenta estadoCuenta) 
            : this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendFormat("Clases que toma: {0}", this.claseQueToma);
            sb.AppendFormat("Estado de Cuenta: {0}", this.estadoCuenta);
            return sb.ToString();
        }
        public static bool operator !=(Alumno a, EClases eClases)
        {
            return !(a == eClases);
        }
        public static bool operator ==(Alumno a, EClases eClases)
        {
            if (a.claseQueToma == eClases && a.estadoCuenta != EEstadoCuenta.Deudor)
                return true;
            return false;
        }
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " + this.claseQueToma;
        }
        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
