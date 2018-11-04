using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;
using static Clases_Instanciables.Universidad;


namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        #region Enumerado
        /// <summary>
        /// Enumerado de Estado de Cuenta
        /// </summary>
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        #endregion

        #region Atributos
        EEstadoCuenta estadoCuenta;
        EClases claseQueToma;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por Defecto
        /// </summary>
        public Alumno()
        {

        }

        /// <summary>
        /// Constructor Alumno con Parametros
        /// </summary>
        /// <param name="id">ID del Alumno</param>
        /// <param name="nombre">Nombre del Alumno</param>
        /// <param name="apellido">Apellido del Alumno</param>
        /// <param name="dni">DNI del Alumno</param>
        /// <param name="nacionalidad">Nacionalidad del Alumno</param>
        /// <param name="claseQueToma">Clase que toma el Alumno</param>
        public Alumno(int id, string nombre,string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma) : base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor de Alumno con parametros
        /// </summary>
        /// <param name="id">ID del Alumno</param>
        /// <param name="nombre">Nombre del Alumno</param>
        /// <param name="apellido">Apellido del Alumno</param>
        /// <param name="dni">DNI del Alumno</param>
        /// <param name="nacionalidad">Nacionalidad del Alumno</param>
        /// <param name="claseQueToma">Clase que toma el Alumno</param>
        /// <param name="estadoCuenta">Estado de Cuenta del Alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma,EEstadoCuenta estadoCuenta) 
            : this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra datos del Alumno
        /// </summary>
        /// <returns>Datos del Alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendFormat("{0}\n", this.ParticiparEnClase());
            sb.AppendFormat("ESTADO DE CUENTA: {0}\n", this.estadoCuenta);
            return sb.ToString();
        }
        /// <summary>
        /// Verifica si el Alumno no toma esa clase
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="eClases">Clase a comparar</param>
        /// <returns>True = Alumno no toma esa clase, caso contrario False</returns>
        public static bool operator !=(Alumno a, EClases eClases)
        {
            return !(a == eClases);
        }

        /// <summary>
        /// Verifica si el Alumno toma esa Clase
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="eClases">Clase a comparar</param>
        /// <returns>TRUE = Si toma esa clase y no es Deudor - FALSE = No toma esa Clase y/o es Deudor</returns>
        public static bool operator ==(Alumno a, EClases eClases)
        {
            if (a.claseQueToma == eClases && a.estadoCuenta != EEstadoCuenta.Deudor)
                return true;
            return false;
        }

        /// <summary>
        /// Muestra clase que toma Alumno
        /// </summary>
        /// <returns>Clase que toma</returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE: " + this.claseQueToma;
        }

        /// <summary>
        /// Hace publico Datos del Alumno
        /// </summary>
        /// <returns>Datos del Alumno</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion
    }
}
